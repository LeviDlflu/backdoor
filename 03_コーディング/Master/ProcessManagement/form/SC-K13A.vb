Public Class SC_K13A
    Dim headerName As Hashtable = New Hashtable From {
                             {"個体No", "Individual No" & vbCrLf & "(個体No)"},
                             {"数量", "Quantity" & vbCrLf & "(数量)"},
                             {"日付・時間", "Date / Time" & vbCrLf & "(日付・時間)"},
                             {"不良原因", "Cause of failure" & vbCrLf & "(不良原因)"},
                             {"キャビ", "Caviar" & vbCrLf & "(キャビ)"}
                            }

    Private Const COL_NO_ID As String = "項番"
    Private Const COL_INDIVISUAL_NO As String = "個体No"
    Private Const COL_QUANTITY As String = "数量"
    Private Const COL_DATETIME As String = "日付・時間"
    Private Const COL_CAUSE_FAILURE As String = "不良原因"
    Private Const COL_CAVIAR As String = "キャビ"

    '初期処理
    Private Sub Init()
        srDate.Text = Format(Now, "yyyy/MM/dd HH:mm")

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

    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub SC_K13A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()

    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        'Dim frm As New SC_K13()
        'frm.ShowDialog()
        'Me.Show()
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
                Case COL_INDIVISUAL_NO, COL_CAUSE_FAILURE, COL_CAVIAR
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_QUANTITY
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

        gridData.Columns(0).Width = 100
        gridData.Columns(1).Width = 150
        gridData.Columns(2).Width = 150
        gridData.Columns(3).Width = 400
        gridData.Columns(4).Width = 400

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
        dt.Columns.Add(New DataColumn(COL_INDIVISUAL_NO, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_QUANTITY, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DATETIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CAUSE_FAILURE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CAVIAR, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "1"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 1
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "1"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 2
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "2"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 3
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "11"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 4
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "31"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 5
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "5"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 6
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "7"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"

            End Select
            dt.Rows.Add(addRow)
        Next

        Return dt

    End Function
End Class