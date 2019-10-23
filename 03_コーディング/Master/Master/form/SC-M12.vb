Public Class SC_M12

    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"車種コード", "Vehicle type" & vbCrLf & "(車種コード)"},
                             {"車種名", "Vehicle type name" & vbCrLf & "(車種名)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const TABLE_NAME As String = "車種マスタ"

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_VEHICLE_TYPE As String = "車種コード"
    Private Const COL_VEHICLE_TYPE_NAME As String = "車種名"
    Private Const COL_REMARKS As String = "備考"


    Dim xml As New CmnXML("SC-M12.xml", "SC-M12")

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_M12_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtVehicleType.Text = String.Empty
        Me.txtVehicleTypeName.Text = String.Empty
        Me.txtRemartks.Text = String.Empty
        Me.cmbHinsyu.SelectedIndex = -1

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
            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = HEADER_NAME(col.ColumnName)
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns(1).DefaultCellStyle.BackColor = Color.WhiteSmoke
        gridData.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

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

        gridData.Columns(0).Width = 100
        gridData.Columns(1).Width = 100
        gridData.Columns(2).Width = 200
        gridData.Columns(3).Width = 400

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
                For i As Integer = 1 To 3

                    Select Case i
                        Case 1
                            gridData.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Case Else
                            gridData.CurrentRow.Cells(i).Style.BackColor = Color.White
                            gridData.CurrentRow.Cells(i).ReadOnly = False
                    End Select
                Next
            Else

                For i As Integer = 1 To 3
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnMenu0.Click

        Dim dt As New DataTable
        Dim strSelect As String = xml.GetSQL_Str("SELECT_001")
        Dim strWhere As String = xml.GetSQL_Str("WHERE_001")
        Dim selectSql As String

        If String.IsNullOrEmpty(cmbHinsyu.Text) Then
            selectSql = String.Format(strSelect, "")
        Else
            selectSql = String.Format(strSelect, String.Format(strWhere, cmbHinsyu.Text))
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


                End If

                setGrid(dt)

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Insert(追加)事件
    ''' </summary>
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnMenu1.Click

        If MsgBox(String.Format(clsGlobal.MSG2("I0001")),
                  vbOKCancel + vbQuestion,
                  My.Settings.systemName) = DialogResult.OK Then

            '必須チェック
            '車種コード
            If txtVehicleType.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_VEHICLE_TYPE))
                txtVehicleType.BackColor = Color.Red
                Return
            Else
                txtVehicleType.BackColor = Color.White
            End If

            '車種名
            If txtVehicleTypeName.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", COL_VEHICLE_TYPE_NAME))
                txtVehicleTypeName.BackColor = Color.Red
                Return
            Else
                txtVehicleTypeName.BackColor = Color.White
            End If

            '桁数チェック
            '車種コード
            If txtVehicleType.Text.Equals(String.Empty) = False And txtVehicleType.Text.Length > 4 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_VEHICLE_TYPE, 4))
                txtVehicleType.BackColor = Color.Red
                Return
            Else
                txtVehicleType.BackColor = Color.White
            End If

            '車種名
            If txtVehicleTypeName.Text.Equals(String.Empty) = False And txtVehicleTypeName.Text.Length > 20 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_VEHICLE_TYPE_NAME, 5))
                txtVehicleTypeName.BackColor = Color.Red
                Return
            Else
                txtVehicleTypeName.BackColor = Color.White
            End If

            '備考
            If txtRemartks.Text.Equals(String.Empty) = False And txtRemartks.Text.Length > 50 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_REMARKS, 50))
                txtRemartks.BackColor = Color.Red
                Return
            Else
                txtRemartks.BackColor = Color.White
            End If

            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '重複チェック
                    '車種コード
                    Dim resultData As DataTable = New DataTable
                    Dim strSelect As String = String.Format(xml.GetSQL_Str("SELECT_001"), xml.GetSQL_Str("WHERE_001"))
                    resultData = clsSQLServer.GetDataTable(String.Format(strSelect, txtVehicleType.Text))
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

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                txtVehicleType.Text,
                                                                txtVehicleTypeName.Text,
                                                                txtRemartks.Text, 0, "0"))

                    clsSQLServer.Disconnect()

                    '最新データを検索
                    btnSearch_Click(sender, e)

                    Me.txtVehicleType.Text = String.Empty
                    Me.txtVehicleTypeName.Text = String.Empty
                    Me.txtRemartks.Text = String.Empty

                End If

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Update(更新)事件
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnMenu2.Click

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

                            Dim gridCells As DataGridViewCellCollection = gridData.Rows(i).Cells

                            Dim txtVehicleType As String = gridCells(COL_VEHICLE_TYPE).Value
                            Dim txtVehicleTypeName As String = gridCells(COL_VEHICLE_TYPE_NAME).Value
                            Dim txtRemarks As String = gridCells(COL_REMARKS).Value

                            '桁数チェック
                            '車種名
                            If txtVehicleTypeName.Equals(String.Empty) = False And txtVehicleTypeName.Length > 20 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_VEHICLE_TYPE_NAME, 5))
                                gridCells(COL_VEHICLE_TYPE_NAME).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_VEHICLE_TYPE_NAME).Style.BackColor = Color.White
                            End If

                            '備考
                            If txtRemartks.Equals(String.Empty) = False And txtRemarks.Length > 50 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0030", COL_REMARKS, 50))
                                gridCells(COL_REMARKS).Style.BackColor = Color.Red
                                Exit For
                            Else
                                gridCells(COL_REMARKS).Style.BackColor = Color.White
                            End If

                            'データを更新
                            Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    txtVehicleType,
                                                                    txtVehicleTypeName,
                                                                    txtRemarks))

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
    ''' Delete(削除)事件
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnMenu3.Click

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

                            Dim txtVehicleType As String = gridData.Rows(i).Cells(COL_VEHICLE_TYPE).Value

                            '削除
                            Dim sqlstr As String = xml.GetSQL_Str("DELETE_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr, txtVehicleType))

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
    ''' クリア事件
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnMenu4.Click

        Me.cmbHinsyu.Text = String.Empty

        Me.txtVehicleType.Text = String.Empty
        Me.txtVehicleTypeName.Text = String.Empty
        Me.txtRemartks.Text = String.Empty

        Me.txtVehicleType.BackColor = Color.White
        Me.txtVehicleTypeName.BackColor = Color.White
        Me.txtRemartks.BackColor = Color.White

    End Sub

    ''' <summary>
    ''' 終了
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
                  vbYesNo + vbQuestion,
                  My.Settings.systemName) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class