Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class SC_M18

    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"区分", "Division" & vbCrLf & "(区分)"},
                             {"区分名", "Division name" & vbCrLf & "(区分名)"},
                             {"品名コード", "Product code" & vbCrLf & "(品名コード)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"},
                             {"設定コード", "Setting code" & vbCrLf & "(設定コード)"},
                             {"設定コード名", "Setting name" & vbCrLf & "(設定コード名)"},
                             {"設定コード２", "Setting code2" & vbCrLf & "(設定コード２)"},
                             {"設定コード名２", "Setting name2" & vbCrLf & "(設定コード名２)"},
                             {"設定コード３", "Setting code3" & vbCrLf & "(設定コード３)"},
                             {"設定コード名３", "Setting name3" & vbCrLf & "(設定コード名３)"},
                             {"設定コード４", "Setting code4" & vbCrLf & "(設定コード４)"},
                             {"設定コード名４", "Setting name4" & vbCrLf & "(設定コード名４)"},
                             {"備考２", "Remarks2" & vbCrLf & "(備考２)"}
                            }

    Private Const COL_SELECT As String = "選択"
    Private Const COL_DIVISION As String = "区分"
    Private Const COL_DIVISION_NAME As String = "区分名"
    Private Const COL_PRODUCT_CODE As String = "品名コード"
    Private Const COL_REMARKS As String = "備考"
    Private Const COL_SETTING_CODE As String = "設定コード"
    Private Const COL_SETTING_NAME As String = "設定コード名"
    Private Const COL_SETTING_CODE2 As String = "設定コード２"
    Private Const COL_SETTING_NAME2 As String = "設定コード名２"
    Private Const COL_SETTING_CODE3 As String = "設定コード３"
    Private Const COL_SETTING_NAME3 As String = "設定コード名３"
    Private Const COL_SETTING_CODE4 As String = "設定コード４"
    Private Const COL_SETTING_NAME4 As String = "設定コード名４"
    Private Const COL_REMARKS2 As String = "備考２"

    Private Const ITEM_KOUTEI As String = "工程"
    Private Const ITEM_SYASYU As String = "車種"
    Private Const ITEM_HINMEI As String = "品名"
    Dim i As Integer = 0
    Private list As New List(Of String)
    Dim xml As New CmnXML("SC-M18.xml", "SC-M18")

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        '必須チェック
        If Not IsNecessary() Then
            Return
        End If

        Dim dtResult As DataTable = createGridData()

        'データ確認
        If dtResult.Rows.Count = 0 Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0008"))
        End If

        '検索結果を画面に表示
        setGrid(dtResult)

    End Sub

    ''' <summary>
    ''' 必須チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function isNecessary() As Boolean
        '工程
        If String.IsNullOrEmpty(cmb_Koutei.Text) Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            cmb_Koutei.BackColor = Color.Red
            Return False
        Else
            cmb_Koutei.BackColor = Color.White
        End If

        Return True
    End Function

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable

        Dim dt As New DataTable

        Dim baseSql As String
        Dim selectSql As New StringBuilder
        Dim whereCond As String
        Dim sortCond As String

        baseSql = xml.GetSQL_Str("SELECT_005")
        selectSql.Append(baseSql)

        '工程コード
        whereCond = xml.GetSQL_Str("WHERE_001")
        selectSql.Append(String.Format(whereCond, cmb_Koutei.SelectedValue))

        '区分
        If Not String.IsNullOrEmpty(cmb_Kbn.Text) Then
            whereCond = xml.GetSQL_Str("WHERE_002")
            selectSql.Append(String.Format(whereCond, cmb_Kbn.SelectedValue))
        End If

        '車種コード
        If Not String.IsNullOrEmpty(cmb_Syasyu.Text) Then
            whereCond = xml.GetSQL_Str("WHERE_003")
            selectSql.Append(String.Format(whereCond, cmb_Syasyu.SelectedValue))
        End If

        '品名コード
        If Not String.IsNullOrEmpty(cmb_HinCd.Text) Then
            whereCond = xml.GetSQL_Str("WHERE_004")
            selectSql.Append(String.Format(whereCond, cmb_HinCd.SelectedValue))
        End If


        '区分（昇順）
        sortCond = xml.GetSQL_Str("SORT_001")

        selectSql.Append(sortCond)

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                dt = clsSQLServer.GetDataTable(selectSql.ToString)

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        Return dt

    End Function

    ''' <summary>
    ''' グリッドを設定する
    ''' </summary>
    ''' <param name="dtData"></param>
    Private Sub setGrid(ByRef dtData As DataTable)
        gridData.Columns.Clear()

        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = HEADER_NAME(COL_SELECT)
        addColSentaku.HeaderText = HEADER_NAME(COL_SELECT)
        addColSentaku.Name = "sentaku"
        addColSentaku.HeaderCell.Style.BackColor = Color.LightGray
        gridData.Columns.Add(addColSentaku)

        For Each col As DataColumn In dtData.Columns
            If col.ColumnName = COL_DIVISION Or col.ColumnName = COL_DIVISION_NAME Or col.ColumnName =
                COL_PRODUCT_CODE Or col.ColumnName = COL_REMARKS Then
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.LightGray
                addCol.HeaderCell.Style.BackColor = Color.LightGray
                gridData.Columns.Add(addCol)
            Else
                Dim addCol As New DataGridViewTextBoxColumn()
                addCol.DataPropertyName = col.ColumnName
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
                addCol.Name = col.ColumnName
                addCol.DefaultCellStyle.BackColor = Color.White
                addCol.HeaderCell.Style.BackColor = Color.LightGray
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
        gridData.Columns(1).Width = 55
        gridData.Columns(2).Width = 90
        gridData.Columns(3).Width = 80
        gridData.Columns(4).Width = 120
        gridData.Columns(5).Width = 82
        gridData.Columns(6).Width = 110
        gridData.Columns(7).Width = 82
        gridData.Columns(8).Width = 110
        gridData.Columns(9).Width = 82
        gridData.Columns(10).Width = 110
        gridData.Columns(11).Width = 82
        gridData.Columns(12).Width = 110
        gridData.Columns(13).Width = 120

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
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    Private Sub SC_M18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim strSelect As String
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable
            Dim dt3 As New DataTable
            Dim dt4 As New DataTable
            Dim dt5 As New DataTable

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                'コード区分
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt1 = clsSQLServer.GetDataTable(String.Format(strSelect, "042"))
                Me.cmb_Kbn.DataSource = dt1
                Me.cmb_Kbn.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmb_Kbn.DisplayMember = dt1.Columns.Item(1).ColumnName

                '工程コード
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt2 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Koutei.DataSource = dt2
                Me.cmb_Koutei.ValueMember = dt2.Columns.Item(0).ColumnName
                Me.cmb_Koutei.DisplayMember = dt2.Columns.Item(1).ColumnName

                '車種名
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt3 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Syasyu.DataSource = dt3
                Me.cmb_Syasyu.ValueMember = dt3.Columns.Item(0).ColumnName
                Me.cmb_Syasyu.DisplayMember = dt3.Columns.Item(1).ColumnName

                '品名
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt4 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_HinCd.DataSource = dt4
                Me.cmb_HinCd.ValueMember = dt4.Columns.Item(0).ColumnName
                Me.cmb_HinCd.DisplayMember = dt4.Columns.Item(1).ColumnName

                '品名コード
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt5 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Copy_HinCd.DataSource = dt5
                Me.cmb_Copy_HinCd.ValueMember = dt5.Columns.Item(0).ColumnName
                Me.cmb_Copy_HinCd.DisplayMember = dt5.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 　クリアボタン押下
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0009")),
          vbOKCancel + vbQuestion,
          My.Settings.systemName) = DialogResult.OK Then
            cmb_Kbn.SelectedIndex = -1
            cmb_Koutei.SelectedIndex = -1
            cmb_Syasyu.SelectedIndex = -1
            cmb_HinCd.SelectedIndex = -1
            cmb_Copy_HinCd.SelectedIndex = -1
            'gridData.RowHeadersDefaultCellStyle.BackColor = Color.LightGray
            gridData.Columns.Clear()
        End If


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
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

        If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
            gridData.EndEdit()
            Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
            If Checked Then

                For i As Integer = 5 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = False
                Next
            Else

                For i As Integer = 5 To gridData.Columns.Count - 1
                    gridData.CurrentRow.Cells(i).ReadOnly = True
                Next
            End If
        End If

    End Sub

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        If MsgBox(String.Format(clsGlobal.MSG2("I0002")),
                 vbOKCancel + vbQuestion,
                 My.Settings.systemName) = DialogResult.OK Then
            Try

                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    For i As Integer = 0 To gridData.Rows.Count - 1

                        '横位置
                        If Not IsNothing(gridData.Rows(i).Cells(0).Value) Then
                            Dim selectSql As String
                            selectSql = xml.GetSQL_Str("SELECT_006")
                            Dim dt As New DataTable()
                            dt = clsSQLServer.GetDataTable(String.Format(selectSql,
                                                                         gridData.Rows(i).Cells(1).Value,
                                                                         gridData.Rows(i).Cells(3).Value))
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show(cmnUtil.GetMessageStr("W0003"))
                                clsSQLServer.Disconnect()
                                Return
                            Else
                                Dim sqlstr As String = xml.GetSQL_Str("UPDATE_001")

                                clsSQLServer.ExecuteQuery(String.Format(sqlstr,
                                                            gridData.Rows(i).Cells(1).Value,
                                                            gridData.Rows(i).Cells(3).Value,
                                                            gridData.Rows(i).Cells(5).Value,
                                                            gridData.Rows(i).Cells(6).Value,
                                                            gridData.Rows(i).Cells(7).Value,
                                                            gridData.Rows(i).Cells(8).Value,
                                                            gridData.Rows(i).Cells(9).Value,
                                                            gridData.Rows(i).Cells(10).Value,
                                                            gridData.Rows(i).Cells(11).Value,
                                                            gridData.Rows(i).Cells(12).Value,
                                                            gridData.Rows(i).Cells(13).Value,
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

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        '品名
        If String.IsNullOrEmpty(cmb_HinCd.Text) Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", "品名"))
            cmb_HinCd.BackColor = Color.Red
            Return
        Else
            cmb_HinCd.BackColor = Color.White
        End If

        '複写品名
        If String.IsNullOrEmpty(cmb_Copy_HinCd.Text) Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
            cmb_Copy_HinCd.BackColor = Color.Red
            Return
        Else
            cmb_Copy_HinCd.BackColor = Color.White
        End If

        '同一品名が選択されています。
        If cmb_HinCd.SelectedValue = cmb_Copy_HinCd.SelectedValue Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
            cmb_HinCd.BackColor = Color.Red
            cmb_Copy_HinCd.BackColor = Color.Red
            Return
        Else
            cmb_HinCd.BackColor = Color.White
            cmb_Copy_HinCd.BackColor = Color.White
        End If


        If clsSQLServer.Connect(clsGlobal.ConnectString) Then
            Dim sqlselect As String
            sqlselect = xml.GetSQL_Str("SELECT_007")
            Dim dt As New DataTable()
            dt = clsSQLServer.GetDataTable(String.Format(sqlselect,
                                                         cmb_HinCd.SelectedValue))
            If dt.Rows.Count > 0 Then
                MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
                clsSQLServer.Disconnect()
                Return
            Else
                Dim selectsql As String
                Dim dtResult As New DataTable()
                selectsql = xml.GetSQL_Str("SELECT_008")
                dtResult = clsSQLServer.GetDataTable(String.Format(selectsql,
                                                             cmb_Copy_HinCd.SelectedValue))
                If dtResult.Rows.Count = 0 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
                    clsSQLServer.Disconnect()
                    Return
                Else
                    Dim insertsql As String
                    insertsql = xml.GetSQL_Str("INSERT_001")
                    For Each row As DataRow In dtResult.Rows
                        clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                             cmb_HinCd.SelectedValue,
                                                             row.Item(1),
                                                             row.Item(2),
                                                             row.Item(3),
                                                             row.Item(4),
                                                             row.Item(5),
                                                             row.Item(6),
                                                             row.Item(7),
                                                             row.Item(8),
                                                             row.Item(9),
                                                             row.Item(10),
                                                             row.Item(11)
                                                             ))
                    Next
                    clsSQLServer.Disconnect()
                End If
            End If
        End If
    End Sub

    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click
        If list.Count = 0 Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
            Return
        End If
        Dim dtable As DataTable = gridData.DataSource
        Dim sortsql As New StringBuilder
        For Each a As String In list
            sortsql.Append(a)
            sortsql.Append(" ASC,")
        Next
        sortsql.Remove(sortsql.Length - 1, 1)
        Dim dv As DataView = dtable.DefaultView
        dv.Sort = sortsql.ToString
        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()

    End Sub

    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click
        If list.Count = 0 Then
            MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
            Return
        End If
        Dim dtable As DataTable = gridData.DataSource
        Dim sortsql As New StringBuilder
        For Each a As String In list
            sortsql.Append(a)
            sortsql.Append(" DESC,")
        Next
        sortsql.Remove(sortsql.Length - 1, 1)
        Dim dv As DataView = dtable.DefaultView
        dv.Sort = sortsql.ToString
        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()
    End Sub


    Private Sub gridData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellClick
        If e.ColumnIndex > 0 Then
            If gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue Then
                list.Remove(gridData.Columns.Item(e.ColumnIndex).Name)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.LightGray
                i -= 1
            Else
                If i > 2 Then
                    MessageBox.Show(cmnUtil.GetMessageStr("W0001", "複写品名"))
                    Return
                End If
                list.Add(gridData.Columns.Item(e.ColumnIndex).Name)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue
                i += 1
            End If
        End If
    End Sub
End Class