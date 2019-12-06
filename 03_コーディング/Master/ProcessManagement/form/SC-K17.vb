Imports PUCCommon
Imports System.Text
Imports System.Reflection
Imports System.Windows.Documents

Public Class SC_K17
    Dim headerName As Hashtable = New Hashtable From {
                             {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                             {"コード名称", "Mold" & vbCrLf & "(金型)"},
                             {"判定理由", "Failure reason" & vbCrLf & "(不良現象)"},
                             {"率", "Rate" & vbCrLf & "(率)"},
                             {"合計", "Total" & vbCrLf & "(合計)"}
                            }
    Private Const COL_PRODUCT_ABBREVIATION As String = "品名略称"
    Private Const COL_MOLD As String = "コード名称"
    Private Const COL_FAILURE_REASON As String = "判定理由"
    Private Const COL_RATE As String = "率"
    Private Const COL_TOTAL As String = "合計"

    Private Const PROCESSCODE As String = "20"

    Private Const DATEFROM As String = "実績日(始点)"
    Private Const DATETO As String = "実績日(終点)"

    Dim xml As New clsGetSqlXML("SC-K17.xml", "SC-K17")


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SC_K17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'init()
        Dim strSelect As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '対象年月
                strSelect = xml.GetSQL_Str("SELECT_001")

                Dim ssr = String.Format(strSelect,
                                                                       businessCode,
                                                                       PROCESSCODE
                                                                       )

                dt1 = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                       businessCode,
                                                                       PROCESSCODE
                                                                       ))
                Me.cmbVariety.DataSource = dt1
                Me.cmbVariety.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmbVariety.DisplayMember = dt1.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' 行ヘッダーに行番号書き込み
    ''' </summary>
    Private Sub griData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles griData.RowPostPaint
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.RowHeadersVisible Then
            '行番号を描画する範囲を決定する
            Dim rect As New Rectangle(e.RowBounds.Left,
                                      e.RowBounds.Top,
                                      dgv.RowHeadersWidth,
                                      e.RowBounds.Height)
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
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        btnSearch.Enabled = False
        'isCheck()
        Dim sqlString As New StringBuilder

        Dim dt As New DataTable

        ''検索条件必須チェック
        If Not isCheck() Then
            btnSearch.Enabled = True
            Return
        End If

        Dim datef, datet As String
        datef = Format(DateValue(dtpDateFrom.Text), "yyyy/MM/dd")
        datet = Format(DateValue(dtpDateTo.Text), "yyyy/MM/dd")

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                If rdoMold.Checked = True Then
                    '集計単位：金型
                    sqlString.Append(xml.GetSQL_Str("SELECT_003_1"))

                    Dim startDay As DateTime = DateValue(dtpDateFrom.Text)
                    Dim endDay As DateTime = DateValue(dtpDateTo.Text)
                    Dim d As DateTime = startDay

                    While d <= endDay
                        '日付別データ
                        sqlString.Append(",SUM(CASE WHEN 実績管理データ.作業年月日='" + Format(d, "yyyy/MM/dd") + "' THEN 1 ELSE 0 END) AS [" + Strings.Right(Format(d, "yyyy/MM/dd")， 5) + "]")
                        d = DateAdd("d", 1, d)
                    End While

                    sqlString.Append(String.Format(xml.GetSQL_Str("SELECT_003_2"),
                                                                           businessCode,
                                                                           datef,
                                                                           datet,
                                                                           PROCESSCODE))

                    If Not String.IsNullOrEmpty(cmbVariety.SelectedValue) Then
                        sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_001"),
                                                                           cmbVariety.SelectedValue))
                    End If

                    If Not String.IsNullOrEmpty(cmbProduct.Text) Then
                        If chkSimilar.Checked Then
                            sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_002"),
                                                       Replace(cmbProduct.Text, ":" + cmbProduct.SelectedValue, "")))
                        Else
                            sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_003"),
                                                       cmbProduct.SelectedValue))
                        End If
                    End If

                    sqlString.Append(xml.GetSQL_Str("SELECT_003_3"))

                Else
                    '集計単位：品名
                    sqlString.Append(xml.GetSQL_Str("SELECT_004_1"))

                    Dim startDay As DateTime = DateValue(dtpDateFrom.Text)
                    Dim endDay As DateTime = DateValue(dtpDateTo.Text)
                    Dim d As DateTime = startDay

                    While d <= endDay
                        '日付別データ
                        sqlString.Append(",SUM(CASE WHEN 実績管理データ.作業年月日='" + Format(d, "yyyy/MM/dd") + "' THEN 1 ELSE 0 END) AS [" + Strings.Right(Format(d, "yyyy/MM/dd")， 5) + "]")
                        d = DateAdd("d", 1, d)
                    End While

                    sqlString.Append(String.Format(xml.GetSQL_Str("SELECT_004_2"),
                                                                           businessCode,
                                                                           datef,
                                                                           datet,
                                                                           PROCESSCODE))

                    If Not String.IsNullOrEmpty(cmbVariety.SelectedValue) Then
                        sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_001"),
                                                                           cmbVariety.SelectedValue))
                    End If

                    If Not String.IsNullOrEmpty(cmbProduct.Text) Then
                        If chkSimilar.Checked Then
                            sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_002"),
                                                       Replace(cmbProduct.Text, ":" + cmbProduct.SelectedValue, "")))
                        Else
                            sqlString.Append(String.Format(xml.GetSQL_Str("WHERE_003"),
                                                       cmbProduct.SelectedValue))
                        End If
                    End If

                    sqlString.Append(xml.GetSQL_Str("SELECT_004_3"))
                End If
                dt = clsSQLServer.GetDataTable(sqlString.ToString)

                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
        End Try

        If dt.Rows.Count = 0 Then
            MessageBox.Show(clsGlobal.MSG2("W0008"))
            griData.Columns.Clear()
            btnSearch.Enabled = True
            Return
        ElseIf dt.Rows.Count > 1000 Then
            MsgBox(String.Format(clsGlobal.MSG2("W9004"), 1000),
                           vbExclamation,
                           systemName)
            griData.Columns.Clear()
            btnSearch.Enabled = True
            Return
        End If

        Dim prodname As String = dt.Rows(0).Item("品名略称")
        Dim moldname As String = dt.Rows(0).Item("コード名称")

        '期間合計
        Dim moldsum As Integer = 0
        '日付別合計
        Dim sum(dt.Columns.Count - 5) As Integer

        Dim dtdata As New DataTable
        For Each col As DataColumn In dt.Columns
            dtdata.Columns.Add(col.ColumnName)
        Next

        '品名金型別合計を表示する
        For rowc As Integer = 0 To dt.Rows.Count - 1

            If prodname.Equals(dt.Rows(rowc).Item("品名略称")) And moldname.Equals(dt.Rows(rowc).Item("コード名称")) Then
                moldsum += dt.Rows(rowc).Item(4)
                For colc As Integer = 5 To dt.Columns.Count - 1
                    sum(colc - 5) += dt.Rows(rowc).Item(colc)
                Next
                dtdata.ImportRow(dt.Rows(rowc))
            Else
                Dim sumrow As DataRow = dtdata.NewRow
                sumrow(0) = prodname
                sumrow(1) = moldname
                sumrow(2) = "計"
                sumrow(4) = moldsum
                moldsum = dt.Rows(rowc).Item(4)

                For colc As Integer = 5 To dt.Columns.Count - 1
                    sumrow(colc) = sum(colc - 5)
                    sum(colc - 5) = dt.Rows(rowc).Item(colc)
                Next

                dtdata.Rows.Add(sumrow)
                dtdata.ImportRow(dt.Rows(rowc))

                prodname = dt.Rows(rowc).Item("品名略称")
                moldname = dt.Rows(rowc).Item("コード名称")
            End If

        Next

        '最後の合計行を表示する
        Dim sumrow2 As DataRow = dtdata.NewRow
        sumrow2(0) = prodname
        sumrow2(1) = moldname
        sumrow2(2) = "計"
        sumrow2(4) = moldsum

        For colc As Integer = 5 To dt.Columns.Count - 1
            sumrow2(colc) = sum(colc - 5)
            sum(colc - 5) = dt.Rows(0).Item(colc)
        Next

        dtdata.Rows.Add(sumrow2)

        setGrid(dtdata)

        lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")

        btnSearch.Enabled = True
    End Sub

    ''' <summary>
    ''' 検索条件必須チェック
    ''' </summary>
    Private Function isCheck() As Boolean

        '実績日(始点)必須チェック
        If String.IsNullOrEmpty(dtpDateFrom.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), DATEFROM))
            dtpDateFrom.BackColor = Color.Red
            Return False
        Else
            dtpDateFrom.BackColor = Color.Yellow
        End If

        '実績日(終点)必須チェック
        If String.IsNullOrEmpty(dtpDateTo.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), DATETO))
            dtpDateTo.BackColor = Color.Red
            Return False
        Else
            dtpDateTo.BackColor = Color.Yellow
        End If

        '実績日有効性チェック
        If DateValue(dtpDateFrom.Text) > DateValue(dtpDateTo.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W1002"), DATETO))
            dtpDateTo.BackColor = Color.Red
            Return False
        Else
            dtpDateTo.BackColor = Color.Yellow
        End If

        '実績日日付範囲チェック
        If DateAdd("m", 1, dtpDateFrom.Text) < DateValue(dtpDateTo.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W1003"), DATETO))
            dtpDateTo.BackColor = Color.Red
            Return False
        Else
            dtpDateTo.BackColor = Color.Yellow
        End If

        '実績日日付範囲チェック
        If DateAdd("m", -2, Now) > DateValue(dtpDateFrom.Text) Then
            MessageBox.Show(clsGlobal.MSG2("W1001"))
            dtpDateTo.BackColor = Color.Red
            Return False
        Else
            dtpDateTo.BackColor = Color.Yellow
        End If

        '実績日日付範囲チェック
        If DateAdd("m", -2, Now) > DateValue(dtpDateTo.Text) Then
            MessageBox.Show(clsGlobal.MSG2("W1001"))
            dtpDateTo.BackColor = Color.Red
            Return False
        Else
            dtpDateTo.BackColor = Color.Yellow
        End If

        Return True
    End Function


    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        griData.Columns.Clear()


        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName
            griData.Columns.Add(addCol)

        Next

        griData.DataSource = dtData.Copy
        griData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        griData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray

        For i As Integer = 0 To griData.Columns.Count - 1
            griData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case griData.Columns(i).Name
                Case COL_PRODUCT_ABBREVIATION, COL_MOLD, COL_FAILURE_REASON
                    griData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                Case COL_RATE, COL_TOTAL
                    griData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    griData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        Next

        griData.AutoResizeColumns()

        For Each col As DataGridViewColumn In griData.Columns
            col.ReadOnly = True
        Next

        griData.Columns(0).Width = 200
        griData.Columns(1).Width = 80
        griData.Columns(2).Width = 100
        griData.Columns(3).Width = 60
        griData.Columns(4).Width = 60

        Dim strSelect As String
        Dim dt1 As New DataTable

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '対象年月
                strSelect = xml.GetSQL_Str("SELECT_005")

                dt1 = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                       Format(DateValue(dtpDateFrom.Text), "yyyy/MM/dd")，
                                                                       Format(DateValue(dtpDateTo.Text), "yyyy/MM/dd")
                                                                       ))

                For i = 5 To griData.Columns.Count - 1
                    If griData.Columns(i).Name = dt1.Rows(i - 5).Item(0) Then
                        If dt1.Rows(i - 5).Item(1) = 0 Then
                            griData.Columns(i).DefaultCellStyle.BackColor = Color.GreenYellow
                        End If
                    End If
                    griData.Columns(i).Width = 50

                Next
                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
        End Try

        For i = 0 To griData.Rows.Count - 2
            If Not String.IsNullOrEmpty(griData.Rows(i).Cells(2).Value.ToString) Then
                If griData.Rows(i).Cells(2).Value.ToString.Equals("計") Then

                    For j = 2 To griData.Columns.Count - 1
                        griData.Rows(i).Cells(j).Style.BackColor = Color.Yellow
                    Next
                End If
            End If
        Next

        griData.MergeColumnNames.Add("品名略称")
        griData.MergeColumnNames.Add("コード名称")

        If rdoProduct.Checked = True Then
            griData.Columns(1).Visible = False
        End If

        '編集不可
        griData.AllowUserToDeleteRows = False
        griData.AllowUserToAddRows = False
        griData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 払出区分
    ''' </summary>
    Private Sub cmbVariety_TextChanged(sender As Object, e As EventArgs) Handles cmbVariety.TextChanged
        Dim strSelect As String
        Dim dt1 As New DataTable

        If cmbVariety.Text <> "" Then
            Try
                'データベース接続
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '対象年月
                    strSelect = xml.GetSQL_Str("SELECT_002")
                    dt1 = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                           businessCode,
                                                                           Mid(cmbVariety.Text, 1, 2)
                                                                           ))
                    Me.cmbProduct.DataSource = dt1
                    Me.cmbProduct.ValueMember = dt1.Columns.Item(0).ColumnName
                    Me.cmbProduct.DisplayMember = dt1.Columns.Item(1).ColumnName

                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cmbVariety_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariety.SelectedIndexChanged
        Dim strSelect As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '対象年月
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt1 = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                       businessCode,
                                                                       cmbVariety.SelectedValue
                                                                       ))
                Me.cmbProduct.DataSource = dt1
                Me.cmbProduct.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmbProduct.DisplayMember = dt1.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' 列の書式設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub griData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles griData.CellFormatting
        If e.ColumnIndex = 3 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(Val(e.Value / 100), "##0.00%")
            End If
        ElseIf e.ColumnIndex > 3 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(Val(e.Value), "####,#0")
            End If
        End If

    End Sub

End Class