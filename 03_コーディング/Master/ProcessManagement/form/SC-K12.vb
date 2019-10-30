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
    ''' <summary>
    ''' 列ヘッダーの行数
    ''' </summary>
    ''' <remarks></remarks>
    Private ColumnHeaderRowCount As Integer = 2

    ''' <summary>
    ''' 列ヘッダーの行の高さ
    ''' </summary>
    ''' <remarks></remarks>
    Private columnHeaderrRowHeight As Integer = 17
    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"

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
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_DETAILS, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORK_NUMBER, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_WORK_INSTRUCTION_DATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DIRECT, GetType(System.String)))
        ''完成
        'dt.Columns.Add(New DataColumn(COL_COMPLETION, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_DEFECT, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_SP_PRO_TRANSFER, GetType(System.String)))

        'dt.Columns.Add(New DataColumn(COL_CORRECTION, GetType(System.String)))
        'dt.Columns.Add(New DataColumn(COL_PASS, GetType(System.String)))

        'For i As Integer = 0 To 3
        '    Dim addRow As DataRow = dt.NewRow
        '    Select Case i
        '        Case 0
        '            addRow(COL_DETAILS) = "FAS"
        '            addRow(COL_WORK_NUMBER) = "11"
        '            addRow(COL_WORK_INSTRUCTION_DATE) = "落下"
        '            addRow(COL_DIRECT) = "製造工場"
        '            addRow(COL_COMPLETION) = "製造工場"
        '            addRow(COL_DEFECT) = "製造工場"
        '            addRow(COL_SP_PRO_TRANSFER) = "製造工場"
        '        Case 1
        '            addRow(COL_DETAILS) = "FAS"
        '            addRow(COL_WORK_NUMBER) = "11"
        '            addRow(COL_WORK_INSTRUCTION_DATE) = "落下"
        '            addRow(COL_DIRECT) = "製造工場"
        '            addRow(COL_COMPLETION) = "製造工場"
        '            addRow(COL_DEFECT) = "製造工場"
        '            addRow(COL_SP_PRO_TRANSFER) = "製造工場"
        '        Case 2
        '            addRow(COL_DETAILS) = "FAS"
        '            addRow(COL_WORK_NUMBER) = "11"
        '            addRow(COL_WORK_INSTRUCTION_DATE) = "落下"
        '            addRow(COL_DIRECT) = "製造工場"
        '            addRow(COL_COMPLETION) = "製造工場"
        '            addRow(COL_DEFECT) = "製造工場"
        '            addRow(COL_SP_PRO_TRANSFER) = "製造工場"
        '        Case 3
        '            addRow(COL_DETAILS) = "FAS"
        '            addRow(COL_WORK_NUMBER) = "11"
        '            addRow(COL_WORK_INSTRUCTION_DATE) = "落下"
        '            addRow(COL_DIRECT) = "製造工場"
        '            addRow(COL_COMPLETION) = "製造工場"
        '            addRow(COL_DEFECT) = "製造工場"
        '            addRow(COL_SP_PRO_TRANSFER) = "製造工場"
        '        Case 4
        '            addRow(COL_DETAILS) = "FAS"
        '            addRow(COL_WORK_NUMBER) = "11"
        '            addRow(COL_WORK_INSTRUCTION_DATE) = "落下"
        '            addRow(COL_DIRECT) = "製造工場"
        '            addRow(COL_COMPLETION) = "製造工場"
        '            addRow(COL_DEFECT) = "製造工場"
        '            addRow(COL_SP_PRO_TRANSFER) = "製造工場"

        '    End Select
        'dt.Rows.Add(addRow)
        'Next

        Return dt

    End Function

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        gridData.Columns.Clear()


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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 80
        gridData.Columns(2).Width = 120
        gridData.Columns(3).Width = 80
        gridData.Columns(4).Width = 80
        gridData.Columns(5).Width = 80
        gridData.Columns(6).Width = 140
        gridData.Columns(7).Width = 100
        gridData.Columns(8).Width = 140


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Select Case cmb_Kbn.SelectedValue
            Case "1"
                Patten1()
            Case "2"
                Patten2()
            Case "3"
                Patten3()
        End Select
        'setGrid(createGridData())
        Label56.Text = Format(Now, "yyyy/MM/dd hh:mm")
        Label56.BackColor = Color.SkyBlue
    End Sub

    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick
        If gridData.Columns(e.ColumnIndex).Name = COL_DETAILS And e.RowIndex >= 0 Then
            Dim frm As New SC_K12A()
            frm.ShowDialog()
            Me.Show()
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub SC_K12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add(" ", "")
        dt.Rows.Add("1", "A")
        dt.Rows.Add("2", "B")
        dt.Rows.Add("3", "C")
        cmb_Kbn.DataSource = dt
        cmb_Kbn.ValueMember = dt.Columns.Item(0).ColumnName
        cmb_Kbn.DisplayMember = dt.Columns.Item(1).ColumnName
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub

    ''' <summary>
    ''' 列ヘッダーセル定義構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure HeaderCell
        Public Row As Integer
        Public Column As Integer
        Public RowSpan As Integer
        Public ColumnSpan As Integer
        Public Text As String

        ''' <summary>
        ''' 列ヘッダーセル定義
        ''' </summary>
        ''' <param name="paramRow">行</param>
        ''' <param name="paramColumn">列</param>
        ''' <param name="paramRowSpan">結合する行数</param>
        ''' <param name="paramColumnSpan">結合する列数</param>
        ''' <param name="paramText">セルに関連付けられたテキスト</param>
        ''' <remarks></remarks>
        Sub New(ByVal paramRow As Integer, ByVal paramColumn As Integer, ByVal paramRowSpan As Integer, ByVal paramColumnSpan As Integer, ByVal paramText As String)
            ' TODO: Complete member initialization 
            Row = paramRow
            Column = paramColumn
            RowSpan = paramRowSpan
            ColumnSpan = paramColumnSpan
            Text = paramText
        End Sub

    End Structure

    ''' <summary>
    ''' 列ヘッダーセル定義
    ''' </summary>
    ''' <remarks></remarks>
    Public HeaderCells As HeaderCell()

    Private Sub gridData_Paint(sender As Object, e As PaintEventArgs) Handles gridData.Paint
        '列が無い場合
        If Me.gridData.ColumnCount = 0 Then
            Exit Sub
        End If

        '行が無い場合
        If Me.gridData.RowCount = 0 Then
            Exit Sub
        End If

        '列ヘッダーの行の高さの取得
        Dim rowHeight As Integer = Me.gridData.ColumnHeadersHeight / ColumnHeaderRowCount

        Dim lineWidth As Integer = 1

        '列ヘッダーを指定された行数にセル表示する
        For columuns = 0 To Me.gridData.ColumnCount - 1

            For rows = 0 To ColumnHeaderRowCount - 1

                '列ヘッダーの表示領域の取得
                Dim rect As Rectangle = Me.gridData.GetCellDisplayRectangle(columuns, -1, True)

                '列ヘッダーの描画領域の底部の座標を保存
                Dim btm As Integer = rect.Bottom

                'セルの描画領域のY座標
                Select Case Me.gridData.BorderStyle
                    Case Windows.Forms.BorderStyle.None
                        rect.Y = rowHeight * rows
                    Case Windows.Forms.BorderStyle.FixedSingle
                        rect.Y = rowHeight * rows + lineWidth
                    Case Windows.Forms.BorderStyle.Fixed3D
                        rect.Y = rowHeight * rows + (lineWidth * 2)
                End Select

                'セルの描画領域のX座標
                rect.X -= lineWidth

                'セルの描画領域の高さ
                rect.Height = rowHeight

                '最下行の場合高さを調整
                If rows = Me.ColumnHeaderRowCount - 1 Then
                    rect.Height = btm - rect.Y - lineWidth
                End If

                Dim gridPen As New Pen(Me.gridData.GridColor)
                e.Graphics.DrawRectangle(gridPen, rect)

                'セルの背景色の領域
                rect.Y += lineWidth
                rect.X += lineWidth
                rect.Height -= lineWidth
                rect.Width -= lineWidth

                '背景色
                Dim backBrash As New SolidBrush(Me.gridData.BackColor)

                e.Graphics.FillRectangle(backBrash, rect)

                '見出しを最下列に表示
                If rows = Me.ColumnHeaderRowCount - 1 Then

                    Dim text As String = Me.gridData.Columns(columuns).HeaderText
                    Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

                    TextRenderer.DrawText(e.Graphics, text, Me.gridData.ColumnHeadersDefaultCellStyle.Font,
                                          rect, Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor,
                                          formatFlg)
                End If

                'リソースの解放
                gridPen.Dispose()
                backBrash.Dispose()
            Next
        Next

        '列ヘッダーセル定義の処理
        For i = 0 To Me.HeaderCells.Count - 1

            'セルの結合の開始行がヘッダーの行数より大きい場合は除外
            If HeaderCells(i).Row > Me.ColumnHeaderRowCount - 1 Then
                Continue For
            End If

            'セルの結合の開始列の列インデックスが列数より大きい場合は除外
            If HeaderCells(i).Column > Me.gridData.ColumnCount - 1 Then
                Continue For
            End If

            '描画領域の設定
            Dim rect As Rectangle = Nothing

            '結合する列中のソート状態
            Dim sortText As String = String.Empty

            '結合するセルの幅の取得
            For j = Me.HeaderCells(i).Column To Me.HeaderCells(i).Column + Me.HeaderCells(i).ColumnSpan - 1

                If Me.gridData.Columns(j).Displayed = False Then
                    Continue For
                End If

                If rect = Nothing Then
                    rect = Me.gridData.GetCellDisplayRectangle(j, -1, True)
                Else
                    rect.Width += Me.gridData.GetCellDisplayRectangle(j, -1, True).Width
                End If
            Next

            '結合するセルが画面中に無い場合
            If rect = Nothing Then
                Continue For
            End If

            '結合する行がヘッダー行数より大きい場合
            Dim rowSapn As Integer = Me.HeaderCells(i).RowSpan
            If rowSapn > ColumnHeaderRowCount Then
                rowSapn = ColumnHeaderRowCount
            End If

            '列ヘッダーの描画領域の底部の座標を保存
            Dim btm As Integer = rect.Bottom

            '結合するセルの描画領域のY座標
            Select Case Me.gridData.BorderStyle
                Case Windows.Forms.BorderStyle.None
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row)
                Case Windows.Forms.BorderStyle.FixedSingle
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row) + lineWidth
                Case Windows.Forms.BorderStyle.Fixed3D
                    rect.Y = rowHeight * (Me.HeaderCells(i).Row) + (lineWidth * 2)
            End Select

            '結合するセルの描画領域のX座標
            rect.X -= lineWidth

            '結合するセルの描画領域の高さ
            rect.Height = rowHeight * rowSapn

            '最下行の場合は描画領域の高さを調整する
            If Me.HeaderCells(i).Row + rowSapn = Me.ColumnHeaderRowCount Then
                rect.Height = btm - rect.Y - lineWidth
            End If

            'グッリドの線
            Dim gridPen As New Pen(Me.gridData.GridColor)

            '背景色の取得
            Dim backgroundColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.BackColor

            '背景色
            Dim backBrash As New SolidBrush(backgroundColor)

            'くぼみ線
            Dim whiteBrash As New SolidBrush(Color.White)

            '枠線の描画
            e.Graphics.DrawRectangle(gridPen, rect)

            '結合セルの背景色の描画領域の設定
            rect.Y += lineWidth
            rect.X += lineWidth
            rect.Height -= lineWidth
            rect.Width -= lineWidth

            '背景色の描画
            e.Graphics.FillRectangle(backBrash, rect)

            'テキストの描画
            Dim foreColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor
            Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

            TextRenderer.DrawText(e.Graphics, Me.HeaderCells(i).Text & sortText,
                                  Me.gridData.ColumnHeadersDefaultCellStyle.Font,
                                  rect, foreColor, formatFlg)
            'リソースの解放
            gridPen.Dispose()
            backBrash.Dispose()
            whiteBrash.Dispose()
        Next
    End Sub

    ''' <summary>
    ''' 結合元のセルの文字位置から結合後の文字位置を取得する
    ''' </summary>
    ''' <param name="alignment">テキストの配置</param>
    ''' <remarks></remarks>
    Private Function GetTextFormatFlags(ByVal alignment As DataGridViewContentAlignment) As TextFormatFlags
        Try
            ''文字の描画
            Dim formatFlg As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis

            '表示位置
            Select Case alignment
                Case DataGridViewContentAlignment.BottomCenter
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomLeft
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.BottomRight
                    formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleCenter
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleLeft
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.MiddleRight
                    formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopCenter
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopLeft
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
                Case DataGridViewContentAlignment.TopRight
                    formatFlg = TextFormatFlags.Top Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
            End Select

            Return formatFlg

        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub Patten1()
        gridData.Columns.Clear()
        HeaderCells = {
            New HeaderCell(0, 0, 6, 1, headerName（COL_DETAILS)),
            New HeaderCell(0, 1, 6, 1, headerName（COL_WORK_NUMBER)),
            New HeaderCell(0, 2, 6, 1, headerName(COL_WORK_INSTRUCTION_DATE)),
            New HeaderCell(0, 3, 6, 1, headerName(COL_DIRECT)),
            New HeaderCell(0, 4, 6, 1, headerName(COL_GOODS_NAME)),
            New HeaderCell(0, 5, 6, 1, headerName(COL_GOODS_ABBREVIATION)),
            New HeaderCell(0, 6, 6, 1, headerName(COL_MATERIAL_DIVISION)),
            New HeaderCell(0, 7, 6, 1, headerName(COL_INSTRUCTION)),
            New HeaderCell(0, 8, 6, 1, headerName(COL_START)),
            New HeaderCell(0, 9, 6, 1, headerName(COL_COMPLETION)),
            New HeaderCell(0, 10, 6, 1, headerName(COL_FAILURE)),
            New HeaderCell(0, 11, 6, 1, headerName(COL_MATERIAL_FAILURE_M)),
            New HeaderCell(0, 12, 6, 1, headerName(COL_MATERIAL_FAILURE_F)),
            New HeaderCell(0, 13, 6, 1, headerName(COL_REPAIR)),
            New HeaderCell(0, 14, 6, 1, headerName(COL_REPAINT)),
            New HeaderCell(0, 15, 6, 1, headerName(COL_REPAINT_INVESTMENT)),
            New HeaderCell(0, 16, 6, 1, headerName(COL_REMAINING_INSTRUCTION)),
            New HeaderCell(0, 17, 6, 1, headerName(COL_LATEST_INPUT_ACTUAL_TIME)),
            New HeaderCell(0, 18, 6, 1, headerName(COL_FORCED_EXCLUSION))
        }

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = COL_DETAILS
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable
        dt.Columns.Add(COL_WORK_NUMBER)
        dt.Columns.Add(COL_WORK_INSTRUCTION_DATE)
        dt.Columns.Add(COL_DIRECT)
        dt.Columns.Add(COL_GOODS_NAME)
        dt.Columns.Add(COL_GOODS_ABBREVIATION)
        dt.Columns.Add(COL_MATERIAL_DIVISION)
        dt.Columns.Add(COL_INSTRUCTION)
        dt.Columns.Add(COL_START)
        dt.Columns.Add(COL_COMPLETION)
        dt.Columns.Add(COL_FAILURE)
        dt.Columns.Add(COL_MATERIAL_FAILURE_M)
        dt.Columns.Add(COL_MATERIAL_FAILURE_F)
        dt.Columns.Add(COL_REPAIR)
        dt.Columns.Add(COL_REPAINT)
        dt.Columns.Add(COL_REPAINT_INVESTMENT)
        dt.Columns.Add(COL_REMAINING_INSTRUCTION)
        dt.Columns.Add(COL_LATEST_INPUT_ACTUAL_TIME)
        dt.Columns.Add(COL_FORCED_EXCLUSION)

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

        gridData.DataSource = dt
        gridData.AutoResizeColumns()

        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_WORK_NUMBER).Width = 100
        gridData.Columns(COL_WORK_INSTRUCTION_DATE).Width = 100
        gridData.Columns(COL_DIRECT).Width = 50
        gridData.Columns(COL_GOODS_NAME).Width = 100
        gridData.Columns(COL_GOODS_ABBREVIATION).Width = 150
        gridData.Columns(COL_MATERIAL_DIVISION).Width = 100
        gridData.Columns(COL_INSTRUCTION).Width = 100
        gridData.Columns(COL_START).Width = 100
        gridData.Columns(COL_COMPLETION).Width = 100
        gridData.Columns(COL_FAILURE).Width = 100
        gridData.Columns(COL_MATERIAL_FAILURE_M).Width = 100
        gridData.Columns(COL_MATERIAL_FAILURE_F).Width = 100
        gridData.Columns(COL_REPAIR).Width = 100
        gridData.Columns(COL_REPAINT).Width = 100
        gridData.Columns(COL_REPAINT_INVESTMENT).Width = 120
        gridData.Columns(COL_REMAINING_INSTRUCTION).Width = 120
        gridData.Columns(COL_LATEST_INPUT_ACTUAL_TIME).Width = 130
        gridData.Columns(COL_FORCED_EXCLUSION).Width = 100
    End Sub

    Private Sub Patten2()
        gridData.Columns.Clear()
        HeaderCells = {
            New HeaderCell(0, 0, 6, 1, headerName（COL_DETAILS)),
            New HeaderCell(0, 1, 6, 1, headerName（COL_WORK_NUMBER)),
            New HeaderCell(0, 2, 6, 1, headerName(COL_WORK_INSTRUCTION_DATE)),
            New HeaderCell(0, 3, 6, 1, headerName(COL_DIRECT)),
            New HeaderCell(0, 4, 6, 1, headerName（COL_VARIET_NAME)),
            New HeaderCell(0, 5, 6, 1, headerName(COL_CAR_TYPE_CODE)),
            New HeaderCell(0, 6, 6, 1, headerName(COL_DELIVERY_DATE_DELIVERY_TIME)),
            New HeaderCell(0, 7, 6, 1, headerName(COL_DAILY_LINE)),
            New HeaderCell(0, 8, 6, 1, headerName(COL_TRUCK_NO)),
            New HeaderCell(0, 9, 6, 1, headerName(COL_INSTRUCTION)),
            New HeaderCell(0, 10, 6, 1, headerName(COL_START)),
            New HeaderCell(0, 11, 6, 1, headerName(COL_COMPLETION)),
            New HeaderCell(0, 12, 6, 1, headerName(COL_FAILURE)),
            New HeaderCell(0, 13, 6, 1, headerName(COL_HOLD)),
            New HeaderCell(0, 14, 6, 1, headerName(COL_PACKING_WAIT)),
            New HeaderCell(0, 15, 6, 1, headerName(COL_REMAINING_INSTRUCTION)),
            New HeaderCell(0, 16, 6, 1, headerName(COL_PACKING_SPECIFICATION)),
            New HeaderCell(0, 17, 6, 1, headerName(COL_CUSTOMER_PART_NUMBER)),
            New HeaderCell(0, 18, 6, 1, headerName(COL_LATEST_INPUT_ACTUAL_TIME)),
            New HeaderCell(0, 19, 6, 1, headerName(COL_FORCED_EXCLUSION))
        }

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = COL_DETAILS
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable
        dt.Columns.Add(COL_WORK_NUMBER)
        dt.Columns.Add(COL_WORK_INSTRUCTION_DATE)
        dt.Columns.Add(COL_DIRECT)
        dt.Columns.Add(COL_VARIET_NAME)
        dt.Columns.Add(COL_CAR_TYPE_CODE)
        dt.Columns.Add(COL_DELIVERY_DATE_DELIVERY_TIME)
        dt.Columns.Add(COL_DAILY_LINE)
        dt.Columns.Add(COL_TRUCK_NO)
        dt.Columns.Add(COL_INSTRUCTION)
        dt.Columns.Add(COL_START)
        dt.Columns.Add(COL_COMPLETION)
        dt.Columns.Add(COL_FAILURE)
        dt.Columns.Add(COL_HOLD)
        dt.Columns.Add(COL_PACKING_WAIT)
        dt.Columns.Add(COL_REMAINING_INSTRUCTION)
        dt.Columns.Add(COL_PACKING_SPECIFICATION)
        dt.Columns.Add(COL_CUSTOMER_PART_NUMBER)
        dt.Columns.Add(COL_LATEST_INPUT_ACTUAL_TIME)
        dt.Columns.Add(COL_FORCED_EXCLUSION)

        Dim dr As DataRow

        For index = 1 To 5
            dr = dt.NewRow()
            dr.Item(COL_WORK_NUMBER) = COL_WORK_NUMBER & index
            dr.Item(COL_WORK_INSTRUCTION_DATE) = COL_WORK_INSTRUCTION_DATE & index
            dr.Item(COL_DIRECT) = COL_DIRECT & index
            dr.Item(COL_VARIET_NAME) = COL_VARIET_NAME & index
            dr.Item(COL_CAR_TYPE_CODE) = COL_CAR_TYPE_CODE & index
            dr.Item(COL_DELIVERY_DATE_DELIVERY_TIME) = COL_DELIVERY_DATE_DELIVERY_TIME & index
            dr.Item(COL_DAILY_LINE) = COL_DAILY_LINE & index
            dr.Item(COL_TRUCK_NO) = COL_TRUCK_NO & index
            dr.Item(COL_INSTRUCTION) = COL_INSTRUCTION & index
            dr.Item(COL_START) = COL_START & index
            dr.Item(COL_COMPLETION) = COL_COMPLETION & index
            dr.Item(COL_FAILURE) = COL_FAILURE & index
            dr.Item(COL_HOLD) = COL_HOLD & index
            dr.Item(COL_PACKING_WAIT) = COL_PACKING_WAIT & index
            dr.Item(COL_REMAINING_INSTRUCTION) = COL_REMAINING_INSTRUCTION & index
            dr.Item(COL_PACKING_SPECIFICATION) = COL_PACKING_SPECIFICATION & index
            dr.Item(COL_CUSTOMER_PART_NUMBER) = COL_CUSTOMER_PART_NUMBER & index
            dr.Item(COL_LATEST_INPUT_ACTUAL_TIME) = COL_LATEST_INPUT_ACTUAL_TIME & index
            dr.Item(COL_FORCED_EXCLUSION) = COL_FORCED_EXCLUSION & index
            dt.Rows.Add(dr)
        Next

        '子タイトル設定する
        gridData.DataSource = dt
        gridData.AutoResizeColumns()
        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_WORK_NUMBER).Width = 100
        gridData.Columns(COL_WORK_INSTRUCTION_DATE).Width = 100
        gridData.Columns(COL_DIRECT).Width = 50
        gridData.Columns(COL_VARIET_NAME).Width = 100
        gridData.Columns(COL_CAR_TYPE_CODE).Width = 150
        gridData.Columns(COL_DELIVERY_DATE_DELIVERY_TIME).Width = 100
        gridData.Columns(COL_DAILY_LINE).Width = 100
        gridData.Columns(COL_TRUCK_NO).Width = 100
        gridData.Columns(COL_INSTRUCTION).Width = 100
        gridData.Columns(COL_START).Width = 100
        gridData.Columns(COL_COMPLETION).Width = 100
        gridData.Columns(COL_FAILURE).Width = 100
        gridData.Columns(COL_HOLD).Width = 100
        gridData.Columns(COL_PACKING_WAIT).Width = 100
        gridData.Columns(COL_REMAINING_INSTRUCTION).Width = 100
        gridData.Columns(COL_PACKING_SPECIFICATION).Width = 100
        gridData.Columns(COL_CUSTOMER_PART_NUMBER).Width = 100
        gridData.Columns(COL_LATEST_INPUT_ACTUAL_TIME).Width = 100
        gridData.Columns(COL_FORCED_EXCLUSION).Width = 100
    End Sub

    Private Sub Patten3()
        gridData.Columns.Clear()
        HeaderCells = {
            New HeaderCell(0, 0, 6, 1, headerName（COL_DETAILS)),
            New HeaderCell(0, 1, 6, 1, headerName（COL_WORK_NUMBER)),
            New HeaderCell(0, 2, 6, 1, headerName(COL_WORK_INSTRUCTION_DATE)),
            New HeaderCell(0, 3, 6, 1, headerName(COL_DIRECT)),
            New HeaderCell(0, 4, 6, 1, headerName(COL_GOODS_NAME)),
            New HeaderCell(0, 5, 6, 1, headerName(COL_MONEY_TYPE)),
            New HeaderCell(0, 6, 6, 1, headerName(COL_GOODS_ABBREVIATION))}

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = COL_DETAILS
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        Dim dt As New DataTable
        dt.Columns.Add(COL_WORK_NUMBER)
        dt.Columns.Add(COL_WORK_INSTRUCTION_DATE)
        dt.Columns.Add(COL_DIRECT)
        dt.Columns.Add(COL_GOODS_NAME)
        dt.Columns.Add(COL_MONEY_TYPE)
        dt.Columns.Add(COL_GOODS_ABBREVIATION)

        Dim dr As DataRow

        For index = 1 To 10
            dr = dt.NewRow()
            dr.Item(COL_WORK_NUMBER) = COL_WORK_NUMBER & index
            dr.Item(COL_WORK_INSTRUCTION_DATE) = COL_WORK_INSTRUCTION_DATE & index
            dr.Item(COL_DIRECT) = COL_DIRECT & index
            dr.Item(COL_GOODS_NAME) = COL_GOODS_NAME & index
            dr.Item(COL_MONEY_TYPE) = COL_MONEY_TYPE & index
            dr.Item(COL_GOODS_ABBREVIATION) = COL_GOODS_ABBREVIATION & index
            dt.Rows.Add(dr)
        Next

        '子タイトル設定する
        gridData.DataSource = dt
        'gridData.Columns(COL_COMPLETION_THE_DAY).HeaderText = COL_TODAY
        'gridData.Columns(COL_COMPLETION_CORRECTION).HeaderText = COL_CORRECTION
        'gridData.Columns(COL_DEFECT_THE_DAY).HeaderText = COL_TODAY
        'gridData.Columns(COL_DEFECT_CORRECTION).HeaderText = COL_CORRECTION
        'gridData.Columns(COL_SP_PROP_TRANSFER_PASS).HeaderText = COL_PASS
        'gridData.Columns(COL_SP_PROP_TRANSFER_DEFECT).HeaderText = COL_DEFECT
        'gridData.AutoResizeColumns()
        gridData.AutoResizeColumns()
        'Grid幅設定する
        gridData.Columns(COL_DETAILS).Width = 60
        gridData.Columns(COL_WORK_NUMBER).Width = 100
        gridData.Columns(COL_WORK_INSTRUCTION_DATE).Width = 100
        gridData.Columns(COL_DIRECT).Width = 50
        gridData.Columns(COL_GOODS_NAME).Width = 100
        gridData.Columns(COL_MONEY_TYPE).Width = 150
        gridData.Columns(COL_GOODS_ABBREVIATION).Width = 100
    End Sub

End Class