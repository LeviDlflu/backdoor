﻿Public Class SC_M12

    Private Sub Init()
        'Me.cmbMode.SelectedIndex = 0
        'Me.txtVehicleType.Enabled = False
        'Me.txtVehicleTypeName.Enabled = False
        Me.txtVehicleType.Text = String.Empty
        Me.txtVehicleTypeName.Text = String.Empty
        Me.txtRemartks.Text = String.Empty
        Me.cmbHinsyu.SelectedIndex = -1

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("Select" & vbCrLf & "(選択)", GetType(System.Boolean)))
        dt.Columns.Add("車種コード")
        dt.Columns.Add("車種名")
        dt.Columns.Add("備考")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item("車種コード") = "013N"
        dr.Item("車種名") = "クルーガー"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "126"
        dr.Item("車種名") = "バルサー"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "186"
        dr.Item("車種名") = "ZR　エクストレイル"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "359"
        dr.Item("車種名") = "T30エクストレイル"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "363"
        dr.Item("車種名") = "バルサー"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "415A"
        dr.Item("車種名") = "RX"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("車種コード") = "420"
        dr.Item("車種名") = "P32Eエクストレイル"
        dt.Rows.Add(dr)

        gridData.DataSource = dt

        gridData.Columns.Item(1).ReadOnly = True
        'gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(1).HeaderText = "Vehicle type" & vbCrLf & "(車種コード)"
        gridData.Columns.Item(1).Width = 100
        gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        gridData.Columns.Item(2).ReadOnly = True
        'gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(2).HeaderText = "Vehicle type name" & vbCrLf & "(車種名)"
        gridData.Columns.Item(2).Width = 400
        'gridData.AutoResizeColumns()

        gridData.Columns.Item(3).ReadOnly = True
        gridData.Columns.Item(3).HeaderText = "Remarks" & vbCrLf & "(備考)"
        gridData.Columns.Item(3).Width = 200

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

    Private Sub SC_M12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub
End Class