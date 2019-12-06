
Imports System.Xml

Public Class SC_M10

    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"設備NO", "Equipment NO" & vbCrLf & "(設備NO)"},
                             {"設備名", "Equipment name" & vbCrLf & "(設備名)"},
                             {"中工程コード", "Middle_process_code" & vbCrLf & "(中工程コード)"},
                             {"ラインコード", "Line Code" & vbCrLf & "(ラインコード)"},
                             {"大工程コード", "Large process code" & vbCrLf & "(大工程コード)"},
                             {"表示順序", "Display order" & vbCrLf & "(表示順序)"},
                             {"自動ラベルフラグ", "Automatic label flag" & vbCrLf & "(自動ラベルフラグ)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_SCODE As String = "設備NO"
    Private Const COL_SNAME As String = "設備名"
    Private Const COL_HKOUTEI As String = "中工程コード"
    Private Const COL_LINE As String = "ラインコード"
    Private Const COL_KOUTEI As String = "大工程コード"
    Private Const COL_ORDER As String = "表示順序"
    Private Const COL_LABEL As String = "自動ラベルフラグ"
    Private Const COL_BIKOU As String = "備考"

    Private Const TABLE_NAME As String = "設備マスタ"
    Private Const MSG_NUMERICAL As String = "{0}は数値で入力してください。"
    Private Const HEADER_FORMAT As String = "{0}" + vbCrLf + "({1})"
    Private Const XML_FORMAT As String = "Language[@name='{0}']"

    Dim xml As New CmnXML("SC-M10.xml", "SC-M10")
    Dim strLanguage As String = "jpn"

    '標準通過工程コード
    Dim dtHkoutei As New DataTable
    'ラインコード
    Dim dtLine As New DataTable
    '工程コード
    Dim dtkoutei As New DataTable
    '自動ラベルフラグ設定
    Dim dtAutoLabel As New DataTable

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)

        gridData.Columns.Clear()

        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = HEADER_NAME(COL_SENTAKU)
        addColSentaku.HeaderText = HEADER_NAME(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)

        For Each col As DataColumn In dtData.Columns
            Select Case col.ColumnName
                Case COL_HKOUTEI, COL_LINE, COL_KOUTEI, COL_LABEL
                    Dim addCol As New DataGridViewComboBoxColumn()
                    addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                    addCol.FlatStyle = FlatStyle.Flat
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = HEADER_NAME(col.ColumnName)
                    addCol.Name = col.ColumnName

                    Dim newDT As New DataTable
                    Select Case col.ColumnName
                        Case COL_HKOUTEI
                            newDT = dtHkoutei
                        Case COL_LINE
                            newDT = dtLine
                        Case COL_KOUTEI
                            newDT = dtkoutei
                        Case COL_LABEL
                            newDT = dtAutoLabel
                    End Select

                    addCol.DataSource = newDT
                    addCol.ValueMember = newDT.Columns.Item(0).ColumnName
                    addCol.DisplayMember = newDT.Columns.Item(1).ColumnName

                    gridData.Columns.Add(addCol)

                Case Else
                    Dim addCol As New DataGridViewTextBoxColumn()
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = HEADER_NAME(col.ColumnName)
                    addCol.Name = col.ColumnName
                    gridData.Columns.Add(addCol)
            End Select
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_SNAME, COL_LABEL, COL_BIKOU
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 125
        gridData.Columns(2).Width = 160
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 110
        gridData.Columns(5).Width = 110
        gridData.Columns(6).Width = 90
        gridData.Columns(7).Width = 120
        gridData.Columns(8).Width = 320

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
    ''' 検索ボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim dt As New DataTable
        Dim strSelect As String = xml.GetSQL_Str("SELECT_001")
        Dim strWhere As String = xml.GetSQL_Str("WHERE_001")
        Dim selectSql As String

        If String.IsNullOrEmpty(cmb_Kbn.Text) Then
            selectSql = String.Format(strSelect, "")
        Else
            selectSql = String.Format(strSelect, String.Format(strWhere, cmb_Kbn.SelectedValue))
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
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_M10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim strSelect As String
            Dim dt As New DataTable

            dt.Columns.Add("Code", GetType(String))
            dt.Columns.Add("Name", GetType(String))
            dt.Rows.Add(" ", "")
            dt.Rows.Add("0", "０：手動ラベル")
            dt.Rows.Add("1", "１：自動ラベル")

            '自動ラベルフラグ
            Me.cmbLabel.DataSource = dt
            Me.cmbLabel.ValueMember = dt.Columns.Item(0).ColumnName
            Me.cmbLabel.DisplayMember = dt.Columns.Item(1).ColumnName

            dtAutoLabel.Columns.Add("Code", GetType(String))
            dtAutoLabel.Columns.Add("Name", GetType(String))
            dtAutoLabel.Rows.Add(" ", "")
            dtAutoLabel.Rows.Add("0", "０：手動ラベル")
            dtAutoLabel.Rows.Add("1", "１：自動ラベル")

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '検索条件　工程コード
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Kbn.DataSource = dt
                Me.cmb_Kbn.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmb_Kbn.DisplayMember = dt.Columns.Item(1).ColumnName

                dtkoutei = clsSQLServer.GetDataTable(strSelect)

                '工程コード
                Dim dt2 As New DataTable
                dt2 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbCoutei.DataSource = dt2
                Me.cmbCoutei.ValueMember = dt2.Columns.Item(0).ColumnName
                Me.cmbCoutei.DisplayMember = dt2.Columns.Item(1).ColumnName

                '標準通過工程コード
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbSkoutei.DataSource = dt
                Me.cmbSkoutei.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbSkoutei.DisplayMember = dt.Columns.Item(1).ColumnName

                dtHkoutei = clsSQLServer.GetDataTable(strSelect)
                Dim dr As DataRow = dtHkoutei.Rows(0)
                dtHkoutei.Rows.Remove(dr)

                'ライン区分
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, "87"))
                Me.cmbLine.DataSource = dt
                Me.cmbLine.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbLine.DisplayMember = dt.Columns.Item(1).ColumnName

                dtLine = clsSQLServer.GetDataTable(String.Format(strSelect, "87"))

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try

        Me.cmb_Kbn.Text = String.Empty

        controlsClear()

    End Sub

    ''' <summary>
    ''' 画面コントロールのカラーをクリアする
    ''' </summary>
    Private Sub controlsColorClear()

        Me.txtScode.BackColor = Color.White
        Me.txtSname.BackColor = Color.White
        Me.cmbSkoutei.BackColor = Color.White
        Me.cmbLine.BackColor = Color.White
        Me.cmbCoutei.BackColor = Color.White
        Me.txtSort.BackColor = Color.White
        Me.cmbLabel.BackColor = Color.White
        Me.txtLabel.BackColor = Color.White

    End Sub


    ''' <summary>
    ''' 画面コントロールをクリアする
    ''' </summary>
    Private Sub controlsClear()

        Me.txtScode.Text = String.Empty
        Me.txtSname.Text = String.Empty
        Me.cmbSkoutei.Text = String.Empty
        Me.cmbLine.Text = String.Empty
        Me.cmbCoutei.Text = String.Empty
        Me.txtSort.Text = String.Empty
        Me.cmbLabel.Text = String.Empty
        Me.txtLabel.Text = String.Empty

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

                For i As Integer = 2 To 8
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 2 To 8
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' Insert(追加)事件
    ''' </summary>
    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            '必須チェック
            '設備NO
            If txtScode.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_SCODE))
                txtScode.BackColor = Color.Red
                Return
            Else
                txtScode.BackColor = Color.White
            End If

            '設備略称
            If txtSname.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_SNAME))
                txtSname.BackColor = Color.Red
                Return
            Else
                txtSname.BackColor = Color.White
            End If

            '標準通過工程コード
            If cmbSkoutei.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_HKOUTEI))
                cmbSkoutei.BackColor = Color.Red
                Return
            Else
                cmbSkoutei.BackColor = Color.White
            End If

            '桁数チェック
            '設備NO
            If txtScode.Text.Equals(String.Empty) = False And txtScode.Text.Length > 4 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_SCODE, 4))
                txtScode.BackColor = Color.Red
                Return
            Else
                txtScode.BackColor = Color.White
            End If

            '設備略称
            If txtSname.Text.Equals(String.Empty) = False And txtSname.Text.Length > 20 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_SNAME, 20))
                txtSname.BackColor = Color.Red
                Return
            Else
                txtSname.BackColor = Color.White
            End If

            '備考
            If txtLabel.Text.Equals(String.Empty) = False And txtLabel.Text.Length > 50 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BIKOU, 50))
                txtLabel.BackColor = Color.Red
                Return
            Else
                txtLabel.BackColor = Color.White
            End If

            '数値チェック
            '表示順序
            If txtSort.Text.Equals(String.Empty) = False And IsNumeric(txtSort.Text) = False Then
                MessageBox.Show(String.Format(MSG_NUMERICAL, COL_ORDER))
                txtSort.BackColor = Color.Red
                Return
            Else
                txtSort.BackColor = Color.White
            End If

            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '重複チェック
                    Dim resultData As DataTable = New DataTable
                    Dim strSelect As String = xml.GetSQL_Str("SELECT_005")
                    '設備NO
                    resultData = clsSQLServer.GetDataTable(String.Format(strSelect, txtScode.Text))
                    If resultData IsNot Nothing And resultData.Rows.Count > 0 Then
                        '重複データがある場合、メッセージを表示して、追加処理を終止する
                        MsgBox(String.Format(clsGlobal.MSG2("W0009")),
                               vbExclamation,
                               My.Settings.systemName)

                        clsSQLServer.Disconnect()

                        Return
                    End If

                    'データを追加
                    Dim sqlstr As String = xml.GetSQL_Str("INSERT_001")

                    Dim ssr = String.Format(sqlstr, "0",
                                                                txtScode.Text,
                                                                txtSname.Text,
                                                                "0",
                                                                If(cmbCoutei.Text Is String.Empty, DBNull.Value, cmbCoutei.SelectedValue),
                                                                cmbSkoutei.SelectedValue,
                                                                If(cmbLine.Text Is String.Empty, DBNull.Value, cmbLine.SelectedValue),
                                                                If(txtSort.Text Is String.Empty, "NULL", "'" & CInt(txtSort.Text) & "'"),
                                                                If(cmbLabel.Text Is String.Empty, DBNull.Value, cmbLabel.SelectedValue),
                                                                txtLabel.Text)
                    clsSQLServer.ExecuteQuery(String.Format(sqlstr, "0",
                                                                txtScode.Text,
                                                                txtSname.Text,
                                                                "0",
                                                                If(cmbCoutei.Text Is String.Empty, DBNull.Value, cmbCoutei.SelectedValue),
                                                                cmbSkoutei.SelectedValue,
                                                                If(cmbLine.Text Is String.Empty, DBNull.Value, cmbLine.SelectedValue),
                                                                If(txtSort.Text Is String.Empty, "NULL", "'" & CInt(txtSort.Text) & "'"),
                                                                If(cmbLabel.Text Is String.Empty, DBNull.Value, cmbLabel.SelectedValue),
                                                                txtLabel.Text))

                    'clsSQLServer.ExecuteQuery(String.Format(sqlstr, "0",
                    '                                            txtScode.Text,
                    '                                            txtSname.Text,
                    '                                            cmbSkoutei.SelectedValue,
                    '                                            If(cmbLine.Text Is String.Empty, DBNull.Value, cmbLine.SelectedValue),
                    '                                            If(cmbCoutei.Text Is String.Empty, DBNull.Value, cmbCoutei.SelectedValue),
                    '                                            If(txtSort.Text Is String.Empty, DBNull.Value, CInt(txtSort.Text)),
                    '                                            If(cmbLabel.Text Is String.Empty, DBNull.Value, cmbLabel.SelectedValue),
                    '                                            txtLabel.Text))

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
    ''' 　更新ボタン押下
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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

                            Dim strScode, strSname, strHkoutei, strLine, strKoutei, strLabel, strBikou As String
                            Dim strOrder

                            If IsDBNull(gridCells(COL_SCODE).Value) Then
                                strScode = String.Empty
                            Else
                                strScode = gridCells(COL_SCODE).Value
                            End If
                            If IsDBNull(gridCells(COL_SNAME).Value) Then
                                strSname = String.Empty
                            Else
                                strSname = gridCells(COL_SNAME).Value
                            End If
                            If IsDBNull(gridCells(COL_HKOUTEI).Value) Then
                                strHkoutei = String.Empty
                            Else
                                strHkoutei = gridCells(COL_HKOUTEI).Value
                            End If
                            If IsDBNull(gridCells(COL_LINE).Value) Then
                                strLine = String.Empty
                            Else
                                strLine = gridCells(COL_LINE).Value
                            End If
                            If IsDBNull(gridCells(COL_KOUTEI).Value) Then
                                strKoutei = String.Empty
                            Else
                                strKoutei = gridCells(COL_KOUTEI).Value
                            End If
                            If IsDBNull(gridCells(COL_ORDER).Value) Then
                                strOrder = String.Empty
                                'strOrder = DBNull.Value
                            Else
                                strOrder = gridCells(COL_ORDER).Value
                            End If
                            If IsDBNull(gridCells(COL_LABEL).Value) Then
                                strLabel = String.Empty
                            Else
                                strLabel = gridCells(COL_LABEL).Value
                            End If
                            If IsDBNull(gridCells(COL_BIKOU).Value) Then
                                strBikou = String.Empty
                            Else
                                strBikou = gridCells(COL_BIKOU).Value
                            End If

                            'Dim strScode As String = getdbdata(gridCells(COL_SCODE).Value)
                            'Dim strSname As String = getdbdata(gridCells(COL_SNAME).Value)
                            'Dim strHkoutei As String = getdbdata(gridCells(COL_HKOUTEI).Value)
                            'Dim strLine As String = getdbdata(gridCells(COL_LINE).Value)
                            'Dim strKoutei As String = getdbdata(gridCells(COL_KOUTEI).Value)
                            'Dim strOrder As String = getdbdata(gridCells(COL_ORDER).Value)
                            'Dim strLabel As String = getdbdata(gridCells(COL_LABEL).Value)
                            'Dim strBikou As String = getdbdata(gridCells(COL_BIKOU).Value)

                            '必須チェック
                            '設備略称
                            If strSname.Equals(String.Empty) Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_SNAME))
                                gridCells(COL_SNAME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_SNAME).Style.BackColor = Color.White
                            End If

                            '標準通過工程コード
                            If strHkoutei.Equals(String.Empty) Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_HKOUTEI))
                                gridCells(COL_HKOUTEI).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_HKOUTEI).Style.BackColor = Color.White
                            End If

                            '桁数チェック
                            '設備略称
                            If strSname.Equals(String.Empty) = False And strSname.Length > 20 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_SNAME, 20))
                                gridCells(COL_SNAME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_SNAME).Style.BackColor = Color.White
                            End If

                            '備考
                            If strBikou.Equals(String.Empty) = False And strBikou.Length > 50 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BIKOU, 50))
                                gridCells(COL_BIKOU).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_BIKOU).Style.BackColor = Color.White
                            End If

                            '数値チェック
                            '表示順序
                            If strOrder.Equals(String.Empty) = False And IsNumeric(strOrder) = False Then
                                MessageBox.Show(String.Format(MSG_NUMERICAL, COL_ORDER))
                                gridCells(COL_ORDER).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_ORDER).Style.BackColor = Color.White
                            End If


                            'データを更新
                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")
                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                        strScode,
                                                                        strSname,
                                                                        strHkoutei,
                                                                        strLine,
                                                                        strKoutei,
                                                                        strOrder,
                                                                        strLabel,
                                                                        strBikou))

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
    ''' 　削除ボタン押下
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

                            Dim strScode As String = gridData.Rows(i).Cells(COL_SCODE).Value

                            '削除
                            Dim sqlstr As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr, strScode))

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

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            gridData.Columns.Clear()

            Me.cmb_Kbn.Text = String.Empty

            controlsClear()

            controlsColorClear()

        End If

    End Sub

    ''' <summary>
    ''' 　EXCELボタン押下
    ''' </summary>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        MsgBox("グリッドの内容がEXCEL出力される予定です。")
    End Sub


    Function getdbdata(str As String)
        Dim dbdata As String = String.Empty

        If IsDBNull(str) Then
            dbdata = String.Empty
        Else
            dbdata = str
        End If

        Return dbdata

    End Function

End Class



