Public Class DataGridViewMerge
    Inherits DataGridView


    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        'TODO: 在此处添加自定义绘制代码

        '调用基类 OnPaint
        MyBase.OnPaint(pe)
    End Sub

    Structure SpanInfo
        Dim Text As String
        Dim Position As Integer
        Dim Left As Integer
        Dim Right As Integer
        Private v As Integer
        Private colIndex As Integer

        Public Sub New(text As String, v As Integer, colIndex As Integer, right As Integer)
            Me.New()
            Me.Text = text
            Me.v = v
            Me.colIndex = colIndex
            Me.Right = right
        End Sub
    End Structure

    Dim SpanRows As New Dictionary(Of Integer, SpanInfo)

    'Private Dictionary<int, SpanInfo> SpanRows = New Dictionary<int, SpanInfo>() '需要2维表头的列

    Public Sub AddSpanHeader(ColIndex As Integer, ColCount As Integer, Text As String)

        If ColCount < 2 Then
            Throw New Exception("行宽应大于等于2，合并1列无意义。")
        End If

        '将这些列加入列表
        Dim Right As Integer = ColIndex + ColCount - 1 '同一大标题下的最后一列的索引
        SpanRows(ColIndex) = New SpanInfo(Text, 1, ColIndex, Right) '添加标题下的最左列
        SpanRows(Right) = New SpanInfo(Text, 3, ColIndex, Right) '添加该标题下的最右列
        Dim i As Integer
        For i = ColIndex + 1 To Right - 1 '中间的列
            SpanRows(i) = New SpanInfo(Text, 2, ColIndex, Right)
        Next
    End Sub

    '清除合并的列
    Public Sub ClearSpanInfo()
        SpanRows.Clear()
    End Sub

    'Private Sub DataGridViewEx_Scroll(sender As Object, e As ScrollEventArgs)

    '    If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then

    '        timer1.Enabled = False
    '        timer1.Enabled = True
    '    End If
    'End Sub

    '刷新显示表头
    Public Sub ReDrawHead()

        'Dim si
        'For Each si In SpanRows.Keys
        '    Me.SetDisplayRectLocation()
        '    Me.Invalidate(Me.GetCellDisplayRectangle(si, -1, True))
        'Next
        'DataGridView1.Refresh()

    End Sub

    'Private Sub timer1_Tick(sender As Object, e As EventArgs)

    '    timer1.Enabled = False
    '    ReDrawHead()

    'End Sub



    Protected Overrides Sub OnCellPainting(e As DataGridViewCellPaintingEventArgs)
        Try
            If e.RowIndex > -1 And e.ColumnIndex > -1 Then
                DrawCell(e)
            Else
                '二维表头
                If e.RowIndex = -1 Then

                    If SpanRows.ContainsKey(e.ColumnIndex) Then   '被合并的列 

                        '画边框
                        Dim g As Graphics = e.Graphics
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border)

                        Dim Left As Integer = e.CellBounds.Left, Top = e.CellBounds.Top + 2,
                            Right = e.CellBounds.Right, Bottom = e.CellBounds.Bottom

                        Select Case SpanRows(e.ColumnIndex).Position
                            Case 1
                                Left += 2
                                Exit Select
                            Case 2
                                Exit Select
                            Case 3
                                Right -= 2
                                Exit Select
                        End Select

                        '画上半部分底色
                        g.FillRectangle(New SolidBrush(Me._mergecolumnheaderbackcolor), Left, Top, Right - Left, CInt((Bottom - Top) / 2))

                        '画中线

                        Dim myGridColor As Pen = New Pen(Me.GridColor)
                        g.DrawLine(myGridColor, Left, CInt((Top + Bottom) / 2), Right, CInt((Top + Bottom) / 2))

                        '写小标题
                        Dim sf As StringFormat
                        sf = New StringFormat()
                        sf.Alignment = StringAlignment.Center
                        sf.LineAlignment = StringAlignment.Center

                        g.DrawString(e.Value + "", e.CellStyle.Font, Brushes.Black,
                            New Rectangle(Left, (Top + Bottom) / 2, Right - Left, (Bottom - Top) / 2), sf)
                        Left = Me.GetColumnDisplayRectangle(SpanRows(e.ColumnIndex).Left, True).Left - 2

                        If (Left < 0) Then Left = Me.GetCellDisplayRectangle(-1, -1, True).Width
                        Right = Me.GetColumnDisplayRectangle(SpanRows(e.ColumnIndex).Right, True).Right - 2
                        If Right < 0 Then
                            Right = Me.Width
                        End If

                        g.DrawString(SpanRows(e.ColumnIndex).Text, e.CellStyle.Font, Brushes.Black, New Rectangle(Left, Top, Right - Left, CInt((Bottom - Top) / 2)), sf)
                        e.Handled = True
                    End If
                End If
                MyBase.OnCellPainting(e)
            End If
        Catch
            End
        End Try
    End Sub


    Private Sub DrawCell(e As DataGridViewCellPaintingEventArgs)
        If e.CellStyle.Alignment = DataGridViewContentAlignment.NotSet Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        Dim gridBrush As Brush = New SolidBrush(Me.GridColor)
        Dim backBrush As SolidBrush = New SolidBrush(e.CellStyle.BackColor)
        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim cellwidth As Integer
        '上面相同的行数
        Dim UpRows As Integer = 0
        '下面相同的行数
        Dim DownRows As Integer = 0
        '总行数
        Dim count As Integer = 0
        If (Me.MergeColumnNames.Contains(Me.Columns(e.ColumnIndex).Name) And Not e.RowIndex = -1) Then
            cellwidth = e.CellBounds.Width
            Dim gridLinePen As Pen = New Pen(gridBrush)
            Dim curValue As String = IIf(e.Value Is Nothing, "", e.Value.ToString().Trim())
            Dim curSelected As String = IIf(Me.CurrentRow.Cells(e.ColumnIndex).Value Is Nothing, "", Me.CurrentRow.Cells(e.ColumnIndex).Value.ToString().Trim())
            If Not String.IsNullOrEmpty(curValue) Then
                '#Region 获取下面的行数

                Dim i As Integer
                For i = e.RowIndex To Me.Rows.Count - 1

                    If (Me.Rows(i).Cells(e.ColumnIndex).Value.ToString().Equals(curValue)) Then
                        DownRows += 1
                        If e.RowIndex <> i Then
                            cellwidth = IIf(cellwidth < Me.Rows(i).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.Rows(i).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit For
                    End If
                Next
                '#endregion
                '#Region 获取上面的行数

                For i = e.RowIndex To 0 Step -1
                    If (Me.Rows(i).Cells(e.ColumnIndex).Value.ToString().Equals(curValue)) Then
                        UpRows += 1
                        If e.RowIndex <> i Then
                            cellwidth = IIf(cellwidth < Me.Rows(i).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.Rows(i).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit For
                    End If
                Next
                '#endregion
                count = DownRows + UpRows - 1
                If count < 2 Then
                    Return
                End If
            End If
            If Me.Rows(e.RowIndex).Selected Then
                backBrush.Color = e.CellStyle.SelectionBackColor
                fontBrush.Color = e.CellStyle.SelectionForeColor
            End If

            '以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds)
            '画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count)
            If DownRows = 1 Then
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                count = 0
            End If
            '画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
            e.Handled = True
        End If

    End Sub


    '画字符串
    ' </summary>
    ' <param name="e"></param>
    ' <param name="cellwidth"></param>
    ' <param name="UpRows"></param>
    ' <param name="DownRows"></param>
    ' <param name="count"></param>
    Private Sub PaintingFont(e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, cellwidth As Integer, UpRows As Integer, DownRows As Integer, count As Integer)
        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim FontHeight As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height)
        Dim fontwidth As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width)
        Dim cellheight As Integer = e.CellBounds.Height

        If e.CellStyle.Alignment = DataGridViewContentAlignment.BottomCenter Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - FontHeight)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.BottomLeft) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - FontHeight)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.BottomRight) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - FontHeight)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - FontHeight) / 2)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - FontHeight) / 2)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - FontHeight) / 2)
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.TopCenter) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.TopLeft) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf (e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight) Then
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1))
        Else
            e.Graphics.DrawString(e.Value.ToString, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - FontHeight) / 2)
        End If
    End Sub


    Public Property MergeColumnHeaderBackColor As Color

        Get
            Return Me._mergecolumnheaderbackcolor
        End Get
        Set
            Me._mergecolumnheaderbackcolor = Value
        End Set

    End Property
    Private _mergecolumnheaderbackcolor As Color = System.Drawing.SystemColors.Control


    Public Property MergeColumnNames As List(Of String)
        Get
            Return _mergecolumnname
        End Get
        Set
            _mergecolumnname = Value
        End Set
    End Property
    Private _mergecolumnname As List(Of String) = New List(Of String)()


End Class
