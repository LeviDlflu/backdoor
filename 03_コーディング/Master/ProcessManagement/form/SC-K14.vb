Public Class SC_K14
    Dim headerName As Hashtable = New Hashtable From {
                             {"品名略称", "Product name abbreviation" & vbCrLf & "(品名略称)"},
                             {"区分", "Section" & vbCrLf & "(区分)"},
                             {"合計", "Total" & vbCrLf & "(合計)"}
                            }
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_SECTION As String = "区分"
    Private Const COL_TOTAL As String = "合計"

    Private Const CONST_SYSTEM_NAME As String = "前日以前実績参照"

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbProcess.Text = String.Empty
        Me.cmbVariety.Text = String.Empty
        Me.cmbSection.Text = String.Empty
        Me.cmbVehicleType.Text = String.Empty
        Me.cmbSalesVarieties.Text = String.Empty
        Me.cmbPackingSpecifications.Text = String.Empty
        Me.cmbProductName.Text = String.Empty

        Dim dt As New DataTable

        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add("0", "成形")
        dt.Rows.Add("1", "塗装")
        dt.Rows.Add("2", "組立")

        '自動ラベルフラグ
        Me.cmbProcess.DataSource = dt
        Me.cmbProcess.ValueMember = dt.Columns.Item(0).ColumnName
        Me.cmbProcess.DisplayMember = dt.Columns.Item(1).ColumnName

    End Sub


    ''' <summary>
    ''' 　・行ヘッダーに行番号書き込み
    ''' </summary>
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

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_PRODUCT_NAME_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SECTION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_TOTAL, GetType(System.String)))
        For j As Integer = 1 To 31
            Dim headName As String = Now.Month & "/" & j

            dt.Columns.Add(New DataColumn(headName, GetType(System.String)))
        Next

        Dim PARAM_CODE As String = Me.cmbProcess.Text

        Dim code1 As String = "成形"
        Dim code2 As String = "塗装"
        Dim code3 As String = "組立"

        For item As Integer = 0 To 2
            Select Case PARAM_CODE
                Case code1

                    For i As Integer = 0 To 3
                        Dim addRow As DataRow = dt.NewRow
                        addRow(COL_PRODUCT_NAME_ABBREVIATION) = "PNA" & item
                        addRow(COL_TOTAL) = "1000"

                        Select Case i
                            Case 0
                                addRow(COL_SECTION) = "ショット"
                            Case 1
                                addRow(COL_SECTION) = "合格"
                            Case 2
                                addRow(COL_SECTION) = "不良"
                            Case 3
                                addRow(COL_SECTION) = "調整"

                        End Select
                        For j As Integer = 1 To 31
                            Dim headName As String = Now.Month & "/" & j
                            addRow(headName) = j
                        Next

                        dt.Rows.Add(addRow)
                    Next

                Case code2

                Case code3

            End Select
        Next

        Return dt

    End Function

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        gridData.Columns.Clear()

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'For i As Integer = 0 To gridData.Columns.Count - 1
        '    gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

        '    '横位置
        '    Select Case gridData.Columns(i).Name
        '        Case COL_DETAILS
        '            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '        Case Else
        '            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    End Select

        'Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        'gridData.Columns(0).Width = 50
        'gridData.Columns(1).Width = 150
        'gridData.Columns(2).Width = 150
        'gridData.Columns(3).Width = 400
        'gridData.Columns(4).Width = 400
        'gridData.Columns(5).Width = 100


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 検索ボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")

        setGrid(createGridData())

        Dim cmbGridView As New CmbDataGridGiew(Me.gridData)
        cmbGridView.Add(0, 0, 3, 0)
        cmbGridView.Add(4, 0, 7, 0)
        cmbGridView.Add(8, 0, 11, 0)
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        'If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
        '          vbYesNo + vbQuestion,
        '          My.Settings.systemName) = DialogResult.Yes Then
        '    Me.Close()
        'End If

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub gridData_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentDoubleClick
        If e.ColumnIndex > -1 Then
            Dim frm As New SC_K14A()
            frm.ShowDialog()
            Me.Show()
        End If
    End Sub
End Class

''' <summary>
''' データグリッドロード後
''' Dim cmbGridView As New CmbDataGridGiew(Me.gridData)
''' cmbGridView.Add(0, 0, 3, 0)
''' </summary>
Public Class CmbDataGridGiew
    Private data As New List(Of MyRect)
    Private Dgv As DataGridView

    Public Sub New(_dgv As DataGridView)
        Me.Dgv = _dgv
        AddHandler _dgv.CellPainting, AddressOf DGV_Cellparnting
    End Sub

    Public Sub Add(_rect As MyRect)
        Me.data.Add(_rect)
        Me.SetCellEnabled(_rect)
    End Sub
    Public Sub Add(_top As Integer, _left As Integer, _bottom As Integer, _right As Integer)
        Me.data.Add(New MyRect(_top, _left, _bottom, _right))
        Me.SetCellEnabled(New MyRect(_top, _left, _bottom, _right))
    End Sub

    Private Sub SetCellEnabled(_rect As MyRect)
        For i = _rect.Top To _rect.Bottom
            For j = _rect.Left To _rect.Right
                Me.Dgv.Rows(i).Cells(j).ReadOnly = True
            Next
        Next
    End Sub

    Private Function InRects(rowIndex As Integer, colIndex As Integer) As Integer
        For i = 0 To Me.data.Count - 1
            If Me.data(i).InRect(rowIndex, colIndex) Then
                Return i
            End If
        Next

        Return -1

    End Function

    Private Sub DGV_Cellparnting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        Using gridBrush As Brush = New SolidBrush(Me.Dgv.GridColor), backColorBrush As SolidBrush = New SolidBrush(e.CellStyle.BackColor)
            Using gridLinePen = New Pen(gridBrush)
                If Me.data.Count = 0 Then
                    Return
                End If

                Dim index As Integer = Me.InRects(e.RowIndex, e.ColumnIndex)
                If index = -1 Then
                    Return
                End If

                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                If e.RowIndex = Me.data(index).Bottom Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                End If
                If e.ColumnIndex = Me.data(index).Right Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                End If

                e.Handled = True

                For i = 0 To Me.data.Count - 1
                    Dim rect1 As Rectangle = Me.Dgv.GetCellDisplayRectangle(Me.data(i).Left, Me.data(i).Top, False)
                    Dim rect2 As Rectangle = Me.Dgv.GetCellDisplayRectangle(Me.data(i).Right, Me.data(i).Bottom, False)
                    Dim rect As New Rectangle(rect1.Left, rect1.Top, rect2.Right - rect1.Left, rect2.Bottom - rect1.Top)
                    Dim text As String

                    Try
                        text = Me.Dgv.Rows(Me.data(i).Top).Cells(Me.data(i).Left).Value.ToString().Trim()
                    Catch ex As Exception
                        text = ""
                    End Try

                    Dim sz As SizeF = e.Graphics.MeasureString(text, e.CellStyle.Font)
                    e.Graphics.DrawString(text, e.CellStyle.Font, New SolidBrush(e.CellStyle.ForeColor),
                                          rect.Left + (rect.Width - sz.Width) / 2,
                                          rect.Top + (rect.Height - sz.Height) / 2,
                                          StringFormat.GenericDefault)
                Next

            End Using

        End Using
    End Sub
End Class

Public Class MyRect
    Public Top As Integer
    Public Bottom As Integer
    Public Right As Integer
    Public Left As Integer
    Public Sub New(_top As Integer, _left As Integer, _bottom As Integer, _right As Integer)
        Me.Top = _top
        Me.Left = _left
        Me.Bottom = _bottom
        Me.Right = _right
    End Sub
    Public Function InRect(rowIndex As Integer, colIndex As Integer) As Boolean
        If rowIndex >= Me.Top And rowIndex <= Me.Bottom And colIndex >= Me.Left And colIndex <= Me.Right Then
            Return True
        Else
            Return False
        End If
    End Function
End Class