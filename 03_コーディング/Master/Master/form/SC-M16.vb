Public Class SC_M16

    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"プログラムID", "Program ID" & vbCrLf & "(プログラムID)"},
                             {"画面ID", "Form ID" & vbCrLf & "(画面ID)"},
                             {"画面名称", "Form name" & vbCrLf & "(画面名称)"},
                             {"グループID", "Group ID" & vbCrLf & "(グループID)"},
                             {"権限", "Authority name" & vbCrLf & "(権限名)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_PROGRAM_ID As String = "プログラムID"
    Private Const COL_FORM_ID As String = "画面ID"
    Private Const COL_FORM_NAME As String = "画面名称"
    Private Const COL_GROUP_ID As String = "グループID"
    Private Const COL_AUTHORITY_NAME As String = "権限"

    Dim xml As New CmnXML("SC-M16.xml", "SC-M16")

    Dim dataTable As New DataTable()

    Dim dtAuthority As New DataTable()

    Private Sub Init()
        Me.txtFormID.Text = String.Empty
        Me.txtProgram.Text = String.Empty
        Me.txtFormName.Text = String.Empty
        Me.cmbGroup.Text = String.Empty
        Me.cmbAuthority.Text = String.Empty

        setGroupId("")

        setAuthority()

        xml.InitUser(Me.txtLoginUser, Me.TextBox1)

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    ''' <summary>
    ''' 　画面項目グループID初期化
    ''' </summary>
    Private Sub setGroupId(ByVal str As String)

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim strSelect As String = xml.GetSQL_Str("SELECT_001")
                strSelect = String.Format(strSelect, "009")

                Dim dt As New DataTable()
                'コード
                dataTable = clsSQLServer.GetDataTable(strSelect)
                Me.cmbGroupId.DataSource = dataTable
                Me.cmbGroupId.ValueMember = dataTable.Columns.Item(0).ColumnName
                Me.cmbGroupId.DisplayMember = dataTable.Columns.Item(1).ColumnName

                '検索条件　コード
                dt = dataTable.Copy
                Me.cmbGroup.DataSource = dt
                Me.cmbGroup.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbGroup.DisplayMember = dt.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()
            End If


            If Not IsNothing(str) Then
                Me.cmbGroupId.Text = str
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 　画面項目権限名初期化
    ''' </summary>
    Private Sub setAuthority()


        dtAuthority.Columns.Add("権限", Type.GetType("System.String"))
        dtAuthority.Columns.Add("権限名", Type.GetType("System.String"))

        dtAuthority.Rows.Add("9", "")
        dtAuthority.Rows.Add("0", "0:権限なし")
        dtAuthority.Rows.Add("1", "1:参照のみ")
        dtAuthority.Rows.Add("2", "2:すべて")


        'CustomDropDownComboBoxの設定
        Me.cmbAuthority.DataSource = dtAuthority

        ' 表示用の列を設定
        Me.cmbAuthority.DisplayMember = dtAuthority.Columns.Item(1).ColumnName
        ' データ用の列を設定
        Me.cmbAuthority.ValueMember = dtAuthority.Columns.Item(0).ColumnName

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

    Private Sub SC_M16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
                  vbYesNo + vbQuestion,
                  My.Settings.systemName) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String
                Dim dt As New DataTable()

                If Me.cmbGroupId.Text.Equals(String.Empty) Then
                    sqlstr = xml.GetSQL_Str("SELECT_002")
                Else
                    sqlstr = xml.GetSQL_Str("SELECT_003")
                    sqlstr = String.Format(sqlstr, cmbGroupId.SelectedValue)
                End If

                dt = clsSQLServer.GetDataTable(sqlstr)

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
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)

        Try
            gridData.Columns.Clear()

            Dim dt As New DataTable()

            '選択
            Dim addColSentaku As New DataGridViewCheckBoxColumn()
            addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
            addColSentaku.HeaderText = headerName(COL_SENTAKU)
            addColSentaku.Name = "sentaku"
            gridData.Columns.Add(addColSentaku)

            For Each col As DataColumn In dtData.Columns

                If col.ColumnName = COL_GROUP_ID Then
                    Dim addCol As New DataGridViewComboBoxColumn()
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = headerName(col.ColumnName)
                    addCol.Name = col.ColumnName

                    '検索条件　コード
                    dt = dataTable.Copy

                    addCol.DataSource = dt
                    addCol.DisplayMember = dt.Columns.Item(1).ColumnName
                    addCol.ValueMember = dt.Columns.Item(0).ColumnName
                    gridData.Columns.Add(addCol)

                ElseIf col.ColumnName = COL_AUTHORITY_NAME Then
                    Dim addCol As New DataGridViewComboBoxColumn()
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = headerName(col.ColumnName)
                    addCol.Name = col.ColumnName

                    '検索条件　コード
                    dt = dtAuthority.Copy

                    addCol.DataSource = dt
                    addCol.DisplayMember = dt.Columns.Item(1).ColumnName
                    addCol.ValueMember = dt.Columns.Item(0).ColumnName

                    gridData.Columns.Add(addCol)

                Else
                    Dim addCol As New DataGridViewTextBoxColumn()
                    addCol.DataPropertyName = col.ColumnName
                    addCol.HeaderText = headerName(col.ColumnName)
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
                    Case COL_FORM_NAME, COL_GROUP_ID, COL_AUTHORITY_NAME
                        gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case Else
                        gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Select

                'gridData.AutoResizeColumns()

            Next

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
            gridData.Columns(4).Width = 150
            gridData.Columns(5).Width = 200

            '複数選択不可
            gridData.MultiSelect = False
            '編集不可
            gridData.AllowUserToDeleteRows = False
            gridData.AllowUserToAddRows = False
            gridData.AllowUserToResizeRows = False

        Catch ex As Exception

            MsgBox(String.Format(clsGlobal.MSG2("E999")),
                   vbExclamation,
                   My.Settings.systemName)
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
                For i As Integer = 1 To 5
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 1 To 5
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            gridData.Columns.Clear()

            controlClear()
        End If
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            If Me.txtFormID.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_FORM_ID))
                Me.txtFormID.BackColor = Color.Red
                Return
            Else
                Me.txtFormID.BackColor = Color.White
            End If

            If Me.cmbGroup.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_GROUP_ID))
                Me.cmbGroup.BackColor = Color.Red
                Return
            Else
                Me.cmbGroup.BackColor = Color.White
            End If

            If Me.cmbAuthority.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_AUTHORITY_NAME))
                Me.cmbAuthority.BackColor = Color.Red
                Return
            Else
                Me.cmbAuthority.BackColor = Color.White
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '追加処理の重複データをチェックする
                    Dim dt As New DataTable()
                    Dim sqlstr As String = xml.GetSQL_Str("SELECT_004")
                    sqlstr = String.Format(sqlstr, Me.cmbGroup.SelectedValue, Me.txtFormID.Text)

                    dt = clsSQLServer.GetDataTable(sqlstr)

                    If dt.Rows.Count > 0 Then

                        '重複データがある場合、メッセージを表示して、追加処理を終止する
                        MsgBox(String.Format(clsGlobal.MSG2("W0009")),
                               vbExclamation,
                               My.Settings.systemName)

                        clsSQLServer.Disconnect()

                        Return

                    End If

                    sqlstr = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            Me.cmbGroup.SelectedValue,
                                                            Me.txtFormID.Text,
                                                            Me.txtProgram.Text,
                                                            Me.txtFormName.Text,
                                                            Me.cmbAuthority.SelectedValue))

                    clsSQLServer.Disconnect()

                    setGroupId(Me.cmbGroupId.Text)

                    btnSearch_Click(sender, e)

                End If

            Catch ex As Exception
                Throw
            End Try

            Me.cmbGroup.Text = String.Empty
            Me.cmbGroup.BackColor = Color.White

            Me.txtFormID.Text = String.Empty
            Me.txtFormID.BackColor = Color.White

            Me.txtProgram.Text = String.Empty
            Me.txtProgram.BackColor = Color.White

            Me.txtFormName.Text = String.Empty
            Me.txtFormName.BackColor = Color.White

            Me.cmbAuthority.Text = String.Empty
            Me.cmbAuthority.BackColor = Color.White
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0002")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    Dim selectedCount As Boolean = False
                    'レコード存在しない場合、エラーが発生する
                    If gridData.Rows.Count = 0 Then
                        MsgBox(String.Format(clsGlobal.MSG2("W9001")),
                               vbExclamation,
                               My.Settings.systemName)
                        Return
                    End If

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            '更新処理の重複データをチェックする
                            Dim dt As New DataTable()
                            Dim sqlstr As String = xml.GetSQL_Str("SELECT_004")
                            sqlstr = String.Format(sqlstr,
                                                   gridData.Rows(i).Cells(4).Value,
                                                   gridData.Rows(i).Cells(2).Value)

                            dt = clsSQLServer.GetDataTable(sqlstr)

                            If dt.Rows.Count > 0 Then

                                '重複データがある場合、メッセージを表示して、追加処理を終止する
                                MsgBox(String.Format(clsGlobal.MSG2("W0009")),
                               vbExclamation,
                               My.Settings.systemName)

                                clsSQLServer.Disconnect()

                                Return

                            End If

                            sqlstr = xml.GetSQL_Str("UPDATE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            gridData.Rows(i).Cells(1).Value,
                                                            gridData.Rows(i).Cells(2).Value,
                                                            gridData.Rows(i).Cells(3).Value,
                                                            gridData.Rows(i).Cells(4).Value,
                                                            gridData.Rows(i).Cells(5).Value))

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

                    btnSearch_Click(sender, e)
                End If
            Catch ex As Exception
                Throw
            End Try

        End If

        'clsCSV.ConvertDataTableToCsv(dt， "aa.txt", True, True)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0003")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    Dim sqlstr As String
                    Dim selectedCount As Boolean = False
                    'レコード存在しない場合、エラーが発生する
                    If gridData.Rows.Count = 0 Then
                        MsgBox(String.Format(clsGlobal.MSG2("W9001")),
                               vbExclamation,
                               My.Settings.systemName)
                        Return
                    End If

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            sqlstr = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(4).Value,
                                                                    gridData.Rows(i).Cells(2).Value))
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

                    setGroupId(Me.cmbGroupId.Text)

                    btnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    '画面コントロールをクリアする
    Private Sub controlClear()

        Me.cmbGroupId.Text = String.Empty

        Me.txtFormID.Text = String.Empty
        Me.txtFormID.BackColor = Color.White

        Me.txtProgram.Text = String.Empty
        Me.txtProgram.BackColor = Color.White

        Me.txtFormName.Text = String.Empty
        Me.txtFormName.BackColor = Color.White

        Me.cmbGroup.Text = String.Empty
        Me.cmbGroup.BackColor = Color.White

        Me.cmbAuthority.Text = String.Empty
        Me.cmbAuthority.BackColor = Color.White
    End Sub

    Private Sub gridData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles gridData.DataError

        'Try
        '    For row As Integer = 0 To gridData.Rows.Count - 1

        '        For i As Integer = 0 To gridData.Columns.Count - 1

        '            '横位置
        '            Select Case gridData.Columns(i).Name

        '                Case COL_GROUP_ID

        '                    'GridView数字チェック
        '                    If e.ColumnIndex = gridData.Columns(i).Index Then

        '                    End If
        '            End Select
        '        Next
        '    Next
        'Catch ex As Exception

        '    MsgBox("aaa",
        '                           vbExclamation,
        '                           My.Settings.systemName)

        '    'MsgBox(String.Format("{0}:{1}:{2}", i, row, gridData.Item(i, row).Value),
        '    '                       vbExclamation,
        '    '                       My.Settings.systemName)
        'End Try
    End Sub
End Class