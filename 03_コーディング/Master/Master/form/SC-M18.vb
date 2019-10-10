Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class SC_M18

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If gridData.Rows.Count > 0 Then
            gridData.Columns.Clear()
        End If

        Dim cn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As DataTable

        'Dim cnStr As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;integrated security=true;"
        Dim cnStr As String = "Data Source=WIN-CPGPKU87FDV;Initial Catalog=BackDoor;user id=backdooruser;password=pass@word2;"

        'Dim Str As New StringBuilder
        'Str.Append("select * from Ｍ＿作業計画データ")
        Dim Str As String
        Str = "select * from 作業計画"
        Str = "select * from 作業計画"


        Dim sqlstr As New StringBuilder

        sqlstr.Append("select")
        sqlstr.Append("'001' as 区分")
        sqlstr.Append(",'区分' as 区分名")
        sqlstr.Append(",'abc0001' as 品名コード")
        sqlstr.Append(",'備考' as 備考")
        sqlstr.Append(",cast(品名コード as int) as 設定コード")
        sqlstr.Append(",'設定コード' as 設定コード名")
        sqlstr.Append(",trim(cast(作番 as varchar)) as 設定コード２")
        sqlstr.Append(",'設定コード２' as 設定コード名２")
        sqlstr.Append(",trim(cast((作番 + 1) as varchar)) as 設定コード３")
        sqlstr.Append(",'設定コード３' as 設定コード名３")
        sqlstr.Append(",'11' as 設定コード４")
        sqlstr.Append(",'設定コード４' as 設定コード名４")
        sqlstr.Append(",'作業時間：' + cast(作業年月日 as varchar) as 備考２")
        sqlstr.Append(" from 実績管理データ")
        sqlstr.Append(" order by 5")

        cn = New SqlConnection(cnStr)

        Dim addCol As New DataGridViewCheckBoxColumn()
        addCol.DataPropertyName = "Select" & vbCrLf & "(選択)"
        addCol.HeaderText = "Select" & vbCrLf & "(選択)"
        addCol.Name = "sentaku"
        gridData.Columns.Add(addCol)


        da = New SqlDataAdapter(sqlstr.ToString, cn)
        dt = New DataTable()


        da.Fill(dt)
        gridData.DataSource = dt


        gridData.Columns(1).HeaderText = "Division" & vbCrLf & "(区分)"
        gridData.Columns(2).HeaderText = "Division name" & vbCrLf & "(区分名)"
        gridData.Columns(3).HeaderText = "Product code" & vbCrLf & "(品名コード)"
        gridData.Columns(4).HeaderText = "Remarks" & vbCrLf & "(備考)"
        gridData.Columns(5).HeaderText = "Setting code" & vbCrLf & "(設定コード)"
        gridData.Columns(6).HeaderText = "Setting name" & vbCrLf & "(設定コード名)"
        gridData.Columns(7).HeaderText = "Setting code2" & vbCrLf & "(設定コード２)"
        gridData.Columns(8).HeaderText = "Setting name2" & vbCrLf & "(設定コード名２)"
        gridData.Columns(9).HeaderText = "Setting code3" & vbCrLf & "(設定コード３)"
        gridData.Columns(10).HeaderText = "Setting name3" & vbCrLf & "(設定コード名３)"
        gridData.Columns(11).HeaderText = "Setting code4" & vbCrLf & "(設定コード４)"
        gridData.Columns(12).HeaderText = "Setting name4" & vbCrLf & "(設定コード名４)"
        gridData.Columns(13).HeaderText = "Remarks2" & vbCrLf & "(備考２)"

        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim ii As Integer
        For ii = 0 To gridData.Columns.Count - 1
            gridData.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case "sentaku"
                    col.ReadOnly = False
                    col.DefaultCellStyle.BackColor = Color.LightSkyBlue
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 55
        gridData.Columns(2).Width = 90
        gridData.Columns(3).Width = 80
        gridData.Columns(4).Width = 120
        gridData.Columns(5).Width = 82
        gridData.Columns(6).Width = 110
        gridData.Columns(7).Width = 82
        gridData.Columns(8).Width = 110
        gridData.Columns(9).Width = 82
        gridData.Columns(10).Width = 110
        gridData.Columns(11).Width = 82
        gridData.Columns(12).Width = 110
        gridData.Columns(13).Width = 120

        '複数選択不可
        'gridData.MultiSelect = False
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
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M18_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridData.Columns.Clear()

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
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 5 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 5 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

End Class