Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports PUCCommon

Public Class SC_M19

    Dim REG_FORMAT As New Regex("^([01][0-9]|2[0-3])(:[0-5][0-9]){1,2}$")
    Dim HEADER_NAME As Hashtable = New Hashtable

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_DIVISION As String = "区分"
    Private Const COL_LINE_DIVISION As String = "ライン区分"
    Private Const COL_BREAK_START_TIME As String = "休憩開始時間"
    Private Const COL_BREAK_END_TIME As String = "休憩終了時間"
    Private Const COL_BREAK_TIME As String = "休憩時間"
    Private Const COL_DATE_CHANGE_INDICATOR As String = "日付変更区分"

    'Dim FIELDS As String() = {COL_SENTAKU,
    '                            COL_PROCESS_CODE,
    '                            COL_DIVISION,
    '                            COL_LINE_DIVISION,
    '                            COL_BREAK_START_TIME,
    '                            COL_BREAK_END_TIME,
    '                            COL_BREAK_TIME,
    '                            COL_DATE_CHANGE_INDICATOR}

    Private Const TABLE_NAME As String = "勤務テーブルマスタ"

    Private Const MSG_FORMAT As String = "{0}の書式は「00:00」で入力してください。"
    Private Const MSG_TIME As String = "休憩開始時間は休憩終了時間より大きくない。"
    Private Const HEADER_FORMAT As String = "{0}" + vbCrLf + "({1})"
    Private Const XML_FORMAT As String = "Language[@name='{0}']"

    Dim xml As New CmnXML("SC-M19.xml", "SC-M19")
    'Dim language As clsLanguage = New clsLanguage

    Dim strLanguage As String = "jpn"

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnMenu0.Click

        Dim dt As New DataTable
        Dim strSelect As String = xml.GetSQL_Str("SELECT_001")
        Dim strWhere As String = xml.GetSQL_Str("WHERE_001")
        Dim selectSql As String

        If String.IsNullOrEmpty(cmb_Koutei.Text) Then
            selectSql = String.Format(strSelect, "")
        Else
            selectSql = String.Format(strSelect, String.Format(strWhere, cmb_Koutei.SelectedValue))
        End If

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                dt = clsSQLServer.GetDataTable(selectSql)

                If dt.Rows.Count = 0 Then

                    gridData.Columns.Clear()

                    MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           My.Settings.systemName)

                    clsSQLServer.Disconnect()

                    Return

                End If

                setGrid(dt)

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub


    ''' <summary>
    ''' 行番号
    ''' </summary>
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


    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    ''' <summary>
    ''' 名前設定
    ''' </summary>
    Public Sub SetControlsLable()

        '    Dim xmlResult As XmlNode = xml.GetControlsLableElement("SC-M19")

        '    'Master
        '    Dim xmlMaster As XmlNode = xmlResult.SelectSingleNode("Master")
        '    If xmlMaster IsNot Nothing Then
        '        Dim mstControl As Label = Me.Controls.Find("lblMaster0", True).First
        '        Dim mstControl1 As Label = Me.Controls.Find("lblMaster1", True).First

        '        mstControl.Text = xmlMaster.Attributes.GetNamedItem("enu").Value
        '        mstControl1.Text = xmlMaster.Attributes.GetNamedItem(strLanguage).Value
        '    End If

        '    'Button
        '    Dim xmlButtons As XmlNodeList = xmlResult.SelectNodes(String.Format(XML_FORMAT, "btnMenu"))

        '    If xmlButtons IsNot Nothing And xmlButtons.Count > 0 Then
        '        For Each xml As XmlNode In xmlButtons

        '            Dim btnName As String = "btnMenu" & xml.Attributes(1).Value
        '            Dim btnControl As Button = Me.Controls.Find(btnName, True).First

        '            If btnControl IsNot Nothing Then
        '                btnControl.Text = String.Format(HEADER_FORMAT, xml.Attributes.GetNamedItem("enu").Value, xml.Attributes.GetNamedItem(strLanguage).Value)
        '            End If

        '        Next
        '    End If

        '    'Lable
        '    Dim xmlLabels As XmlNodeList = xmlResult.SelectNodes(String.Format(XML_FORMAT, "lblName"))
        '    If xmlLabels IsNot Nothing And xmlLabels.Count > 0 Then
        '        For Each xml As XmlNode In xmlLabels

        '            Dim lblName As String = "lblName" & xml.Attributes(1).Value
        '            Dim lblName2 As String = "lblName" & xml.Attributes(1).Value & xml.Attributes(1).Value
        '            Dim lblControl As Label = Me.Controls.Find(lblName, True).First
        '            Dim lblControl2 As Label = Me.Controls.Find(lblName2, True).First

        '            If lblControl IsNot Nothing Then
        '                lblControl.Text = xml.Attributes.GetNamedItem("enu").Value
        '            End If

        '            If lblControl2 IsNot Nothing Then
        '                lblControl2.Text = "(" & xml.Attributes.GetNamedItem(strLanguage).Value & ")"
        '            End If

        '        Next

        '    End If

        '    'DataGridView
        '    Dim xmlDGVHeader As XmlNodeList = xmlResult.SelectNodes(String.Format(XML_FORMAT, "dgvHeader"))
        '    If xmlDGVHeader IsNot Nothing And xmlDGVHeader.Count > 0 Then

        '        For Each xml As XmlNode In xmlDGVHeader

        '            Dim dgvName As String = "dgvHeader" & xml.Attributes(1).Value
        '            Dim headName As String = xml.Attributes.GetNamedItem("enu").Value
        '            Dim headName2 As String = xml.Attributes.GetNamedItem(strLanguage).Value

        '            HEADER_NAME.Add(FIELDS(xml.Attributes(1).Value), String.Format(HEADER_FORMAT, headName, headName2))

        '        Next
        '    End If

    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_M19_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SetControlsLable()
        'language.LoadLanguage(strLanguage, "SC-M19", FIELDS, Me.Controls)

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

        Try
            Dim strSelect As String
            Dim dt As New DataTable

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '工程コード
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbKoutei.DataSource = dt
                Me.cmbKoutei.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbKoutei.DisplayMember = dt.Columns.Item(1).ColumnName

                '検索条件　工程コード
                Dim dt2 As New DataTable
                dt2 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Koutei.DataSource = dt2
                Me.cmb_Koutei.ValueMember = dt2.Columns.Item(0).ColumnName
                Me.cmb_Koutei.DisplayMember = dt2.Columns.Item(1).ColumnName

                '区分
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, "45"))
                Me.cmbKubun.DataSource = dt
                Me.cmbKubun.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbKubun.DisplayMember = dt.Columns.Item(1).ColumnName

                'ライン区分
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, "87"))
                Me.cmbLine.DataSource = dt
                Me.cmbLine.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbLine.DisplayMember = dt.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        Me.cmb_Koutei.Text = String.Empty
        controlsClear()

    End Sub

    ''' <summary>
    ''' クリア
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnMenu4.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            gridData.Columns.Clear()

            Me.cmb_Koutei.Text = String.Empty
            controlsClear()

            controlsColorClear()
        End If

    End Sub

    ''' <summary>
    ''' 画面コントロールのカラーをクリアする
    ''' </summary>
    Private Sub controlsColorClear()

        Me.cmbKubun.BackColor = Color.White
        Me.cmbLine.BackColor = Color.White
        Me.cmb_Koutei.BackColor = Color.White
        Me.txtStart.BackColor = Color.White
        Me.txtEnd.BackColor = Color.White
        Me.cmbHenkou.BackColor = Color.White

    End Sub


    ''' <summary>
    ''' 画面コントロールをクリアする
    ''' </summary>
    Private Sub controlsClear()

        Me.cmbKoutei.Text = String.Empty
        Me.cmbKubun.Text = String.Empty
        Me.cmbLine.Text = String.Empty
        Me.txtStart.Text = String.Empty
        Me.txtEnd.Text = String.Empty
        Me.cmbHenkou.Text = String.Empty

    End Sub

    ''' <summary>
    ''' 終了
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnMenu5.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
                  vbYesNo + vbQuestion,
                  My.Settings.systemName) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' データ一覧を設定
    ''' </summary>
    Private Sub setGrid(ByRef dtData As DataTable)

        gridData.Columns.Clear()

        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = HEADER_NAME(COL_SENTAKU)
        addColSentaku.HeaderText = HEADER_NAME(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)

        '項目
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_DATE_CHANGE_INDICATOR Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                addCol.FlatStyle = FlatStyle.Flat
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.Items.Add(" ")
                addCol.Items.Add("Y")
                addCol.Items.Add("N")
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                gridData.Columns.Add(addCol)
            End If
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '編集不可項目を設定する。
            Select Case i
                Case 1
                    gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                Case 2
                    gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                Case 3
                    gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                Case 6
                    gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 125
        gridData.Columns(2).Width = 90
        gridData.Columns(3).Width = 90
        gridData.Columns(4).Width = 110
        gridData.Columns(5).Width = 110
        gridData.Columns(6).Width = 100
        gridData.Columns(7).Width = 200

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then
                For i As Integer = 1 To 7

                    Select Case i
                        Case 1
                            gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Case 2
                            gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Case 3
                            gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Case 6
                            gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Case Else
                            gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                            gridData.CurrentRow.Cells(i).ReadOnly = False
                    End Select
                Next
            Else

                For i As Integer = 1 To 7
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' Insert(追加)事件
    ''' </summary>
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnMenu1.Click
        Dim strKouteiCode As String = cmbKoutei.SelectedValue
        Dim strKouteiName As String = cmbKoutei.Text
        Dim strKubunCode As String = cmbKubun.SelectedValue
        Dim strKubunName As String = cmbKubun.Text
        Dim strLineCode As String = cmbLine.SelectedValue
        Dim strLineName As String = cmbLine.Text
        Dim numBreakTime As Integer

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            '必須チェック
            '工程コード
            If cmbKoutei.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_PROCESS_CODE))
                cmbKoutei.BackColor = Color.Red
                Return
            Else
                cmbKoutei.BackColor = Color.White
            End If

            '区分
            If cmbKubun.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_DIVISION))
                cmbKubun.BackColor = Color.Red
                Return
            Else
                cmbKubun.BackColor = Color.White
            End If

            'ライン区分
            If cmbLine.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_LINE_DIVISION))
                cmbLine.BackColor = Color.Red
                Return
            Else
                cmbLine.BackColor = Color.White
            End If

            '桁数チェック
            '休憩開始時間
            If txtStart.Text.Equals(String.Empty) = False And txtStart.Text.Length <> 5 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BREAK_START_TIME, 5))
                txtStart.BackColor = Color.Red
                Return
            Else
                txtStart.BackColor = Color.White
            End If

            '休憩終了時間
            If txtEnd.Text.Equals(String.Empty) = False And txtEnd.Text.Length <> 5 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BREAK_END_TIME, 5))
                txtEnd.BackColor = Color.Red
                Return
            Else
                txtEnd.BackColor = Color.White
            End If

            '書式チェック
            '休憩開始時間
            If txtStart.Text.Equals(String.Empty) = False And REG_FORMAT.IsMatch(txtStart.Text) = False Then
                MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_START_TIME))
                txtStart.BackColor = Color.Red
                Return
            Else
                txtStart.BackColor = Color.White
            End If

            '休憩終了時間
            If txtEnd.Text.Equals(String.Empty) = False And REG_FORMAT.IsMatch(txtEnd.Text) = False Then
                MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_END_TIME))
                txtEnd.BackColor = Color.Red
                Return
            Else
                txtEnd.BackColor = Color.White
            End If


            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '重複チェック
                    Dim resultData As DataTable = New DataTable
                    Dim strSelect As String = xml.GetSQL_Str("SELECT_004")
                    '工程コード/区分/ライン区分
                    resultData = clsSQLServer.GetDataTable(String.Format(strSelect, strKouteiCode, strKubunCode, strLineCode))
                    If resultData IsNot Nothing And resultData.Rows.Count > 0 Then
                        '重複データがある場合、メッセージを表示して、追加処理を終止する
                        MsgBox(String.Format(clsGlobal.MSG2("W0009")),
                               vbExclamation,
                               My.Settings.systemName)

                        clsSQLServer.Disconnect()

                        Return
                    End If

                    '休憩時間
                    If txtStart.Text IsNot String.Empty And txtEnd.Text IsNot String.Empty Then
                        '休憩開始時間 > 休憩終了時間
                        If TimeSpan.Parse(txtEnd.Text) < TimeSpan.Parse(txtStart.Text) Then
                            MessageBox.Show(MSG_TIME)
                            txtStart.BackColor = Color.Red
                            txtEnd.BackColor = Color.Red
                            Return
                        Else
                            txtStart.BackColor = Color.White
                            txtEnd.BackColor = Color.White
                        End If

                        numBreakTime = (TimeSpan.Parse(txtEnd.Text) - TimeSpan.Parse(txtStart.Text)).TotalMinutes
                    End If

                    'データを追加
                    Dim sqlstr As String = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                strKouteiCode,
                                                                strKubunCode,
                                                                strLineCode,
                                                                txtStart.Text,
                                                                txtEnd.Text,
                                                                cmbHenkou.Text,
                                                                numBreakTime))

                    clsSQLServer.Disconnect()

                    '最新データを検索
                    btnSearch_Click(sender, e)

                    controlsClear()

                End If

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
            End Try

        End If
    End Sub

    ''' <summary>
    ''' Update(更新)事件
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnMenu2.Click

        Dim gridCells As DataGridViewCellCollection
        If MsgBox(String.Format(clsGlobal.MSG2("I0002")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            'レコード存在しない場合、エラーが発生する
            If gridData.Rows.Count = 0 Then
                MsgBox(String.Format(clsGlobal.MSG2("W9001")), vbExclamation, My.Settings.systemName)
                Return
            End If

            Try

                Dim selectedCount As Boolean = False
                For i As Integer = 0 To gridData.Rows.Count - 1
                    If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                        If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                            gridCells = gridData.Rows(i).Cells

                            Dim numBreakTime As Integer
                            Dim strKouteiCode As String = gridCells(COL_PROCESS_CODE).Value
                            Dim strKubunCode As String = gridCells(COL_DIVISION).Value
                            Dim strLineCode As String = gridCells(COL_LINE_DIVISION).Value
                            Dim strStartDT As String = gridCells(COL_BREAK_START_TIME).Value
                            Dim strEndDT As String = gridCells(COL_BREAK_END_TIME).Value
                            Dim strDataChangeIndicator As String = gridCells(COL_DATE_CHANGE_INDICATOR).Value

                            '桁数チェック
                            '休憩開始時間
                            If strStartDT.Equals(String.Empty) = False And strStartDT.Length <> 5 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BREAK_START_TIME, 5))
                                gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                            End If

                            '休憩終了時間
                            If strEndDT.Equals(String.Empty) = False And strEndDT.Length <> 5 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BREAK_END_TIME, 5))
                                gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                            End If

                            '書式チェック
                            '休憩開始時間
                            If strStartDT.Equals(String.Empty) = False And REG_FORMAT.IsMatch(strStartDT) = False Then
                                MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_START_TIME))
                                gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                            End If

                            '休憩終了時間
                            If strEndDT.Equals(String.Empty) = False And REG_FORMAT.IsMatch(strEndDT) = False Then
                                MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_END_TIME))
                                gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                            End If

                            '休憩時間
                            If strStartDT IsNot String.Empty And strEndDT IsNot String.Empty Then
                                '休憩開始時間 > 休憩終了時間
                                If TimeSpan.Parse(strEndDT) < TimeSpan.Parse(strStartDT) Then
                                    MessageBox.Show(MSG_TIME)
                                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                                    Exit For
                                Else
                                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                                End If

                                numBreakTime = (TimeSpan.Parse(strEndDT) - TimeSpan.Parse(strStartDT)).TotalMinutes
                            End If

                            'データを更新
                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    strKouteiCode,
                                                                    strKubunCode,
                                                                    strLineCode,
                                                                    strStartDT,
                                                                    strEndDT,
                                                                    strDataChangeIndicator,
                                                                    numBreakTime))

                            selectedCount = True

                            clsSQLServer.Disconnect()

                            btnSearch_Click(sender, e)

                        End If

                    End If
                Next

                '選択されてないレコードがエラー発生する
                If selectedCount = False Then
                    MsgBox(String.Format(clsGlobal.MSG2("W9001")),
                               vbExclamation,
                               My.Settings.systemName)
                    Return
                End If

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Delete(削除)事件
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnMenu3.Click

        Dim selectedCount As Boolean = False

        If MsgBox(String.Format(clsGlobal.MSG2("I0003")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            'レコード存在しない場合、エラーが発生する
            If gridData.Rows.Count = 0 Then
                MsgBox(String.Format(clsGlobal.MSG2("W9001")),
                               vbExclamation,
                               My.Settings.systemName)
                Return
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                            Dim strKouteiCode As String = gridData.Rows(i).Cells(COL_PROCESS_CODE).Value
                            Dim strKubunCode As String = gridData.Rows(i).Cells(COL_DIVISION).Value
                            Dim strLineCode As String = gridData.Rows(i).Cells(COL_LINE_DIVISION).Value

                            '削除
                            Dim sqlstr As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr, strKouteiCode, strKubunCode, strLineCode))

                            selectedCount = True

                        End If

                    Next

                    '選択されてないレコードがエラー発生する
                    If selectedCount = False Then
                        MsgBox(String.Format(clsGlobal.MSG2("W9001")),
                               vbExclamation,
                               My.Settings.systemName)
                        Return
                    End If

                    clsSQLServer.Disconnect()

                    '再検索
                    btnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
            End Try
        End If
    End Sub
End Class