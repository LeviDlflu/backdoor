Public Class SC_K17
    Dim headerName As Hashtable = New Hashtable From {
                             {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                             {"不良現象", "Failure reason" & vbCrLf & "(不良現象)"},
                             {"率", "Rate" & vbCrLf & "(率)"},
                             {"合計", "Total" & vbCrLf & "(合計)"},
                             {"日付", "Date" & vbCrLf & "(日付)"},
                             {"金型", "Mold" & vbCrLf & "(金型)"}
                            }
    Private Const COL_PRODUCT_ABBREVIATION As String = "品名略称"
    Private Const COL_FAILURE_REASON As String = "不良現象"
    Private Const COL_RATE As String = "率"
    Private Const COL_TOTAL As String = "合計"
    Private Const COL_DATE As String = "日付"
    Private Const COL_MOLD As String = "金型"


    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"

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
        dt.Columns.Add(New DataColumn(COL_PRODUCT_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FAILURE_REASON, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_RATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_TOTAL, GetType(System.String)))
        '完成
        dt.Columns.Add(New DataColumn(COL_DATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MOLD, GetType(System.String)))
        For i As Integer = 0 To 3
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_PRODUCT_ABBREVIATION) = "FAS"
                    addRow(COL_FAILURE_REASON) = "11"
                    addRow(COL_RATE) = "落下"
                    addRow(COL_TOTAL) = "製造工場"
                    addRow(COL_DATE) = "製造工場"
                    addRow(COL_MOLD) = "製造工場"
                Case 1
                    addRow(COL_PRODUCT_ABBREVIATION) = "FAS"
                    addRow(COL_FAILURE_REASON) = "11"
                    addRow(COL_RATE) = "落下"
                    addRow(COL_TOTAL) = "製造工場"
                    addRow(COL_DATE) = "製造工場"
                    addRow(COL_MOLD) = "製造工場"
                Case 2
                    addRow(COL_PRODUCT_ABBREVIATION) = "FAS"
                    addRow(COL_FAILURE_REASON) = "11"
                    addRow(COL_RATE) = "落下"
                    addRow(COL_TOTAL) = "製造工場"
                    addRow(COL_DATE) = "製造工場"
                    addRow(COL_MOLD) = "製造工場"
                Case 3
                    addRow(COL_PRODUCT_ABBREVIATION) = "FAS"
                    addRow(COL_FAILURE_REASON) = "11"
                    addRow(COL_RATE) = "落下"
                    addRow(COL_TOTAL) = "製造工場"
                    addRow(COL_DATE) = "製造工場"
                    addRow(COL_MOLD) = "製造工場"
                Case 4
                    addRow(COL_PRODUCT_ABBREVIATION) = "FAS"
                    addRow(COL_FAILURE_REASON) = "11"
                    addRow(COL_RATE) = "落下"
                    addRow(COL_TOTAL) = "製造工場"
                    addRow(COL_DATE) = "製造工場"
                    addRow(COL_MOLD) = "製造工場"

            End Select
            dt.Rows.Add(addRow)
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
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_PRODUCT_ABBREVIATION
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select

        Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(0).Width = 140
        gridData.Columns(1).Width = 120
        gridData.Columns(2).Width = 80
        gridData.Columns(3).Width = 80
        gridData.Columns(4).Width = 80
        gridData.Columns(5).Width = 80


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
        Label56.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label56.BackColor = Color.SkyBlue
    End Sub


    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub SC_K17_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

End Class