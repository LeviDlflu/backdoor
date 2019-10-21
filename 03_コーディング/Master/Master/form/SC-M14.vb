
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text


Public Class SC_M14
    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"ＩＰアドレス", "IP address" & vbCrLf & "(ＩＰアドレス)"},
                             {"設備", "Facility" & vbCrLf & "(設備)"},
                             {"稼動区分", "Operation division" & vbCrLf & "(稼動区分)"},
                             {"機種", "Equipment type" & vbCrLf & "(機種)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}}

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_IP_ADDRESS As String = "ＩＰアドレス"
    Private Const COL_Facility As String = "設備"
    Private Const COL_OPERATION_DIVISION As String = "稼動区分"
    Private Const COL_EQUIPMENT_TYPE As String = "機種"
    Private Const COL_REMARKS As String = "備考"
    Private Const TABLENAME As String = "ＩＰアドレス管理マスタ"
    Dim dtAutoLabel As New DataTable

    Dim xml As New CmnXML("SC-M14.xml"， "SC-M14")

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim sqlstr As String
                Dim strWhere As String = "WHERE"
                Dim where1 As String
                Dim where2 As String
                Dim where3 As String
                Dim sort As String
                Dim strAnd As String = "AND"
                sqlstr = xml.GetSQL_Str("SELECT_001")
                where1 = xml.GetSQL_Str("WHERE_001")
                where2 = xml.GetSQL_Str("WHERE_002")
                where3 = xml.GetSQL_Str("WHERE_003")
                sort = xml.GetSQL_Str("SORT_001")

                If String.IsNullOrEmpty(ComboBox1.Text) Then
                    If String.IsNullOrEmpty(cmb_Koutei.Text) Then
                        If String.IsNullOrEmpty(ComboBox2.Text) Then
                            sqlstr = sqlstr & " " & sort
                        Else
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where3, ComboBox2.SelectedValue) & " " & sort
                        End If
                    Else
                        If String.IsNullOrEmpty(ComboBox2.Text) Then
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where2, cmb_Koutei.Text.Substring(0, 1)) & " " & sort
                        Else
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where2, cmb_Koutei.Text.Substring(0, 1)) & " " & strAnd & " " & String.Format(where3, ComboBox2.SelectedValue) & " " & sort
                        End If
                    End If
                Else
                    If String.IsNullOrEmpty(cmb_Koutei.Text) Then
                        If String.IsNullOrEmpty(ComboBox2.Text) Then
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where1, ComboBox1.SelectedValue) & " " & sort
                        Else
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where1, ComboBox1.SelectedValue) & " " & strAnd & " " & String.Format(where3, ComboBox2.SelectedValue) & " " & sort
                        End If
                    Else
                        If String.IsNullOrEmpty(ComboBox2.Text) Then
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where1, ComboBox1.SelectedValue) & " " & strAnd & " " & String.Format(where2, cmb_Koutei.Text.Substring(0, 1)) & " " & sort
                        Else
                            sqlstr = sqlstr & " " & strWhere & " " & String.Format(where1, ComboBox1.SelectedValue) & " " & strAnd & " " & String.Format(where2, cmb_Koutei.Text.Substring(0, 1)) & " " & strAnd & " " & String.Format(where3, ComboBox2.SelectedValue) & " " & sort
                        End If
                    End If
                End If
                Dim dt As New DataTable()

                dt = clsSQLServer.GetDataTable(sqlstr)

                If dt.Rows.Count = 0 Then
                    Dim msg As New clsMessage("W0008")

                    MsgBox(msg.Show, vbCritical, TABLENAME)

                End If

                setGrid(dt)

                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            gridData.DataSource = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        'gridData.Rows.Clear()
        gridData.Columns.Clear()

        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = HEADER_NAME(COL_SENTAKU)
        addColSentaku.HeaderText = HEADER_NAME(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_OPERATION_DIVISION Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.White
                addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                addCol.FlatStyle = FlatStyle.Flat
                addCol.DataSource = dtAutoLabel
                addCol.ValueMember = dtAutoLabel.Columns.Item(0).ColumnName
                addCol.DisplayMember = dtAutoLabel.Columns.Item(1).ColumnName
                gridData.Columns.Add(addCol)
                'TODO
            ElseIf col.ColumnName = COL_Facility Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.LightGray
                addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                addCol.FlatStyle = FlatStyle.Flat
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    Dim selectSql1 As String
                    selectSql1 = xml.GetSQL_Str("SELECT_002")
                    Dim dt1 As New DataTable()
                    dt1 = clsSQLServer.GetDataTable(selectSql1)
                    addCol.DataSource = dt1
                    addCol.ValueMember = "設備コード"
                    addCol.DisplayMember = "設備略称"
                    clsSQLServer.Disconnect()
                End If
                gridData.Columns.Add(addCol)
            ElseIf col.ColumnName = COL_EQUIPMENT_TYPE Or col.ColumnName = COL_REMARKS Then
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.White
                gridData.Columns.Add(addCol)
                Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
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
        gridData.Columns(1).Width = 90
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 160
        gridData.Columns(5).Width = 320

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
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add(" ", "")
        dt.Rows.Add("0", "0:予備")
        dt.Rows.Add("1", "1:稼動")
        dtAutoLabel = dt
        initComboxValue()
    End Sub

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
          vbOKCancel + vbQuestion,
          My.Settings.systemName) = DialogResult.OK Then
            gridData.Columns.Clear()
            cmb_Koutei.SelectedIndex = -1
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
            ComboBox4.SelectedIndex = -1
            TextBox2.Text = String.Empty
            TextBox3.Text = String.Empty
            txtHinSyuCD.Text = String.Empty
        End If
    End Sub



    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
                  vbYesNo + vbQuestion,
                  My.Settings.systemName) = DialogResult.Yes Then
            Me.Close()
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

                For i As Integer = 3 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 3 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    Private Sub initComboxValue()
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim selectSql1 As String
                Dim selectSql2 As String
                selectSql1 = xml.GetSQL_Str("SELECT_002")
                selectSql2 = xml.GetSQL_Str("SELECT_003")
                Dim dt1 As New DataTable()
                Dim dt2 As New DataTable()
                Dim dt3 As New DataTable()
                dt1 = clsSQLServer.GetDataTable(selectSql1)
                dt2 = clsSQLServer.GetDataTable(selectSql2)
                dt3 = clsSQLServer.GetDataTable(selectSql1)

                Me.ComboBox1.ValueMember = "設備コード"
                Me.ComboBox1.DisplayMember = "設備略称"
                Me.ComboBox1.DataSource = dt1
                ComboBox1.SelectedIndex = -1

                Me.ComboBox3.ValueMember = "設備コード"
                Me.ComboBox3.DisplayMember = "設備略称"
                Me.ComboBox3.DataSource = dt3
                ComboBox3.SelectedIndex = -1

                Me.ComboBox2.ValueMember = COL_IP_ADDRESS
                Me.ComboBox2.DisplayMember = COL_IP_ADDRESS
                Me.ComboBox2.DataSource = dt2
                ComboBox2.SelectedIndex = -1

                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Insert(追加)事件
    ''' </summary>
    Private Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            If txtHinSyuCD.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_IP_ADDRESS))
                txtHinSyuCD.BackColor = Color.Red
                Return
            Else
                If txtHinSyuCD.Text.Length <> 14 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_IP_ADDRESS, "14"))
                    txtHinSyuCD.BackColor = Color.Red
                    Return
                Else
                    txtHinSyuCD.BackColor = Color.White
                End If
            End If

            If TextBox2.Text.Length > 30 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_EQUIPMENT_TYPE, "30"))
                TextBox2.BackColor = Color.Red
                Return
            Else
                TextBox2.BackColor = Color.White
            End If

            If TextBox3.Text.Length > 50 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_REMARKS, "50"))
                TextBox3.BackColor = Color.Red
                Return
            Else
                TextBox3.BackColor = Color.White
            End If

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim selectSql As String
                selectSql = xml.GetSQL_Str("SELECT_004")
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(String.Format(selectSql, txtHinSyuCD.Text))
                If dt.Rows.Count = 1 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                    ComboBox3.SelectedIndex = -1
                    ComboBox4.SelectedIndex = -1
                    TextBox2.Text = String.Empty
                    TextBox3.Text = String.Empty
                    txtHinSyuCD.Text = String.Empty
                    clsSQLServer.Disconnect()
                    Return
                Else
                    Dim OperationDivision As String
                    If String.IsNullOrEmpty(ComboBox4.Text) Then
                        OperationDivision = String.Empty
                    Else
                        OperationDivision = ComboBox4.Text.Substring(0, 1)
                    End If
                    Dim insertsql As String = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                           txtHinSyuCD.Text,
                                                           ComboBox3.SelectedValue,
                                                           OperationDivision,
                                                           TextBox2.Text, TextBox3.Text, Now))
                    clsSQLServer.Disconnect()
                    MessageBox.Show(cmnUtil.GetMessageStr("Q0001"))
                    ComboBox3.SelectedIndex = -1
                    ComboBox4.SelectedIndex = -1
                    TextBox2.Text = String.Empty
                    TextBox3.Text = String.Empty
                    txtHinSyuCD.Text = String.Empty
                    btnSearch_Click(sender, e)
                    initComboxValue()
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Delete(削除)事件
    ''' </summary>
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0003")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then
                            Dim deleteCount As Integer
                            Dim deletesql As String = xml.GetSQL_Str("DELETE_001")
                            deleteCount = clsSQLServer.ExecuteQuery(String.Format(deletesql, gridData.Rows(i).Cells(1).Value))
                            If deleteCount = 0 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0068"))
                            End If
                        End If
                    Next
                    clsSQLServer.Disconnect()
                    btnSearch_Click(sender, e)
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Update(更新)事件
    ''' </summary>
    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0002")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then
                            Dim selectSql As String
                            selectSql = xml.GetSQL_Str("SELECT_004")
                            Dim dt As New DataTable()
                            dt = clsSQLServer.GetDataTable(String.Format(selectSql,
                                                                         gridData.Rows(i).Cells(1).Value))
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0003"))
                                clsSQLServer.Disconnect()
                                Return
                            Else
                                Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                                clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            gridData.Rows(i).Cells(1).Value,
                                                            gridData.Rows(i).Cells(3).Value,
                                                            gridData.Rows(i).Cells(4).Value,
                                                            gridData.Rows(i).Cells(5).Value,
                                                            Now))
                            End If

                        End If

                    Next

                    clsSQLServer.Disconnect()
                    btnSearch_Click(sender, e)
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub
End Class