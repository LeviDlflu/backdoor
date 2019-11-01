Public Class SC_K17
    Dim headerName As Hashtable = New Hashtable From {
                             {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                             {"金型", "Mold" & vbCrLf & "(金型)"},
                             {"不良現象", "Failure reason" & vbCrLf & "(不良現象)"},
                             {"率", "Rate" & vbCrLf & "(率)"},
                             {"合計", "Total" & vbCrLf & "(合計)"},
                             {"日付", "Date" & vbCrLf & "(日付)"}
                            }
    Private Const COL_PRODUCT_ABBREVIATION As String = "品名略称"
    Private Const COL_MOLD As String = "金型"
    Private Const COL_FAILURE_REASON As String = "不良現象"
    Private Const COL_RATE As String = "率"
    Private Const COL_TOTAL As String = "合計"
    Private Const COL_DATE As String = "日付"


    Private Const FORM_NAME As String = "Defect analysis by mold(成形金型番号別不良分析)"
    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
        gridData.MergeColumnNames.Add(COL_PRODUCT_ABBREVIATION)
        gridData.MergeColumnNames.Add(COL_MOLD)
        Label67.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label67.BackColor = Color.SkyBlue
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SC_K17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME
    End Sub

    ''' <summary>
    ''' 行ヘッダーに行番号書き込み
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

        dt.Columns.Add(New DataColumn(COL_PRODUCT_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MOLD, GetType(System.Int16)))
        dt.Columns.Add(New DataColumn(COL_FAILURE_REASON, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_RATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_TOTAL, GetType(System.String)))
        For j As Integer = 1 To 31
            Dim headName As String = Now.Month & "/" & j
            dt.Columns.Add(New DataColumn(headName, GetType(System.String)))
        Next
        For item As Integer = 0 To 2
            For i As Integer = 0 To 4
                Dim addRow As DataRow = dt.NewRow
                addRow(COL_MOLD) = item
                addRow(COL_PRODUCT_ABBREVIATION) = "SMD" & item
                addRow(COL_TOTAL) = "1000"
                addRow(COL_RATE) = "1" & item

                Select Case i
                    Case 0
                        addRow(COL_FAILURE_REASON) = "ショット"
                    Case 1
                        addRow(COL_FAILURE_REASON) = "合格"
                    Case 2
                        addRow(COL_FAILURE_REASON) = "不良"
                    Case 3
                        addRow(COL_FAILURE_REASON) = "調整"
                    Case 4
                        addRow(COL_FAILURE_REASON) = "調整"
                    Case 4
                        addRow(COL_FAILURE_REASON) = "調整"
                End Select
                For j As Integer = 1 To 31
                    Dim headName As String = Now.Month & "/" & j
                    addRow(headName) = j
                Next

                dt.Rows.Add(addRow)
            Next

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

        For i As Integer = 0 To gridData.DisplayedColumnCount(True)
            Select Case i
                Case 0
                    gridData.Columns(i).Width = 200
                Case 1
                    gridData.Columns(i).Width = 80
                Case 2
                    gridData.Columns(i).Width = 70
                Case 3
                    gridData.Columns(i).Width = 150
                Case Else
                    gridData.Columns(i).Width = 50
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

End Class