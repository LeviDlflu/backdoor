Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Public Class SC_M20

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"稼働年月", "Working days_YM" & vbCrLf & "(稼働年月)"},
                             {"稼働日", "Working days_D" & vbCrLf & "(稼働日)"},
                             {"稼働年月日", "Working days_YMD" & vbCrLf & "(稼働年月日)"},
                             {"直区分", "Direct division" & vbCrLf & "(直区分)"},
                             {"稼働区分", "Operation category" & vbCrLf & "(稼働区分)"},
                             {"稼働区分２", "Operation category2" & vbCrLf & "(稼働区分２)"},
                             {"稼働区分３", "Operation category3" & vbCrLf & "(稼働区分３)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_WORKING_YM As String = "稼働年月"
    Private Const COL_WORKING_D As String = "稼働日"
    Private Const COL_WORKING_YMD As String = "稼働年月日"
    Private Const COL_DIRECT As String = "直区分"
    Private Const COL_CATEGORY As String = "稼働区分"
    Private Const COL_CATEGORY_2 As String = "稼働区分２"
    Private Const COL_CATEGORY_3 As String = "稼働区分３"

    Dim xml As New CmnXML("SC-M20.xml")
    Dim strLanguage As String = "chs"
    Dim lngXml As New CmnXML("LanguageDefine.xml")
    Dim mXmlDoc As New XmlDocument

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub tmrClockSec_Tick(sender As Object, e As EventArgs) Handles tmrClockSec.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub SC_M20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初期設定
        'Me.Text = getTitle(GAMEN_SC_M20)
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
        InitCombox4Value()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            'gridData.Columns.Clear()
            Dim connent As New Conn
            Dim cn As New SqlConnection
            connent.fncCnOpen(cn)

            Dim da As SqlDataAdapter

            Dim sqlstr As String = xml.GetSQL("select", "select_001")

            da = New SqlDataAdapter(sqlstr, cn)
            Dim dt = New DataTable()
            dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
            dt.Columns.Add(New DataColumn(COL_WORKING_YM, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_WORKING_D, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_WORKING_YMD, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_CATEGORY, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_CATEGORY_2, GetType(System.String)))
            dt.Columns.Add(New DataColumn(COL_CATEGORY_3, GetType(System.String)))

            da.SelectCommand.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
            da.SelectCommand.Parameters("@WORKING_YM").Value = Me.ComboBox4.Text

            Dim count = da.Fill(dt)
            If count < 0 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0008", "データが存在していません。"))
                Me.ComboBox4.SelectedIndex = -1
                Return
            Else

                setGrid(dt)
            End If
            connent.subCnClose(cn)
        Catch ex As Exception
            MsgBox(ex.Message)
            gridData.DataSource = Nothing
        End Try

    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbYesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YM, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_D, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YMD, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY_2, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY_3, GetType(System.String)))

        Return dt

    End Function

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        'gridData.Rows.Clear()
        gridData.Columns.Clear()
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_SENTAKU Then
                Dim addCol As New DataGridViewCheckBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = headerName(col.ColumnName)
                addCol.Name = "sentaku"
                gridData.Columns.Add(addCol)
            ElseIf col.ColumnName = COL_CATEGORY Or col.ColumnName = COL_CATEGORY_2 Or col.ColumnName = COL_CATEGORY_3 Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = col.ColumnName
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.LightGray
                addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                addCol.FlatStyle = FlatStyle.Flat
                addCol.Items.Add(" ")
                addCol.Items.Add("1")
                addCol.Items.Add("2")
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = headerName(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.LightGray
                gridData.Columns.Add(addCol)
            End If
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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


        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 120
        gridData.Columns(2).Width = 100
        gridData.Columns(3).Width = 120
        gridData.Columns(4).Width = 150
        gridData.Columns(5).Width = 150
        gridData.Columns(6).Width = 150
        gridData.Columns(7).Width = 150


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　・行ヘッダーに行番号書き込み
    ''' </summary>
    Private Sub gridData_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles gridData.CellPainting

        '/// 行番号 ///
        '列ヘッダーかどうか調べる
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)

            '行番号を描画する
            TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.CellStyle.Font,
                indexRect,
                e.CellStyle.ForeColor,
                TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画が完了したことを知らせる
            e.Handled = True
        End If

    End Sub

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 5 To 7
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                Next
            Else

                For i As Integer = 5 To 7
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.LightGray
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0009"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            gridData.Columns.Clear()
            ComboBox4.SelectedIndex = -1
            Me.dtpWorkingYMD.Value = Now
            Me.cmbProcess.Text = String.Empty
            Me.ComboBox1.Text = String.Empty
            Me.ComboBox2.Text = String.Empty
            Me.ComboBox3.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        If MsgBox(cmnUtil.GetMessageStr("Q0001"), vbOKCancel, "生産管理システム") = DialogResult.OK Then
            If dtpWorkingYMD.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "稼働年月日"))
                dtpWorkingYMD.BackColor = Color.Red
                Return
            Else
                dtpWorkingYMD.BackColor = Color.White
            End If

            If cmbProcess.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "直区分"))
                cmbProcess.BackColor = Color.Red
                Return
            Else
                cmbProcess.BackColor = Color.White
            End If

            Dim conn As New Conn
            Dim sqlcn As New SqlConnection
            Dim da As SqlDataAdapter
            conn.fncCnOpen(sqlcn)

            Dim sqlselect2 As String = xml.GetSQL("select", "select_002")

            da = New SqlDataAdapter(sqlselect2, sqlcn)

            Dim dt = createGridData()

            da.SelectCommand.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
            da.SelectCommand.Parameters("@WORKING_YM").Value = Format(dtpWorkingYMD.Value, "yyyyMM")

            da.SelectCommand.Parameters.Add("@WORKING_D", SqlDbType.VarChar, 2)
            da.SelectCommand.Parameters("@WORKING_D").Value = Format(dtpWorkingYMD.Value, "dd")

            da.SelectCommand.Parameters.Add("@WORKING_YMD", SqlDbType.Date)
            da.SelectCommand.Parameters("@WORKING_YMD").Value = dtpWorkingYMD.Value

            da.SelectCommand.Parameters.Add("@DIRECT", SqlDbType.VarChar, 1)
            da.SelectCommand.Parameters("@DIRECT").Value = cmbProcess.Text

            Dim count = da.Fill(dt)

            conn.subCnClose(sqlcn)

            If count > 0 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0009", "データが既に存在しています。"))
                Me.dtpWorkingYMD.Value = Now
                Me.cmbProcess.Text = String.Empty
                Me.ComboBox1.Text = String.Empty
                Me.ComboBox2.Text = String.Empty
                Me.ComboBox3.Text = String.Empty
                Return
            Else
                Dim connent As New Conn
                Dim cn As New SqlConnection
                Dim cmd As SqlCommand
                connent.fncCnOpen(cn)

                Dim sqlstr As String = xml.GetSQL("insert", "insert_001")

                cmd = New SqlCommand(sqlstr, cn)

                cmd.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
                cmd.Parameters("@WORKING_YM").Value = Format(dtpWorkingYMD.Value, "yyyyMM")

                cmd.Parameters.Add("@WORKING_D", SqlDbType.VarChar, 2)
                cmd.Parameters("@WORKING_D").Value = Format(dtpWorkingYMD.Value, "dd")

                cmd.Parameters.Add("@WORKING_YMD", SqlDbType.Date)
                cmd.Parameters("@WORKING_YMD").Value = dtpWorkingYMD.Value

                cmd.Parameters.Add("@DIRECT", SqlDbType.VarChar, 1)
                cmd.Parameters("@DIRECT").Value = cmbProcess.Text

                cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 1)
                If IsDBNull(ComboBox3.Text) Then
                    cmd.Parameters("@CATEGORY").Value = ComboBox3.Text.Substring(0, 1)
                Else
                    cmd.Parameters("@CATEGORY").Value = String.Empty
                End If

                cmd.Parameters.Add("@CATEGORY_2", SqlDbType.VarChar, 1)
                If IsDBNull(ComboBox3.Text) Then
                    cmd.Parameters("@CATEGORY_2").Value = ComboBox2.Text.Substring(0, 1)
                Else
                    cmd.Parameters("@CATEGORY_2").Value = String.Empty
                End If

                cmd.Parameters.Add("@CATEGORY_3", SqlDbType.VarChar, 1)
                If IsDBNull(ComboBox3.Text) Then
                    cmd.Parameters("@CATEGORY_3").Value = ComboBox1.Text.Substring(0, 1)
                Else
                    cmd.Parameters("@CATEGORY_3").Value = String.Empty
                End If

                cmd.Parameters.Add("@INSERTTIME", SqlDbType.Date)
                cmd.Parameters("@INSERTTIME").Value = Now

                cmd.ExecuteNonQuery()

                connent.subCnClose(cn)
                MessageBox.Show(cmnUtil.GetMessageStr("Q0001", "追加しますか。"))
                Me.dtpWorkingYMD.Value = Now
                Me.cmbProcess.Text = String.Empty
                Me.ComboBox1.Text = String.Empty
                Me.ComboBox2.Text = String.Empty
                Me.ComboBox3.Text = String.Empty
                btnSearch_Click(sender, e)
                InitCombox4Value()

            End If
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

                    cmd.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
                    cmd.Parameters("@WORKING_YM").Value = gridData.Rows(i).Cells(1).Value

                    cmd.Parameters.Add("@WORKING_D", SqlDbType.VarChar, 2)
                    cmd.Parameters("@WORKING_D").Value = gridData.Rows(i).Cells(2).Value

                    cmd.Parameters.Add("@WORKING_YMD", SqlDbType.Date)
                    cmd.Parameters("@WORKING_YMD").Value = gridData.Rows(i).Cells(3).Value

                    cmd.Parameters.Add("@DIRECT", SqlDbType.VarChar, 1)
                    cmd.Parameters("@DIRECT").Value = gridData.Rows(i).Cells(4).Value

                    cmd.ExecuteNonQuery()
                End If

            Next

            connent.subCnClose(cn)

            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub InitCombox4Value()
        Dim conn As New Conn
        Dim sqlcn As New SqlConnection
        Dim da As SqlDataAdapter
        conn.fncCnOpen(sqlcn)

        Dim sqlselect3 As String = xml.GetSQL("select", "select_003")

        da = New SqlDataAdapter(sqlselect3, sqlcn)

        Dim dt = createGridData()
        da.Fill(dt)

        Me.ComboBox4.ValueMember = "稼働年月"
        Me.ComboBox4.DisplayMember = "稼働年月"
        Me.ComboBox4.DataSource = dt

        ComboBox4.SelectedIndex = -1
        conn.subCnClose(sqlcn)
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
                    Dim conn As New Conn
                    Dim sqlcn As New SqlConnection
                    Dim da As SqlDataAdapter
                    conn.fncCnOpen(sqlcn)

                    Dim sqlselect2 As String = xml.GetSQL("select", "select_002")

                    da = New SqlDataAdapter(sqlselect2, sqlcn)

                    Dim dt = createGridData()

                    da.SelectCommand.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
                    da.SelectCommand.Parameters("@WORKING_YM").Value = gridData.Rows(i).Cells(1).Value

                    da.SelectCommand.Parameters.Add("@WORKING_D", SqlDbType.VarChar, 2)
                    da.SelectCommand.Parameters("@WORKING_D").Value = gridData.Rows(i).Cells(2).Value

                    da.SelectCommand.Parameters.Add("@WORKING_YMD", SqlDbType.Date)
                    da.SelectCommand.Parameters("@WORKING_YMD").Value = gridData.Rows(i).Cells(3).Value

                    da.SelectCommand.Parameters.Add("@DIRECT", SqlDbType.VarChar, 1)
                    da.SelectCommand.Parameters("@DIRECT").Value = gridData.Rows(i).Cells(4).Value

                    Dim count = da.Fill(dt)

                    conn.subCnClose(sqlcn)
                    If count <= 0 Then
                        MessageBox.Show(cmnUtil.GetMessageStr("W0003", "データが存在していません。"))
                        btnSearch_Click(sender, e)
                        Return
                    Else
                        cmd = New SqlCommand(sqlstr, cn)

                        cmd.Parameters.Add("@WORKING_YM", SqlDbType.VarChar, 6)
                        cmd.Parameters("@WORKING_YM").Value = gridData.Rows(i).Cells(1).Value

                        cmd.Parameters.Add("@WORKING_D", SqlDbType.VarChar, 2)
                        cmd.Parameters("@WORKING_D").Value = gridData.Rows(i).Cells(2).Value

                        cmd.Parameters.Add("@WORKING_YMD", SqlDbType.Date)
                        cmd.Parameters("@WORKING_YMD").Value = gridData.Rows(i).Cells(3).Value

                        cmd.Parameters.Add("@DIRECT", SqlDbType.VarChar, 1)
                        cmd.Parameters("@DIRECT").Value = gridData.Rows(i).Cells(4).Value

                        cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 1)
                        cmd.Parameters("@CATEGORY").Value = gridData.Rows(i).Cells(5).Value

                        cmd.Parameters.Add("@CATEGORY_2", SqlDbType.VarChar, 1)
                        cmd.Parameters("@CATEGORY_2").Value = gridData.Rows(i).Cells(6).Value

                        cmd.Parameters.Add("@CATEGORY_3", SqlDbType.VarChar, 1)
                        cmd.Parameters("@CATEGORY_3").Value = gridData.Rows(i).Cells(7).Value

                        cmd.Parameters.Add("@UPDATETIME", SqlDbType.Date)
                        cmd.Parameters("@UPDATETIME").Value = Now

                        cmd.ExecuteNonQuery()
                    End If

                End If

            Next

            connent.subCnClose(cn)

            btnSearch_Click(sender, e)
        End If
    End Sub
    Public Function GetElement(ByVal node As String, ByVal element As String) As XmlNode
        Dim xmlResult As XmlNode = Nothing
        Dim mXmlNode As XmlNode = mXmlDoc.SelectSingleNode("//" + node)
        Dim xmlNodes As XmlNodeList = mXmlNode.SelectNodes(element)
        For Each fNode As XmlNode In xmlNodes
            If fNode.Attributes(0).Value = "SC-M19" Then
                xmlResult = fNode
                Exit For
            End If
        Next

        Return xmlResult
    End Function

End Class