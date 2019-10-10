Public Class SC_M13
    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_PROCESS_CODE As String = "Process code" & vbCrLf & "(工程コード)"
    Private Const COL_DEFECT_CODE As String = "Defect code" & vbCrLf & "(不良コード)"
    Private Const COL_DEFECT_PHENOMENON_NAME As String = "Defect phenomenon name" & vbCrLf & "(不良現象名)"

    Private Sub Init()
        Me.txtDefect.Text = String.Empty
        Me.txtDefectName.Text = String.Empty
        'Me.cmbHinsyu.SelectedIndex = -1

        'Dim dt As New DataTable

        'dt.Columns.Add("工程コード")
        'dt.Columns.Add("不良コード")
        'dt.Columns.Add("不良現象名")

        'Dim dr As DataRow

        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "11"
        'dr.Item("不良現象名") = "落下"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "12"
        'dr.Item("不良現象名") = "キズ"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "25"
        'dr.Item("不良現象名") = "凹凸"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "30"
        'dr.Item("不良現象名") = "溶着不良"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "40"
        'dr.Item("不良現象名") = "生地不良(ゲット)"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "42"
        'dr.Item("不良現象名") = "変形"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr.Item("工程コード") = "FAS"
        'dr.Item("不良コード") = "47"
        'dr.Item("不良現象名") = "クラック"
        'dt.Rows.Add(dr)

        'gridData.DataSource = dt
        'gridData.Columns.Item(0).ReadOnly = True
        'gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(0).HeaderText = "Process code" & vbCrLf & "(工程コード)"
        'gridData.Columns.Item(0).Width = 200
        'gridData.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'gridData.Columns.Item(1).ReadOnly = True
        ''gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(1).HeaderText = "Defect code" & vbCrLf & "(不良コード)"
        'gridData.Columns.Item(1).Width = 200
        'gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'gridData.Columns.Item(2).ReadOnly = True
        ''gridData.Columns.Item(2).DefaultCellStyle.BackColor = Color.LightGray
        'gridData.Columns.Item(2).HeaderText = "Defect phenomenon name" & vbCrLf & "(不良現象名)"
        'gridData.Columns.Item(2).Width = 400
        ''gridData.AutoResizeColumns()

        'gridData.Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        'gridData.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable

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
    Private Sub SC_M13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Case COL_PROCESS_CODE
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
        gridData.Columns(3).Width = 400

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
        dt.Columns.Add(New DataColumn(COL_PROCESS_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECT_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECT_PHENOMENON_NAME, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "11"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "落下"
                Case 1
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "12"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "キズ"
                Case 2
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "25"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "凹凸"
                Case 3
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "30"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "溶着不良"
                Case 4
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "40"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "生地不良(ゲット)"
                Case 5
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "42"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "変形"
                Case 6
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "47"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "クラック"

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
                For i As Integer = 1 To 3
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 1 To 3
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class