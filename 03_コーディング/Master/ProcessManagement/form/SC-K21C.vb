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
        Me.Print.Enabled = True
        Me.Back.Enabled = True

        Me.Target_date.Value = Date.Today()
        Me.Withdrawal_category.Text = String.Empty

        Timer1.Interval = 10
        Timer1.Start()

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

        GridCtrl.Columns(0).Width = 60
        GridCtrl.Columns(1).Width = 100
        GridCtrl.Columns(2).Width = 100
        GridCtrl.Columns(3).Width = 200

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BottomDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    End Sub

    Private Sub GridCtrl_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles GridCtrl.CellPainting
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            Dim indexrect As Drawing.Rectangle = e.CellBounds
            indexrect.Inflate(-2, -2)
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexrect, e.CellStyle.ForeColor, TextFormatFlags.Right)
            e.Handled = True
        End If
    End Sub
End Class