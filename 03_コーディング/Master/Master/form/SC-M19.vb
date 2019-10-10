Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class SC_M19
    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_PROCESS_CODE As String = "Process code" & vbCrLf & "(工程コード)"
    Private Const COL_DIVISION As String = "Division" & vbCrLf & "(区分)"
    Private Const COL_LINE_DIVISION As String = "Line Division" & vbCrLf & "(ライン区分)"
    Private Const COL_BREAK_START_TIME As String = "Break start time" & vbCrLf & "(休憩開始時間)"
    Private Const COL_BREAK_END_TIME As String = "Break end time" & vbCrLf & "(休憩終了時間)"
    Private Const COL_DATE_CHANGE_INDICATOR As String = "Date change indicator" & vbCrLf & "(日付変更区分)"

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())

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


    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbKoutei.Text = String.Empty
        Me.cmbKubun.Text = String.Empty
        Me.cmbLine.Text = String.Empty
        Me.txtStart.Text = String.Empty
        Me.txtEnd.Text = String.Empty
        Me.cmbHenkou.Text = String.Empty
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")


    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridData.Columns.Clear()

        Label12.Visible = False
        Label20.Visible = False
        gridData.Visible = False

    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
            Me.Close()
        End If

    End Sub

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
            ElseIf col.ColumnName = COL_DATE_CHANGE_INDICATOR Then
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
                Case COL_DIVISION, COL_LINE_DIVISION
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
        gridData.Columns(1).Width = 125
        gridData.Columns(2).Width = 90
        gridData.Columns(3).Width = 90
        gridData.Columns(4).Width = 110
        gridData.Columns(5).Width = 110
        gridData.Columns(6).Width = 200

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
        dt.Columns.Add(New DataColumn(COL_DIVISION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_LINE_DIVISION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_BREAK_START_TIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_BREAK_END_TIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DATE_CHANGE_INDICATOR, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 1
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 2
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 3
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 4
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 5
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"
                Case 6
                    addRow(COL_PROCESS_CODE) = "P2001"
                    addRow(COL_DIVISION) = "C01"
                    addRow(COL_LINE_DIVISION) = "落下"
                    addRow(COL_BREAK_START_TIME) = "09:00"
                    addRow(COL_BREAK_END_TIME) = "18:00"

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

                For i As Integer = 2 To 6
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To 6
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class