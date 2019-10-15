Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

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

    Private Const TABLE_NAME As String = "勤務テーブルマスタ"

    Private Const MSG_FORMAT As String = "{0}の書式は「00:00」で入力してください。"
    Private Const HEADER_FORMAT As String = "{0}" + vbCrLf + "({1})"

    Dim cn As SqlConnection
    Dim connent As New Conn
    Dim xml As New CmnXML("SC-M19.xml")

    Dim strLanguage As String = "chs"
    Dim lngXml As New CmnXML("LanguageDefine.xml")
    Dim mXmlDoc As New XmlDocument


    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnMenu0.Click
        Dim dtResult As DataTable = createGridData()

        'データ確認
        If dtResult Is Nothing Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0008"))
            Return
        End If

        setGrid(dtResult)

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

    ''' <summary>
    ''' 名前設定
    ''' </summary>
    Public Sub SetControlsLable()
        mXmlDoc.Load("LanguageDefine.xml")
        Dim xmlResult As XmlNode = GetElement("languages", "form")
        'Header
        Dim xmlMaster As XmlNode = xmlResult.SelectSingleNode("master")
        Me.Label18.Text = xmlMaster.Attributes.GetNamedItem("enu").Value
        Me.Label15.Text = xmlMaster.Attributes.GetNamedItem(strLanguage).Value

        Dim xmlLables As XmlNodeList = xmlResult.SelectNodes("lable")
        For Each lblXml As XmlNode In xmlLables
            'Button
            For i As Integer = 0 To 5
                Dim btnName As String = "btnMenu" & i.ToString()
                If lblXml.Attributes(0).Value = btnName Then
                    Dim btnControl As Button = Panel1.Controls.Find(btnName, True).First
                    btnControl.Text = lblXml.Attributes.GetNamedItem("enu").Value & vbCrLf & "(" & lblXml.Attributes.GetNamedItem(strLanguage).Value & ")"
                End If
            Next

            'Lable
            For i As Integer = 0 To 9
                Dim lblName As String = "lblTitle" & i.ToString()
                Dim lblName2 As String = "lblTitle" & i.ToString() & i.ToString()
                If lblXml.Attributes(0).Value = lblName Then
                    Dim lblControl As Label = Me.Controls.Find(lblName, True).First
                    Dim lblControl2 As Label = Me.Controls.Find(lblName2, True).First
                    lblControl.Text = lblXml.Attributes.GetNamedItem("enu").Value
                    lblControl2.Text = "(" & lblXml.Attributes.GetNamedItem(strLanguage).Value & ")"
                End If
            Next

            'DataGridView
            For i As Integer = 0 To 7
                Dim dgvName As String = "dgvHeader" & i.ToString()
                If lblXml.Attributes(0).Value = dgvName Then
                    Dim headName As String = lblXml.Attributes.GetNamedItem("enu").Value
                    Dim headName2 As String = lblXml.Attributes.GetNamedItem(strLanguage).Value
                    Select Case i
                        Case 0
                            HEADER_NAME.Add(COL_SENTAKU, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 1
                            HEADER_NAME.Add(COL_PROCESS_CODE, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 2
                            HEADER_NAME.Add(COL_DIVISION, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 3
                            HEADER_NAME.Add(COL_LINE_DIVISION, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 4
                            HEADER_NAME.Add(COL_BREAK_START_TIME, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 5
                            HEADER_NAME.Add(COL_BREAK_END_TIME, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 6
                            HEADER_NAME.Add(COL_BREAK_TIME, String.Format(HEADER_FORMAT, headName, headName2))
                        Case 7
                            HEADER_NAME.Add(COL_DATE_CHANGE_INDICATOR, String.Format(HEADER_FORMAT, headName, headName2))
                    End Select
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_M19_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetControlsLable()

        Me.cmbKoutei.Text = String.Empty
        Me.cmbKubun.Text = String.Empty
        Me.cmbLine.Text = String.Empty
        Me.txtStart.Text = String.Empty
        Me.txtEnd.Text = String.Empty
        Me.cmbHenkou.Text = String.Empty
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

        'データベース接続
        connent.fncCnOpen(cn)

        Dim dsDataSet As DataSet = New DataSet
        Dim dsDataSet2 As DataSet = New DataSet
        Dim sdaAdapter As SqlDataAdapter

        '工程コード
        Dim strSelect As String = xml.GetSQL("select", "select_002")
        sdaAdapter = New SqlDataAdapter(strSelect, cn)
        sdaAdapter.Fill(dsDataSet)
        Me.cmbKoutei.DataSource = dsDataSet.Tables(0)
        Me.cmbKoutei.ValueMember = "工程コード"
        Me.cmbKoutei.DisplayMember = "工程略称"

        sdaAdapter.Fill(dsDataSet2)
        Me.cmb_Koutei.DataSource = dsDataSet2.Tables(0)
        Me.cmb_Koutei.ValueMember = "工程コード"
        Me.cmb_Koutei.DisplayMember = "工程略称"

        '区分
        dsDataSet = New DataSet
        strSelect = xml.GetSQL("select", "select_003")
        sdaAdapter = New SqlDataAdapter(String.Format(strSelect, "45"), cn)
        sdaAdapter.Fill(dsDataSet)
        Me.cmbKubun.DataSource = dsDataSet.Tables(0)
        Me.cmbKubun.ValueMember = "コード"
        Me.cmbKubun.DisplayMember = "コード名称"

        'ライン区分
        dsDataSet = New DataSet
        strSelect = xml.GetSQL("select", "select_003")
        sdaAdapter = New SqlDataAdapter(String.Format(strSelect, "87"), cn)
        sdaAdapter.Fill(dsDataSet)
        Me.cmbLine.DataSource = dsDataSet.Tables(0)
        Me.cmbLine.ValueMember = "コード"
        Me.cmbLine.DisplayMember = "コード名称"

        connent.subCnClose(cn)

    End Sub

    ''' <summary>
    ''' クリア
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnMenu4.Click
        gridData.Columns.Clear()

        lblTitle2.Visible = False
        lblTitle22.Visible = False
        'gridData.Visible = False

        Me.cmbKoutei.SelectedIndex = -1
        Me.cmbKubun.SelectedIndex = -1
        Me.cmbLine.SelectedIndex = -1
        Me.cmb_Koutei.SelectedIndex = -1
        Me.txtStart.Text = String.Empty
        Me.txtEnd.Text = String.Empty

    End Sub

    ''' <summary>
    ''' 終了
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnMenu5.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
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
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        Dim strSelect As String = xml.GetSQL("select", "select_001")
        Dim strWhere As String = xml.GetSQL("where", "where_001")
        Dim strSort As String = xml.GetSQL("sort", "sort_001")
        Dim selectSql As String

        If String.IsNullOrEmpty(cmb_Koutei.Text) Then
            selectSql = strSelect & " " & strSort
        Else
            selectSql = strSelect & " " & String.Format(strWhere, cmb_Koutei.SelectedValue) & " " & strSort
        End If

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                dt = clsSQLServer.GetDataTable(selectSql)

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        Return dt

    End Function

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

        '重複チェック
        Dim dsDataSet As DataSet = New DataSet
        Dim sdaAdapter As SqlDataAdapter
        Dim strSelect As String = xml.GetSQL("select", "select_004")
        '工程コード/区分/ライン区分
        sdaAdapter = New SqlDataAdapter(String.Format(strSelect, strKouteiCode, strKubunCode, strLineCode), cn)
        sdaAdapter.Fill(dsDataSet)
        If dsDataSet.Tables.Count > 0 And dsDataSet.Tables(0).Rows.Count > 0 Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
            cmbKoutei.BackColor = Color.Red
            cmbKubun.BackColor = Color.Red
            cmbLine.BackColor = Color.Red
            Return
        Else
            cmbKoutei.BackColor = Color.White
            cmbKubun.BackColor = Color.White
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
        If txtStart.Text And REG_FORMAT.IsMatch(txtStart.Text) = False Then
            MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_START_TIME))
            txtStart.BackColor = Color.Red
            Return
        Else
            txtStart.BackColor = Color.White
        End If

        '休憩終了時間
        If txtEnd.Text And REG_FORMAT.IsMatch(txtEnd.Text) = False Then
            MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_END_TIME))
            txtEnd.BackColor = Color.Red
            Return
        Else
            txtEnd.BackColor = Color.White
        End If

        'データを追加
        If MsgBox(cmnUtil.GetMessageStr("Q0001"), vbOKCancel, TABLE_NAME) = DialogResult.OK Then

            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    Dim sqlstr As String = xml.GetSQL("insert", "insert_001")

                    'TODO
                    'clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                    '                                        strKouteiCode & ":" & strKouteiName,
                    '                                        strKubunCode & ":" & strKubunName,
                    '                                        strLineCode & ":" & strLineName,
                    '                                        txtStart.Text,
                    '                                        txtEnd.Text,
                    '                                        cmbHenkou.Text))
                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            strKouteiCode.Substring(3),
                                                            strKubunCode.Substring(1),
                                                            strLineCode.Substring(1),
                                                            txtStart.Text,
                                                            txtEnd.Text,
                                                            cmbHenkou.Text))

                    clsSQLServer.Disconnect()

                    '最新データを検索
                    btnSearch_Click(sender, e)

                    Me.cmbKoutei.SelectedIndex = -1
                    Me.cmbKubun.SelectedIndex = -1
                    Me.cmbLine.SelectedIndex = -1
                    Me.cmb_Koutei.SelectedIndex = -1
                    Me.txtStart.Text = String.Empty
                    Me.txtEnd.Text = String.Empty

                End If

            Catch ex As Exception
                Throw
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Update(更新)事件
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnMenu2.Click

        Dim bolSelect As Boolean = False
        Dim gridCells As DataGridViewCellCollection

        For i As Integer = 0 To gridData.Rows.Count - 1
            If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                gridCells = gridData.Rows(i).Cells

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
                    Return
                Else
                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                End If

                '休憩終了時間
                If strEndDT.Equals(String.Empty) = False And strEndDT.Length <> 5 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BREAK_END_TIME, 5))
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                    Return
                Else
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                End If

                '書式チェック
                '休憩開始時間
                If strStartDT And REG_FORMAT.IsMatch(strStartDT) = False Then
                    MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_START_TIME))
                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                    Return
                Else
                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                End If

                '休憩終了時間
                If strEndDT And REG_FORMAT.IsMatch(strEndDT) = False Then
                    MessageBox.Show(String.Format(MSG_FORMAT, COL_BREAK_END_TIME))
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                    Return
                Else
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                End If

                '存在チェック
                Dim dsDataSet As DataSet = New DataSet
                Dim sdaAdapter As SqlDataAdapter
                Dim strSelect As String = xml.GetSQL("select", "select_004")
                sdaAdapter = New SqlDataAdapter(String.Format(strSelect, strKouteiCode, strKubunCode, strLineCode), cn)
                sdaAdapter.Fill(dsDataSet)
                If dsDataSet.Tables.Count < 1 And dsDataSet.Tables(0).Rows.Count < 1 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                    Return
                Else
                    gridCells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                    gridCells(COL_BREAK_END_TIME).Style.BackColor = Color.White
                End If

                'データを更新
                If MsgBox(cmnUtil.GetMessageStr("Q0002"), vbOKCancel, TABLE_NAME) = DialogResult.OK Then

                    Try
                        If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                            Dim sqlstr As String = xml.GetSQL("update", "update_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                    strKouteiCode,
                                                    strKubunCode,
                                                    strLineCode,
                                                    strStartDT,
                                                    strEndDT,
                                                    strDataChangeIndicator))

                            clsSQLServer.Disconnect()

                            'btnSearch_Click(sender, e)

                        End If

                    Catch ex As Exception
                        Throw
                    End Try
                End If

                Exit For
            End If
        Next

    End Sub

    ''' <summary>
    ''' Delete(削除)事件
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnMenu3.Click

        Dim strKouteiCode As String
        Dim strKubunCode As String
        Dim strLineCode As String
        If MsgBox(cmnUtil.GetMessageStr("Q0003"), vbOKCancel, TABLE_NAME) = DialogResult.OK Then

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                            strKouteiCode = gridData.Rows(i).Cells(COL_PROCESS_CODE).Value
                            strKubunCode = gridData.Rows(i).Cells(COL_DIVISION).Value
                            strLineCode = gridData.Rows(i).Cells(COL_LINE_DIVISION).Value

                            '存在チェック
                            Dim dsDataSet As DataSet = New DataSet
                            Dim sdaAdapter As SqlDataAdapter
                            Dim strSelect As String = xml.GetSQL("select", "select_004")
                            sdaAdapter = New SqlDataAdapter(String.Format(strSelect, strKouteiCode, strKubunCode, strLineCode), cn)
                            sdaAdapter.Fill(dsDataSet)
                            If dsDataSet.Tables.Count < 1 And dsDataSet.Tables(0).Rows.Count < 1 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                                gridData.Rows(i).Cells(COL_BREAK_START_TIME).Style.BackColor = Color.Red
                                gridData.Rows(i).Cells(COL_BREAK_END_TIME).Style.BackColor = Color.Red
                                Return
                            Else
                                gridData.Rows(i).Cells(COL_BREAK_START_TIME).Style.BackColor = Color.White
                                gridData.Rows(i).Cells(COL_BREAK_END_TIME).Style.BackColor = Color.White

                                '削除
                                Dim sqlstr As String = xml.GetSQL("delete", "delete_001")

                                clsSQLServer.ExecuteQuery(String.Format(sqlstr, strKouteiCode, strKubunCode, strLineCode))

                            End If

                            Exit For
                        End If

                    Next

                    clsSQLServer.Disconnect()

                    '再検索
                    btnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub
End Class