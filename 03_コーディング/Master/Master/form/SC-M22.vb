Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_M22

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"管理ＮＯ種別", "Management NO type" & vbCrLf & "(管理ＮＯ種別)"},
                             {"固定部", "Fixed part" & vbCrLf & "(固定部)"},
                             {"番号", "Number" & vbCrLf & "(番号)"},
                             {"変動データ部", "Fluctuation data section" & vbCrLf & "(変動データ部)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_SNOTYPE As String = "管理ＮＯ種別"
    Private Const COL_SFIXEDPART As String = "固定部"
    Private Const COL_SNUMBER As String = "番号"
    Private Const COL_SSECTION As String = "変動データ部"
    Private Const COL_SBIKOU As String = "備考"

    Dim xml As New CmnXML("SC-M22.xml")

    Dim da As SqlDataAdapter
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

        xml.InitUser(Me.txtLoginUser, Me.TextBox1)

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

        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
        addColSentaku.HeaderText = headerName(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
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

        If MsgBox(cmnUtil.GetMessageStr("M0001"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try

            If clsSQLServer.Connect() Then

                Dim sqlstr As String = xml.GetSQL("select", "select_001")

                Dim dt As New DataTable()

                dt = clsSQLServer.GetDataTable(sqlstr)

                dt.Columns.Add(New DataColumn(COL_SBIKOU, GetType(System.String)))

                setGrid(dt)

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try
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

        If MsgBox(cmnUtil.GetMessageStr("Q0009"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            gridData.Columns.Clear()
        End If
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0001"), vbOKCancel, "生産管理システム") = DialogResult.OK Then

            If txtManagementNoType.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "管理ＮＯ種別"))
                txtManagementNoType.BackColor = Color.Red
                Return
            Else
                txtManagementNoType.BackColor = Color.White
            End If

            If txtFixedPart.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "固定部"))
                txtFixedPart.BackColor = Color.Red
                Return
            Else
                txtFixedPart.BackColor = Color.White
            End If

            If txtNumber.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "番号"))
                txtNumber.BackColor = Color.Red
                Return
            Else
                txtNumber.BackColor = Color.White
            End If

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

            btnSearch_Click(sender, e)

            Me.txtManagementNoType.Text = String.Empty
            Me.txtFixedPart.Text = String.Empty
            Me.txtNumber.Text = String.Empty
            Me.txtFluctuationDataSection.Text = String.Empty
            Me.txtRemartks.Text = String.Empty
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0002"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            Dim connent As New Conn
            Dim cn As New SqlConnection
            Dim cmd As SqlCommand
            connent.fncCnOpen(cn)

            Dim sqlstr As String = xml.GetSQL("update", "update_001")

            For i As Integer = 0 To gridData.Rows.Count - 1

                '横位置
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

            connent.subCnClose(cn)

            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0003"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            Dim connent As New Conn
            Dim cn As New SqlConnection
            Dim cmd As SqlCommand
            connent.fncCnOpen(cn)

            Dim sqlstr As String = xml.GetSQL("delete", "delete_001")


            For i As Integer = 0 To gridData.Rows.Count - 1

                '横位置
                If IsDBNull(gridData.Rows(i).Cells(0).Value) Then

                Else

                    cmd = New SqlCommand(sqlstr, cn)

                    cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 2)
                    cmd.Parameters("@PNAME").Value = gridData.Rows(i).Cells(1).Value

                    cmd.Parameters.Add("@POSITION", SqlDbType.VarChar, 8)
                    cmd.Parameters("@POSITION").Value = gridData.Rows(i).Cells(2).Value

                    cmd.ExecuteNonQuery()
                End If

            Next

            connent.subCnClose(cn)

            btnSearch_Click(sender, e)
        End If
    End Sub

End Class