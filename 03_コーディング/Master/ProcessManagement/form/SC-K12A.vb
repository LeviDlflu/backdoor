Public Class SC_K12A
    Dim headerName As Hashtable = New Hashtable From {
                             {"個体NO", "Individual NO" & vbCrLf & "(個体NO)"},
                             {"数量", "Count" & vbCrLf & "(数量)"},
                             {"日付・時間", "Date・Time" & vbCrLf & "(日付・時間)"},
                             {"詳細情報", "Detail information" & vbCrLf & "(詳細情報)"}
                            }
    Private Const COL_INDIVIDUAL_NO As String = "個体NO"
    Private Const COL_COUNT As String = "数量"
    Private Const COL_DATETIME As String = "日付・時間"
    Private Const COL_DETAIL_INFORMATION As String = "詳細情報"

    Private Const FORM_NAME As String = "Progress details(進捗管理詳細)"
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
        dt.Columns.Add(New DataColumn(COL_INDIVIDUAL_NO, GetType(System.Int16)))
        dt.Columns.Add(New DataColumn(COL_COUNT, GetType(System.Int16)))
        dt.Columns.Add(New DataColumn(COL_DATETIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DETAIL_INFORMATION, GetType(System.String)))

        Dim dr As DataRow

        For index = 1 To 5
            dr = dt.NewRow()
            dr.Item(COL_INDIVIDUAL_NO) = index
            dr.Item(COL_COUNT) = index
            dr.Item(COL_DATETIME) = Format(Now, "yyyy/MM/dd hh:mm")
            dr.Item(COL_DETAIL_INFORMATION) = COL_DETAIL_INFORMATION & index
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
                Case COL_INDIVIDUAL_NO
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_COUNT
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
        gridData.Columns(1).Width = 80
        gridData.Columns(2).Width = 120
        gridData.Columns(3).Width = 200


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
        Label67.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label67.BackColor = Color.SkyBlue
    End Sub


    Private Sub SC_K12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME
    End Sub

    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click

    End Sub

    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click

    End Sub
End Class