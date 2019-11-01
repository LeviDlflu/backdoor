Public Class SC_K16
    Dim headerName As Hashtable = New Hashtable From {
                                {"詳細", "Details" & vbCrLf & "(詳細)"},
                                {"設備", "Equipment" & vbCrLf & "(設備)"},
                                {"品名略称", "Goods abbreviation" & vbCrLf & "(品名略称)"},
                                {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                                {"金型", "Money type" & vbCrLf & "(金型)"},
                                {"指示数", "Instruction number" & vbCrLf & "(指示数)"},
                                {"ショット数", "Shots number" & vbCrLf & "(ショット数)"},
                                {"合格数", "Passing number" & vbCrLf & "(合格数)"},
                                {"不良数", "Failure number" & vbCrLf & "(不良数)"},
                                {"調整数", "Adjustment number" & vbCrLf & "(調整数)"},
                                {"その他払出", "Other payout" & vbCrLf & "(その他払出)"},
                                {"合格率", "Passing rate" & vbCrLf & "(合格率)"},
                                {"不良率", "Defective rate" & vbCrLf & "(不良率)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_EQUIPMENT As String = "設備"
    Private Const COL_GOODS_ABBREVIATION As String = "品名略称"
    Private Const COL_CUSTOMER_PART_NUMBER As String = "客先部品番号"
    Private Const COL_MONEY_TYPE As String = "金型"
    Private Const COL_INSTRUCTION_NUMBER As String = "指示数"
    Private Const COL_SHOTS_NUMBER As String = "ショット数"
    Private Const COL_PASSING_NUMBER As String = "合格数"
    Private Const COL_FAILURE_NUMBER As String = "不良数"
    Private Const COL_ADJUSTMENT_NUMBER As String = "調整数"
    Private Const COL_OTHER_PAYOUT As String = "その他払出"
    Private Const COL_PASSING_RATE As String = "合格率"
    Private Const COL_DEFECTIVE_RATE As String = "不良率"

    Private Const CONST_SYSTEM_NAME As String = "成形実績参照画面"
    Private Const FORM_NAME As String = "Molding achievement reference(成形実績参照)"

    Public gridCells As DataGridViewCellCollection

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbProcess.Text = String.Empty
        Me.cmbVariety.Text = String.Empty
        Me.cmbMoneyType.Text = String.Empty
        Me.cmbProductName.Text = String.Empty

        Me.StartPosition = FormStartPosition.CenterScreen

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

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

        dt.Columns.Add(New DataColumn(COL_EQUIPMENT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_GOODS_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CUSTOMER_PART_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MONEY_TYPE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_INSTRUCTION_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SHOTS_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PASSING_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FAILURE_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ADJUSTMENT_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_OTHER_PAYOUT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PASSING_RATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECTIVE_RATE, GetType(System.String)))


        For item As Integer = 0 To 3
            Dim addRow As DataRow = dt.NewRow

            If item = 3 Then
                addRow(COL_GOODS_ABBREVIATION) = "合計"
                addRow(COL_INSTRUCTION_NUMBER) = item
                addRow(COL_SHOTS_NUMBER) = item
                addRow(COL_PASSING_NUMBER) = item
                addRow(COL_FAILURE_NUMBER) = item
                addRow(COL_ADJUSTMENT_NUMBER) = item
                addRow(COL_OTHER_PAYOUT) = item
                addRow(COL_PASSING_RATE) = 90.25
                addRow(COL_DEFECTIVE_RATE) = 3.65
            Else
                addRow(COL_EQUIPMENT) = "設備" & item
                addRow(COL_GOODS_ABBREVIATION) = "品名略称" & item
                addRow(COL_CUSTOMER_PART_NUMBER) = "客先部品番号" & item
                addRow(COL_MONEY_TYPE) = item
                addRow(COL_INSTRUCTION_NUMBER) = item
                addRow(COL_SHOTS_NUMBER) = item
                addRow(COL_PASSING_NUMBER) = item
                addRow(COL_FAILURE_NUMBER) = item
                addRow(COL_ADJUSTMENT_NUMBER) = item
                addRow(COL_OTHER_PAYOUT) = item
                addRow(COL_PASSING_RATE) = 90.25
                addRow(COL_DEFECTIVE_RATE) = 3.65
            End If

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

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

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
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            If col.Name = COL_DETAILS Then
                col.ReadOnly = False
            Else
                col.ReadOnly = True
            End If

            '横位置
            Select Case col.Name
                Case COL_EQUIPMENT, COL_GOODS_ABBREVIATION, COL_CUSTOMER_PART_NUMBER
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_MONEY_TYPE
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next

        gridData.Columns(COL_DETAILS).Width = 55
        gridData.Columns(COL_EQUIPMENT).Width = 90
        gridData.Columns(COL_GOODS_ABBREVIATION).Width = 130
        gridData.Columns(COL_CUSTOMER_PART_NUMBER).Width = 140
        gridData.Columns(COL_MONEY_TYPE).Width = 90
        gridData.Columns(COL_INSTRUCTION_NUMBER).Width = 120
        gridData.Columns(COL_SHOTS_NUMBER).Width = 90
        gridData.Columns(COL_PASSING_NUMBER).Width = 100
        gridData.Columns(COL_FAILURE_NUMBER).Width = 100
        gridData.Columns(COL_ADJUSTMENT_NUMBER).Width = 120
        gridData.Columns(COL_OTHER_PAYOUT).Width = 90
        gridData.Columns(COL_PASSING_RATE).Width = 85
        gridData.Columns(COL_DEFECTIVE_RATE).Width = 100


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

    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS And e.RowIndex > -1 Then

            gridCells = gridData.Rows(e.RowIndex).Cells

            Dim frm As New SC_K16A()
            frm.ShowDialog()
            Me.Show()
        End If
    End Sub
End Class
