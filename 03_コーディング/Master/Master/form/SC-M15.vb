Public Class SC_M15

    Private Sub Init()
        Me.txtDivision.Text = String.Empty
        Me.txtCode.Text = String.Empty
        Me.txtCodeName.Text = String.Empty
        Me.txtItem1.Text = String.Empty
        Me.txtItem2.Text = String.Empty
        Me.txtItem3.Text = String.Empty
        Me.txtItem4.Text = String.Empty
        Me.txtItem5.Text = String.Empty
        Me.cmbDivision.SelectedIndex = -1

        Dim dt As New DataTable

        dt.Columns.Add("コード区分")
        dt.Columns.Add("コード")
        dt.Columns.Add("コード名称")
        dt.Columns.Add("項目１")
        dt.Columns.Add("項目２")
        dt.Columns.Add("項目３")
        dt.Columns.Add("項目４")
        dt.Columns.Add("項目５")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item("コード区分") = "000"
        dr.Item("コード") = "000"
        dr.Item("コード名称") = "コントロール情報"
        dr.Item("項目１") = "000"
        dr.Item("項目３") = "コントロール情報"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "000"
        dr.Item("コード") = "001"
        dr.Item("コード名称") = "社内支給先コード"
        dr.Item("項目１") = "000"
        dr.Item("項目３") = "社内関係情報"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "001"
        dr.Item("コード") = "1"
        dr.Item("コード名称") = "品証"
        dr.Item("項目１") = "001"
        dr.Item("項目３") = "分類"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "001"
        dr.Item("コード") = "2"
        dr.Item("コード名称") = "設計"
        dr.Item("項目１") = "001"
        dr.Item("項目３") = "分類"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "003"
        dr.Item("コード") = "KG"
        dr.Item("コード名称") = "㎏"
        dr.Item("項目１") = "003"
        dr.Item("項目３") = "単位"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "003"
        dr.Item("コード") = "ﾏｲ"
        dr.Item("コード名称") = "枚"
        dr.Item("項目１") = "003"
        dr.Item("項目３") = "単位"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("コード区分") = "005"
        dr.Item("コード") = "A06"
        dr.Item("コード名称") = "日産九州工場1"
        dr.Item("項目１") = "005"
        dr.Item("項目３") = "日産九州工場"
        dt.Rows.Add(dr)

        gridData.DataSource = dt
        gridData.Columns.Item(0).ReadOnly = True
        'gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(0).HeaderText = "Code division" & vbCrLf & "(コード区分)"
        gridData.Columns.Item(0).Width = 200
        gridData.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns.Item(1).ReadOnly = True
        'gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(1).HeaderText = "Code" & vbCrLf & "(コード)"
        gridData.Columns.Item(1).Width = 200
        gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns.Item(2).ReadOnly = True
        'gridData.Columns.Item(2).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(2).HeaderText = "Code name" & vbCrLf & "(コード名称)"
        gridData.Columns.Item(2).Width = 350


        gridData.Columns.Item(3).ReadOnly = True
        'gridData.Columns.Item(3).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(3).HeaderText = "Item1" & vbCrLf & "(項目１)"


        gridData.Columns.Item(4).ReadOnly = True
        'gridData.Columns.Item(4).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(4).HeaderText = "Item2" & vbCrLf & "(項目２)"


        gridData.Columns.Item(5).ReadOnly = True
        'gridData.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(5).HeaderText = "Item3" & vbCrLf & "(項目３)"


        gridData.Columns.Item(6).ReadOnly = True
        'gridData.Columns.Item(6).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(6).HeaderText = "Item4" & vbCrLf & "(項目４)"


        gridData.Columns.Item(7).ReadOnly = True
        'gridData.Columns.Item(7).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(7).HeaderText = "Item5" & vbCrLf & "(項目５)"
        'gridData.AutoResizeColumns()

        gridData.Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(4).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(5).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(6).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(7).SortMode = DataGridViewColumnSortMode.NotSortable

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
        TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

    Private Sub SC_M15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub
End Class