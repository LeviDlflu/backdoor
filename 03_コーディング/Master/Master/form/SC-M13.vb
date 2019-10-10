Public Class SC_M13
    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_PROCESS_CODE As String = "Process code" & vbCrLf & "(工程コード)"
    Private Const COL_DEFECT_CODE As String = "Defect code" & vbCrLf & "(不良コード)"
    Private Const COL_DEFECT_PHENOMENON_NAME As String = "Defect phenomenon name" & vbCrLf & "(不良現象名)"
    Private Const COL_REMARKS As String = "Remarks" & vbCrLf & "(備考)"
    Private Const COL_DISPLAY_DIVISION As String = "Display division" & vbCrLf & "(表示区分)"

    Private Sub Init()
        Me.txtDefect.Text = String.Empty
        Me.txtDefectName.Text = String.Empty

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
        TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)
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
            ElseIf col.ColumnName = COL_DISPLAY_DIVISION Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = col.ColumnName
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
                Case COL_DEFECT_PHENOMENON_NAME, COL_REMARKS
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
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_PROCESS_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECT_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DEFECT_PHENOMENON_NAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REMARKS, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DISPLAY_DIVISION, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "11"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "落下"
                    addRow(COL_REMARKS) = "製造工場"
                Case 1
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "12"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "キズ"
                    addRow(COL_REMARKS) = "製造工場"
                Case 2
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "25"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "凹凸"
                    addRow(COL_REMARKS) = "製造工場"
                Case 3
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "30"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "溶着不良"
                    addRow(COL_REMARKS) = "製造工場"
                Case 4
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "40"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "生地不良(ゲット)"
                    addRow(COL_REMARKS) = "製造工場"
                Case 5
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "42"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "変形"
                    addRow(COL_REMARKS) = "製造工場"
                Case 6
                    addRow(COL_PROCESS_CODE) = "FAS"
                    addRow(COL_DEFECT_CODE) = "47"
                    addRow(COL_DEFECT_PHENOMENON_NAME) = "クラック"
                    addRow(COL_REMARKS) = "製造工場"

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
                For i As Integer = 1 To 5
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 1 To 5
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class