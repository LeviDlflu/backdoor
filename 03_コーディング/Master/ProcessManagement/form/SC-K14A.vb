Public Class SC_K14A
    Dim headerName As Hashtable = New Hashtable From {
                             {"個体No", "Individual No" & vbCrLf & "(個体No)"},
                             {"ラベル発行No", "Label issue No" & vbCrLf & "(ラベル発行No)"},
                             {"設備名称", "Facility name" & vbCrLf & "(設備名称)"},
                             {"金型", "Mold" & vbCrLf & "(金型)"},
                             {"キャビ", "Caviar" & vbCrLf & "(金型)"},
                             {"客先部品番号", "Customer part number" & vbCrLf & "(客先部品番号)"},
                             {"品名略称", "Product name abbreviation" & vbCrLf & "(品名略称)"},
                             {"判定日付・時間", "Judgment date / Time" & vbCrLf & "(判定日付・時間)"},
                             {"数量", "Quantity" & vbCrLf & "(数量)"},
                             {"不良原因", "Cause of failure" & vbCrLf & "(不良原因)"},
                             {"倉庫(払出元)", "Warehouse (withdrawal source)" & vbCrLf & "(倉庫(払出元))"},
                             {"品名", "Product name" & vbCrLf & "(品名)"},
                             {"払出日", "Withdrawal Date" & vbCrLf & "(払出日)"},
                             {"払出理由", "Reason For withdrawal" & vbCrLf & "(払出理由)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"},
                             {"リペア理由", "Reason For repair" & vbCrLf & "(リペア理由)"},
                             {"再塗装理由", "Reason For repainting" & vbCrLf & "(再塗装理由)"},
                             {"生地不良原因", "Cause Of fabric failure" & vbCrLf & "(生地不良原因)"},
                             {"再投入", "Re-injection" & vbCrLf & "(再投入)"},
                             {"氏名", "Full name" & vbCrLf & "(氏名)"}
                            }
    Private Const COL_INDIVIDUAL_NO As String = "個体No"
    Private Const COL_LABEL_ISSUE_NO As String = "ラベル発行No"
    Private Const COL_FACILITY_NAME As String = "設備名称"
    Private Const COL_MOLD As String = "金型"
    Private Const COL_CAVIAR As String = "キャビ"
    Private Const COL_CUSTOMER_PART_NUMBER As String = "客先部品番号"
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_JUDGMENT_DATE_TIME As String = "判定日付・時間"
    Private Const COL_QUANTITY As String = "数量"
    Private Const COL_CAUSE_OF_FAILURE As String = "不良原因"
    Private Const COL_WAREHOUSE As String = "倉庫(払出元)"
    Private Const COL_PRODUCT_NAME As String = "品名"
    Private Const COL_WITHDRAWAL_DATE As String = "払出日"
    Private Const COL_REASON_FOR_WITHDRAWAL As String = "払出理由"
    Private Const COL_REMARKS As String = "備考"
    Private Const COL_REASON_FOR_REPAIR As String = "リペア理由"
    Private Const COL_REASON_FOR_REPAINTING As String = "再塗装理由"
    Private Const COL_CAUSE_OF_FABRIC_FAILURE As String = "生地不良原因"
    Private Const COL_RE_INJECTION As String = "再投入"
    Private Const COL_FULL_NAME As String = "氏名"

    'ショット
    Dim SMD_SHOT As String() = {COL_FACILITY_NAME, COL_MOLD, COL_JUDGMENT_DATE_TIME, COL_QUANTITY}
    '合格
    Dim SMD_PASSING As String() = {COL_INDIVIDUAL_NO, COL_LABEL_ISSUE_NO, COL_FACILITY_NAME, COL_MOLD, COL_CAVIAR, COL_CUSTOMER_PART_NUMBER,
                                    COL_PRODUCT_NAME_ABBREVIATION, COL_JUDGMENT_DATE_TIME, COL_QUANTITY, COL_FULL_NAME}
    '不良
    Dim SMD_BAD As String() = {COL_INDIVIDUAL_NO, COL_LABEL_ISSUE_NO, COL_FACILITY_NAME, COL_MOLD, COL_CAVIAR, COL_CUSTOMER_PART_NUMBER,
                                COL_PRODUCT_NAME_ABBREVIATION, COL_JUDGMENT_DATE_TIME, COL_QUANTITY, COL_CAUSE_OF_FAILURE, COL_FULL_NAME}
    '調整
    Dim SMD_ADJUSTMENT As String() = {COL_INDIVIDUAL_NO, COL_FACILITY_NAME, COL_MOLD, COL_PRODUCT_NAME_ABBREVIATION, COL_JUDGMENT_DATE_TIME, COL_QUANTITY}
    'その他払出
    Dim SMD_OTHERT As String() = {COL_INDIVIDUAL_NO, COL_WAREHOUSE, COL_PRODUCT_NAME, COL_WITHDRAWAL_DATE, COL_REASON_FOR_WITHDRAWAL, COL_REMARKS}

    Private Const CONST_SYSTEM_NAME As String = "前日以前詳細実績参照"

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
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        Select Case SC_K14.cmbProcess.Text
            Case "成形"
                Select Case Me.txtJudgmentCategory.Text
                    Case "ショット"
                        For i As Integer = 0 To SMD_SHOT.Length - 1
                            dt.Columns.Add(New DataColumn(SMD_SHOT(i), GetType(System.String)))
                        Next
                        For j As Integer = 0 To 3
                            Dim addRow As DataRow = dt.NewRow
                            For index As Integer = 0 To SMD_SHOT.Length - 1
                                Select Case index
                                    Case 0
                                        addRow(SMD_SHOT(index)) = "Shot" & index
                                    Case Else
                                        addRow(SMD_SHOT(index)) = index
                                End Select
                            Next

                            dt.Rows.Add(addRow)
                        Next
                    Case "合格"
                        For i As Integer = 0 To SMD_PASSING.Length - 1
                            dt.Columns.Add(New DataColumn(SMD_PASSING(i), GetType(System.String)))
                        Next
                        For j As Integer = 0 To 3
                            Dim addRow As DataRow = dt.NewRow
                            For index As Integer = 0 To SMD_PASSING.Length - 1
                                Select Case index
                                    Case 0
                                        addRow(SMD_PASSING(index)) = "Passing" & index
                                    Case Else
                                        addRow(SMD_PASSING(index)) = index
                                End Select
                            Next

                            dt.Rows.Add(addRow)
                        Next
                    Case "不良"
                        For i As Integer = 0 To SMD_BAD.Length - 1
                            dt.Columns.Add(New DataColumn(SMD_BAD(i), GetType(System.String)))
                        Next
                        For j As Integer = 0 To 3
                            Dim addRow As DataRow = dt.NewRow
                            For index As Integer = 0 To SMD_BAD.Length - 1
                                Select Case index
                                    Case 0
                                        addRow(SMD_BAD(index)) = "Bad" & index
                                    Case Else
                                        addRow(SMD_BAD(index)) = index
                                End Select
                            Next

                            dt.Rows.Add(addRow)
                        Next
                    Case "調整"
                        For i As Integer = 0 To SMD_ADJUSTMENT.Length - 1
                            dt.Columns.Add(New DataColumn(SMD_ADJUSTMENT(i), GetType(System.String)))
                        Next
                        For j As Integer = 0 To 3
                            Dim addRow As DataRow = dt.NewRow
                            For index As Integer = 0 To SMD_ADJUSTMENT.Length - 1
                                Select Case index
                                    Case 0
                                        addRow(SMD_ADJUSTMENT(index)) = "Adjustment" & index
                                    Case Else
                                        addRow(SMD_ADJUSTMENT(index)) = index
                                End Select
                            Next

                            dt.Rows.Add(addRow)
                        Next
                    Case "その他払出"
                        For i As Integer = 0 To SMD_OTHERT.Length - 1
                            dt.Columns.Add(New DataColumn(SMD_OTHERT(i), GetType(System.String)))
                        Next
                        For j As Integer = 0 To 3
                            Dim addRow As DataRow = dt.NewRow
                            For index As Integer = 0 To SMD_OTHERT.Length - 1
                                Select Case index
                                    Case 0
                                        addRow(SMD_OTHERT(index)) = "Other" & index
                                    Case Else
                                        addRow(SMD_OTHERT(index)) = index
                                End Select
                            Next

                            dt.Rows.Add(addRow)
                        Next
                End Select
        End Select

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
        'For i As Integer = 0 To gridData.Columns.Count - 1
        '    gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

        '    '横位置
        '    Select Case gridData.Columns(i).Name
        '        Case COL_DETAILS
        '            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '        Case Else
        '            gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    End Select

        'Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        'gridData.Columns(0).Width = 50
        'gridData.Columns(1).Width = 150
        'gridData.Columns(2).Width = 150
        'gridData.Columns(3).Width = 400
        'gridData.Columns(4).Width = 400
        'gridData.Columns(5).Width = 100


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        'If MsgBox(String.Format(clsGlobal.MSG2("I0099")),
        '          vbYesNo + vbQuestion,
        '          My.Settings.systemName) = DialogResult.Yes Then
        '    Me.Close()
        'End If

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick

    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K14A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtJudgmentCategory.Text = SC_K14.judgmentCategory
        Me.txtJudgmentClassification.Text = SC_K14.judgmentClassification

        setGrid(createGridData())

    End Sub

End Class