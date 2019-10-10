Public Class SC_M16

    Private Sub Init()
        Me.cmbMode.SelectedIndex = 0
        Me.txtProgram.Enabled = False
        Me.txtFormID.Enabled = False
        Me.txtFormName.Enabled = False
        Me.cmbGroup.Enabled = False
        Me.cmbAuthority.Enabled = False

        Me.txtProgram.Text = String.Empty
        Me.txtFormID.Text = String.Empty
        Me.txtFormName.Text = String.Empty
        Me.cmbGroup.SelectedIndex = -1
        Me.cmbAuthority.SelectedIndex = -1

        Dim dt As New DataTable

        dt.Columns.Add("プログラムID")
        dt.Columns.Add("画面ID")
        dt.Columns.Add("画面名称")
        dt.Columns.Add("グループID")
        dt.Columns.Add("権限")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_001"
        dr.Item("画面ID") = "FRMSYS1"
        dr.Item("画面名称") = "画面管理画面"
        dr.Item("グループID") = "99"
        dr.Item("権限") = "2"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_A01"
        dr.Item("画面ID") = "FAB0100"
        dr.Item("画面名称") = "3ヶ月内示登録画面"
        dr.Item("グループID") = "10"
        dr.Item("権限") = "1"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_A01"
        dr.Item("画面ID") = "FAB0100"
        dr.Item("画面名称") = "3ヶ月内示登録画面"
        dr.Item("グループID") = "70"
        dr.Item("権限") = "1"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_A01"
        dr.Item("画面ID") = "FBB0100"
        dr.Item("画面名称") = "受注データ登録画面"
        dr.Item("グループID") = "20"
        dr.Item("権限") = "1"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_B01"
        dr.Item("画面ID") = "FAC0100"
        dr.Item("画面名称") = "外部データ取込み画面"
        dr.Item("グループID") = "30"
        dr.Item("権限") = "2"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_B01"
        dr.Item("画面ID") = "FAC0100"
        dr.Item("画面名称") = "外部データ取込み画面"
        dr.Item("グループID") = "40"
        dr.Item("権限") = "1"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr.Item("プログラムID") = "Pro_C01"
        dr.Item("画面ID") = "FCA0100"
        dr.Item("画面名称") = "3ヶ月生産計画画面(製品)"
        dr.Item("グループID") = "60"
        dr.Item("権限") = "2"
        dt.Rows.Add(dr)

        gridData.Columns.Clear()
        gridData.DataSource = dt
        gridData.Columns.Item(0).ReadOnly = True
        'gridData.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(0).HeaderText = "Program ID" & vbCrLf & "(プログラムID)"
        gridData.Columns.Item(0).Width = 200
        gridData.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        gridData.Columns.Item(1).ReadOnly = True
        'gridData.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(1).HeaderText = "Form ID" & vbCrLf & "(画面ID)"
        gridData.Columns.Item(1).Width = 200
        gridData.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns.Item(2).ReadOnly = True
        'gridData.Columns.Item(2).DefaultCellStyle.BackColor = Color.LightGray
        gridData.Columns.Item(2).HeaderText = "Form name" & vbCrLf & "(画面名称)"
        gridData.Columns.Item(2).Width = 350

        gridData.Columns.Item(3).Visible = False
        gridData.Columns.Item(4).Visible = False

        'グループID
        Dim dtGroup As New DataTable
        dtGroup.Columns.Add("Value")
        dtGroup.Columns.Add("Text")

        Dim dr1 As DataRow

        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "10"
        dr1.Item(1) = "10：生産"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "20"
        dr1.Item(1) = "20：資材"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "30"
        dr1.Item(1) = "30：経理"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "40"
        dr1.Item(1) = "40：製造"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "50"
        dr1.Item(1) = "50：品保"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "60"
        dr1.Item(1) = "60：総務"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "70"
        dr1.Item(1) = "70：一般"
        dtGroup.Rows.Add(dr1)
        dr1 = dtGroup.NewRow()
        dr1.Item(0) = "99"
        dr1.Item(1) = "99：システム"
        dtGroup.Rows.Add(dr1)

        Dim column As New DataGridViewComboBoxColumn()
        column.DataPropertyName = "グループID"
        column.ReadOnly = False
        column.HeaderText = "Group ID" & vbCrLf & "(グループID)"
        column.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        column.DataSource = dtGroup
        column.DisplayMember = "Text"
        column.ValueMember = "Value"
        gridData.Columns.Add(column)

        '権限
        Dim dtAuto As New DataTable
        dtAuto.Columns.Add("Value")
        dtAuto.Columns.Add("Text")

        dr1 = dtAuto.NewRow()
        dr1.Item(0) = "1"
        dr1.Item(1) = "1：参照のみ"
        dtAuto.Rows.Add(dr1)
        dr1 = dtAuto.NewRow()
        dr1.Item(0) = "2"
        dr1.Item(1) = "2：すべて"
        dtAuto.Rows.Add(dr1)

        column = New DataGridViewComboBoxColumn()
        column.DataPropertyName = "権限"
        column.ReadOnly = False
        column.HeaderText = "Authority name" & vbCrLf & "(権限)"
        column.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        column.DataSource = dtAuto
        column.DisplayMember = "Text"
        column.ValueMember = "Value"
        gridData.Columns.Add(column)

        'gridData.AutoResizeColumns()

        gridData.Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(3).SortMode = DataGridViewColumnSortMode.NotSortable
        gridData.Columns.Item(4).SortMode = DataGridViewColumnSortMode.NotSortable

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

    Private Sub SC_M16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub
End Class