﻿Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports PUCCommon.clsGlobal

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

        SetVarietyType()

        xml.InitUser(Me.txtLoginUser, Me.TextBox1)

        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")

    End Sub

    ''' <summary>
    ''' 　画面項目管理NO種別初期化
    ''' </summary>
    Private Sub SetVarietyType()

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

        gridData.Columns(0).Width = 90
        gridData.Columns(1).Width = 180
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 180

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

    Private Sub SC_M11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub BtnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Dim msg As New clsMessage("I00099")
        If MsgBox(msg.Show, vbYesNo + vbQuestion, "生産管理システム") = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

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
                    Dim msg As New clsMessage("W0008")

                    MsgBox(msg.Show, vbCritical, "生産管理システム")

                    clsSQLServer.Disconnect()

                    Return

                End If


                If Me.cmbHinsyu.Text.Equals(String.Empty) Then
                    sqlstr = xml.GetSQL_Str("SELECT_002")
                Else
                    sqlstr = xml.GetSQL_Str("SELECT_003")
                    sqlstr = String.Format(sqlstr, cmbHinsyu.Text)
                End If

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
    Private Sub GridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 1 To 3
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.Yellow

                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else
                For i As Integer = 1 To 3

                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White

                    gridData.CurrentRow.Cells(i).ReadOnly = True

                Next
            End If
        End If

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I001"), ClsLogString.RunState.Msg)

        Dim msg As New clsMessage("I0009")
        If MsgBox(msg.Show, vbOKCancel + vbQuestion, "生産管理システム") = DialogResult.OK Then
            gridData.Columns.Clear()
        End If

        'clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I002"), ClsLogString.RunState.Msg)
    End Sub

    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        Dim msg As New clsMessage("I0001")
        If MsgBox(msg.Show, vbOKCancel + vbExclamation, "生産管理システム") = DialogResult.OK Then

            If txtHinSyuCD.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "品種コード"))
                txtHinSyuCD.BackColor = Color.Red
                Return
            Else
                txtHinSyuCD.BackColor = Color.White
            End If

            If txtHinSyuMei.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "品種名"))
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
                        msg = New clsMessage("W0009")

                        MsgBox(msg.Show, vbCritical, "生産管理システム")

                        clsSQLServer.Disconnect()

                        Return

                    End If

                    sqlstr = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            txtHinSyuCD.Text,
                                                            txtHinSyuMei.Text,
                                                            txtRemartks.Text))

                    clsSQLServer.Disconnect()

                    BtnSearch_Click(sender, e)

                    SetVarietyType()

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

        Dim msg As New clsMessage("I0002")
        If MsgBox(cmnUtil.GetMessageStr("Q0002"), vbOKCancel + vbExclamation, "生産管理システム") = DialogResult.OK Then
            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            gridData.Rows(i).Cells(1).Value,
                                                            gridData.Rows(i).Cells(2).Value,
                                                            gridData.Rows(i).Cells(3).Value))
                        End If
                    Next

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

        Dim msg As New clsMessage("I0003")
        If MsgBox(msg.Show, vbOKCancel + vbExclamation, "生産管理システム") = DialogResult.OK Then

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then


                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If gridData.Rows(i).Cells(0).Value = True Then

                            Dim sqlstr As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value))

                        End If

                    Next

                    clsSQLServer.Disconnect()

                    BtnSearch_Click(sender, e)

                    SetVarietyType()
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub
End Class