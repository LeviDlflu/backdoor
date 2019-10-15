Imports PUCCommon.clsGlobal
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

    Dim xml As New CmnXML("SC-M13.xml")

    Private Sub Init()
        Me.cmbProcess.Text = String.Empty
        Me.txtDefect.Text = String.Empty
        Me.txtDefectName.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
        Me.txtDisplaydivision.Text = String.Empty

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
    Private Sub SC_M13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                Dim sqlStr As String = xml.GetSQL("select", "select_001")
                Dim dt As New DataTable()
                dt = clsSQLServer.GetDataTable(sqlStr)

                'setGrid(createGridData(dt))
                setGrid(dt)
                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        If gridData.Rows.Count > 0 Then
            gridData.Columns.Clear()
        End If

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
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData(ByRef dtData As DataTable) As DataTable
        'Dim dt As New DataTable
        'dt.Columns.Add(New DataColumn(COL_SENTAKU, GetType(System.Boolean)))
        'dt.Columns.Add(New DataColumn(COL_PROCESS_CODE, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_DEFECT_CODE, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_DEFECT_PHENOMENON_NAME, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_REMARKS, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_DISPLAY_DIVISION, GetType(System.String)))

        'For i As Integer = 0 To dtData.Rows.Count - 1
        '    Dim addRow As DataRow = dt.NewRow
        '    addRow(COL_PROCESS_CODE) = dtData.Rows(i).Item("工程コード")
        '    addRow(COL_DEFECT_CODE) = dtData.Rows(i).Item("不良コード")
        '    addRow(COL_DEFECT_PHENOMENON_NAME) = dtData.Rows(i).Item("不良現象名")
        '    addRow(COL_REMARKS) = dtData.Rows(i).Item("備考")

        '    dt.Rows.Add(addRow)
        'Next

        'Return dt

    End Function

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

        If MsgBox(cmnUtil.GetMessageStr("Q0001"), vbOKCancel, "不良現象マスタ") = DialogResult.OK Then

            If cmbProcess.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "工程コード"))
                cmbProcess.BackColor = Color.Red
                Return
            Else
                cmbProcess.BackColor = Color.White
            End If

            If txtDefect.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "不良コード"))
                txtDefect.BackColor = Color.Red
                Return
            Else
                txtDefect.BackColor = Color.White
            End If

            If txtDefectName.Text.Equals(String.Empty) Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "不良現象名"))
                txtDefectName.BackColor = Color.Red
                Return
            Else
                txtDefectName.BackColor = Color.White
            End If

            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    Dim sqlstr As String = xml.GetSQL("insert", "insert_001")

                    clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            cmbProcess.Text.Substring(0, 2),
                                                            txtDefect.Text,
                                                            txtDefectName.Text,
                                                            txtRemarks.Text,
                                                            "0"))
                    clsSQLServer.Disconnect()
                    btnSearch_Click(sender, e)

                End If

            Catch ex As Exception
                Throw
            End Try

            Me.cmbProcess.Text = String.Empty
            Me.txtDefect.Text = String.Empty
            Me.txtDefectName.Text = String.Empty
            Me.txtRemarks.Text = String.Empty
            Me.txtDisplaydivision.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MsgBox(cmnUtil.GetMessageStr("Q0002"), vbOKCancel, "不良現象マスタ") = DialogResult.OK Then
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                For i As Integer = 0 To gridData.Rows.Count - 1
                    If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then
                        Dim sqlstr As String = xml.GetSQL("update", "update_001")
                        clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                gridData.Rows(i).Cells(1).Value,
                                                                gridData.Rows(i).Cells(2).Value,
                                                                gridData.Rows(i).Cells(3).Value,
                                                                gridData.Rows(i).Cells(4).Value,
                                                                gridData.Rows(i).Cells(5).Value))
                    End If
                Next
                clsSQLServer.Disconnect()
                btnSearch_Click(sender, e)

            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0003"), vbOKCancel + vbExclamation, "不良現象マスタ") = DialogResult.OK Then

            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    For i As Integer = 0 To gridData.Rows.Count - 1
                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then

                            Dim sqlstr As String = xml.GetSQL("delete", "delete_001")

                            clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                                    gridData.Rows(i).Cells(1).Value,
                                                                    gridData.Rows(i).Cells(2).Value))

                        End If

                    Next

                    clsSQLServer.Disconnect()

                    btnSearch_Click(sender, e)

                    'setManagementNoType()
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    ''' <summary>
    ''' クリア処理
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If MsgBox(cmnUtil.GetMessageStr("Q0009"), vbOKCancel, "不良現象マスタ") = DialogResult.OK Then
            gridData.Columns.Clear()
        End If
    End Sub

End Class