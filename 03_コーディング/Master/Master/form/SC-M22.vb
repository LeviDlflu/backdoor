Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_M22


    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
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

    Dim xml As New CmnXML("SC-M22.xml", "SC-M22")

    ''' <summary>
    ''' 　画面初期化
    ''' </summary>
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

        setManagementNoType("")

        xml.InitUser(Me.txtLoginUser, Me.TextBox1)

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    ''' <summary>
    ''' 　画面項目管理NO種別初期化
    ''' </summary>
    Private Sub setManagementNoType(ByVal str As String)

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String = xml.GetSQL_Str("SELECT_001")

                Dim dt As New DataTable()

                dt = clsSQLServer.GetDataTable(sqlstr)

                Dim drWork As DataRow = dt.NewRow

                drWork(dt.Columns.Item(0).ColumnName) = "00"
                drWork(dt.Columns.Item(0).ColumnName) = ""
                dt.Rows.InsertAt(drWork, 0)

                Me.cmbManagementNoType.DataSource = dt

                ' 表示用の列を設定
                Me.cmbManagementNoType.DisplayMember = dt.Columns.Item(0).ColumnName
                ' データ用の列を設定
                Me.cmbManagementNoType.ValueMember = dt.Columns.Item(0).ColumnName

                clsSQLServer.Disconnect()

            End If

            If Not IsNothing(str) Then
                Me.cmbManagementNoType.Text = str
            End If

        Catch ex As Exception
            Throw
        End Try
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

        Dim addCol As New DataGridViewTextBoxColumn()

        For Each col As DataColumn In dtData.Columns
            addCol = New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName

            If col.ColumnName = COL_SNUMBER Then
                addCol.MaxInputLength = 10
            ElseIf col.ColumnName = COL_SSECTION Then
                addCol.MaxInputLength = 10
            ElseIf col.ColumnName = COL_SBIKOU Then
                addCol.MaxInputLength = 50
            End If

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

    ''' <summary>
    ''' 　画面Load
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub SC_M22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
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
    ''' 　検索ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String
                Dim dt As New DataTable()

                If Me.cmbManagementNoType.Text.Equals(String.Empty) Then
                    sqlstr = xml.GetSQL_Str("SELECT_002")
                Else
                    sqlstr = xml.GetSQL_Str("SELECT_003")
                    sqlstr = String.Format(sqlstr, cmbManagementNoType.Text)
                End If

                dt = clsSQLServer.GetDataTable(sqlstr)

                If dt.Rows.Count = 0 Then

                    MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           My.Settings.systemName)

                    clsSQLServer.Disconnect()

                    Return

                End If


                sqlstr = xml.GetSQL_Str("SELECT_004")
                sqlstr = String.Format(sqlstr, cmbManagementNoType.Text)

                dt = clsSQLServer.GetDataTable(sqlstr)

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
    ''' 　クリアボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I001"), ClsLogString.RunState.Msg)

        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            gridData.Columns.Clear()

            Me.cmbManagementNoType.Text = String.Empty

            Me.txtManagementNoType.Text = String.Empty
            Me.txtFixedPart.Text = String.Empty
            Me.txtNumber.Text = String.Empty
            Me.txtFluctuationDataSection.Text = String.Empty
            Me.txtRemartks.Text = String.Empty
        End If

        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I002"), ClsLogString.RunState.Msg)
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            If txtManagementNoType.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_SNOTYPE))
                'cmnUtil.GetMessageStr("W0001", "管理ＮＯ種別"))
                txtManagementNoType.BackColor = Color.Red
                Return
            Else
                txtManagementNoType.BackColor = Color.White
            End If

            If txtFixedPart.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_SFIXEDPART))
                txtFixedPart.BackColor = Color.Red
                Return
            Else
                txtFixedPart.BackColor = Color.White
            End If

            If txtNumber.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_SNUMBER))
                txtNumber.BackColor = Color.Red
                Return
            Else
                txtNumber.BackColor = Color.White
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '追加処理の重複データをチェックする
                    Dim dt As New DataTable()
                    Dim sqlstr As String = xml.GetSQL_Str("SELECT_005")
                    sqlstr = String.Format(sqlstr, txtManagementNoType.Text, txtFixedPart.Text)

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
                                                            txtManagementNoType.Text,
                                                            txtFixedPart.Text,
                                                            txtFluctuationDataSection.Text,
                                                            Decimal.Parse(txtNumber.Text),
                                                            txtRemartks.Text))

                    clsSQLServer.Disconnect()

                    setManagementNoType(Me.cmbManagementNoType.Text)

                    btnSearch_Click(sender, e)


                End If

            Catch ex As Exception
                Throw
            End Try

            Me.txtManagementNoType.Text = String.Empty
            Me.txtFixedPart.Text = String.Empty
            Me.txtNumber.Text = String.Empty
            Me.txtFluctuationDataSection.Text = String.Empty
            Me.txtRemartks.Text = String.Empty
        End If
    End Sub


    ''' <summary>
    ''' 　更新ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
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

                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

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
    End Sub


    ''' <summary>
    ''' 　削除ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
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
                                                                    gridData.Rows(i).Cells(1).Value,
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

                    If Not Me.cmbManagementNoType.Text.Equals(String.Empty) Then
                        sqlstr = xml.GetSQL_Str("SELECT_003")
                        sqlstr = String.Format(sqlstr, cmbManagementNoType.Text)
                        Dim dt As New DataTable()

                        dt = clsSQLServer.GetDataTable(sqlstr)

                        If dt.Rows.Count = 0 Then
                            MsgBox("画面対応検索条件のデータ削除のため、全件検索実行",
                                   vbExclamation,
                                   My.Settings.systemName)
                            Me.cmbManagementNoType.Text = String.Empty
                        End If
                    End If

                    clsSQLServer.Disconnect()

                    setManagementNoType(Me.cmbManagementNoType.Text)

                    btnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Private Sub txtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumber.KeyPress

        'キーが [0]～[9] または [BackSpace] 以外の場合イベントをキャンセル
        If Not (("0"c <= e.KeyChar And e.KeyChar <= "9"c) Or e.KeyChar = ControlChars.Back) Then
            'コントロールの既定の処理を省略する場合は true
            e.Handled = True
        End If

    End Sub
End Class