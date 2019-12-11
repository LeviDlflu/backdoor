Imports System.Text
Imports PUCCommon

Public Class SC_K16
    Dim headerName As Hashtable = New Hashtable From {
                                {"詳細", "Details" & vbCrLf & "(詳細)"},
                                {"設備", "Equipment" & vbCrLf & "(設備)"},
                                {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                                {"客先部品番号", "Customer part NO" & vbCrLf & "(客先部品番号)"},
                                {"金型", "Mold" & vbCrLf & "(金型)"},
                                {"指示数", "Order quantity" & vbCrLf & "(指示数)"},
                                {"ショット数", "Shot quantity" & vbCrLf & "(ショット数)"},
                                {"合格数", "Pass quantity" & vbCrLf & "(合格数)"},
                                {"不良数", "Failure quantity" & vbCrLf & "(不良数)"},
                                {"調整数", "Adjustment quantity" & vbCrLf & "(調整数)"},
                                {"その他払出", "Other payout" & vbCrLf & "(その他払出)"},
                                {"合格率", "Pass rate" & vbCrLf & "(合格率)"},
                                {"不良率", "Failure rate" & vbCrLf & "(不良率)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_INDIVIDUAL As String = "区分個体NO"
    Private Const COL_EQUIPMENT As String = "設備"
    Private Const COL_GOODS_ABBREVIATION As String = "品名略称"
    Private Const COL_CUSTOMER_PART_NUMBER As String = "客先部品番号"
    Private Const COL_MOLD As String = "金型"
    Private Const COL_INSTRUCTION_NUMBER As String = "指示数"
    Private Const COL_SHOTS_NUMBER As String = "ショット数"
    Private Const COL_PASSING_NUMBER As String = "合格数"
    Private Const COL_FAILURE_NUMBER As String = "不良数"
    Private Const COL_ADJUSTMENT_NUMBER As String = "調整数"
    Private Const COL_OTHER_PAYOUT As String = "その他払出"
    Private Const COL_PASSING_RATE As String = "合格率"
    Private Const COL_DEFECTIVE_RATE As String = "不良率"

    Public gridCells As DataGridViewCellCollection

    Dim xml As New clsGetSqlXML("SC-K16.xml", "SC-K16")
    Dim sqlFilter As StringBuilder

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbEquipment.Text = String.Empty
        Me.cmbVariety.Text = String.Empty
        Me.cmbMold.Text = String.Empty
        Me.cmbProduct.Text = String.Empty
        '前々月以前の日付を選択不可
        Me.dtpActualFrom.DateTimePicker1.MinDate = Date.Now.AddMonths(-2)
        dtpActualTo.DateTimePicker1.MaxDate = dtpActualFrom.DateTimePicker1.Value.AddMonths(1)
        dtpActualTo.DateTimePicker1.MinDate = dtpActualFrom.DateTimePicker1.Value

        dtpActualFrom.TextBox1.Enabled = False
        dtpActualTo.TextBox1.Enabled = False

        '実績月
        cmbActualMonth.BackColor = Color.LightGray
        cmbActualMonth.Enabled = False

        Try

            Dim strSelect As String
            Dim dt As New DataTable

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '実績月
                strSelect = xml.GetSQL_Str("SELECT_007")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, businessCode))
                Me.cmbActualMonth.DataSource = dt
                Me.cmbActualMonth.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbActualMonth.DisplayMember = dt.Columns.Item(0).ColumnName

                '設備
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbEquipment.DataSource = dt
                Me.cmbEquipment.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbEquipment.DisplayMember = dt.Columns.Item(1).ColumnName

                '金型
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbMold.DataSource = dt
                Me.cmbMold.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbMold.DisplayMember = dt.Columns.Item(1).ColumnName

                '品種
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, businessCode))
                Me.cmbVariety.DataSource = dt
                Me.cmbVariety.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbVariety.DisplayMember = dt.Columns.Item(1).ColumnName

            End If
        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub


    ''' <summary>
    ''' 　・行ヘッダーに行番号書き込み
    ''' </summary>
    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridData.RowPostPaint
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
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByVal dtData As DataTable)
        gridData.Columns.Clear()

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS

        gridData.Columns.Add(btn)

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
            addCol.Name = col.ColumnName

            If col.ColumnName.Equals(COL_INDIVIDUAL) Then
                addCol.Visible = False
            End If

            gridData.Columns.Add(addCol)
        Next

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False

        gridData.DataSource = dtData.Copy

        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            If col.Name = COL_DETAILS Then
                col.ReadOnly = False
            Else
                col.ReadOnly = True
            End If

            '横位置
            Select Case col.Name
                Case COL_EQUIPMENT, COL_GOODS_ABBREVIATION, COL_CUSTOMER_PART_NUMBER
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_MOLD
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select

            If col.Name = COL_PASSING_RATE Or col.Name = COL_DEFECTIVE_RATE Then
                col.DefaultCellStyle.BackColor = Color.Orange
            End If
        Next

        '合計
        Dim dgvRow As DataGridViewRow = gridData.Rows(gridData.Rows.Count - 1)
        dgvRow.DefaultCellStyle.BackColor = Color.LightCyan

        dgvRow.Cells(COL_GOODS_ABBREVIATION).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        gridData.Columns(COL_DETAILS).Width = 55
        gridData.Columns(COL_EQUIPMENT).Width = 120
        gridData.Columns(COL_GOODS_ABBREVIATION).Width = 185
        gridData.Columns(COL_CUSTOMER_PART_NUMBER).Width = 110
        gridData.Columns(COL_MOLD).Width = 60
        gridData.Columns(COL_INSTRUCTION_NUMBER).Width = 85
        gridData.Columns(COL_SHOTS_NUMBER).Width = 85
        gridData.Columns(COL_PASSING_NUMBER).Width = 85
        gridData.Columns(COL_FAILURE_NUMBER).Width = 85
        gridData.Columns(COL_ADJUSTMENT_NUMBER).Width = 85
        gridData.Columns(COL_OTHER_PAYOUT).Width = 85
        gridData.Columns(COL_PASSING_RATE).Width = 85
        gridData.Columns(COL_DEFECTIVE_RATE).Width = 85

    End Sub

    ''' <summary>
    ''' 検索ボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try
            Dim dt As New DataTable()
            sqlFilter = New StringBuilder

            Me.lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")
            Me.lblSearchTime.Visible = True

            '範囲検索の場合
            If rdoRange.Checked Then
                '作業年月日
                sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_003"), dtpActualFrom.DateTimePicker1.Text, dtpActualTo.DateTimePicker1.Text))
            Else
                '作業年月
                sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_004"), cmbActualMonth.Text))
            End If

            '設備NO
            If Not String.IsNullOrWhiteSpace(cmbEquipment.SelectedValue) Then
                sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_005"), cmbEquipment.SelectedValue))
            End If

            '品種コード
            If Not String.IsNullOrWhiteSpace(cmbVariety.SelectedValue) Then
                sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_006"), cmbVariety.SelectedValue))

                '品名
                If String.IsNullOrEmpty(cmbProduct.SelectedValue) Then
                    If Not String.IsNullOrEmpty(cmbProduct.Text) Then
                        If chkSimilar.Checked Then
                            '品名略称
                            sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_009"), cmbProduct.Text))
                        Else
                            '品名略称
                            sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_010"), cmbProduct.Text))
                        End If
                    End If
                Else
                    '品名コード
                    sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_008"), cmbProduct.SelectedValue))
                End If
            End If

            '金型番号
            If String.IsNullOrWhiteSpace(cmbMold.SelectedValue) = False Then
                sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_007"), cmbMold.SelectedValue))
            End If

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim strSql, strSql2 As String

                strSql = xml.GetSQL_Str("SELECT_005")
                strSql2 = xml.GetSQL_Str("SELECT_006")

                dt = clsSQLServer.GetDataTable(String.Format(strSql, businessCode, sqlFilter.ToString))

                If dt.Rows.Count = 0 Then

                    gridData.Columns.Clear()

                    MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           systemName)

                    Return

                ElseIf dt.Rows.Count > 1000 Then

                    MsgBox(String.Format(clsGlobal.MSG2("W9004"), 1000),
                           vbExclamation,
                           systemName)

                End If

                Dim countDT As DataTable = clsSQLServer.GetDataTable(String.Format(strSql2, businessCode, sqlFilter.ToString))
                For Each row In countDT.Rows
                    dt.ImportRow(row)
                Next
            End If

            clsSQLServer.Disconnect()

            setGrid(dt)

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub

    ''' <summary>
    ''' 詳細画面を開く
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS AndAlso e.RowIndex > -1 Then

            'gridCells = gridData.Rows(e.RowIndex).Cells

            Dim frm As New SC_K16A()

            If String.IsNullOrEmpty(gridData.CurrentRow.Cells(COL_INDIVIDUAL).Value.ToString) Then
                'パラメータ.設備
                frm.Equipment = cmbEquipment.Text
                'パラメータ.品名略称
                frm.Product = cmbProduct.Text
                'パラメータ.金型
                frm.Mold = cmbMold.Text
                'パラメータ.個体NO
                frm.Individual = String.Empty
                'パラメータ.検索条件
                frm.WhereInfo = sqlFilter.ToString
            Else
                'パラメータ.品名略称
                frm.Product = gridData.CurrentRow.Cells(COL_GOODS_ABBREVIATION).Value.ToString
                'パラメータ.金型
                frm.Mold = gridData.CurrentRow.Cells(COL_MOLD).Value.ToString
                'パラメータ.設備
                frm.Equipment = gridData.CurrentRow.Cells(COL_EQUIPMENT).Value.ToString
                'パラメータ.個体NO
                frm.Individual = gridData.CurrentRow.Cells(COL_INDIVIDUAL).Value.ToString
                'パラメータ.検索条件
                frm.WhereInfo = String.Empty
            End If

            If rdoRange.Checked Then
                frm.WorkingFrom = dtpActualFrom.TextBox1.Text
                frm.WorkingTo = dtpActualTo.TextBox1.Text
            Else
                frm.WorkingFrom = cmbActualMonth.SelectedValue
                frm.WorkingTo = cmbActualMonth.SelectedValue
            End If

            frm.ShowDialog()
            'Me.Show()
        End If
    End Sub

    ''' <summary>
    ''' 範囲検索/過去検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRange.CheckedChanged
        If rdoRange.Checked = True Then
            '実績月
            cmbActualMonth.Enabled = False
            cmbActualMonth.BackColor = Color.LightGray
            '実績日
            dtpActualFrom.DateTimePicker1.Enabled = True
            dtpActualTo.DateTimePicker1.Enabled = True

            dtpActualFrom.TextBox1.BackColor = Color.Yellow
            dtpActualTo.TextBox1.BackColor = Color.Yellow
        Else
            cmbActualMonth.Enabled = True
            cmbActualMonth.BackColor = Color.Yellow

            dtpActualFrom.DateTimePicker1.Enabled = False
            dtpActualTo.DateTimePicker1.Enabled = False

            dtpActualFrom.TextBox1.BackColor = Color.LightGray
            dtpActualTo.TextBox1.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub dtpActualFrom_ValueChanged(sender As Object, e As EventArgs)
        dtpActualTo.DateTimePicker1.MaxDate = dtpActualFrom.DateTimePicker1.Value.AddMonths(1)
        dtpActualTo.DateTimePicker1.MinDate = dtpActualFrom.DateTimePicker1.Value
    End Sub

    ''' <summary>
    ''' 品名コンボボックスの作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbVariety_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariety.SelectedIndexChanged

        If String.IsNullOrWhiteSpace(cmbVariety.Text) = False Then
            Try

                Dim strSelect As String
                Dim dt As New DataTable

                'データベース接続
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                    '品名
                    strSelect = xml.GetSQL_Str("SELECT_003")
                    dt = clsSQLServer.GetDataTable(String.Format(strSelect, businessCode, cmbVariety.SelectedValue))

                End If
                clsSQLServer.Disconnect()

                Me.cmbProduct.DataSource = dt
                Me.cmbProduct.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbProduct.DisplayMember = dt.Columns.Item(1).ColumnName

                Me.cmbProduct.Enabled = True
                Me.chkSimilar.Enabled = True

            Catch ex As Exception
                Throw
            Finally
                clsSQLServer.Disconnect()
            End Try
        Else
            Me.cmbProduct.DataSource = Nothing
            Me.cmbProduct.Enabled = False
            Me.chkSimilar.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' 列の書式設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridData.CellFormatting
        If e.ColumnIndex > 5 And e.ColumnIndex < 12 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(e.Value, "####,##")
            End If
        ElseIf e.ColumnIndex > 11 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(e.Value / 100, "##0.00%")
            End If
        End If

    End Sub

    ''' <summary>
    ''' Excelボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If gridData.Rows.Count > 0 Then
            Dim xmlHeader As New clsGetSqlXML("ExportHeaderToExcel.xml", "SC-K16")

            Dim strNodeList As ArrayList = xmlHeader.GetXmlNodeList("HEADER_001")

            Dim dgv As DataGridView = gridData

            Dim isOK = clsExcel.ExportToExcel(dgv, "成形実績", strNodeList)

            If isOK = True Then
                MessageBox.Show(Me, "エクスポート完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

End Class