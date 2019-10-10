Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class SC_M19

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim cn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As DataTable

        Dim cnStr As String = "Data Source=WIN-CPGPKU87FDV;Initial Catalog=BackDoor;user id=backdooruser;password=pass@word2;"

        Dim sqlstr As New StringBuilder

        sqlstr.Append("select ")
        sqlstr.Append("工程コード+':'+工程略称")
        sqlstr.Append(",ラインロット区分-1")
        sqlstr.Append(",ラインロット区分")
        sqlstr.Append(",'12:00'")
        sqlstr.Append(",'14:00'")
        sqlstr.Append(",120")
        sqlstr.Append(",ラインロット区分+1 ")
        sqlstr.Append("from 工程マスタ")

        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter(sqlstr.ToString, cn)
        dt = New DataTable()

        da.Fill(dt)
        gridData.DataSource = dt

        gridData.Columns(0).HeaderText = "Process code" & vbCrLf & "(工程コード)"
        gridData.Columns(1).HeaderText = "Division" & vbCrLf & "(区分)"
        gridData.Columns(2).HeaderText = "Line Division" & vbCrLf & "(ライン区分)"
        gridData.Columns(3).HeaderText = "Break start time" & vbCrLf & "(休憩開始時間)"
        gridData.Columns(4).HeaderText = "Break end time" & vbCrLf & "(休憩終了時間)"
        gridData.Columns(5).HeaderText = "Break time" & vbCrLf & "(休憩時間)"
        gridData.Columns(6).HeaderText = "Date change indicator" & vbCrLf & "(日付変更区分)"

        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim ii As Integer
        For ii = 0 To gridData.Columns.Count - 1
            gridData.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable
            gridData.Columns(ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        gridData.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridData.Columns(0).Width = 125
        gridData.Columns(1).Width = 90
        gridData.Columns(2).Width = 90
        gridData.Columns(3).Width = 110
        gridData.Columns(4).Width = 110
        gridData.Columns(5).Width = 100
        gridData.Columns(6).Width = 130

        Label12.Visible = True
        Label20.Visible = True
        gridData.Visible = True

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


    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbKoutei.Enabled = False
        cmbKubun.Enabled = False
        cmbLine.Enabled = False
        txtStart.Enabled = False
        txtEnd.Enabled = False
        cmbHenkou.Enabled = False

        Label12.Visible = False
        Label20.Visible = False
        gridData.Visible = False

    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged

        Select Case cmbMode.Text
            Case "参照"
                cmbKoutei.Enabled = False
                cmbKubun.Enabled = False
                cmbLine.Enabled = False
                txtStart.Enabled = False
                txtEnd.Enabled = False
                cmbHenkou.Enabled = False
            Case "追加"
                cmbKoutei.Enabled = True
                cmbKubun.Enabled = True
                cmbLine.Enabled = True
                txtStart.Enabled = True
                txtEnd.Enabled = True
                cmbHenkou.Enabled = True
            Case "修正"
                cmbKoutei.Enabled = False
                cmbKubun.Enabled = False
                cmbLine.Enabled = False
                txtStart.Enabled = False
                txtEnd.Enabled = False
                cmbHenkou.Enabled = False
            Case "削除"
                cmbKoutei.Enabled = False
                cmbKubun.Enabled = False
                cmbLine.Enabled = False
                txtStart.Enabled = False
                txtEnd.Enabled = False
                cmbHenkou.Enabled = False

        End Select

        If cmbMode.Text = "" Then

        End If
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
End Class