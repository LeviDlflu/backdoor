Public Class SC_M11

    Private Sub Init()
        'Me.cmbMode.SelectedIndex = 0
        'Me.txtHinSyuCD.Enabled = False
        'Me.txtHinSyuMei.Enabled = False
        Me.txtHinSyuCD.Text = String.Empty
        Me.txtHinSyuMei.Text = String.Empty
        Me.txtRemartks.Text = String.Empty
        Me.cmbHinsyu.SelectedIndex = -1

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("Select" & vbCrLf & "(選択)", GetType(System.Boolean)))
        dt.Columns.Add("品種コード")
        dt.Columns.Add("品種名")
        dt.Columns.Add("備考")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item("品種コード") = "01"
        dr.Item("品種名") = "Mバックドア"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "02"
        dr.Item("品種名") = "バックドア　RSM"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "03"
        dr.Item("品種名") = "インパネ"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "04"
        dr.Item("品種名") = "コンソール・ポケット"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "05"
        dr.Item("品種名") = "ドアトリム"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "06"
        dr.Item("品種名") = "バンパーモール"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("品種コード") = "07"
        dr.Item("品種名") = "FINバックドア"
        dt.Rows.Add(dr)

        gridData.DataSource = dt

        gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightSkyBlue

        gridData.Columns.Item(1).ReadOnly = True
        'gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(1).HeaderText = "Variety" & vbCrLf & "(品種コード)"
        'gridData.Columns.Item(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns.Item(1).Width = 100
        gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns.Item(2).ReadOnly = True
        'gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(2).HeaderText = "Variety name" & vbCrLf & "(品種名)"
        'gridData.Columns.Item(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns.Item(2).Width = 400

        gridData.Columns.Item(3).ReadOnly = True
        gridData.Columns.Item(3).HeaderText = "Remarks" & vbCrLf & "(備考)"
        gridData.Columns.Item(3).Width = 200
        'gridData.AutoResizeColumns()

        gridData.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

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
        TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

    Private Sub SC_M11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub
End Class