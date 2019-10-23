Public Class SC_M15
    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"コード区分", "Code division" & vbCrLf & "(コード区分)"},
                             {"コード", "Code" & vbCrLf & "(コード)"},
                             {"コード名称", "Code name" & vbCrLf & "(コード名称)"},
                             {"コード名称（英語）", "Code division(English)" & vbCrLf & "(コード名称（英語）)"},
                             {"表示順序", "Display order" & vbCrLf & "(表示順序)"},
                             {"項目１", "Item 1" & vbCrLf & "(項目１)"},
                             {"項目２", "Item 2" & vbCrLf & "(項目２)"},
                             {"項目３", "Item 3" & vbCrLf & "(項目３)"},
                             {"項目４", "Item 4" & vbCrLf & "(項目４)"},
                             {"項目５", "Item 5" & vbCrLf & "(項目５)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }
    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_CODE_DIVISION As String = "コード区分"
    Private Const COL_CODE As String = "コード"
    Private Const COL_CODE_NAME As String = "コード名称"
    Private Const COL_CODE_NAME_ENGLISH As String = "コード名称（英語）"
    Private Const COL_DISPLAY_ORDER As String = "表示順序"
    Private Const COL_ITEM1 As String = "項目１"
    Private Const COL_ITEM2 As String = "項目２"
    Private Const COL_ITEM3 As String = "項目３"
    Private Const COL_ITEM4 As String = "項目４"
    Private Const COL_ITEM5 As String = "項目５"
    Private Const COL_REMARKS As String = "備考"
    Private Const CONST_DIVISION_CODE_NAME = "コード_名称"

    Dim xml As New CmnXML("SC-M15.xml", "SC-M15")
    Private Sub Init()
        controlClear()
        setCodeDivisionType("")
        xml.InitUser(Me.txtLoginUser, Me.TextBox1)
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

    Private Sub SC_M15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        controlColorClear()
        getDataToGrid(True)
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        gridData.Columns.Clear()
        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
        addColSentaku.HeaderText = headerName(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)

        For Each col As DataColumn In dtData.Columns
            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = col.ColumnName
            addCol.Name = col.ColumnName
            If col.ColumnName = COL_CODE_NAME Or col.ColumnName = COL_CODE_NAME_ENGLISH Or
                col.ColumnName = COL_ITEM3 Or col.ColumnName = COL_REMARKS Then
                addCol.MaxInputLength = 50
            ElseIf col.ColumnName = COL_ITEM1 Or col.ColumnName = COL_ITEM2 Or
                col.ColumnName = COL_ITEM4 Or col.ColumnName = COL_ITEM5 Then
                addCol.MaxInputLength = 20
            End If
            gridData.Columns.Add(addCol)
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_CODE_NAME, COL_CODE_NAME_ENGLISH, COL_ITEM2, COL_ITEM3, COL_ITEM4, COL_ITEM5, COL_REMARKS
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
        gridData.Columns(1).Width = 100
        gridData.Columns(2).Width = 100
        gridData.Columns(3).Width = 300
        gridData.Columns(4).Width = 300
        gridData.Columns(5).Width = 100
        gridData.Columns(6).Width = 200
        gridData.Columns(7).Width = 200
        gridData.Columns(8).Width = 300
        gridData.Columns(9).Width = 200
        gridData.Columns(10).Width = 200
        gridData.Columns(11).Width = 300

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
                For i As Integer = 3 To 11
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.Yellow
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 3 To 11
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    Private Sub getDataToGrid(flag As Boolean)
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim sqlStr As String
                If Me.cmbDivision.Text.Equals(String.Empty) Then
                    sqlStr = xml.GetSQL_Str("SELECT_001")
                Else
                    sqlStr = xml.GetSQL_Str("SELECT_003")
                    sqlStr = String.Format(sqlStr, (cmbDivision.Text.ToString().Split(":"))(0))

                End If
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(sqlStr)
                If (flag = True) Then
                    '0件の場合、メッセージを表示する
                    If dt.Rows.Count = 0 Then
                        Dim msg As New clsMessage("W0008")
                        MsgBox(msg.Show,
                               vbExclamation,
                               My.Settings.systemName)
                        Return
                    End If
                End If
                'gridView設定
                setGrid(dt)

            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim msg As New clsMessage("I0001")
        '追加確認メッセージ
        If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then
            Dim wMsg As New clsMessage("W0001")
            If txtDivision.Text.Equals(String.Empty) Then
                'コード区分必須チェック
                MsgBox(String.Format(wMsg.Show, COL_CODE_DIVISION), vbExclamation, My.Settings.systemName)
                txtDivision.BackColor = Color.Red
                Return
            Else
                txtDivision.BackColor = Color.White
            End If

            If txtCode.Text.Equals(String.Empty) Then
                'コード必須チェック
                MsgBox(String.Format(wMsg.Show, COL_CODE), vbExclamation, My.Settings.systemName)
                txtCode.BackColor = Color.Red
                Return
            Else
                txtCode.BackColor = Color.White
            End If

            If txtCodeName.Text.Equals(String.Empty) Then
                'コード名称必須チェック
                MsgBox(String.Format(wMsg.Show, COL_CODE_NAME), vbExclamation, My.Settings.systemName)
                txtCodeName.BackColor = Color.Red
                Return
            Else
                txtCodeName.BackColor = Color.White
            End If

            '表示順序最大値チェック
            If Not txtDisplayorder.SelectedText.Equals(String.Empty) Then
                If Convert.ToInt64(txtDisplayorder.SelectedText) > 2147483647 Or Convert.ToInt64(txtDisplayorder.SelectedText) < 0 Then
                    Dim maxLengthMsg As New clsMessage("W9002")
                    MsgBox(String.Format(maxLengthMsg.Show, COL_DISPLAY_ORDER), vbExclamation, My.Settings.systemName)
                    Return
                End If
            End If
            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    '追加処理の重複データをチェックする
                    Dim dt As New DataTable()
                    Dim sqlstr As String = xml.GetSQL_Str("SELECT_002")
                    sqlstr = String.Format(sqlstr, txtDivision.Text, txtCode.Text)

                    dt = clsSQLServer.GetDataTable(sqlstr)

                    If dt.Rows.Count > 0 Then

                        '重複データがある場合、メッセージを表示して、追加処理を終止する
                        msg = New clsMessage("W0009")

                        MsgBox(msg.Show, vbExclamation, My.Settings.systemName)

                        Return

                    End If

                    sqlstr = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            txtDivision.Text,
                                                            txtCode.Text,
                                                            txtCodeName.Text,
                                                            txtCodeNameEng.Text,
                                                            txtDisplayorder.SelectedText,
                                                            txtItem1.Text,
                                                            txtItem2.Text,
                                                            txtItem3.Text,
                                                            txtItem4.Text,
                                                            txtItem5.Text,
                                                            txtRemarks.Text))
                    setCodeDivisionType(Me.cmbDivision.Text)
                    getDataToGrid(False)

                End If

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
                controlClear()
            End Try

        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim msg As New clsMessage("I0002")
            Dim wMsg As New clsMessage("W9001")
            '更新確認メッセージ
            If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    Dim selectedCount As Boolean = False
                    'レコード存在しない場合、エラーが発生する
                    If gridData.Rows.Count = 0 Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        If gridData.Rows(i).Cells(0).Value = True Then
                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")
                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value,
                                                                    gridData.Rows(i).Cells(3).Value,
                                                                    gridData.Rows(i).Cells(4).Value,
                                                                    gridData.Rows(i).Cells(5).Value,
                                                                    gridData.Rows(i).Cells(6).Value,
                                                                    gridData.Rows(i).Cells(7).Value,
                                                                    gridData.Rows(i).Cells(8).Value,
                                                                    gridData.Rows(i).Cells(9).Value,
                                                                    gridData.Rows(i).Cells(10).Value,
                                                                    gridData.Rows(i).Cells(11).Value))
                            selectedCount = True
                        End If
                    Next
                    'レコードが選択されてないとエラー発生する
                    If selectedCount = False Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If
                    getDataToGrid(False)

                End If
            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
            controlClear()
            controlColorClear()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim msg As New clsMessage("I0003")
        '削除確認メッセージ
        If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then

            Dim wMsg As New clsMessage("W9001")
            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    Dim selectedCount As Boolean = False
                    Dim sqlstr As String
                    'レコード存在しない場合、エラーが発生する
                    If gridData.Rows.Count = 0 Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            sqlstr = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value))
                            selectedCount = True
                        End If

                    Next
                    'レコードが選択されてないとエラー発生する
                    If selectedCount = False Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If
                    If Not Me.cmbDivision.Text.Equals(String.Empty) Then
                        sqlstr = xml.GetSQL_Str("SELECT_003")
                        sqlstr = String.Format(sqlstr, (cmbDivision.Text.ToString().Split(":"))(0))
                        Dim dt As New DataTable()

                        dt = clsSQLServer.GetDataTable(sqlstr)

                        If dt.Rows.Count = 0 Then
                            MsgBox("検索条件のデータが削除されたため、全件検索実行する",
                                   vbExclamation,
                                   My.Settings.systemName)
                            Me.cmbDivision.Text = String.Empty
                        End If
                    End If
                    setCodeDivisionType(Me.cmbDivision.Text)
                    getDataToGrid(False)

                End If
            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
                'controlClear()
                controlColorClear()
            End Try
        End If
    End Sub


    ''' <summary>
    ''' クリア処理
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim msg As New clsMessage("I0009")
        'クリア確認メッセージ
        If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then

            gridData.Columns.Clear()
            controlClear()
            controlColorClear()
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Dim selectedCount As Boolean = False
        'レコードが選択される場合、保存されていないメッセージを表示する
        If gridData.Rows.Count > 0 Then
            For i As Integer = 0 To gridData.Rows.Count - 1
                '横位置
                If gridData.Rows(i).Cells(0).Value = True Then
                    selectedCount = True
                End If
            Next
            If selectedCount = True Then
                Dim wMsg As New clsMessage("W0099")
                If MsgBox(wMsg.Show, vbYesNoCancel + vbQuestion, My.Settings.systemName) = DialogResult.Yes Then
                    Me.Close()
                End If
            End If
        End If
        'レコードが選択されない場合、画面閉じるメッセージを表示する
        If selectedCount = False Then
            Dim msg As New clsMessage("I0099")
            If MsgBox(msg.Show, vbYesNo + vbQuestion, My.Settings.systemName) = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub setCodeDivisionType(ByVal str As String)

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String = xml.GetSQL_Str("SELECT_004")

                '検索条件部 コード区分
                Dim dt = clsSQLServer.GetDataTable(sqlstr)

                Me.cmbDivision.DataSource = dt
                Me.cmbDivision.DisplayMember = CONST_DIVISION_CODE_NAME
                Me.cmbDivision.ValueMember = dt.Columns.Item(0).ColumnName
            End If
            If Not IsNothing(str) Then
                Me.cmbDivision.Text = str
            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try
    End Sub

    '画面コントロールをクリアする
    Private Sub controlClear()
        'クリア処理の場合、検索条件部をクリアする
        Me.txtCode.Text = String.Empty
        Me.txtCodeName.Text = String.Empty
        Me.txtCodeNameEng.Text = String.Empty
        Me.txtDisplayorder.Text = String.Empty
        Me.txtDivision.Text = String.Empty
        Me.txtItem1.Text = String.Empty
        Me.txtItem2.Text = String.Empty
        Me.txtItem3.Text = String.Empty
        Me.txtItem4.Text = String.Empty
        Me.txtItem5.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
    End Sub

    '画面コントロールのカラーをクリアする
    Private Sub controlColorClear()
        Me.txtDivision.BackColor = Color.White
        Me.txtCode.BackColor = Color.White
        Me.txtCodeName.BackColor = Color.White
    End Sub

    Private Sub txtDisplayorder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDisplayorder.KeyPress
        'キーが [0]～[9] または [BackSpace] 以外の場合イベントをキャンセル
        If Not (("0"c <= e.KeyChar And e.KeyChar <= "9"c) Or e.KeyChar = ControlChars.Back) Then
            'コントロールの既定の処理を省略する場合は true
            e.Handled = True
        End If
    End Sub

    Private Sub gridData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles gridData.DataError
        'GridView数字チェック
        If e.ColumnIndex = gridData.Columns(5).Index Then
            MsgBox(clsGlobal.MSG2("W9003"),
                   vbExclamation,
                   My.Settings.systemName)
        End If

    End Sub
End Class