Imports PUCCommon
Imports System.Text

Public Class SC_K13
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"品名略称", "Product name" & vbCrLf & "(品名)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"金型", "Mold" & vbCrLf & "(金型)"},
                             {"着手", "Start" & vbCrLf & "(着手)"},
                             {"完成", "Completion" & vbCrLf & "(完成)"},
                             {"不良", "Defect" & vbCrLf & "(不良)"},
                             {"SP･試作･他工程振替", "SP・Prototype・Other process transfer" & vbCrLf & "(SP･試作･他工程振替)"},
                             {"当日", "Today" & vbCrLf & "(当日)"},
                             {"訂正", "Correction" & vbCrLf & "(訂正)"},
                             {"合格", "Pass" & vbCrLf & "(合格)"},
                             {"生地", "Fabric" & vbCrLf & "(生地)"},
                             {"直行", "Direct" & vbCrLf & "(直行)"},
                             {"再塗装", "Repainting" & vbCrLf & "(再塗装)"},
                             {"スポット", "Spot" & vbCrLf & "(スポット)"},
                             {"生地不良＿成形", "Defective fabric (molding)" & vbCrLf & "生地不良(成形)"},
                             {"生地不良＿仕上", "Defective fabric (finish)" & vbCrLf & "生地不良(仕上)"},
                             {"再塗装判定", "Repaint judgment" & vbCrLf & "(再塗装判定)"},
                             {"スポット判定", "Spot judgment" & vbCrLf & "(スポット判定)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PRODUCT_NAME As String = "品名略称"
    Private Const COL_CUSTOMER_PART_NO As String = "客先部品番号"
    Private Const COL_MOLD As String = "金型"
    Private Const COL_START As String = "着手"
    Private Const COL_COMPLETION As String = "完成"
    Private Const COL_DEFECT As String = "不良"
    Private Const COL_SP_PRO_TRANSFER As String = "SP･試作･他工程振替"
    Private Const COL_TODAY As String = "当日"
    Private Const COL_CORRECTION As String = "訂正"
    Private Const COL_PASS As String = "合格"
    Private Const COL_COMPLETION_THE_DAY As String = "完成＿当日"
    Private Const COL_COMPLETION_CORRECTION As String = "完成＿訂正"
    Private Const COL_DEFECT_THE_DAY As String = "不良＿当日"
    Private Const COL_DEFECT_CORRECTION As String = "不良＿訂正"
    Private Const COL_SP_PROP_TRANSFER_PASS As String = "SP･試作･他工程振替＿合格"
    Private Const COL_SP_PROP_TRANSFER_DEFECT As String = "SP･試作･他工程振替＿不良"

    Private Const COL_START_FABRIC As String = "着手＿生地"
    Private Const COL_START_REPAINTING As String = "着手＿再塗装"
    Private Const COL_COMPLETION_DIRECT As String = "完成＿直行"
    Private Const COL_COMPLETING_REPAINTING As String = "完成＿再塗装"
    Private Const COL_COMPLETING_SPOT As String = "完成＿スポット"

    Private Const COL_DEFECTIVE_FABRIC_MOLDING As String = "生地不良＿成形"
    Private Const COL_DEFECTIVE_FABRIC_FINISH As String = "生地不良＿仕上"
    Private Const COL_REPAINT_JUDGMENT As String = "再塗装判定"
    Private Const COL_SPOT_JUDGMENT As String = "スポット判定"

    Private Const COL_FABRIC As String = "生地"
    Private Const COL_REPAINTING As String = "再塗装"
    Private Const COL_DIRECT As String = "直行"
    Private Const COL_MOLDING As String = "成形"
    Private Const COL_FINISH As String = "仕上"
    Private Const COL_SPOT As String = "スポット"

    Private Const COL_HIDDEN_1 As String = "データ存在フラグ"
    Private Const COL_HIDDEN_2 As String = "品名事業所コード"
    Private Const COL_HIDDEN_3 As String = "パック品名略称"
    Private Const COL_HIDDEN_4 As String = "納入先コード"
    Private Const COL_HIDDEN_5 As String = "納入区分"
    Private Const COL_HIDDEN_6 As String = "製品半製品区分"
    Private Const COL_HIDDEN_7 As String = "設備"

    Private Const FORM_NAME_K14 As String = "The results before the previous days(前日以前実績参照)"
    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"

    ''' <summary>
    ''' 列ヘッダーの行数
    ''' </summary>
    ''' <remarks></remarks>
    Private ColumnHeaderRowCount As Integer = 2

    ''' <summary>
    ''' 列ヘッダーの行の高さ
    ''' </summary>
    ''' <remarks></remarks>
    Private columnHeaderrRowHeight As Integer = 30

    Dim xml As New clsGetSqlXML("SC-K13.xml", "SC-K13")

    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SC_K13_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim strSelect As String
            Dim dt As New DataTable

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '大工程
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbProcess.DataSource = dt
                Me.cmbProcess.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbProcess.DisplayMember = dt.Columns.Item(1).ColumnName

                '品種
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbVariety.DataSource = dt
                Me.cmbVariety.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbVariety.DisplayMember = dt.Columns.Item(1).ColumnName

                '区分
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbSection.DataSource = dt
                Me.cmbSection.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbSection.DisplayMember = dt.Columns.Item(1).ColumnName

                '車種
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbVehicleType.DataSource = dt
                Me.cmbVehicleType.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbVehicleType.DisplayMember = dt.Columns.Item(1).ColumnName

                '設備
                strSelect = xml.GetSQL_Str("SELECT_005")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, cmbProcess.SelectedValue))
                Me.cmbFacility.DataSource = dt
                Me.cmbFacility.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbFacility.DisplayMember = dt.Columns.Item(1).ColumnName

            End If

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim dt As New DataTable()
        Me.lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")
        Me.lblSearchTime.Visible = True

        gridData.Columns.Clear()

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim strSql As String = String.Empty
                Dim sqlFilter As New StringBuilder

                Select Case cmbProcess.SelectedValue
                    Case "10", "20"
                        '成形/成形仕上
                        strSql = xml.GetSQL_Str("SELECT_006")
                    Case "30"
                        '塗装
                        strSql = xml.GetSQL_Str("SELECT_007")
                    Case "40"
                        '組立
                        strSql = xml.GetSQL_Str("SELECT_008")
                End Select

                '区分
                If Not String.IsNullOrEmpty(cmbSection.SelectedValue) Then
                    sqlFilter.AppendLine(String.Format(xml.GetSQL_Str("WHERE_001"), cmbSection.SelectedValue))
                End If

                '車種
                If Not String.IsNullOrEmpty(cmbVehicleType.SelectedValue) Then
                    sqlFilter.AppendLine(String.Format(xml.GetSQL_Str("WHERE_002"), cmbVehicleType.SelectedValue))
                End If

                '設備
                If Not String.IsNullOrEmpty(cmbFacility.SelectedValue) Then
                    sqlFilter.AppendLine(String.Format(xml.GetSQL_Str("WHERE_003"), cmbFacility.SelectedValue))
                End If

                dt = clsSQLServer.GetDataTable(String.Format(strSql, businessCode, cmbProcess.SelectedValue, cmbVariety.SelectedValue, sqlFilter.ToString))

            End If

            clsSQLServer.Disconnect()

            If dt.Rows.Count = 0 Then

                MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           systemName)

                Return

            ElseIf dt.Rows.Count > 1000 Then

                MsgBox(String.Format(clsGlobal.MSG2("W9004"), 1000),
                           vbExclamation,
                           systemName)

            End If


            Dim btn As New DataGridViewButtonColumn()
            btn.Name = COL_DETAILS
            btn.HeaderText = headerName(COL_DETAILS)
            btn.DefaultCellStyle.NullValue = COL_DETAILS
            gridData.Columns.Add(btn)

            Select Case cmbProcess.SelectedValue
                Case "10", "20"
                    '成形/成形仕上
                    Patten1(dt)
                Case "30"
                    '塗装
                    Patten2(dt)
                Case "40"
                    '組立
                    Patten3(dt)
            End Select

            '画面非表示列
            gridData.Columns(COL_HIDDEN_1).Visible = False
            gridData.Columns(COL_HIDDEN_2).Visible = False
            gridData.Columns(COL_HIDDEN_3).Visible = False
            gridData.Columns(COL_HIDDEN_4).Visible = False
            gridData.Columns(COL_HIDDEN_5).Visible = False
            gridData.Columns(COL_HIDDEN_6).Visible = False
            gridData.Columns(COL_HIDDEN_7).Visible = False

            '複数選択不可
            gridData.MultiSelect = False
            '編集不可
            gridData.AllowUserToDeleteRows = False
            gridData.AllowUserToAddRows = False
            gridData.AllowUserToResizeRows = False

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS And e.RowIndex >= 0 Then
            Dim frm As New SC_K13A()

            'パラメータ.工程
            frm.Process = cmbProcess.Text
            'パラメータ.設備
            frm.Facility = gridData.CurrentRow.Cells(COL_HIDDEN_7).Value.ToString
            'パラメータ.品名略称
            frm.Product = gridData.CurrentRow.Cells(COL_PRODUCT_NAME).Value.ToString

            Select Case cmbProcess.SelectedValue
                Case "10", "20"
                    'パラメータ.金型
                    frm.Mold = gridData.CurrentRow.Cells(COL_MOLD).Value.ToString
            End Select

            '★

            frm.ShowDialog()
            'Me.Show()
        End If
    End Sub

    Private Sub Patten1(ByVal dt As DataTable)

        For Each col As DataColumn In dt.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dt.Copy
        gridData.ColumnHeadersHeight = 70
        gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.AddSpanHeader(4, 2, headerName(COL_COMPLETION))
        gridData.AddSpanHeader(6, 2, headerName(COL_DEFECT))
        gridData.AddSpanHeader(8, 2, headerName(COL_SP_PRO_TRANSFER))


        gridData.Columns(COL_COMPLETION_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).HeaderText = headerName(COL_PASS)
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).HeaderText = headerName(COL_DEFECT)
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
                Case COL_PRODUCT_NAME, COL_CUSTOMER_PART_NO
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_MOLD
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 50
        gridData.Columns(COL_PRODUCT_NAME).Width = 150
        gridData.Columns(COL_CUSTOMER_PART_NO).Width = 170
        gridData.Columns(COL_MOLD).Width = 110
        gridData.Columns(COL_COMPLETION_THE_DAY).Width = 120
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 120
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 120
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 120
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).Width = 120
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).Width = 120
    End Sub

    Private Sub Patten2(ByVal dt As DataTable)

        For Each col As DataColumn In dt.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dt.Copy
        gridData.ColumnHeadersHeight = 70
        gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.AddSpanHeader(2, 2, headerName(COL_START))
        gridData.AddSpanHeader(4, 4, headerName(COL_COMPLETION))
        gridData.AddSpanHeader(8, 2, headerName(COL_DEFECT))

        gridData.Columns(COL_START_FABRIC).HeaderText = headerName(COL_FABRIC)
        gridData.Columns(COL_START_REPAINTING).HeaderText = headerName(COL_REPAINTING)
        gridData.Columns(COL_COMPLETION_DIRECT).HeaderText = headerName(COL_DIRECT)
        gridData.Columns(COL_COMPLETING_REPAINTING).HeaderText = headerName(COL_REPAINTING)
        gridData.Columns(COL_COMPLETING_SPOT).HeaderText = headerName(COL_SPOT)
        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)

        gridData.Columns(COL_DEFECTIVE_FABRIC_MOLDING).HeaderText = headerName(COL_DEFECTIVE_FABRIC_MOLDING)
        gridData.Columns(COL_DEFECTIVE_FABRIC_FINISH).HeaderText = headerName(COL_DEFECTIVE_FABRIC_FINISH)
        gridData.Columns(COL_REPAINT_JUDGMENT).HeaderText = headerName(COL_REPAINT_JUDGMENT)
        gridData.Columns(COL_SPOT_JUDGMENT).HeaderText = headerName(COL_SPOT_JUDGMENT)

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
                Case COL_PRODUCT_NAME
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 50
        gridData.Columns(COL_PRODUCT_NAME).Width = 140
        gridData.Columns(COL_START_FABRIC).Width = 65
        gridData.Columns(COL_START_REPAINTING).Width = 80
        gridData.Columns(COL_COMPLETION_DIRECT).Width = 65
        gridData.Columns(COL_COMPLETING_REPAINTING).Width = 80
        gridData.Columns(COL_COMPLETING_SPOT).Width = 80
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 80
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 65
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 80
        gridData.Columns(COL_DEFECTIVE_FABRIC_MOLDING).Width = 110
        gridData.Columns(COL_DEFECTIVE_FABRIC_FINISH).Width = 110
        gridData.Columns(COL_REPAINT_JUDGMENT).Width = 100
        gridData.Columns(COL_SPOT_JUDGMENT).Width = 100

    End Sub

    Private Sub Patten3(ByVal dt As DataTable)

        For Each col As DataColumn In dt.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dt.Copy
        gridData.ColumnHeadersHeight = 70
        gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.AddSpanHeader(4, 2, headerName(COL_COMPLETION))
        gridData.AddSpanHeader(6, 2, headerName(COL_DEFECT))
        gridData.AddSpanHeader(8, 2, headerName(COL_SP_PRO_TRANSFER))

        gridData.Columns(COL_COMPLETION_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = headerName(COL_TODAY)
        gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = headerName(COL_CORRECTION)
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).HeaderText = headerName(COL_PASS)
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).HeaderText = headerName(COL_DEFECT)
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
                Case COL_PRODUCT_NAME, COL_CUSTOMER_PART_NO
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 50
        gridData.Columns(COL_PRODUCT_NAME).Width = 150
        gridData.Columns(COL_CUSTOMER_PART_NO).Width = 170
        gridData.Columns(COL_START).Width = 110
        gridData.Columns(COL_COMPLETION_THE_DAY).Width = 120
        gridData.Columns(COL_COMPLETION_CORRECTION).Width = 120
        gridData.Columns(COL_DEFECT_THE_DAY).Width = 120
        gridData.Columns(COL_DEFECT_CORRECTION).Width = 120
        gridData.Columns(COL_SP_PROP_TRANSFER_PASS).Width = 120
        gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).Width = 120
    End Sub

    Private Sub btnBeforeDay_Click(sender As Object, e As EventArgs) Handles btnBeforeDay.Click
        Dim frm As New SC_K14()
        frm.Text = "[K-14]" & FORM_NAME_K14
        frm.lblMaster.Text = FORM_NAME_K14
        frm.ShowDialog()
        Me.Show()
    End Sub

End Class
