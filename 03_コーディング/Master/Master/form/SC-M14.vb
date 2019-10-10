
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class SC_M14

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If gridData.Rows.Count > 0 Then
            gridData.Columns.Clear()
        End If

        Dim cn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As DataTable

        Dim cnStr As String = "Data Source=WIN-CPGPKU87FDV;Initial Catalog=BackDoor;user id=backdooruser;password=pass@word2;"

        Dim sqlstr As New StringBuilder

        sqlstr.Append("select ")
        sqlstr.Append("ＩＰアドレス,")
        sqlstr.Append("case 稼動区分 when 0 then '0:予備' else '1:稼動' end,")
        sqlstr.Append("機種,")
        sqlstr.Append("備考")
        sqlstr.Append(" from Ｍ＿ＩＰアドレス管理マスタ")

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

        gridData.Columns(1).HeaderText = "IP address" & vbCrLf & "(ＩＰアドレス)"
        gridData.Columns(2).HeaderText = "Operation division" & vbCrLf & "(稼働区分)"
        gridData.Columns(3).HeaderText = "Equipment type" & vbCrLf & "(機種)"
        gridData.Columns(4).HeaderText = "Remarks" & vbCrLf & "(備考)"


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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 90
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 160
        gridData.Columns(4).Width = 320

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
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M14_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                For i As Integer = 2 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub


End Class