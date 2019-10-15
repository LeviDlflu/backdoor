
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class SC_M10

    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_SCODE As String = "Facility NO" & vbCrLf & "(設備NO)"
    Private Const COL_SNAME As String = "Facility abbreviation" & vbCrLf & "(設備略称)"
    Private Const COL_HKOUTEI As String = "Standard passing process code" & vbCrLf & "(標準通過工程コード)"
    Private Const COL_LINE As String = "Line Code" & vbCrLf & "(ラインコード)"
    Private Const COL_KOUTEI As String = "Process code" & vbCrLf & "(工程コード)"
    Private Const COL_ORDER As String = "Display order" & vbCrLf & "(表示順序)"
    Private Const COL_LABEL As String = "Auto label flag" & vbCrLf & "(自動ラベルフラグ)"
    Private Const COL_BIKOU As String = "Remarks" & vbCrLf & "(備考)"

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_SCODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SNAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_HKOUTEI, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_LINE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_KOUTEI, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ORDER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_LABEL, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_BIKOU, GetType(System.String)))

        For i As Integer = 0 To 4
            Dim addRow As DataRow = dt.NewRow

            Select Case i
                Case 0
                    addRow(COL_SCODE) = "M001"
                    addRow(COL_SNAME) = "射出００１"
                    addRow(COL_HKOUTEI) = "smd"
                    addRow(COL_LINE) = "1"
                    addRow(COL_KOUTEI) = "2B"
                    addRow(COL_ORDER) = "1"
                    addRow(COL_LABEL) = "０：手動ラベル"
                    addRow(COL_BIKOU) = "備考"
                Case 1
                    addRow(COL_SCODE) = "M002"
                    addRow(COL_SNAME) = "射出００２"
                    addRow(COL_HKOUTEI) = "smd"
                    addRow(COL_LINE) = "1"
                    addRow(COL_KOUTEI) = "2B"
                    addRow(COL_ORDER) = "2"
                    addRow(COL_LABEL) = "０：手動ラベル"
                    addRow(COL_BIKOU) = "備考"
                Case 2
                    addRow(COL_SCODE) = "M003"
                    addRow(COL_SNAME) = "射出００３"
                    addRow(COL_HKOUTEI) = "smd"
                    addRow(COL_LINE) = "1"
                    addRow(COL_KOUTEI) = "2B"
                    addRow(COL_ORDER) = "3"
                    addRow(COL_LABEL) = "０：手動ラベル"
                    addRow(COL_BIKOU) = "備考"
                Case 3
                    addRow(COL_SCODE) = "M004"
                    addRow(COL_SNAME) = "射出００4"
                    addRow(COL_HKOUTEI) = "smd"
                    addRow(COL_LINE) = "1"
                    addRow(COL_KOUTEI) = "2B"
                    addRow(COL_ORDER) = "4"
                    addRow(COL_LABEL) = "０：手動ラベル"
                    addRow(COL_BIKOU) = "備考"
                Case 4
                    addRow(COL_SCODE) = "M005"
                    addRow(COL_SNAME) = "射出００５"
                    addRow(COL_HKOUTEI) = "smd"
                    addRow(COL_LINE) = "1"
                    addRow(COL_KOUTEI) = "2B"
                    addRow(COL_ORDER) = "5"
                    addRow(COL_LABEL) = "０：手動ラベル"
                    addRow(COL_BIKOU) = "備考"

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
                Case COL_SNAME, COL_LABEL, COL_BIKOU
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
        gridData.Columns(2).Width = 160
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 110
        gridData.Columns(5).Width = 110
        gridData.Columns(6).Width = 90
        gridData.Columns(7).Width = 120
        gridData.Columns(8).Width = 320

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


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        setGrid(createGridData())

        'Label12.Visible = True
        'Label20.Visible = True
        'gridData.Visible = True

    End Sub

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Label12.Visible = False
        'Label20.Visible = False
        'gridData.Visible = False

    End Sub

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridData.Columns.Clear()

        'Label12.Visible = False
        'Label20.Visible = False
        'gridData.Visible = False

    End Sub



    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
            Me.Close()
        End If

    End Sub


    ''' <summary>
    ''' 　EXCELボタン押下
    ''' </summary>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        MsgBox("グリッドの内容がEXCEL出力される予定です。")
    End Sub


    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 2 To 8
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To 8
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class