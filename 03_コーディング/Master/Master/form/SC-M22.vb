Imports Master.Conn
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_M22

    Private Const COL_SENTAKU As String = "Select" & vbCrLf & "(選択)"
    Private Const COL_SNOTYPE As String = "管理ＮＯ種別"
    Private Const COL_SFIXEDPART As String = "固定部"
    Private Const COL_SNUMBER As String = "番号"
    Private Const COL_SSECTION As String = "変動データ部"
    Private Const COL_SBIKOU As String = "備考"
    'Private Const COL_SNOTYPE As String = "Management NO type" & vbCrLf & "(管理ＮＯ種別)"
    'Private Const COL_SFIXEDPART As String = "Fixed part" & vbCrLf & "(固定部)"
    'Private Const COL_SNUMBER As String = "Number" & vbCrLf & "(番号)"
    'Private Const COL_SSECTION As String = "Fluctuation data section" & vbCrLf & "(変動データ部)"
    'Private Const COL_SBIKOU As String = "Remarks" & vbCrLf & "(備考)"

    Dim xml As New CmnXML("SC-M22.xml")

    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Private Sub Init()
        Me.txtManagementNoType.Enabled = True
        Me.txtFixedPart.Enabled = True
        Me.txtNumber.Enabled = True
        Me.txtFluctuationDataSection.Enabled = True
        Me.txtRemartks.Enabled = True
        Me.txtManagementNoType.Text = String.Empty
        Me.txtFixedPart.Text = String.Empty
        Me.txtNumber.Text = String.Empty
        Me.txtFluctuationDataSection.Text = String.Empty
        Me.txtRemartks.Text = String.Empty
        Me.cmbDivision.SelectedIndex = -1

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)

        If gridData.Rows.Count > 0 Then

            gridData.Columns.Clear()

        End If

        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_SENTAKU Then
                Dim addCol As New DataGridViewCheckBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = "sentaku"
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = col.ColumnName
                gridData.Columns.Add(addCol)
            End If
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_SFIXEDPART, COL_SBIKOU, COL_SSECTION
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_SNUMBER
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case "sentaku"
                    col.ReadOnly = False
                    col.DefaultCellStyle.BackColor = Color.LightSkyBlue
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(0).Width = 90
        gridData.Columns(1).Width = 180
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 180
        gridData.Columns(5).Width = 200

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
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

    Private Sub SC_M22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim connent As New Conn
        Dim cn As New SqlConnection
        connent.fncCnOpen(cn)

        Dim da As SqlDataAdapter

        Dim sqlstr As String = xml.GetSQL("select", "select_001")

        da = New SqlDataAdapter(sqlstr, cn)

        dt = New DataTable()

        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_SNOTYPE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SFIXEDPART, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SNUMBER, GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn(COL_SSECTION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SBIKOU, GetType(System.String)))

        da.Fill(dt)

        'Dim dr As DataRow

        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "01"
        'dr(COL_SFIXEDPART) = "AAAAAA"
        'dr(COL_SNUMBER) = "1"
        'dr(COL_SSECTION) = "00001"
        'dr(COL_SBIKOU) = "備考01"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "02"
        'dr(COL_SFIXEDPART) = "AAAAAB"
        'dr(COL_SNUMBER) = "2"
        'dr(COL_SSECTION) = "00002"
        'dr(COL_SBIKOU) = "備考02"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "03"
        'dr(COL_SFIXEDPART) = "AAAAAC"
        'dr(COL_SNUMBER) = "3"
        'dr(COL_SSECTION) = "00003"
        'dr(COL_SBIKOU) = "備考03"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "04"
        'dr(COL_SFIXEDPART) = "AAAAAD"
        'dr(COL_SNUMBER) = "4"
        'dr(COL_SSECTION) = "00004"
        'dr(COL_SBIKOU) = "備考04"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "05"
        'dr(COL_SFIXEDPART) = "AAAAAE"
        'dr(COL_SNUMBER) = "5"
        'dr(COL_SSECTION) = "00005"
        'dr(COL_SBIKOU) = "備考05"
        'dt.Rows.Add(dr)
        'dr = dt.NewRow()
        'dr(COL_SNOTYPE) = "06"
        'dr(COL_SFIXEDPART) = "AAAAAF"
        'dr(COL_SNUMBER) = "6"
        'dr(COL_SSECTION) = "00006"
        'dr(COL_SBIKOU) = "備考06"
        'dt.Rows.Add(dr)

        setGrid(dt)

        connent.subCnClose(cn)
    End Sub

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 3 To 5
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.Yellow

                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 3 To 5

                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White

                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridData.Columns.Clear()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Dim connent As New Conn
        Dim cn As New SqlConnection
        Dim cmd As SqlCommand
        connent.fncCnOpen(cn)

        Dim sqlstr As String = xml.GetSQL("insert", "insert_001")

        cmd = New SqlCommand(sqlstr, cn)

        cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
        cmd.Parameters("@PNAME").Value = txtManagementNoType.Text

        cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
        cmd.Parameters("@POSITION").Value = txtFixedPart.Text

        cmd.Parameters.Add("@TEAM", SqlDbType.VarChar, 10)
        cmd.Parameters("@TEAM").Value = txtFluctuationDataSection.Text

        cmd.Parameters.Add("@NUM", SqlDbType.Decimal, 10)
        cmd.Parameters("@NUM").Value = Decimal.Parse(txtNumber.Text)

        cmd.ExecuteNonQuery()

        connent.subCnClose(cn)

        Me.txtManagementNoType.Text = String.Empty
        Me.txtFixedPart.Text = String.Empty
        Me.txtNumber.Text = String.Empty
        Me.txtFluctuationDataSection.Text = String.Empty
        Me.txtRemartks.Text = String.Empty

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim connent As New Conn
        Dim cn As New SqlConnection
        Dim cmd As SqlCommand
        connent.fncCnOpen(cn)

        Dim sqlstr As String = xml.GetSQL("update", "update_001")

        For i As Integer = 0 To gridData.Rows.Count - 1

            '横位置
            'Dim Checked As Boolean = CType(gridData.Rows(i).Cells(0).Value, Boolean)

            If IsDBNull(gridData.Rows(i).Cells(0).Value) Then

            Else

                cmd = New SqlCommand(sqlstr, cn)

                cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
                cmd.Parameters("@PNAME").Value = gridData.Rows(i).Cells(1).Value

                cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
                cmd.Parameters("@POSITION").Value = gridData.Rows(i).Cells(2).Value

                cmd.Parameters.Add("@NUM", SqlDbType.Decimal, 10)
                cmd.Parameters("@NUM").Value = Decimal.Parse(gridData.Rows(i).Cells(3).Value)

                cmd.Parameters.Add("@TEAM", SqlDbType.VarChar, 10)
                cmd.Parameters("@TEAM").Value = gridData.Rows(i).Cells(4).Value

                cmd.ExecuteNonQuery()
            End If

        Next


        'If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
        '    gridData.EndEdit()
        '    Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)

        '    If Checked Then

        '        For i As Integer = 1 To 4

        '            Select Case i
        '                Case 1
        '                    cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
        '                    cmd.Parameters("@PNAME").Value = gridData.CurrentRow.Cells(i).Value
        '                Case 2
        '                    cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
        '                    cmd.Parameters("@POSITION").Value = gridData.CurrentRow.Cells(i).Value
        '                Case 3
        '                    cmd.Parameters.Add("@NUM", SqlDbType.Decimal, 10)
        '                    cmd.Parameters("@NUM").Value = Decimal.Parse(gridData.CurrentRow.Cells(i).Value)
        '                Case 4
        '                    cmd.Parameters.Add("@TEAM", SqlDbType.VarChar, 10)
        '                    cmd.Parameters("@TEAM").Value = gridData.CurrentRow.Cells(i).Value
        '            End Select

        '            'MessageBox.Show(gridData.CurrentRow.Cells(i).Value)
        '        Next
        '    End If
        'End If

        'cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
        'cmd.Parameters("@PNAME").Value = txtManagementNoType.Text

        'cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
        'cmd.Parameters("@POSITION").Value = txtFixedPart.Text

        'cmd.Parameters.Add("@TEAM", SqlDbType.VarChar, 10)
        'cmd.Parameters("@TEAM").Value = txtFluctuationDataSection.Text

        'cmd.Parameters.Add("@NUM", SqlDbType.Decimal, 10)
        'cmd.Parameters("@NUM").Value = Decimal.Parse(txtNumber.Text)


        connent.subCnClose(cn)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim connent As New Conn
        Dim cn As New SqlConnection
        Dim cmd As SqlCommand
        connent.fncCnOpen(cn)

        Dim sqlstr As String = xml.GetSQL("delete", "delete_001")

        cmd = New SqlCommand(sqlstr, cn)

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)

            If Checked Then

                For i As Integer = 1 To 2
                    MessageBox.Show(gridData.CurrentRow.Cells(i).Value)
                Next
            End If
        End If

        cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
        cmd.Parameters("@PNAME").Value = txtManagementNoType.Text

        cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
        cmd.Parameters("@POSITION").Value = txtFixedPart.Text

        cmd.ExecuteNonQuery()

        connent.subCnClose(cn)
    End Sub
End Class