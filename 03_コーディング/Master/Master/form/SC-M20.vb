﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Public Class SC_M20

    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"稼働年月", "Working days_YM" & vbCrLf & "(稼働年月)"},
                             {"稼働日", "Working days_D" & vbCrLf & "(稼働日)"},
                             {"稼働年月日", "Working days_YMD" & vbCrLf & "(稼働年月日)"},
                             {"直区分", "Direct division" & vbCrLf & "(直区分)"},
                             {"稼働区分", "Operation category" & vbCrLf & "(稼働区分)"},
                             {"稼働区分２", "Operation category2" & vbCrLf & "(稼働区分２)"},
                             {"稼働区分３", "Operation category3" & vbCrLf & "(稼働区分３)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_WORKING_YM As String = "稼働年月"
    Private Const COL_WORKING_D As String = "稼働日"
    Private Const COL_WORKING_YMD As String = "稼働年月日"
    Private Const COL_DIRECT As String = "直区分"
    Private Const COL_CATEGORY As String = "稼働区分"
    Private Const COL_CATEGORY_2 As String = "稼働区分２"
    Private Const COL_CATEGORY_3 As String = "稼働区分３"
    Private Const TABLENAME As String = "顧客カレンダーマスタ"

    Dim dtAutoLabel As New DataTable
    Dim xml As New CmnXML("SC-M20.xml", "SC-M20")

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub tmrClockSec_Tick(sender As Object, e As EventArgs) Handles tmrClockSec.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub SC_M20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初期設定
        'Me.Text = getTitle(GAMEN_SC_M20)
        Dim dt As New DataTable
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add(" ", "")
        dt.Rows.Add("1", "1:稼働")
        dt.Rows.Add("2", "2:非稼働")
        dtAutoLabel = dt
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
        InitCombox4Value()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnMenu0.Click
        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String

                If Me.ComboBox4.Text.Equals(String.Empty) Then
                    sqlstr = xml.GetSQL_Str("SELECT_004")
                Else
                    sqlstr = xml.GetSQL_Str("SELECT_001")
                    sqlstr = String.Format(sqlstr, ComboBox4.Text)
                End If

                Dim dt As New DataTable()

                dt = clsSQLServer.GetDataTable(sqlstr)

                If dt.Rows.Count = 0 Then
                    Dim msg As New clsMessage("W0008")

                    MsgBox(msg.Show, vbCritical, TABLENAME)

                End If

                setGrid(dt)

                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            gridData.DataSource = Nothing
        End Try

    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnMenu5.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
                  vbYesNo + vbQuestion,
                  My.Settings.systemName) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YM, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_D, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORKING_YMD, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CATEGORY_2, GetType(System.String)))

        Return dt

    End Function

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        'gridData.Rows.Clear()
        gridData.Columns.Clear()

        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = HEADER_NAME(COL_SENTAKU)
        addColSentaku.HeaderText = HEADER_NAME(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)
        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_CATEGORY Or col.ColumnName = COL_CATEGORY_2 Then
                Dim addCol As New DataGridViewComboBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.White
                addCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                addCol.FlatStyle = FlatStyle.Flat
                addCol.DataSource = dtAutoLabel
                addCol.ValueMember = dtAutoLabel.Columns.Item(0).ColumnName
                addCol.DisplayMember = dtAutoLabel.Columns.Item(1).ColumnName
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.LightGray
                gridData.Columns.Add(addCol)
            End If
        Next
        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
        gridData.Columns(1).Width = 120
        gridData.Columns(2).Width = 100
        gridData.Columns(3).Width = 120
        gridData.Columns(4).Width = 150
        gridData.Columns(5).Width = 150
        gridData.Columns(6).Width = 150


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
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 5 To 6
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                Next
            Else

                For i As Integer = 5 To 6
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                    gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnMenu4.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
          vbOKCancel + vbQuestion,
          My.Settings.systemName) = DialogResult.OK Then
            gridData.Columns.Clear()
            ComboBox4.SelectedIndex = -1
            Me.dtpWorkingYMD.Value = Now
            Me.cmbProcess.Text = String.Empty
            Me.ComboBox2.Text = String.Empty
            Me.ComboBox3.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnMenu1.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            If dtpWorkingYMD.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_WORKING_YMD))
                dtpWorkingYMD.BackColor = Color.Red
                Return
            Else
                dtpWorkingYMD.BackColor = Color.White
            End If

            If cmbProcess.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_DIRECT))
                cmbProcess.BackColor = Color.Red
                Return
            Else
                cmbProcess.BackColor = Color.White
            End If

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim selectSql As String
                selectSql = xml.GetSQL_Str("SELECT_002")
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(String.Format(selectSql, Format(dtpWorkingYMD.Value, "yyyyMM"), Format(dtpWorkingYMD.Value, "dd"), dtpWorkingYMD.Value, cmbProcess.Text))
                If dt.Rows.Count = 1 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0009"))
                    Me.dtpWorkingYMD.Value = Now
                    Me.cmbProcess.Text = String.Empty
                    Me.ComboBox2.Text = String.Empty
                    Me.ComboBox3.Text = String.Empty
                    clsSQLServer.Disconnect()
                    Return
                Else
                    Dim CATEGORY As String
                    Dim CATEGORY2 As String
                    If String.IsNullOrEmpty(ComboBox3.Text) Then
                        CATEGORY = String.Empty
                    Else
                        CATEGORY = ComboBox3.Text.Substring(0, 1)
                    End If

                    If String.IsNullOrEmpty(ComboBox2.Text) Then
                        CATEGORY2 = String.Empty
                    Else
                        CATEGORY2 = ComboBox2.Text.Substring(0, 1)
                    End If


                    Dim insertsql As String = xml.GetSQL_Str("INSERT_001")

                    clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                            Format(dtpWorkingYMD.Value, "yyyyMM"),
                                                            Format(dtpWorkingYMD.Value, "dd"),
                                                            dtpWorkingYMD.Value, cmbProcess.Text,
                                                            CATEGORY, CATEGORY2, Now))
                    clsSQLServer.Disconnect()
                    MessageBox.Show(cmnUtil.GetMessageStr("Q0001"))
                    Me.dtpWorkingYMD.Value = Now
                    Me.cmbProcess.Text = String.Empty
                    Me.ComboBox2.Text = String.Empty
                    Me.ComboBox3.Text = String.Empty
                    btnSearch_Click(sender, e)
                    InitCombox4Value()
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnMenu3.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0003")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then


                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                            Dim deletesql As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(deletesql,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value,
                                                                    gridData.Rows(i).Cells(3).Value,
                                                                    gridData.Rows(i).Cells(4).Value))

                        End If

                    Next

                    clsSQLServer.Disconnect()

                    btnSearch_Click(sender, e)

                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Private Sub InitCombox4Value()
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim selectSql As String
                selectSql = xml.GetSQL_Str("SELECT_003")
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(selectSql)

                Me.ComboBox4.ValueMember = COL_WORKING_YM
                Me.ComboBox4.DisplayMember = COL_WORKING_YM
                Me.ComboBox4.DataSource = dt

                ComboBox4.SelectedIndex = -1
                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnMenu2.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0002")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then
            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then
                            Dim selectSql As String
                            selectSql = xml.GetSQL_Str("SELECT_002")
                            Dim dt As New DataTable()
                            dt = clsSQLServer.GetDataTable(String.Format(selectSql,
                                                                         gridData.Rows(i).Cells(1).Value,
                                                                         gridData.Rows(i).Cells(2).Value,
                                                                         gridData.Rows(i).Cells(3).Value,
                                                                         gridData.Rows(i).Cells(4).Value))
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0003"))
                                clsSQLServer.Disconnect()
                                Return
                            Else
                                Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                                clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            gridData.Rows(i).Cells(1).Value,
                                                            gridData.Rows(i).Cells(2).Value,
                                                            gridData.Rows(i).Cells(3).Value,
                                                            gridData.Rows(i).Cells(4).Value,
                                                            gridData.Rows(i).Cells(5).Value,
                                                            gridData.Rows(i).Cells(6).Value,
                                                            Now))
                            End If

                        End If

                    Next

                    clsSQLServer.Disconnect()
                    btnSearch_Click(sender, e)
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

End Class