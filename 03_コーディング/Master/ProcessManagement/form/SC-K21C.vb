Public Class SC_K21C
    Dim headerName As Hashtable = New Hashtable From {
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"工程略称", "Process abbreviation" & vbCrLf & "(工程略称)"},
                             {"品種", "Variety" & vbCrLf & "(品種)"},
                             {"払出数量合計", "Payment quantity total" & vbCrLf & "(払出数量合計)"}
                            }
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_PROCESS_ABBREVIATION As String = "工程略称"
    Private Const COL_VARIETY As String = "品種"
    Private Const COL_PAYMENT_QUANTITY_TOTAL As String = "払出数量合計"

    Private Const FORM_NAME As String = "Total by process variety (工程品種別集計)"
    Private Sub SC_K21A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub

    Private Sub init()
        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME
        Label67.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label67.BackColor = Color.SkyBlue
        setGrid(createGridData())
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt = New DataTable()

        dt.Columns.Add(New DataColumn(COL_PROCESS_CODE, Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(COL_PROCESS_ABBREVIATION, Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(COL_VARIETY, Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(COL_PAYMENT_QUANTITY_TOTAL, Type.GetType("System.Double")))

        Dim dr As DataRow

        For index = 1 To 5
            dr = dt.NewRow()
            dr.Item(COL_PROCESS_CODE) = COL_PROCESS_CODE & index
            dr.Item(COL_PROCESS_ABBREVIATION) = COL_PROCESS_ABBREVIATION & index
            dr.Item(COL_VARIETY) = COL_VARIETY & index
            dr.Item(COL_PAYMENT_QUANTITY_TOTAL) = index
            dt.Rows.Add(dr)
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
                Case COL_PROCESS_CODE
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

        gridData.Columns(0).Width = 120
        gridData.Columns(1).Width = 200
        gridData.Columns(2).Width = 200
        gridData.Columns(3).Width = 260


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False

    End Sub

    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridData.RowPostPaint
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.RowHeadersVisible Then
            '行番号を描画する範囲を決定する
            Dim rect As New Rectangle(e.RowBounds.Left, e.RowBounds.Top,
        dgv.RowHeadersWidth, e.RowBounds.Height)
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

End Class
