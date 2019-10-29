Public Class SC_K14A
    Dim headerName As Hashtable = New Hashtable From {
                             {"個体No", "Individual No" & vbCrLf & "(個体No)"},
                             {"ラベル発行No", "Label issue No" & vbCrLf & "(ラベル発行No)"},
                             {"設備名称", "Facility name" & vbCrLf & "(設備名称)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"品名略称", "Product name abbreviation" & vbCrLf & "(品名略称)"},
                             {"判定日付・時間", "Judgment date / Time" & vbCrLf & "(判定日付・時間)"},
                             {"数量", "Quantity" & vbCrLf & "(数量)"},
                             {"不良原因", "Cause of failure" & vbCrLf & "(不良原因)"},
                             {"氏名", "Full name" & vbCrLf & "(氏名)"}
                            }
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_SECTION As String = "区分"
    Private Const COL_CLASSIFICATION As String = "分類"

    Private Const CONST_SYSTEM_NAME As String = "前日以前詳細実績参照"

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
        dt.Columns.Add(New DataColumn(COL_CLASSIFICATION, GetType(System.String)))

        For i As Integer = 0 To 3
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_PRODUCT_NAME_ABBREVIATION) = "FAS"
                    addRow(COL_SECTION) = "11"
                    addRow(COL_CLASSIFICATION) = "落下"
                Case 1
                    addRow(COL_PRODUCT_NAME_ABBREVIATION) = "FAS"
                    addRow(COL_SECTION) = "11"
                    addRow(COL_CLASSIFICATION) = "落下"
                Case 2
                    addRow(COL_PRODUCT_NAME_ABBREVIATION) = "FAS"
                    addRow(COL_SECTION) = "11"
                    addRow(COL_CLASSIFICATION) = "落下"
                Case 3
                    addRow(COL_PRODUCT_NAME_ABBREVIATION) = "FAS"
                    addRow(COL_SECTION) = "11"
                    addRow(COL_CLASSIFICATION) = "落下"
                Case 4
                    addRow(COL_PRODUCT_NAME_ABBREVIATION) = "FAS"
                    addRow(COL_SECTION) = "11"
                    addRow(COL_CLASSIFICATION) = "落下"

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

    ''' <summary>
    ''' 検索ボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
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

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick

    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K14A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtJudgmentClassification.Text = "判定区分"
        Me.txtJudgmentCategory.Text = "判定分類"

    End Sub

End Class