Imports System.Text
Imports System.Data
Imports System.Data.SqlClient


Public Class SC_K21C
    Private Sub SC_K21C_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub

    Private Sub init()
        Me.Target_date.Enabled = True
        Me.Withdrawal_category.Enabled = True
        Me.Finish.Enabled = True

        Me.Target_date.Value = Date.Today()
        Me.Withdrawal_category.Text = String.Empty

        Timer1.Interval = 10
        Timer1.Start()

        Me.SearchDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")

        setGrid()
    End Sub

    Private Sub setGrid()
        GridCtrl.Columns.Clear()
        GridCtrl.AutoResizeColumns()


        GridCtrl.ReadOnly = True
        Dim dt = New DataTable()

        dt.Columns.Add(New DataColumn("工程コード", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("工程略称", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("品種", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("払出数量合計", Type.GetType("System.Double")))

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "P32R"
        dr.Item(3) = 61
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "KAS"
        dr.Item(1) = "モ 組立"
        dr.Item(2) = "J32U"
        dr.Item(3) = 29
        dt.Rows.Add(dr)

        GridCtrl.DataSource = dt.Copy

        GridCtrl.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        GridCtrl.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCtrl.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        GridCtrl.Columns(0).Width = 100
        GridCtrl.Columns(1).Width = 200
        GridCtrl.Columns(2).Width = 200
        GridCtrl.Columns(3).Width = 200

        GridCtrl.Columns(0).HeaderText = "Process code" & vbCrLf & "(工程コード)"
        GridCtrl.Columns(1).HeaderText = "Process abbreviation" & vbCrLf & "(工程略称)"
        GridCtrl.Columns(2).HeaderText = "Variety" & vbCrLf & "(品種)"
        GridCtrl.Columns(3).HeaderText = "Withdrawal count" & vbCrLf & "(払出数量合計)"

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BottomDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    End Sub

    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles GridCtrl.RowPostPaint
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

    Private Sub Finish_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Finish_Click_1(sender As Object, e As EventArgs) Handles Finish.Click

    End Sub
End Class