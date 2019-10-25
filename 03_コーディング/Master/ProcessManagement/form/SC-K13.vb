Public Class SC_K13
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"品名", "Product name" & vbCrLf & "(品名)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"着手", "Start" & vbCrLf & "(着手)"},
                             {"完成", "Completion" & vbCrLf & "(完成)"},
                             {"不良", "Defect" & vbCrLf & "(不良)"},
                             {"SP･試作･他工程振替", "SP・Prototype・Other process transfer" & vbCrLf & "(SP･試作･他工程振替)"},
                             {"当日", "Today" & vbCrLf & "(当日)"},
                             {"訂正", "Correction" & vbCrLf & "(訂正)"},
                             {"合格", "Pass" & vbCrLf & "(合格)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PRODUCT_NAME As String = "品名"
    Private Const COL_CUSTOMER_PART_NO As String = "客先部品番号"
    Private Const COL_START As String = "着手"
    Private Const COL_COMPLETION As String = "完成"
    Private Const COL_DEFECT As String = "不良"
    Private Const COL_SP_PRO_TRANSFER As String = "SP･試作･他工程振替"
    Private Const COL_TODAY As String = "当日"
    Private Const COL_CORRECTION As String = "訂正"
    Private Const COL_PASS As String = "合格"

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
        dt.Columns.Add(New DataColumn(COL_DETAILS, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PRODUCT_NAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CUSTOMER_PART_NO, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_START, GetType(System.String)))
        '完成
        dt.Columns.Add(New DataColumn(COL_COMPLETION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SP_PRO_TRANSFER, GetType(System.String)))

        dt.Columns.Add(New DataColumn(COL_CORRECTION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PASS, GetType(System.String)))

        For i As Integer = 0 To 3
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_DETAILS) = "FAS"
                    addRow(COL_PRODUCT_NAME) = "11"
                    addRow(COL_CUSTOMER_PART_NO) = "落下"
                    addRow(COL_START) = "製造工場"
                    addRow(COL_COMPLETION) = "製造工場"
                    addRow(COL_DEFECT) = "製造工場"
                    addRow(COL_SP_PRO_TRANSFER) = "製造工場"
                Case 1
                    addRow(COL_DETAILS) = "FAS"
                    addRow(COL_PRODUCT_NAME) = "11"
                    addRow(COL_CUSTOMER_PART_NO) = "落下"
                    addRow(COL_START) = "製造工場"
                    addRow(COL_COMPLETION) = "製造工場"
                    addRow(COL_DEFECT) = "製造工場"
                    addRow(COL_SP_PRO_TRANSFER) = "製造工場"
                Case 2
                    addRow(COL_DETAILS) = "FAS"
                    addRow(COL_PRODUCT_NAME) = "11"
                    addRow(COL_CUSTOMER_PART_NO) = "落下"
                    addRow(COL_START) = "製造工場"
                    addRow(COL_COMPLETION) = "製造工場"
                    addRow(COL_DEFECT) = "製造工場"
                    addRow(COL_SP_PRO_TRANSFER) = "製造工場"
                Case 3
                    addRow(COL_DETAILS) = "FAS"
                    addRow(COL_PRODUCT_NAME) = "11"
                    addRow(COL_CUSTOMER_PART_NO) = "落下"
                    addRow(COL_START) = "製造工場"
                    addRow(COL_COMPLETION) = "製造工場"
                    addRow(COL_DEFECT) = "製造工場"
                    addRow(COL_SP_PRO_TRANSFER) = "製造工場"
                Case 4
                    addRow(COL_DETAILS) = "FAS"
                    addRow(COL_PRODUCT_NAME) = "11"
                    addRow(COL_CUSTOMER_PART_NO) = "落下"
                    addRow(COL_START) = "製造工場"
                    addRow(COL_COMPLETION) = "製造工場"
                    addRow(COL_DEFECT) = "製造工場"
                    addRow(COL_SP_PRO_TRANSFER) = "製造工場"

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

        ''選択
        'Dim addColSentaku As New DataGridViewCheckBoxColumn()
        'addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
        'addColSentaku.HeaderText = headerName(COL_SENTAKU)
        'addColSentaku.Name = "sentaku"
        'gridData.Columns.Add(addColSentaku)

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
                Case COL_DETAILS
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 150
        gridData.Columns(2).Width = 150
        gridData.Columns(3).Width = 400
        gridData.Columns(4).Width = 400
        gridData.Columns(5).Width = 100


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
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

    End Sub
End Class