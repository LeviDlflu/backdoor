Public Class SC_M15
    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_CODE As String = "Code" & vbCrLf & "(コード)"
    Private Const COL_CODE_NAME As String = "Code name" & vbCrLf & "(コード名称)"
    Private Const COL_CODE_DIVISION As String = "Code division" & vbCrLf & "(コード区分)"
    Private Const COL_ITEM1 As String = "Item 1" & vbCrLf & "(項目１)"
    Private Const COL_ITEM2 As String = "Item 2" & vbCrLf & "(項目２)"
    Private Const COL_ITEM3 As String = "Item 3" & vbCrLf & "(項目３)"
    Private Const COL_ITEM4 As String = "Item 4" & vbCrLf & "(項目４)"
    Private Const COL_ITEM5 As String = "Item 5" & vbCrLf & "(項目５)"
    Private Const COL_REMARKS As String = "Remarks" & vbCrLf & "(備考)"
    Private Sub Init()
        'Me.txtDivision.Text = String.Empty
        'Me.txtCode.Text = String.Empty
        'Me.txtCodeName.Text = String.Empty
        'Me.txtItem1.Text = String.Empty
        'Me.txtItem2.Text = String.Empty
        'Me.txtItem3.Text = String.Empty
        'Me.txtItem4.Text = String.Empty
        'Me.txtItem5.Text = String.Empty
        'Me.cmbDivision.SelectedIndex = -1

        'Dim dt As New DataTable

        'dt.Columns.Add("コード区分")
        'dt.Columns.Add("コード")
        'dt.Columns.Add("コード名称")
        'dt.Columns.Add("項目１")
        'dt.Columns.Add("項目２")
        'dt.Columns.Add("項目３")
        'dt.Columns.Add("項目４")
        'dt.Columns.Add("項目５")

        'Dim dr As DataRow

        'dr = dt.NewRow()
        'dr.Item("コード区分") = "000"
        'dr.Item("コード") = "000"
        'dr.Item("コード名称") = "コントロール情報"
        'dr.Item("項目１") = "000"
        'dr.Item("項目３") = "コントロール情報"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "000"
        'dr.Item("コード") = "001"
        'dr.Item("コード名称") = "社内支給先コード"
        'dr.Item("項目１") = "000"
        'dr.Item("項目３") = "社内関係情報"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "001"
        'dr.Item("コード") = "1"
        'dr.Item("コード名称") = "品証"
        'dr.Item("項目１") = "001"
        'dr.Item("項目３") = "分類"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "001"
        'dr.Item("コード") = "2"
        'dr.Item("コード名称") = "設計"
        'dr.Item("項目１") = "001"
        'dr.Item("項目３") = "分類"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "003"
        'dr.Item("コード") = "KG"
        'dr.Item("コード名称") = "㎏"
        'dr.Item("項目１") = "003"
        'dr.Item("項目３") = "単位"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "003"
        'dr.Item("コード") = "ﾏｲ"
        'dr.Item("コード名称") = "枚"
        'dr.Item("項目１") = "003"
        'dr.Item("項目３") = "単位"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("コード区分") = "005"
        'dr.Item("コード") = "A06"
        'dr.Item("コード名称") = "日産九州工場1"
        'dr.Item("項目１") = "005"
        'dr.Item("項目３") = "日産九州工場"
        'dt.Rows.Add(dr)

        'gridData.DataSource = dt
        'gridData.Columns.Item(0).ReadOnly = True
        ''gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(0).HeaderText = "Code division" & vbCrLf & "(コード区分)"
        'gridData.Columns.Item(0).Width = 200
        'gridData.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'gridData.Columns.Item(1).ReadOnly = True
        ''gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(1).HeaderText = "Code" & vbCrLf & "(コード)"
        'gridData.Columns.Item(1).Width = 200
        'gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'gridData.Columns.Item(2).ReadOnly = True
        ''gridData.Columns.Item(2).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(2).HeaderText = "Code name" & vbCrLf & "(コード名称)"
        'gridData.Columns.Item(2).Width = 350


        'gridData.Columns.Item(3).ReadOnly = True
        ''gridData.Columns.Item(3).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(3).HeaderText = "Item1" & vbCrLf & "(項目１)"


        'gridData.Columns.Item(4).ReadOnly = True
        ''gridData.Columns.Item(4).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(4).HeaderText = "Item2" & vbCrLf & "(項目２)"


        'gridData.Columns.Item(5).ReadOnly = True
        ''gridData.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(5).HeaderText = "Item3" & vbCrLf & "(項目３)"


        'gridData.Columns.Item(6).ReadOnly = True
        ''gridData.Columns.Item(6).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(6).HeaderText = "Item4" & vbCrLf & "(項目４)"


        'gridData.Columns.Item(7).ReadOnly = True
        ''gridData.Columns.Item(7).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(7).HeaderText = "Item5" & vbCrLf & "(項目５)"
        ''gridData.AutoResizeColumns()

        'gridData.Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(4).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(5).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(6).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(7).SortMode = DataGridViewColumnSortMode.NotSortable

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

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
        TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

    Private Sub SC_M15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        If gridData.Rows.Count > 0 Then
            'gridData.Rows.Clear()
            gridData.Columns.Clear()
        End If
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_SENTAKU Then
                Dim addCol As New DataGridViewCheckBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = "sentaku"
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = col.ColumnName
                gridData.Columns.Add(addCol)
            End If
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_CODE
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select

        Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case "sentaku"
                    col.ReadOnly = False
                    col.DefaultCellStyle.BackColor = Color.LightSkyBlue
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 200
        gridData.Columns(2).Width = 200
        gridData.Columns(3).Width = 350
        gridData.Columns(4).Width = 300
        gridData.Columns(5).Width = 300
        gridData.Columns(6).Width = 300

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CODE_NAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CODE_DIVISION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ITEM1, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ITEM2, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ITEM3, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ITEM4, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ITEM5, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REMARKS, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_CODE) = "A01"
                    addRow(COL_CODE_NAME) = "B01"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                Case 1
                    addRow(COL_CODE) = "A02"
                    addRow(COL_CODE_NAME) = "B02"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                Case 2
                    addRow(COL_CODE) = "A02"
                    addRow(COL_CODE_NAME) = "B02"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                Case 3
                    addRow(COL_CODE) = "A03"
                    addRow(COL_CODE_NAME) = "B03"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                Case 4
                    addRow(COL_CODE) = "A04"
                    addRow(COL_CODE_NAME) = "B04"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                Case 5
                    addRow(COL_CODE) = "A05"
                    addRow(COL_CODE_NAME) = "B05"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"
                    addRow(COL_REMARKS) = "落下"
                Case 6
                    addRow(COL_CODE) = "A06"
                    addRow(COL_CODE_NAME) = "B06"
                    addRow(COL_CODE_DIVISION) = "日本"
                    addRow(COL_ITEM1) = "テスト１"
                    addRow(COL_ITEM2) = "テスト２"
                    addRow(COL_ITEM3) = "テスト３"
                    addRow(COL_ITEM4) = "テスト４"
                    addRow(COL_ITEM5) = "テスト５"
                    addRow(COL_REMARKS) = "備考欄テスト"

            End Select
            dt.Rows.Add(addRow)
        Next

        Return dt

    End Function

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then
                For i As Integer = 1 To 9
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 1 To 9
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class