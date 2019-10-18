
Public Class SC_M10

    Class CustomComboBox
        Public Property Value As String
        Public Property Name As String

    End Class

    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"設備NO", "Facility NO" & vbCrLf & "(設備NO)"},
                             {"設備略称", "Facility abbreviation" & vbCrLf & "(設備略称)"},
                             {"標準通過工程コード", "Standard passing process code" & vbCrLf & "(標準通過工程コード)"},
                             {"ラインコード", "Line Code" & vbCrLf & "(ラインコード)"},
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"表示順序", "Display order" & vbCrLf & "(表示順序)"},
                             {"自動ラベルフラグ", "Auto label flag" & vbCrLf & "(自動ラベルフラグ)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_SCODE As String = "設備NO"
    Private Const COL_SNAME As String = "設備略称"
    Private Const COL_HKOUTEI As String = "標準通過工程コード"
    Private Const COL_LINE As String = "ラインコード"
    Private Const COL_KOUTEI As String = "工程コード"
    Private Const COL_ORDER As String = "表示順序"
    Private Const COL_LABEL As String = "自動ラベルフラグ"
    Private Const COL_BIKOU As String = "備考"

    Private Const TABLE_NAME As String = "設備マスタ"
    Private Const MSG_NUMERICAL As String = "{0}は数値で入力してください。"

    Dim xml As New CmnXML("SC-M10.xml", "SC-M10")
    '自動ラベルフラグ設定
    Dim AUTO_LABEL As New List(Of CustomComboBox) From {
            New CustomComboBox With {.Value = "-1", .Name = " "},
            New CustomComboBox With {.Value = "0", .Name = "０：手動ラベル"},
            New CustomComboBox With {.Value = "1", .Name = "１：自動ラベル"}}


    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable

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

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        Return dt

    End Function

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
                Case COL_HKOUTEI
                Case COL_LINE
                Case COL_KOUTEI
                Case COL_LABEL
                    Dim addCol As New DataGridViewComboBoxColumn()
                    addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                    addCol.FlatStyle = FlatStyle.Flat
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = HEADER_NAME(col.ColumnName)
                    addCol.Name = col.ColumnName
                    addCol.DataSource = AUTO_LABEL
                    addCol.ValueMember = "Name"
                    addCol.DisplayMember = "Name"
                    gridData.Columns.Add(addCol)
                Case Else
                    Dim addCol As New DataGridViewTextBoxColumn()
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = col.ColumnName
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
        Dim dtResult As DataTable = createGridData()

        'データ確認
        If dtResult Is Nothing Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0008"))
            Return
        End If

        setGrid(dtResult)

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

        Me.cmb_Kbn.Text = String.Empty
        Me.txtScode.Text = String.Empty
        Me.txtSname.Text = String.Empty
        Me.cmbSkoutei.Text = String.Empty
        Me.cmbLine.Text = String.Empty
        Me.cmbCoutei.Text = String.Empty
        Me.txtSort.Text = String.Empty
        Me.cmbLabel.Text = String.Empty
        Me.txtLabel.Text = String.Empty

        Try
            Dim strSelect As String
            Dim dt As New DataTable

            '自動ラベルフラグ
            'Me.cmbLabel.DataSource = AUTO_LABEL
            'Me.cmbLabel.ValueMember = "Value"
            'Me.cmbLabel.DisplayMember = "Name"

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '検索条件　工程コード
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Kbn.DataSource = dt
                Me.cmb_Kbn.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmb_Kbn.DisplayMember = dt.Columns.Item(1).ColumnName

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

                'ライン区分
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, "87"))
                Me.cmbLine.DataSource = dt
                Me.cmbLine.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbLine.DisplayMember = dt.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
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
                    MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                    txtScode.BackColor = Color.Red
                    Return
                Else
                    txtScode.BackColor = Color.White
                End If

                'データを追加
                If MsgBox(cmnUtil.GetMessageStr("Q0001"), vbOKCancel, TABLE_NAME) = DialogResult.OK Then
                    Dim sqlstr As String = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr, "0",
                                                                txtScode.Text,
                                                                txtSname.Text,
                                                                cmbSkoutei.SelectedValue,
                                                                If(cmbLine.Text Is String.Empty, DBNull.Value, cmbLine.SelectedValue),
                                                                If(cmbCoutei.Text Is String.Empty, DBNull.Value, cmbCoutei.SelectedValue),
                                                                If(txtSort.Text Is String.Empty, DBNull.Value, CInt(txtSort.Text)),
                                                                If(cmbLabel.Text Is String.Empty, DBNull.Value, cmbLabel.SelectedValue),
                                                                txtLabel.Text))

                    clsSQLServer.Disconnect()

                    '最新データを検索
                    btnSearch_Click(sender, e)

                    Me.cmb_Kbn.Text = String.Empty
                    Me.txtScode.Text = String.Empty
                    Me.txtSname.Text = String.Empty
                    Me.cmbSkoutei.Text = String.Empty
                    Me.cmbLine.Text = String.Empty
                    Me.cmbCoutei.Text = String.Empty
                    Me.txtSort.Text = String.Empty
                    Me.cmbLabel.Text = String.Empty
                    Me.txtLabel.Text = String.Empty

                End If

            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    ''' <summary>
    ''' 　更新ボタン押下
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim gridCells As DataGridViewCellCollection

        Try

            For i As Integer = 0 To gridData.Rows.Count - 1
                If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                    If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                        gridCells = gridData.Rows(i).Cells

                        Dim strScode As String = gridCells(COL_SCODE).Value
                        Dim strSname As String = gridCells(COL_SNAME).Value
                        Dim strHkoutei As String = gridCells(COL_HKOUTEI).Value
                        Dim strLine As String = gridCells(COL_LINE).Value
                        Dim strKoutei As String = gridCells(COL_KOUTEI).Value
                        Dim strOrder As String = gridCells(COL_ORDER).Value
                        Dim strLabel As String = gridCells(COL_LABEL).Value
                        Dim strBikou As String = gridCells(COL_BIKOU).Value

                        '必須チェック
                        '設備略称
                        If strSname.Equals(String.Empty) Then
                            MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_SNAME))
                            gridCells(COL_SNAME).Style.BackColor = Color.Red
                            Return
                        Else
                            gridCells(COL_SNAME).Style.BackColor = Color.White
                        End If

                        '標準通過工程コード
                        If strHkoutei.Equals(String.Empty) Then
                            MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_HKOUTEI))
                            gridCells(COL_HKOUTEI).Style.BackColor = Color.Red
                            Return
                        Else
                            gridCells(COL_HKOUTEI).Style.BackColor = Color.White
                        End If

                        '桁数チェック
                        '設備略称
                        If strSname.Equals(String.Empty) = False And strSname.Length > 20 Then
                            MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_SNAME, 20))
                            gridCells(COL_SNAME).Style.BackColor = Color.Red
                            Return
                        Else
                            gridCells(COL_SNAME).Style.BackColor = Color.White
                        End If

                        '備考
                        If strBikou.Equals(String.Empty) = False And strBikou.Length > 50 Then
                            MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_BIKOU, 50))
                            gridCells(COL_BIKOU).Style.BackColor = Color.Red
                            Return
                        Else
                            gridCells(COL_BIKOU).Style.BackColor = Color.White
                        End If

                        '数値チェック
                        '表示順序
                        If strOrder.Equals(String.Empty) = False And IsNumeric(strOrder) = False Then
                            MessageBox.Show(String.Format(MSG_NUMERICAL, COL_ORDER))
                            gridCells(COL_ORDER).Style.BackColor = Color.Red
                            Return
                        Else
                            gridCells(COL_ORDER).Style.BackColor = Color.Red
                        End If

                        '存在チェック
                        Dim resultData As DataTable = New DataTable
                        Dim strSelect As String = xml.GetSQL_Str("SELECT_005")
                        '設備NO
                        resultData = clsSQLServer.GetDataTable(String.Format(strSelect, strScode))
                        If resultData Is Nothing Or resultData.Rows.Count < 1 Then
                            MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                            gridData.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            'gridCells(COL_SCODE).Style.BackColor = Color.Red
                            Return
                        Else
                            gridData.Rows(i).DefaultCellStyle.BackColor = Color.White
                            'gridCells(COL_SCODE).Style.BackColor = Color.White
                        End If

                        'データを更新
                        If MsgBox(cmnUtil.GetMessageStr("Q0002"), vbOKCancel, TABLE_NAME) = DialogResult.OK Then

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

                            clsSQLServer.Disconnect()

                            btnSearch_Click(sender, e)

                        End If

                    End If

                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 　削除ボタン押下
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridData.Columns.Clear()

        Me.cmb_Kbn.Text = String.Empty
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
    ''' 　EXCELボタン押下
    ''' </summary>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        MsgBox("グリッドの内容がEXCEL出力される予定です。")
    End Sub

End Class

