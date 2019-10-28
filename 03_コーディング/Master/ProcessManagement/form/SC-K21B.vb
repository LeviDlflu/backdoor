Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_K21B
    Private Sub SC_K21B_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        setGrid()
    End Sub

    Private Sub setGrid()
        GridCtrl.Columns.Clear()
        GridCtrl.AutoResizeColumns()

        GridCtrl.ReadOnly = True
        Dim dt = New DataTable()


        dt.Columns.Add(New DataColumn("工程コード", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("工程略称", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("品名略称", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("払出数量合計", Type.GetType("System.Double")))

        Dim dr As DataRow


        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 2B"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 1B"
        dr.Item(3) = 1
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 2D"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 6C"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 1A"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 3B"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 0B"
        dr.Item(3) = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 6A"
        dr.Item(3) = 100
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = "058 バックドア　ASR WW BOAB 2B"
        dr.Item(3) = 3
        dt.Rows.Add(dr)


        GridCtrl.DataSource = dt.Copy


        GridCtrl.Columns(0).Width = 100
        GridCtrl.Columns(1).Width = 150
        GridCtrl.Columns(2).Width = 250
        GridCtrl.Columns(3).Width = 150

        GridCtrl.Columns(0).HeaderText = "Process code" & vbCrLf & "(工程コード)"
        GridCtrl.Columns(1).HeaderText = "Process abbreviation" & vbCrLf & "(工程略称)"
        GridCtrl.Columns(2).HeaderText = "Product abbreviation" & vbCrLf & "(品名略称)"
        GridCtrl.Columns(3).HeaderText = "Withdrawal count" & vbCrLf & "(払出数量合計)"

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BottomDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    End Sub

    Private Sub GridCtrl_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles GridCtrl.CellPainting
        If e.ColumnIndex < 0 And e.RowIndex >= 0 And e.RowIndex < GridCtrl.Rows.Count - 1 Then
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            Dim indexrect As Drawing.Rectangle = e.CellBounds
            indexrect.Inflate(-2, -2)
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexrect, e.CellStyle.ForeColor, TextFormatFlags.Right)
            e.Handled = True
        End If
    End Sub

    Private Sub Finish_Click(sender As Object, e As EventArgs) Handles Finish.Click

    End Sub
End Class