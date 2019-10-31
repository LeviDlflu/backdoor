Public Class SC_K13
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"品名", "Product name" & vbCrLf & "(品名)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"金型", "Mold" & vbCrLf & "(金型)"},
                             {"着手", "Start" & vbCrLf & "(着手)"},
                             {"完成", "Completion" & vbCrLf & "(完成)"},
                             {"不良", "Defect" & vbCrLf & "(不良)"},
                             {"SP･試作･他工程振替", "SP・Prototype・Other process transfer" & vbCrLf & "(SP･試作･他工程振替)"},
                             {"当日", "Today" & vbCrLf & "(当日)"},
                             {"訂正", "Correction" & vbCrLf & "(訂正)"},
                             {"合格", "Pass" & vbCrLf & "(合格)"},
                             {"生地", "Fabric" & vbCrLf & "(生地)"},
                             {"直行", "Direct" & vbCrLf & "(直行)"},
                             {"再塗装", "Repainting" & vbCrLf & "(再塗装)"},
                             {"スポット", "Spot" & vbCrLf & "(スポット)"},
                             {"生地不良(成形)", "Defective fabric (molding)" & vbCrLf & "(生地不良(成形))"},
                             {"生地不良(仕上)", "Defective fabric (finish)" & vbCrLf & "(生地不良(仕上))"},
                             {"再塗装判定", "Repaint judgment" & vbCrLf & "(再塗装判定)"},
                             {"スポット判定", "Spot judgment" & vbCrLf & "(スポット判定)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PRODUCT_NAME As String = "品名"
    Private Const COL_CUSTOMER_PART_NO As String = "客先部品番号"
    Private Const COL_MOLD As String = "金型"
    Private Const COL_START As String = "着手"
    Private Const COL_COMPLETION As String = "完成"
    Private Const COL_DEFECT As String = "不良"
    Private Const COL_SP_PRO_TRANSFER As String = "SP･試作･他工程振替"
    Private Const COL_TODAY As String = "当日"
    Private Const COL_CORRECTION As String = "訂正"
    Private Const COL_PASS As String = "合格"
    Private Const COL_COMPLETION_THE_DAY As String = "完成＿当日"
    Private Const COL_COMPLETION_CORRECTION As String = "完成＿訂正"
    Private Const COL_DEFECT_THE_DAY As String = "不良＿当日"
    Private Const COL_DEFECT_CORRECTION As String = "不良＿訂正"
    Private Const COL_SP_PROP_TRANSFER_PASS As String = "SP･試作･他工程振替＿合格"
    Private Const COL_SP_PROP_TRANSFER_DEFECT As String = "SP･試作･他工程振替＿不良"
    Private Const COL_FABRIC As String = "生地"
    Private Const COL_DIRECT As String = "直行"
    Private Const COL_REPAINTING As String = "再塗装"
    Private Const COL_SPOT As String = "スポット"
    Private Const COL_COMPLETING_REPAINTING As String = "完成_再塗装"
    Private Const COL_DEFECTIVE_FABRIC_MOLDING As String = "生地不良(成形)"
    Private Const COL_DEFECTIVE_FABRIC_FINISH As String = "生地不良(仕上)"
    Private Const COL_REPAINT_JUDGMENT As String = "再塗装判定"
    Private Const COL_SPOT_JUDGMENT As String = "スポット判定"

    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"

    ''' <summary>
    ''' 列ヘッダーの行数
    ''' </summary>
    ''' <remarks></remarks>
    Private ColumnHeaderRowCount As Integer = 2

    ''' <summary>
    ''' 列ヘッダーの行の高さ
    ''' </summary>
    ''' <remarks></remarks>
    Private columnHeaderrRowHeight As Integer = 30

    ''' <summary>
    ''' 列ヘッダーセル定義構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure HeaderCell
        Public Row As Integer
        Public Column As Integer
        Public RowSpan As Integer
        Public ColumnSpan As Integer
        Public Text As String

        ''' <summary>
        ''' 列ヘッダーセル定義
        ''' </summary>
        ''' <param name="paramRow">行</param>
        ''' <param name="paramColumn">列</param>
        ''' <param name="paramRowSpan">結合する行数</param>
        ''' <param name="paramColumnSpan">結合する列数</param>
        ''' <param name="paramText">セルに関連付けられたテキスト</param>
        ''' <remarks></remarks>
        Sub New(ByVal paramRow As Integer, ByVal paramColumn As Integer, ByVal paramRowSpan As Integer, ByVal paramColumnSpan As Integer, ByVal paramText As String)
            Row = paramRow
            Column = paramColumn
            RowSpan = paramRowSpan
            ColumnSpan = paramColumnSpan
            Text = paramText
        End Sub

    End Structure

    ''' <summary>
    ''' 列ヘッダーセル定義
    ''' </summary>
    ''' <remarks></remarks>
    Public HeaderCells As HeaderCell()


    '初期処理
    Private Sub Init()
        'ちらつき防止
        Dim myType As Type = GetType(DataGridView)
        Dim myPropInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        myPropInfo.SetValue(Me.gridData, True, Nothing)

        '列ヘッダーの高さの調整モード
        Me.gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        '列ヘッダーの高さを行数に合わせる
        Me.gridData.ColumnHeadersHeight = columnHeaderrRowHeight * ColumnHeaderRowCount

        srDate.Text = Format(Now, "yyyy/MM/dd HH:mm")

    End Sub

    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridData.RowPostPaint
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.RowHeadersVisible Then
            '行番号を描画する範囲を決定する
            Dim rect As New Rectangle(e.RowBounds.Left,
                                      e.RowBounds.Top,
                                      dgv.RowHeadersWidth,
                                      e.RowBounds.Height)
            rect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics,
                                  (e.RowIndex + 1).ToString(),
                                  e.InheritedRowStyle.Font,
                                  rect,
                                  e.InheritedRowStyle.ForeColor,
                                  TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        gridData.Columns.Clear()
        srDate.Text = Format(Now, "yyyy/MM/dd HH:mm")
        If cmbProcess.SelectedItem = "" Or cmbProcess.SelectedItem = "SMD" Then
            Patten1()
        ElseIf cmbProcess.SelectedItem = "SMM" Then
            Patten2()
        ElseIf cmbProcess.SelectedItem = "SME" Then
            Patten3()
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        'Dim selectedCount As Boolean = False
        'レコードが選択される場合、保存されていないメッセージを表示する
        'If gridData.Rows.Count > 0 Then
        '    For i As Integer = 0 To gridData.Rows.Count - 1
        '        '横位置
        '        If gridData.Rows(i).Cells(0).Value = True Then
        '            selectedCount = True
        '        End If
        '    Next
        'Dim wMsg As New clsMessage("W0099")
        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
        'End If
    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS And e.RowIndex >= 0 Then
            Dim frm As New SC_K13A()
            frm.ShowDialog()
            Me.Show()
        End If

    End Sub

    ''' <summary>
    ''' 結合元のセルの文字位置から結合後の文字位置を取得する
    ''' </summary>
    ''' <param name="alignment">テキストの配置</param>
    ''' <remarks></remarks>
    Private Function GetTextFormatFlags(ByVal alignment As DataGridViewContentAlignment) As TextFormatFlags
        Try
            '文字の描画
            Dim formatFlg As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis

            '表示位置
            Select Case alignment
                Case DataGridViewContentAlignment.BottomCenter
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomLeft
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomRight
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleCenter
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleLeft
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleRight
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopCenter
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopLeft
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopRight
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
            End Select

            Return formatFlg

        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "二重タイトル表示用"

    ''' <summary>
    ''' コントロールを再描画する時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_Paint(sender As Object, e As PaintEventArgs) Handles gridData.Paint
        '列が無い場合
        If Me.gridData.ColumnCount = 0 Then
            Exit Sub
        End If

        '行が無い場合
        If Me.gridData.RowCount = 0 Then
            Exit Sub
        End If

        '列ヘッダーの行の高さの取得
        Dim rowHeight As Integer = Me.gridData.ColumnHeadersHeight / ColumnHeaderRowCount

        Dim lineWidth As Integer = 1

        '列ヘッダーを指定された行数にセル表示する
        For columuns = 0 To Me.gridData.ColumnCount - 1

            For rows = 0 To ColumnHeaderRowCount - 1

                '列ヘッダーの表示領域の取得
                Dim rect As Rectangle = Me.gridData.GetCellDisplayRectangle(columuns, -1, True)

                '列ヘッダーの描画領域の底部の座標を保存
                Dim btm As Integer = rect.Bottom

                'セルの描画領域のY座標
                Select Case Me.gridData.BorderStyle
                    Case Windows.Forms.BorderStyle.None
                        rect.Y = rowHeight * rows
                    Case Windows.Forms.BorderStyle.FixedSingle
                        rect.Y = rowHeight * rows + lineWidth
                    Case Windows.Forms.BorderStyle.Fixed3D
                        rect.Y = rowHeight * rows + (lineWidth * 2)
                End Select

                'セルの描画領域のX座標
                rect.X -= lineWidth

                'セルの描画領域の高さ
                rect.Height = rowHeight

                '最下行の場合高さを調整
                If rows = Me.ColumnHeaderRowCount - 1 Then
                    rect.Height = btm - rect.Y - lineWidth
                End If

                Dim gridPen As New Pen(Me.gridData.GridColor)
                e.Graphics.DrawRectangle(gridPen, rect)

                'セルの背景色の領域
                rect.Y += lineWidth
                rect.X += lineWidth
                rect.Height -= lineWidth
                rect.Width -= lineWidth

                '背景色
                Dim backBrash As New SolidBrush(Me.gridData.BackColor)

                e.Graphics.FillRectangle(backBrash, rect)

                '見出しを最下列に表示
                If rows = Me.ColumnHeaderRowCount - 1 Then

                    Dim text As String = Me.gridData.Columns(columuns).HeaderText
                    Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

                    TextRenderer.DrawText(e.Graphics, text, Me.gridData.ColumnHeadersDefaultCellStyle.Font,
                                          rect, Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor,
                                          formatFlg)
                End If

                'リソースの解放
                gridPen.Dispose()
                backBrash.Dispose()
            Next
        Next

        '列ヘッダーセル定義の処理
        For i = 0 To Me.HeaderCells.Count - 1

            'セルの結合の開始行がヘッダーの行数より大きい場合は除外
            If HeaderCells(i).Row > Me.ColumnHeaderRowCount - 1 Then
                Continue For
            End If

            'セルの結合の開始列の列インデックスが列数より大きい場合は除外
            If HeaderCells(i).Column > Me.gridData.ColumnCount - 1 Then
                Continue For
            End If

            '描画領域の設定
            Dim rect As Rectangle = Nothing

            '結合する列中のソート状態
            Dim sortText As String = String.Empty

            '結合するセルの幅の取得
            For j = Me.HeaderCells(i).Column To Me.HeaderCells(i).Column + Me.HeaderCells(i).ColumnSpan - 1

                If Me.gridData.Columns(j).Displayed = False Then
                    Continue For
                End If

                If rect = Nothing Then
                    rect = Me.gridData.GetCellDisplayRectangle(j, -1, True)
                Else
                    rect.Width += Me.gridData.GetCellDisplayRectangle(j, -1, True).Width
                End If
            Next

            '結合するセルが画面中に無い場合
            If rect = Nothing Then
                Continue For
            End If

            '結合する行がヘッダー行数より大きい場合
            Dim rowSapn As Integer = Me.HeaderCells(i).RowSpan
            If rowSapn > ColumnHeaderRowCount Then
                rowSapn = ColumnHeaderRowCount
            End If

            '列ヘッダーの描画領域の底部の座標を保存
            Dim btm As Integer = rect.Bottom

            '結合するセルの描画領域のY座標
            Select Case Me.gridData.BorderStyle
                Case Windows.Forms.BorderStyle.None
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row)
                Case Windows.Forms.BorderStyle.FixedSingle
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row) + lineWidth
                Case Windows.Forms.BorderStyle.Fixed3D
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row) + (lineWidth * 2)
            End Select

            '結合するセルの描画領域のX座標
            rect.X -= lineWidth

            '結合するセルの描画領域の高さ
            rect.Height = rowHeight * rowSapn

            '最下行の場合は描画領域の高さを調整する
            If Me.HeaderCells(i).Row + rowSapn = Me.ColumnHeaderRowCount Then
                rect.Height = btm - rect.Y - lineWidth
            End If

            'グッリドの線
            Dim gridPen As New Pen(Me.gridData.GridColor)

            '背景色の取得
            Dim backgroundColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.BackColor

            '背景色
            Dim backBrash As New SolidBrush(backgroundColor)

            'くぼみ線
            Dim whiteBrash As New SolidBrush(Color.White)

            '枠線の描画
            e.Graphics.DrawRectangle(gridPen, rect)

            '結合セルの背景色の描画領域の設定
            rect.Y += lineWidth
            rect.X += lineWidth
            rect.Height -= lineWidth
            rect.Width -= lineWidth

            '背景色の描画
            e.Graphics.FillRectangle(backBrash, rect)

            'テキストの描画
            Dim foreColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor
            Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

            TextRenderer.DrawText(e.Graphics, Me.HeaderCells(i).Text & sortText,
                                  Me.gridData.ColumnHeadersDefaultCellStyle.Font,
                                  rect, foreColor, formatFlg)
            'リソースの解放
            gridPen.Dispose()
            backBrash.Dispose()
            whiteBrash.Dispose()
        Next
    End Sub

    ''' <summary>
    ''' 列ヘッダーの描画領域の無効化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InvalidateUnitColumns()
        Try

            If Me.gridData.RowCount > 0 Then
                Dim hRect As Rectangle = Me.gridData.DisplayRectangle
                Me.gridData.Invalidate(hRect)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 列の幅が変更された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles gridData.ColumnWidthChanged
        InvalidateUnitColumns()
    End Sub

    ''' <summary>
    ''' スクロールする時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridData.Scroll
        InvalidateUnitColumns()
    End Sub

    ''' <summary>
    ''' コントロールのサイズが変更された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridData.SizeChanged
        InvalidateUnitColumns()
    End Sub

    ''' <summary>
    ''' マウスのボタンが離された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles gridData.MouseUp

        Try
            ''OnMouseDownイベントで解除されたダブルバッファを適用する
            Dim myType As Type = GetType(DataGridView)
            Dim myPropInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            myPropInfo.SetValue(Me.gridData, True, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

    Private Sub Patten1()

        HeaderCells = {
            New HeaderCell(0, 0, 2, 1, headerName(COL_DETAILS)),
            New HeaderCell(0, 1, 2, 1, headerName(COL_PRODUCT_NAME)),
            New HeaderCell(0, 2, 2, 1, headerName(COL_CUSTOMER_PART_NO)),
            New HeaderCell(0, 3, 2, 1, headerName(COL_MOLD)),
            New HeaderCell(0, 4, 1, 2, headerName(COL_COMPLETION)),
            New HeaderCell(0, 6, 1, 2, headerName(COL_DEFECT)),
            New HeaderCell(0, 8, 1, 2, headerName(COL_SP_PRO_TRANSFER))}

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable
        dt.Columns.Add(COL_PRODUCT_NAME)
        dt.Columns.Add(COL_CUSTOMER_PART_NO)
        dt.Columns.Add(COL_MOLD)
        dt.Columns.Add(COL_COMPLETION_THE_DAY)
        dt.Columns.Add(COL_COMPLETION_CORRECTION)
        dt.Columns.Add(COL_DEFECT_THE_DAY)
        dt.Columns.Add(COL_DEFECT_CORRECTION)
        dt.Columns.Add(COL_SP_PROP_TRANSFER_PASS)
        dt.Columns.Add(COL_SP_PROP_TRANSFER_DEFECT)

        Dim dr As DataRow

        For index = 1 To 20
            dr = dt.NewRow()
            dr.Item(COL_PRODUCT_NAME) = COL_PRODUCT_NAME & index
            dr.Item(COL_CUSTOMER_PART_NO) = COL_CUSTOMER_PART_NO & index
            dr.Item(COL_MOLD) = COL_MOLD & COL_MOLD & COL_MOLD & index
            dr.Item(COL_COMPLETION_THE_DAY) = index
            dr.Item(COL_COMPLETION_CORRECTION) = 2 & index
            dr.Item(COL_DEFECT_THE_DAY) = index
            dr.Item(COL_DEFECT_CORRECTION) = 0
            dr.Item(COL_SP_PROP_TRANSFER_PASS) = 3 & index
            dr.Item(COL_SP_PROP_TRANSFER_DEFECT) = 4 & index
            dt.Rows.Add(dr)
        Next

        '子タイトル設定する
        gridData.DataSource = dt
        gridData.Columns(COL_COMPLETION_THE_DAY).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns(COL_DEFECT_THE_DAY).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns(COL_COMPLETION_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns(COL_DEFECT_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridData.Columns(COL_COMPLETION_THE_DAY).HeaderText = headerName(COL_TODAY)

        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).HeaderText = headerName(COL_PASS)
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).HeaderText = headerName(COL_DEFECT)
        gridData.AutoResizeColumns()

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_PRODUCT_NAME).Width = 130
        gridData.Columns(COL_CUSTOMER_PART_NO).Width = 150
        gridData.Columns(COL_MOLD).Width = 130
        gridData.Columns(COL_COMPLETION_THE_DAY).Width = 100
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 100
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 100
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 100
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).Width = 200
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).Width = 200
    End Sub

    Private Sub Patten2()

        HeaderCells = {New HeaderCell(0, 0, 2, 1, headerName(COL_DETAILS)),
            New HeaderCell(0, 1, 2, 1, headerName(COL_PRODUCT_NAME)),
        New HeaderCell(0, 2, 1, 2, headerName(COL_START)),
        New HeaderCell(0, 4, 1, 4, headerName(COL_COMPLETION)),
        New HeaderCell(0, 8, 1, 2, headerName(COL_DEFECT)),
        New HeaderCell(0, 10, 2, 1, headerName(COL_DEFECTIVE_FABRIC_MOLDING)),
        New HeaderCell(0, 11, 2, 1, headerName(COL_DEFECTIVE_FABRIC_FINISH)),
        New HeaderCell(0, 12, 2, 1, headerName(COL_REPAINT_JUDGMENT)),
        New HeaderCell(0, 13, 2, 1, headerName(COL_SPOT_JUDGMENT))}

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable

        dt.Columns.Add(COL_PRODUCT_NAME)
        dt.Columns.Add("生地")
        dt.Columns.Add(COL_REPAINTING)
        dt.Columns.Add("直行")
        dt.Columns.Add(COL_COMPLETING_REPAINTING)
        dt.Columns.Add("スポット")
        dt.Columns.Add(COL_COMPLETION_CORRECTION)
        dt.Columns.Add(COL_DEFECT_THE_DAY)
        dt.Columns.Add(COL_DEFECT_CORRECTION)
        dt.Columns.Add("生地不良(成形)")
        dt.Columns.Add("生地不良(仕上)")
        dt.Columns.Add("再塗装判定")
        dt.Columns.Add("スポット判定")

        Dim dr As DataRow

        For index = 1 To 9
            dr = dt.NewRow()
            dr.Item("品名") = "品名" & index
            dr.Item("生地") = "1" & index
            dr.Item(COL_REPAINTING) = "2" & index
            dr.Item("直行") = "3" & index
            dr.Item(COL_COMPLETING_REPAINTING) = "4" & index
            dr.Item("スポット") = "5" & index
            dr.Item(COL_COMPLETION_CORRECTION) = "6" & index
            dr.Item(COL_DEFECT_THE_DAY) = "7" & index
            dr.Item(COL_DEFECT_CORRECTION) = "0"
            dr.Item("生地不良(成形)") = "10" & index
            dr.Item("生地不良(仕上)") = "13" & index
            dr.Item("再塗装判定") = "20" & index
            dr.Item("スポット判定") = "31" & index
            dt.Rows.Add(dr)
        Next
        gridData.DataSource = dt
        gridData.Columns(COL_FABRIC).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_REPAINTING).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DIRECT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_COMPLETING_REPAINTING).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_SPOT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_COMPLETION_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECT_THE_DAY).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_COMPLETION_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECT_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECTIVE_FABRIC_MOLDING).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECTIVE_FABRIC_FINISH).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_REPAINT_JUDGMENT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_SPOT_JUDGMENT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        gridData.Columns(COL_FABRIC).HeaderText = headerName(COL_FABRIC)
        gridData.Columns(COL_REPAINTING).HeaderText = headerName(COL_REPAINTING)
        gridData.Columns(COL_DIRECT).HeaderText = headerName(COL_DIRECT)
        gridData.Columns(COL_COMPLETING_REPAINTING).HeaderText = headerName(COL_REPAINTING)
        gridData.Columns(COL_SPOT).HeaderText = headerName(COL_SPOT)
        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.AutoResizeColumns()

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_PRODUCT_NAME).Width = 100
        gridData.Columns(COL_FABRIC).Width = 60
        gridData.Columns(COL_REPAINTING).Width = 60
        gridData.Columns(COL_DIRECT).Width = 60
        gridData.Columns(COL_COMPLETING_REPAINTING).Width = 60
        gridData.Columns(COL_SPOT).Width = 60
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 60
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 60
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 60
        gridData.Columns(COL_DEFECTIVE_FABRIC_MOLDING).Width = 160
        gridData.Columns(COL_DEFECTIVE_FABRIC_FINISH).Width = 160
        gridData.Columns(COL_REPAINT_JUDGMENT).Width = 160
        gridData.Columns(COL_SPOT_JUDGMENT).Width = 160

    End Sub

    Private Sub Patten3()

        HeaderCells = {New HeaderCell(0, 0, 2, 1, headerName(COL_DETAILS)),
            New HeaderCell(0, 1, 2, 1, headerName(COL_PRODUCT_NAME)),
        New HeaderCell(0, 2, 2, 1, headerName(COL_CUSTOMER_PART_NO)),
        New HeaderCell(0, 3, 2, 1, headerName(COL_START)),
        New HeaderCell(0, 4, 1, 2, headerName(COL_COMPLETION)),
        New HeaderCell(0, 6, 1, 2, headerName(COL_DEFECT)),
        New HeaderCell(0, 8, 1, 2, headerName(COL_SP_PRO_TRANSFER))}


        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable

        dt.Columns.Add(COL_PRODUCT_NAME)
        dt.Columns.Add(COL_CUSTOMER_PART_NO)
        dt.Columns.Add(COL_START)
        dt.Columns.Add(COL_COMPLETION_THE_DAY)
        dt.Columns.Add(COL_COMPLETION_CORRECTION)
        dt.Columns.Add(COL_DEFECT_THE_DAY)
        dt.Columns.Add(COL_DEFECT_CORRECTION)
        dt.Columns.Add(COL_PASS)
        dt.Columns.Add(COL_DEFECT)

        Dim dr As DataRow

        For index = 1 To 6
            dr = dt.NewRow()
            dr.Item(COL_PRODUCT_NAME) = "品名" & index
            dr.Item(COL_CUSTOMER_PART_NO) = "客先部品番号" & index
            dr.Item(COL_START) = 7 & index
            dr.Item(COL_COMPLETION_THE_DAY) = 2 & index
            dr.Item(COL_COMPLETION_CORRECTION) = 3 & index
            dr.Item(COL_DEFECT_THE_DAY) = 5 & index
            dr.Item(COL_DEFECT_CORRECTION) = 7 & index
            dr.Item(COL_PASS) = 12 & index
            dr.Item(COL_DEFECT) = 23 & index
            dt.Rows.Add(dr)
        Next

        gridData.DataSource = dt
        gridData.Columns(COL_START).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_COMPLETION_THE_DAY).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_COMPLETION_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECT_THE_DAY).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECT_CORRECTION).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_PASS).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(COL_DEFECT).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        gridData.Columns(COL_COMPLETION_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_PASS).HeaderText = headerName(COL_PASS)
        gridData.Columns(COL_DEFECT).HeaderText = headerName(COL_DEFECT)
        gridData.AutoResizeColumns()

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_PRODUCT_NAME).Width = 160
        gridData.Columns(COL_CUSTOMER_PART_NO).Width = 160
        gridData.Columns(COL_START).Width = 160
        gridData.Columns(COL_COMPLETION_THE_DAY).Width = 100
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 100
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 100
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 100
        gridData.Columns(COL_PASS).Width = 160
        gridData.Columns(COL_DEFECT).Width = 160
    End Sub

    Private Sub SC_K13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()

    End Sub
End Class