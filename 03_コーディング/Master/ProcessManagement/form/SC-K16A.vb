Public Class SC_K16A
    Dim headerName As Hashtable = New Hashtable From {
                                {"個体NO", "Individual NO" & vbCrLf & "(個体NO)"},
                                {"判定日付・時間", "Judgment date・time" & vbCrLf & "(判定日付・時間)"},
                                {"数量", "Count" & vbCrLf & "(数量)"},
                                {"不良原因", "Failure reason" & vbCrLf & "(不良原因)"},
                                {"作業者", "Worker" & vbCrLf & "(作業者)"},
                                {"キャビ", "Kyabi" & vbCrLf & "(キャビ)"}
                            }
    Private Const COL_INDIVIDUAL_NO As String = "個体NO"
    Private Const COL_JUDGMENT_DATE_TIME As String = "判定日付・時間"
    Private Const COL_COUNT As String = "数量"
    Private Const COL_FAILURE_REASON As String = "不良原因"
    Private Const COL_WORKER As String = "作業者"
    Private Const COL_KYABI As String = "キャビ"

    Private Const CONST_SYSTEM_NAME As String = "成形実績明細画面"
    Private Const FORM_NAME As String = "Molding achievement detail(成形実績明細)"

    Dim gridCells As DataGridViewCellCollection

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K16A_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gridCells = SC_K16.gridCells

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

        Dim dt As New DataTable

        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add("0", "ショット")
        dt.Rows.Add("1", "合格")
        dt.Rows.Add("2", "不良")
        dt.Rows.Add("3", "調整")

        '自動ラベルフラグ
        Me.cmbJudgment.DataSource = dt
        Me.cmbJudgment.ValueMember = dt.Columns.Item(0).ColumnName
        Me.cmbJudgment.DisplayMember = dt.Columns.Item(1).ColumnName

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

        dt.Columns.Add(New DataColumn(COL_INDIVIDUAL_NO, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_JUDGMENT_DATE_TIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_COUNT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FAILURE_REASON, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_KYABI, GetType(System.String)))

        For item As Integer = 0 To 3
            Dim addRow As DataRow = dt.NewRow

            addRow(COL_INDIVIDUAL_NO) = "個体NO" & item
            addRow(COL_JUDGMENT_DATE_TIME) = Format(Now, "yyyy/MM/dd HH:mm")
            addRow(COL_COUNT) = item
            addRow(COL_FAILURE_REASON) = "不良原因" & item
            addRow(COL_WORKER) = "作業者" & item
            addRow(COL_KYABI) = item

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
            col.ReadOnly = True
            col.SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case col.Name
                Case COL_COUNT
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select
        Next

        gridData.Columns(COL_INDIVIDUAL_NO).Width = 100
        gridData.Columns(COL_JUDGMENT_DATE_TIME).Width = 120
        gridData.Columns(COL_COUNT).Width = 70
        gridData.Columns(COL_FAILURE_REASON).Width = 150
        gridData.Columns(COL_WORKER).Width = 100
        gridData.Columns(COL_KYABI).Width = 100


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
End Class
