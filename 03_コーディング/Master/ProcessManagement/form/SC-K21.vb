Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_K21

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"受払年月日", "Payment date" & vbCrLf & "(受払年月日)"},
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"工程略称", "Process abbreviation" & vbCrLf & "(工程略称)"},
                             {"個体ＮＯ", "Lot No" & vbCrLf & "(個体ＮＯ)"},
                             {"品名略称", "Product name abbreviation" & vbCrLf & "(品名略称)"},
                             {"払出数量", "Issued quantity" & vbCrLf & "(払出数量)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_PAYMENT_DATE As String = "受払年月日"
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_PROCESS_ABBREVIATION As String = "工程略称"
    Private Const COL_LOT_NO As String = "個体ＮＯ"
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_ISSUED_QUANTITY As String = "払出数量"
    Private Const COL_REMARKS As String = "備考"

    Private Sub SC_K21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
        addColSentaku.HeaderText = headerName(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        GridCtrl.Columns.Add(addColSentaku)

        GridCtrl.ReadOnly = True
        Dim dt = New DataTable()

        dt.Columns.Add(New DataColumn(headerName(COL_PAYMENT_DATE), Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(headerName(COL_PROCESS_CODE), Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(headerName(COL_PROCESS_ABBREVIATION), Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(headerName(COL_LOT_NO), Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(headerName(COL_PRODUCT_NAME_ABBREVIATION), Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn(headerName(COL_ISSUED_QUANTITY), Type.GetType("System.Double")))
        dt.Columns.Add(New DataColumn(headerName(COL_REMARKS), Type.GetType("System.String")))

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item(0) = "JAS"
        dr.Item(1) = "JAS 組立"
        dr.Item(2) = 61
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr.Item(0) = "KAS"
        dr.Item(1) = "モ 組立"
        dr.Item(2) = 29
        dt.Rows.Add(dr)

        GridCtrl.DataSource = dt.Copy

        GridCtrl.Columns(0).Width = 50
        GridCtrl.Columns(1).Width = 100
        GridCtrl.Columns(2).Width = 150
        GridCtrl.Columns(3).Width = 150
        GridCtrl.Columns(4).Width = 150
        GridCtrl.Columns(5).Width = 250
        GridCtrl.Columns(6).Width = 150
        GridCtrl.Columns(7).Width = 300

        GridCtrl.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        GridCtrl.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCtrl.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        GridCtrl.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCtrl.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GridCtrl.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        GridCtrl.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        GridCtrl.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        GridCtrl.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Total_by_process.Click

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BottomDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub
End Class