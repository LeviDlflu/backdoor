Public Class SC_M13

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"不良コード", "Defect code" & vbCrLf & "(不良コード)"},
                             {"不良現象名", "Defect phenomenon name" & vbCrLf & "(不良現象名)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"},
                             {"表示区分", "Display division" & vbCrLf & "(表示区分)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_DEFECT_CODE As String = "不良コード"
    Private Const COL_DEFECT_PHENOMENON_NAME As String = "不良現象名"
    Private Const COL_REMARKS As String = "備考"
    Private Const COL_DISPLAY_DIVISION As String = "表示区分"

    Private Const CONST_PROCESS_NAME = "工程コード_略称"

    Dim xml As New CmnXML("SC-M13.xml", "SC-M13")

    '初期処理
    Private Sub Init()
        controlClear(True)
        setProcessCodeType()

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

    '画面Load
    Private Sub SC_M13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Dim selectedCount As Boolean = False
        'レコードを選択される場合、保存されていないメッセージを表示する
        If gridData.Rows.Count > 0 Then
            For i As Integer = 0 To gridData.Rows.Count - 1
                '横位置
                If gridData.Rows(i).Cells(0).Value = True Then
                    selectedCount = True
                End If
            Next
            If selectedCount = True Then
                Dim wMsg As New clsMessage("W0099")
                If MsgBox(wMsg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then
                    Me.Close()
                End If
            End If
        End If
        'レコードを選択されない場合、画面閉じるメッセージを表示する
        If selectedCount = False Then
            Dim msg As New clsMessage("I0099")
            If MsgBox(msg.Show, vbYesNo + vbQuestion, My.Settings.systemName) = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'controlClear(False)
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
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName
            If col.ColumnName = COL_DEFECT_PHENOMENON_NAME Then
                addCol.MaxInputLength = 14
            ElseIf col.ColumnName = COL_REMARKS Then
                addCol.MaxInputLength = 50
            ElseIf col.ColumnName = COL_DISPLAY_DIVISION Then
                addCol.MaxInputLength = 1
            End If
            gridData.Columns.Add(addCol)
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_DEFECT_PHENOMENON_NAME, COL_REMARKS
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
        gridData.Columns(1).Width = 150
        gridData.Columns(2).Width = 150
        gridData.Columns(3).Width = 400
        gridData.Columns(4).Width = 400
        gridData.Columns(5).Width = 100


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

    ''' <summary>
    '''   追加処理
    ''' </summary>
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim msg As New clsMessage("I0001")
        '追加確認メッセージ
        If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then
            Dim wMsg As New clsMessage("W0001")
            If cmbProcess.Text.Equals(String.Empty) Then
                '工程コード必須チェック
                MsgBox(String.Format(wMsg.Show, COL_PROCESS_CODE), vbExclamation, COL_PROCESS_CODE)
                cmbProcess.BackColor = Color.Red
                cmbProcess.Focus()
                Return
            Else
                cmbProcess.BackColor = Color.White
            End If

            If txtDefect.Text.Equals(String.Empty) Then
                '不良コード必須チェック
                MsgBox(String.Format(wMsg.Show, COL_DEFECT_CODE), vbExclamation, COL_DEFECT_CODE)
                txtDefect.BackColor = Color.Red
                Return
            Else
                txtDefect.BackColor = Color.White
            End If

            If txtDefectName.Text.Equals(String.Empty) Then
                '不良現象名必須チェック
                MsgBox(String.Format(wMsg.Show, COL_DEFECT_PHENOMENON_NAME), vbExclamation, COL_DEFECT_PHENOMENON_NAME)
                txtDefectName.BackColor = Color.Red
                Return
            Else
                txtDefectName.BackColor = Color.White
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    '追加処理の重複データをチェックする
                    Dim dt As New DataTable()
                    Dim sqlstr As String = xml.GetSQL_Str("SELECT_002")
                    sqlstr = String.Format(sqlstr, cmbProcess.SelectedValue, txtDefect.Text)

                    dt = clsSQLServer.GetDataTable(sqlstr)

                    If dt.Rows.Count > 0 Then

                        '重複データがある場合、メッセージを表示して、追加処理を終止する
                        msg = New clsMessage("W0009")

                        MsgBox(msg.Show, vbExclamation, My.Settings.systemName)

                        clsSQLServer.Disconnect()

                        Return

                    End If

                    sqlstr = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            cmbProcess.SelectedValue,
                                                            txtDefect.Text,
                                                            txtDefectName.Text,
                                                            txtRemarks.Text,
                                                            txtDisplaydivision.Text))
                    getDataToGrid(False)

                End If

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
                controlClear(False)
            End Try

        End If
    End Sub

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim msg As New clsMessage("I0002")
            '更新確認メッセージ
            If MsgBox(msg.Show, vbOKCancel + vbQuestion, My.Settings.systemName) = DialogResult.OK Then
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        If gridData.Rows(i).Cells(0).Value = True Then
                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")
                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value,
                                                                    gridData.Rows(i).Cells(3).Value,
                                                                    gridData.Rows(i).Cells(4).Value,
                                                                    gridData.Rows(i).Cells(5).Value))
                        End If
                    Next
                    getDataToGrid(False)

                End If
            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
            controlClear(False)
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
                    'レコード存在しない場合、エラーが発生する
                    If gridData.Rows.Count = 0 Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            Dim sqlstr As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value))
                            selectedCount = True
                        End If

                    Next
                    '選択されてないレコードがエラー発生する
                    If selectedCount = False Then
                        MsgBox(wMsg.Show, vbExclamation, My.Settings.systemName)
                        Return
                    End If

                    getDataToGrid(False)

                End If
            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
                controlClear(False)
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
            controlClear(True)
            controlColorClear()
        End If
    End Sub

    Private Sub setProcessCodeType()

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String = xml.GetSQL_Str("SELECT_004")

                '検索条件部 工程コード
                Dim dt = clsSQLServer.GetDataTable(sqlstr)
                '空白行追加
                Dim drWork As DataRow = dt.NewRow
                drWork(dt.Columns.Item(0).ColumnName) = "0"
                drWork(dt.Columns.Item(1).ColumnName) = " "
                drWork(CONST_PROCESS_NAME) = ""
                dt.Rows.InsertAt(drWork, 0)

                Me.cmbProcessCode.DataSource = dt
                Me.cmbProcessCode.DisplayMember = CONST_PROCESS_NAME
                Me.cmbProcessCode.ValueMember = dt.Columns.Item(0).ColumnName

                '追加部 工程コード
                Dim dt2 = dt.Copy()

                Me.cmbProcess.DataSource = dt2
                Me.cmbProcess.DisplayMember = CONST_PROCESS_NAME
                Me.cmbProcess.ValueMember = dt2.Columns.Item(0).ColumnName
            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try
    End Sub

    Private Sub getDataToGrid(flag As Boolean)
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim sqlStr As String
                If Me.cmbProcessCode.Text.Equals(String.Empty) Then
                    sqlStr = xml.GetSQL_Str("SELECT_001")
                Else
                    sqlStr = xml.GetSQL_Str("SELECT_003")
                    sqlStr = String.Format(sqlStr, cmbProcessCode.SelectedValue)

                End If
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(sqlStr)
                If (flag = True) Then
                    '0件の場合、メッセージを表示する
                    If dt.Rows.Count = 0 Then
                        Dim msg As New clsMessage("W0008")
                        MsgBox(msg.Show, vbExclamation, My.Settings.systemName)
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

    '画面コントロールをクリアする
    Private Sub controlClear(checkFlag As Boolean)
        'クリア処理の場合、検索条件部をクリアする
        If (checkFlag = True) Then
            Me.cmbProcessCode.Text = String.Empty
        End If

        Me.cmbProcess.Text = String.Empty
        Me.txtDefect.Text = String.Empty
        Me.txtDefectName.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
        Me.txtDisplaydivision.Text = 0
    End Sub

    '画面コントロールのカラーをクリアする
    Private Sub controlColorClear()
        Me.cmbProcess.BackColor = Color.White
        Me.txtDefect.BackColor = Color.White
        Me.txtDefectName.BackColor = Color.White
        Me.txtRemarks.BackColor = Color.White
        Me.txtDisplaydivision.BackColor = Color.White
    End Sub

    '追加部の工程コードCombox入力制御
    Private Sub cmbProcess_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProcess.KeyPress
        e.Handled = True
        Return
    End Sub

End Class