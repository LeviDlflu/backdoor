Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports PUCCommon.clsGlobal
Imports System.ComponentModel

Public Class SC_M11

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"品種コード", " Variety" & vbCrLf & "(品種コード)"},
                             {"品種名", "Variety name" & vbCrLf & "品種名"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_VARIETY As String = "品種コード"
    Private Const COL_VARIETYNAME As String = "品種名"
    Private Const COL_REMARKS As String = "備考"


    Private Const MESSAGE_ITEM_PATH As String = "/Messages/{0}/Message[@ID='{1}']/{2}/text()"
    Private Const MESSAGE_ITEM_MESSAGE As String = "Text"

    Dim xml As New CmnXML("SC-M11.xml", "SC-M11")


    Private Sub Init()

        Me.txtHinSyuCD.Enabled = True
        Me.txtRemartks.Enabled = True
        Me.txtHinSyuMei.Enabled = True

        Me.txtHinSyuCD.Text = String.Empty
        Me.txtRemartks.Text = String.Empty
        Me.txtHinSyuMei.Text = String.Empty

        SetVarietyType("")

        xml.InitUser(Me.txtLoginUser, Me.TextBox1)

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    ''' <summary>
    ''' 　画面項目管理NO種別初期化
    ''' </summary>
    Private Sub SetVarietyType(ByVal str As String)

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String = xml.GetSQL_Str("SELECT_001")

                Dim dt As New DataTable()

                dt = clsSQLServer.GetDataTable(sqlstr)

                Dim drWork As DataRow = dt.NewRow

                drWork(dt.Columns.Item(0).ColumnName) = "00"
                drWork(dt.Columns.Item(0).ColumnName) = ""
                dt.Rows.InsertAt(drWork, 0)

                Me.cmbHinsyu.DataSource = dt

                ' 表示用の列を設定
                Me.cmbHinsyu.DisplayMember = dt.Columns.Item(0).ColumnName
                ' データ用の列を設定
                Me.cmbHinsyu.ValueMember = dt.Columns.Item(0).ColumnName

                clsSQLServer.Disconnect()

            End If

            If Not IsNothing(str) Then
                Me.cmbHinsyu.Text = str
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

            If col.ColumnName = COL_VARIETYNAME Then
                addCol.MaxInputLength = 20
            ElseIf col.ColumnName = COL_REMARKS Then
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
                Case COL_VARIETYNAME, COL_REMARKS
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
        gridData.Columns(1).Width = 180
        gridData.Columns(2).Width = 300
        gridData.Columns(3).Width = 620

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
    Private Sub SC_M11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub BtnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
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
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String
                Dim dt As New DataTable()

                If Me.cmbHinsyu.Text.Equals(String.Empty) Then
                    sqlstr = xml.GetSQL_Str("SELECT_002")
                Else
                    sqlstr = xml.GetSQL_Str("SELECT_003")
                    sqlstr = String.Format(sqlstr, cmbHinsyu.Text)
                End If

                dt = clsSQLServer.GetDataTable(sqlstr)

                If dt.Rows.Count = 0 Then

                    gridData.Columns.Clear()

                    sqlstr = xml.GetSQL_Str("SELECT_004")
                    sqlstr = String.Format(sqlstr, cmbHinsyu.Text)

                    dt = clsSQLServer.GetDataTable(sqlstr)

                    setGrid(dt)


                    If dt.Rows.Count = 0 Then

                        MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           My.Settings.systemName)

                        clsSQLServer.Disconnect()

                    End If

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
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub GridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 2 To 3
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.Yellow

                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 2 To 3

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
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I001"), ClsLogString.RunState.Msg)
        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            gridData.Columns.Clear()

            cmbHinsyu.Text = String.Empty

            Me.txtHinSyuCD.Text = String.Empty
            Me.txtRemartks.Text = String.Empty
            Me.txtHinSyuMei.Text = String.Empty
        End If
        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I002"), ClsLogString.RunState.Msg)
    End Sub

    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            If txtHinSyuCD.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_VARIETY))
                'cmnUtil.GetMessageStr("W0001", "管理ＮＯ種別"))
                txtHinSyuCD.BackColor = Color.Red
                Return
            Else
                txtHinSyuCD.BackColor = Color.White
            End If

            If txtHinSyuMei.Text.Equals(String.Empty) Then
                MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), COL_VARIETYNAME))
                txtHinSyuMei.BackColor = Color.Red
                Return
            Else
                txtHinSyuMei.BackColor = Color.White
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '追加処理の重複データをチェックする
                    Dim dt As New DataTable()
                    Dim sqlstr As String = xml.GetSQL_Str("SELECT_003")
                    sqlstr = String.Format(sqlstr, txtHinSyuCD.Text)

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
                                                            txtHinSyuCD.Text,
                                                            txtHinSyuMei.Text,
                                                            txtRemartks.Text))

                    clsSQLServer.Disconnect()

                    SetVarietyType(Me.cmbHinsyu.Text)

                    BtnSearch_Click(sender, e)

                End If

            Catch ex As Exception
                Throw
            End Try

            Me.txtHinSyuCD.Text = String.Empty
            Me.txtRemartks.Text = String.Empty
            Me.txtHinSyuMei.Text = String.Empty
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

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
                                                            gridData.Rows(i).Cells(3).Value))
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

                    BtnSearch_Click(sender, e)
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
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

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
                                                                    gridData.Rows(i).Cells(1).Value))
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

                    If Not Me.cmbHinsyu.Text.Equals(String.Empty) Then
                        sqlstr = xml.GetSQL_Str("SELECT_003")
                        sqlstr = String.Format(sqlstr, cmbHinsyu.Text)
                        Dim dt As New DataTable()

                        dt = clsSQLServer.GetDataTable(sqlstr)

                        If dt.Rows.Count = 0 Then
                            MsgBox("検索条件のデータが削除されたのため、全件検索実行する",
                                   vbExclamation,
                                   My.Settings.systemName)
                            Me.cmbHinsyu.Text = String.Empty
                        End If
                    End If

                    clsSQLServer.Disconnect()

                    SetVarietyType(Me.cmbHinsyu.Text)

                    BtnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Private Sub txtHinSyuCD_TextChanged(sender As Object, e As EventArgs) Handles txtHinSyuCD.TextChanged
        Dim lstr As String
        lstr = Me.txtHinSyuCD.Text
        If Len(lstr) > 2 Then
            MsgBox("品種コードの最大桁数は2")
            txtHinSyuCD.Text = lstr.Substring(0, 2)
        End If
    End Sub

    Private Sub txtHinSyuMei_TextChanged(sender As Object, e As EventArgs) Handles txtHinSyuMei.TextChanged
        Dim lstr As String
        lstr = Me.txtHinSyuMei.Text
        If Len(lstr) > 20 Then
            MsgBox("品種名の最大桁数は20")
            txtHinSyuMei.Text = lstr.Substring(0, 20)
        End If
    End Sub

    Private Sub txtRemartks_TextChanged(sender As Object, e As EventArgs) Handles txtRemartks.TextChanged
        Dim lstr As String
        lstr = Me.txtRemartks.Text
        If Len(lstr) > 50 Then
            MsgBox("備考の最大桁数は50")
            txtRemartks.Text = lstr.Substring(0, 50)
        End If
    End Sub
End Class