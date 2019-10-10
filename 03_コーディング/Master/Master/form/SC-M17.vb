Public Class SC_M17
    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_NAME_CODE As String = "Name code" & vbCrLf & "(氏名コード)"
    Private Const COL_FULL_NAME As String = "Full name" & vbCrLf & "(氏名)"
    Private Const COL_REMARKS As String = "Remarks" & vbCrLf & "(備考)"
    Private Const GAMEN_SC_M17 As String = "SC-M17"

    Private Sub Init()

        Me.txtName.Text = String.Empty
        Me.txtFullNM.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M17_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated
        Init()
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
                Case COL_FULL_NAME, COL_REMARKS
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
        gridData.Columns(1).Width = 120
        gridData.Columns(2).Width = 400
        gridData.Columns(3).Width = 620

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
        dt.Columns.Add(New DataColumn(COL_NAME_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FULL_NAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REMARKS, GetType(System.String)))

        For i As Integer = 0 To 9
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "森田森田森田森田森,森田森田森田森田森,森田森田森田森田森田"
                    addRow(COL_REMARKS) = "成田建築基準法電波障成田建築基準法電波障成田建築基準法電波障成田建築基準法電波障成田建築基準法電波障"
                Case 1
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "佐々木"
                    addRow(COL_REMARKS) = "備考なし"
                Case 2
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "市野"
                    addRow(COL_REMARKS) = "東京営業所"
                Case 3
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "笹森"
                    addRow(COL_REMARKS) = "新宿出張所"
                Case 4
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "早川"
                    addRow(COL_REMARKS) = "渋谷営業所"
                Case 5
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "渡辺"
                    addRow(COL_REMARKS) = "備考なし"
                Case 6
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "山辺"
                    addRow(COL_REMARKS) = "備考なし"
                Case 7
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "森永"
                    addRow(COL_REMARKS) = "大崎建築"
                Case 8
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "明治"
                    addRow(COL_REMARKS) = "品川入力装置"
                Case 9
                    addRow(COL_NAME_CODE) = "E10" + i.ToString
                    addRow(COL_FULL_NAME) = "令和"
                    addRow(COL_REMARKS) = "日立製作所"
            End Select
            dt.Rows.Add(addRow)
        Next

        Return dt

    End Function

    ''' <summary>
    ''' 　・行ヘッダーに行番号書き込み
    ''' </summary>
    Private Sub gridData_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles gridData.CellPainting

        '/// 行番号 ///
        '列ヘッダーかどうか調べる
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)

            '行番号を描画する
            TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.CellStyle.Font,
                indexRect,
                e.CellStyle.ForeColor,
                TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画が完了したことを知らせる
            e.Handled = True
        End If

    End Sub


    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbYesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 2 To 3
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To 3
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class