Public Class SC_M20

    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_WORKING_YM As String = "Working days_YM" & vbCrLf & "(稼働年月)"
    Private Const COL_WORKING_D As String = "Working days_D" & vbCrLf & "(稼働日)"
    Private Const COL_WORKING_YMD As String = "Working days_YMD" & vbCrLf & "(稼働年月日)"
    Private Const COL_DIRECT As String = "Direct division" & vbCrLf & "(直区分)"
    Private Const COL_CATEGORY As String = "Operation category" & vbCrLf & "(稼働区分)"
    Private Const COL_CATEGORY_2 As String = "Operation category2" & vbCrLf & "(稼働区分２)"
    Private Const COL_CATEGORY_3 As String = "Operation category3" & vbCrLf & "(稼働区分３)"

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub tmrClockSec_Tick(sender As Object, e As EventArgs) Handles tmrClockSec.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub SC_M20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初期設定
        'Me.Text = getTitle(GAMEN_SC_M20)
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            setGrid(createGridData())
        Catch ex As Exception
            MsgBox(ex.Message)
            gridData.DataSource = Nothing
        End Try

    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbYesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YM, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_D, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YMD, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY_2, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY_3, GetType(System.String)))

        For i As Integer = 0 To 9
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_WORKING_YM) = "201901"
                    addRow(COL_WORKING_D) = "1"
                    addRow(COL_WORKING_YMD) = "2019/01/01"
                    addRow(COL_DIRECT) = "1"
                Case 1
                    addRow(COL_WORKING_YM) = "201902"
                    addRow(COL_WORKING_D) = "2"
                    addRow(COL_WORKING_YMD) = "2019/02/02"
                    addRow(COL_DIRECT) = "2"
                Case 2
                    addRow(COL_WORKING_YM) = "201903"
                    addRow(COL_WORKING_D) = "3"
                    addRow(COL_WORKING_YMD) = "2019/03/03"
                    addRow(COL_DIRECT) = "3"
                Case 3
                    addRow(COL_WORKING_YM) = "201904"
                    addRow(COL_WORKING_D) = "4"
                    addRow(COL_WORKING_YMD) = "2019/04/04"
                    addRow(COL_DIRECT) = "4"
                Case 4
                    addRow(COL_WORKING_YM) = "201905"
                    addRow(COL_WORKING_D) = "5"
                    addRow(COL_WORKING_YMD) = "2019/05/05"
                    addRow(COL_DIRECT) = "5"
                Case 5
                    addRow(COL_WORKING_YM) = "201906"
                    addRow(COL_WORKING_D) = "6"
                    addRow(COL_WORKING_YMD) = "2019/06/06"
                    addRow(COL_DIRECT) = "1"
                Case 6
                    addRow(COL_WORKING_YM) = "201907"
                    addRow(COL_WORKING_D) = "7"
                    addRow(COL_WORKING_YMD) = "2019/07/07"
                    addRow(COL_DIRECT) = "2"
                Case 7
                    addRow(COL_WORKING_YM) = "201908"
                    addRow(COL_WORKING_D) = "8"
                    addRow(COL_WORKING_YMD) = "2019/08/08"
                    addRow(COL_DIRECT) = "3"
                Case 8
                    addRow(COL_WORKING_YM) = "201909"
                    addRow(COL_WORKING_D) = "9"
                    addRow(COL_WORKING_YMD) = "2019/09/09"
                    addRow(COL_DIRECT) = "4"
                Case 9
                    addRow(COL_WORKING_YM) = "201910"
                    addRow(COL_WORKING_D) = "10"
                    addRow(COL_WORKING_YMD) = "2019/10/10"
                    addRow(COL_DIRECT) = "5"
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
        gridData.Rows.Clear()
        gridData.Columns.Clear()
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_SENTAKU Then
                Dim addCol As New DataGridViewCheckBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = "sentaku"
                gridData.Columns.Add(addCol)
            ElseIf col.ColumnName = COL_CATEGORY Or col.ColumnName = COL_CATEGORY_2 Or col.ColumnName = COL_CATEGORY_3 Then
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
            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
        gridData.Columns(2).Width = 100
        gridData.Columns(3).Width = 120
        gridData.Columns(4).Width = 150
        gridData.Columns(5).Width = 150
        gridData.Columns(6).Width = 150
        gridData.Columns(7).Width = 150


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

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

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 2 To 7
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To 7
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub
End Class