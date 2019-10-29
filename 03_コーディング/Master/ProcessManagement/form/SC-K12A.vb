Public Class SC_K12A
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"作番", "Work number" & vbCrLf & "(作番)"},
                             {"作業指示日", "Work instruction date" & vbCrLf & "(作業指示日)"},
                             {"直", "Direct" & vbCrLf & "(直)"},
                             {"品名", "Goods name" & vbCrLf & "(品名)"},
                             {"金型", "Money type" & vbCrLf & "(金型)"},
                             {"設備略称", "Goods abbreviation" & vbCrLf & "(設備略称)"},
                             {"品種名", "Variety name" & vbCrLf & "(品種名)"},
                             {"車種コード", "Car type code" & vbCrLf & "(車種コード)"},
                             {"梱包仕様", "Packing specification" & vbCrLf & "(梱包仕様)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"生地区分", "Material division" & vbCrLf & "(生地区分)"},
                             {"納入日・納入時間", "Delivery date・Delivery time" & vbCrLf & "(納入日・納入時間)"},
                             {"日産ライン", "Daily line" & vbCrLf & "(日産ライン)"},
                             {"台車ＮＯ", "Truck NO" & vbCrLf & "(台車ＮＯ)"},
                             {"指示", "Instruction" & vbCrLf & "(指示)"},
                             {"ショット", "Shot" & vbCrLf & "(ショット)"},
                             {"調整", "Adjustment" & vbCrLf & "(調整)"},
                             {"着手", "Start" & vbCrLf & "(着手)"},
                             {"完成", "Completion" & vbCrLf & "(完成)"},
                             {"不良", "Failure" & vbCrLf & "(不良)"},
                             {"他振替", "Other transfer" & vbCrLf & "(他振替)"},
                             {"保留", "Hold" & vbCrLf & "(保留)"},
                             {"梱包待ち", "Packing wait" & vbCrLf & "(梱包待ち)"},
                             {"生地不良(成)", "Material failure(M)" & vbCrLf & "(生地不良(成))"},
                             {"生地不良(仕)", "Material failure(F)" & vbCrLf & "(生地不良(仕))"},
                             {"リペア", "Repair" & vbCrLf & "(リペア)"},
                             {"再塗装", "Repaint" & vbCrLf & "(再塗装)"},
                             {"再塗装投入", "Repaint investment" & vbCrLf & "(再塗装投入)"},
                             {"指示残", "Remaining instruction" & vbCrLf & "(指示残)"},
                             {"最新入力実績時間", "Latest input actual time" & vbCrLf & "(最新入力実績時間)"},
                             {"強制除外", "Forced exclusion" & vbCrLf & "(強制除外)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PRODUCT_NAME As String = "作番"
    Private Const COL_CUSTOMER_PART_NO As String = "作業指示日"
    Private Const COL_START As String = "直"
    Private Const COL_COMPLETION As String = "品名"
    Private Const COL_DEFECT As String = "金型"
    Private Const COL_SP_PRO_TRANSFER As String = "設備略称"
    Private Const COL_TODAY As String = "品種名"
    Private Const COL_CORRECTION As String = "車種コード"
    Private Const COL_PASS As String = "梱包仕様"

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
        gridData.Columns(1).Width = 80
        gridData.Columns(2).Width = 120
        gridData.Columns(3).Width = 80
        gridData.Columns(4).Width = 80
        gridData.Columns(5).Width = 80
        gridData.Columns(6).Width = 140
        gridData.Columns(7).Width = 100
        gridData.Columns(8).Width = 140


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

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub SC_K12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add(" ", "")
        dt.Rows.Add("1", "A")
        dt.Rows.Add("2", "B")
        dt.Rows.Add("3", "C")
    End Sub

    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click

    End Sub

    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click

    End Sub
End Class