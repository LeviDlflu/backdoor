Imports System.Reflection
Public Class SC_K12
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"作番", "Work number" & vbCrLf & "(作番)"},
                             {"作業指示日", "Work instruction date" & vbCrLf & "(作業指示日)"},
                             {"直", "Direct" & vbCrLf & "(直)"},
                             {"品名", "Goods name" & vbCrLf & "(品名)"},
                             {"金型", "Money type" & vbCrLf & "(金型)"},
                             {"設備略称", "Goods abbreviation" & vbCrLf & "(設備略称)"},
                             {"品種名", "Variety name" & vbCrLf & "(品種名)"},
                             {"車種コード", "Car type code" & vbCrLf & "(車種コード)"},
                             {"梱包仕様", "Packing specification" & vbCrLf & "(梱包仕様)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"生地区分", "Material division" & vbCrLf & "(生地区分)"},
                             {"納入日・納入時間", "Delivery date・Delivery time" & vbCrLf & "(納入日・納入時間)"},
                             {"日産ライン", "Daily line" & vbCrLf & "(日産ライン)"},
                             {"台車ＮＯ", "Truck NO" & vbCrLf & "(台車ＮＯ)"},
                             {"指示", "Instruction" & vbCrLf & "(指示)"},
                             {"ショット", "Shot" & vbCrLf & "(ショット)"},
                             {"調整", "Adjustment" & vbCrLf & "(調整)"},
                             {"着手", "Start" & vbCrLf & "(着手)"},
                             {"完成", "Completion" & vbCrLf & "(完成)"},
                             {"不良", "Failure" & vbCrLf & "(不良)"},
                             {"他振替", "Other transfer" & vbCrLf & "(他振替)"},
                             {"保留", "Hold" & vbCrLf & "(保留)"},
                             {"梱包待ち", "Packing wait" & vbCrLf & "(梱包待ち)"},
                             {"生地不良(成)", "Material failure(M)" & vbCrLf & "(生地不良(成))"},
                             {"生地不良(仕)", "Material failure(F)" & vbCrLf & "(生地不良(仕))"},
                             {"リペア", "Repair" & vbCrLf & "(リペア)"},
                             {"再塗装", "Repaint" & vbCrLf & "(再塗装)"},
                             {"再塗装投入", "Repaint investment" & vbCrLf & "(再塗装投入)"},
                             {"指示残", "Remaining instruction" & vbCrLf & "(指示残)"},
                             {"最新入力実績時間", "Latest input actual time" & vbCrLf & "(最新入力実績時間)"},
                             {"強制除外", "Forced exclusion" & vbCrLf & "(強制除外)"}
                            }
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_WORK_NUMBER As String = "作番"
    Private Const COL_WORK_INSTRUCTION_DATE As String = "作業指示日"
    Private Const COL_DIRECT As String = "直"
    Private Const COL_GOODS_NAME As String = "品名"
    Private Const COL_MONEY_TYPE As String = "金型"
    Private Const COL_GOODS_ABBREVIATION As String = "設備略称"
    Private Const COL_VARIET_NAME As String = "品種名"
    Private Const COL_CAR_TYPE_CODE As String = "車種コード"
    Private Const COL_PACKING_SPECIFICATION As String = "梱包仕様"
    Private Const COL_CUSTOMER_PART_NUMBER As String = "客先部品番号"
    Private Const COL_MATERIAL_DIVISION As String = "生地区分"
    Private Const COL_DELIVERY_DATE_DELIVERY_TIME As String = "納入日・納入時間"
    Private Const COL_DAILY_LINE As String = "日産ライン"
    Private Const COL_TRUCK_NO As String = "台車ＮＯ"
    Private Const COL_INSTRUCTION As String = "指示"
    Private Const COL_SHOT As String = "ショット"
    Private Const COL_ADJUSTMENT As String = "調整"
    Private Const COL_START As String = "着手"
    Private Const COL_COMPLETION As String = "完成"
    Private Const COL_FAILURE As String = "不良"
    Private Const COL_OTHER_TRANSFER As String = "他振替"
    Private Const COL_HOLD As String = "保留"
    Private Const COL_PACKING_WAIT As String = "梱包待ち"
    Private Const COL_MATERIAL_FAILURE_M As String = "生地不良(成)"
    Private Const COL_MATERIAL_FAILURE_F As String = "生地不良(仕)"
    Private Const COL_REPAIR As String = "リペア"
    Private Const COL_REPAINT As String = "再塗装"
    Private Const COL_REPAINT_INVESTMENT As String = "再塗装投入"
    Private Const COL_REMAINING_INSTRUCTION As String = "指示残"
    Private Const COL_LATEST_INPUT_ACTUAL_TIME As String = "最新入力実績時間"
    Private Const COL_FORCED_EXCLUSION As String = "強制除外"


    Private Sub SC_K12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add("1", "30：塗装")
        dt.Rows.Add("2", "40：組立")
        dt.Rows.Add("3", "20：成形")
        cmb_Kbn.DataSource = dt
        cmb_Kbn.ValueMember = dt.Columns.Item(0).ColumnName
        cmb_Kbn.DisplayMember = dt.Columns.Item(1).ColumnName
        Dim type As Type = gridData.GetType()
        Dim pi As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(gridData, True, Nothing)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
        Label56.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label56.BackColor = Color.SkyBlue
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS And e.RowIndex >= 0 Then
            Dim frm As New SC_K12A()
            frm.ShowDialog()
            Me.Show()
        End If

    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_WORK_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORK_INSTRUCTION_DATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_GOODS_NAME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_GOODS_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MATERIAL_DIVISION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_INSTRUCTION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_START, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_COMPLETION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FAILURE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MATERIAL_FAILURE_M, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_MATERIAL_FAILURE_F, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REPAIR, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REPAINT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REPAINT_INVESTMENT, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_REMAINING_INSTRUCTION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_LATEST_INPUT_ACTUAL_TIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_FORCED_EXCLUSION, GetType(System.String)))


        Dim dr As DataRow

        For index = 1 To 5
            dr = dt.NewRow()
            dr.Item(COL_WORK_NUMBER) = COL_WORK_NUMBER & index
            dr.Item(COL_WORK_INSTRUCTION_DATE) = COL_WORK_INSTRUCTION_DATE & index
            dr.Item(COL_DIRECT) = COL_DIRECT & index
            dr.Item(COL_GOODS_NAME) = COL_GOODS_NAME & index
            dr.Item(COL_GOODS_ABBREVIATION) = COL_GOODS_ABBREVIATION & index
            dr.Item(COL_MATERIAL_DIVISION) = COL_MATERIAL_DIVISION & index
            dr.Item(COL_INSTRUCTION) = COL_INSTRUCTION & index
            dr.Item(COL_START) = COL_START & index
            dr.Item(COL_COMPLETION) = COL_COMPLETION & index
            dr.Item(COL_FAILURE) = COL_FAILURE & index
            dr.Item(COL_MATERIAL_FAILURE_M) = COL_MATERIAL_FAILURE_M & index
            dr.Item(COL_MATERIAL_FAILURE_F) = COL_MATERIAL_FAILURE_F & index
            dr.Item(COL_REPAIR) = COL_REPAIR & index
            dr.Item(COL_REPAINT) = COL_REPAINT & index
            dr.Item(COL_REPAINT_INVESTMENT) = COL_REPAINT_INVESTMENT & index
            dr.Item(COL_REMAINING_INSTRUCTION) = COL_REMAINING_INSTRUCTION & index
            dr.Item(COL_LATEST_INPUT_ACTUAL_TIME) = COL_LATEST_INPUT_ACTUAL_TIME & index
            dr.Item(COL_FORCED_EXCLUSION) = COL_FORCED_EXCLUSION & index
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        gridData.Columns.Clear()

        '詳細
        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS）
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

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
                Case COL_DETAILS
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select

        Next

        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_WORK_NUMBER).Width = 100
        gridData.Columns(COL_WORK_INSTRUCTION_DATE).Width = 200
        gridData.Columns(COL_DIRECT).Width = 50
        gridData.Columns(COL_GOODS_NAME).Width = 100
        gridData.Columns(COL_GOODS_ABBREVIATION).Width = 150
        gridData.Columns(COL_MATERIAL_DIVISION).Width = 100
        gridData.Columns(COL_INSTRUCTION).Width = 100
        gridData.Columns(COL_START).Width = 100
        gridData.Columns(COL_COMPLETION).Width = 100
        gridData.Columns(COL_FAILURE).Width = 100
        gridData.Columns(COL_MATERIAL_FAILURE_M).Width = 200
        gridData.Columns(COL_MATERIAL_FAILURE_F).Width = 200
        gridData.Columns(COL_REPAIR).Width = 100
        gridData.Columns(COL_REPAINT).Width = 100
        gridData.Columns(COL_REPAINT_INVESTMENT).Width = 120
        gridData.Columns(COL_REMAINING_INSTRUCTION).Width = 180
        gridData.Columns(COL_LATEST_INPUT_ACTUAL_TIME).Width = 180
        gridData.Columns(COL_FORCED_EXCLUSION).Width = 100


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


End Class
