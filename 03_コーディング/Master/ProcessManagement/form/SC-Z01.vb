Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Office.Interop
Imports PUCCommon

Public Class SC_Z01

    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
    Dim HEADER_NAME As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "(詳細)"},
                             {"工程", "Process" & vbCrLf & "(工程)"},
                             {"品名略称", "Product name abbreviation" & vbCrLf & "(品名略称)"},
                             {"部品番号", "Part number" & vbCrLf & "(部品番号)"},
                             {"前月末残", "Last month balance" & vbCrLf & "(前月" & vbCrLf & "末残)"},
                             {"当月累計", "Cumulative month" & vbCrLf & "(当月累計)"},
                             {"受入", "Acceptance" & vbCrLf & "(受入)"},
                             {"払出", "Withdrawaln" & vbCrLf & "(払出)"},
                             {"その他払出", "Other payout" & vbCrLf & "(その他払出)"},
                             {"当日", "On the day" & vbCrLf & "(当日)"},
                             {"在庫残", "Stock balance" & vbCrLf & "(在庫残)"}
                            }

    Private Const COL_BIOGRAPHY As String = "来歴"
    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PROCESS As String = "工程"
    Private Const COL_PRODUCT_NAME As String = "品名略称"
    Private Const COL_PART_NUMBER As String = "部品番号"
    Private Const COL_LAST_MONTH_BALANCE As String = "前月末残"
    Private Const COL_CUMULATIVE_MONTH As String = "当月累計"
    Private Const COL_ACCEPTANCE As String = "受入"
    Private Const COL_WITHDRAWALN As String = "払出"
    Private Const COL_OTHER As String = "その他払出"
    Private Const COL_CUMULATIVE_ACCEPTANCE As String = "当月受入数量"
    Private Const COL_CUMULATIVE_WITHDRAWALN As String = "当月払出数量"
    Private Const COL_CUMULATIVE_OTHER As String = "当月その他払出数量"
    Private Const COL_DAY As String = "当日"
    Private Const COL_DAY_ACCEPTANCE As String = "当日受入数量"
    Private Const COL_DAY_WITHDRAWALN As String = "当日払出数量"
    Private Const COL_DAY_OTHER As String = "当日その他払出数量"
    Private Const COL_STOCK_BALANCE As String = "在庫残"
    Private Const COL_DELIVERY_DIVISION As String = "納入区分"
    Private Const COL_PRODUCT_PLANT_CODE As String = "品名事業所コード"
    Private Const COL_PACK_PRODUCT_NAME As String = "パック品名略称"

    Private Const YARD = "置場"
    Private sortList As New Hashtable

    Dim PATTEN_1 As String() = {COL_PROCESS,
                                COL_PRODUCT_NAME,
                                COL_PART_NUMBER,
                                COL_LAST_MONTH_BALANCE,
                                COL_CUMULATIVE_ACCEPTANCE,
                                COL_CUMULATIVE_WITHDRAWALN,
                                COL_CUMULATIVE_OTHER,
                                COL_DAY_ACCEPTANCE,
                                COL_DAY_WITHDRAWALN,
                                COL_DAY_OTHER,
                                COL_STOCK_BALANCE}

    '製品半製品区分
    Dim productKubun As Integer = 1

    Dim dtHeader As New DataTable

    Dim xml As New clsGetSqlXML("SC-Z01.xml", "SC-Z01")

    ''' <summary>
    ''' 　画面初期化
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub SC_Z01_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim strSelect As String
            Dim dt As New DataTable

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '置場
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbYard.DataSource = dt
                Me.cmbYard.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbYard.DisplayMember = dt.Columns.Item(1).ColumnName

                '工程
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbProcess.DataSource = dt
                Me.cmbProcess.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbProcess.DisplayMember = dt.Columns.Item(1).ColumnName

                '品種
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbVariety.DataSource = dt
                Me.cmbVariety.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbVariety.DisplayMember = dt.Columns.Item(1).ColumnName

                '車種
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt = clsSQLServer.GetDataTable(strSelect)
                Me.cmbVehicleType.DataSource = dt
                Me.cmbVehicleType.ValueMember = dt.Columns.Item(0).ColumnName
                Me.cmbVehicleType.DisplayMember = dt.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)

        gridData.Columns.Clear()
        sortList.Clear()

        '詳細
        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_BIOGRAPHY
        btn.HeaderText = HEADER_NAME(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_BIOGRAPHY
        gridData.Columns.Add(btn)

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            If HEADER_NAME(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = HEADER_NAME(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If

            addCol.Name = col.ColumnName
            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dtData.Copy

        gridData.ColumnHeadersHeight = 68
        gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        For i As Integer = 0 To gridData.Columns.Count - 1
            'ソート
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            If gridData.Columns(i).Name = COL_BIOGRAPHY Then
                gridData.Columns(i).DefaultCellStyle.BackColor = Color.White
            End If
            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_PROCESS, COL_PRODUCT_NAME, COL_PART_NUMBER
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                Case COL_DELIVERY_DIVISION, COL_PRODUCT_PLANT_CODE, COL_PACK_PRODUCT_NAME
                    gridData.Columns(i).Visible = False
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End Select
        Next
        gridData.AutoResizeColumns()

        'マージ列
        gridData.AddSpanHeader(5, 3, HEADER_NAME(COL_CUMULATIVE_MONTH))
        gridData.AddSpanHeader(8, 3, HEADER_NAME(COL_DAY))
        gridData.MergeColumnHeaderBackColor = Color.LightGray

        'ヘーダ名前変更
        gridData.Columns(COL_CUMULATIVE_ACCEPTANCE).HeaderText = HEADER_NAME(COL_ACCEPTANCE)
        gridData.Columns(COL_CUMULATIVE_WITHDRAWALN).HeaderText = HEADER_NAME(COL_WITHDRAWALN)
        gridData.Columns(COL_CUMULATIVE_OTHER).HeaderText = HEADER_NAME(COL_OTHER)
        gridData.Columns(COL_DAY_ACCEPTANCE).HeaderText = HEADER_NAME(COL_ACCEPTANCE)
        gridData.Columns(COL_DAY_WITHDRAWALN).HeaderText = HEADER_NAME(COL_WITHDRAWALN)
        gridData.Columns(COL_DAY_OTHER).HeaderText = HEADER_NAME(COL_OTHER)

        '列の幅の設定
        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 95
        gridData.Columns(2).Width = 170
        gridData.Columns(3).Width = 110
        gridData.Columns(4).Width = 100
        gridData.Columns(5).Width = 95
        gridData.Columns(6).Width = 95
        gridData.Columns(7).Width = 95
        gridData.Columns(8).Width = 95
        gridData.Columns(9).Width = 95
        gridData.Columns(10).Width = 95
        gridData.Columns(11).Width = 110

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 行ヘッダーに行番号書き込み
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' スクロールする時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridData.Scroll
        gridData.InvalidateUnitColumns()
    End Sub

    ''' <summary>
    ''' 詳細画面を開く
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick

        If gridData.Columns(e.ColumnIndex).Name = COL_BIOGRAPHY And e.RowIndex >= 0 Then
            'パラメータ.工程
            formParameter.Process = gridData.CurrentRow.Cells(COL_PROCESS).Value.ToString
            'パラメータ.部品番号
            formParameter.PartNumber = gridData.CurrentRow.Cells(COL_PART_NUMBER).Value.ToString
            'パラメータ.品名略称
            formParameter.ProductName = gridData.CurrentRow.Cells(COL_PRODUCT_NAME).Value.ToString
            'パラメータ.品名事業所コード
            formParameter.ProductNamePlantCode = gridData.CurrentRow.Cells(COL_PRODUCT_PLANT_CODE).Value.ToString
            'パラメータ.パック品名略称
            formParameter.PackProductName = gridData.CurrentRow.Cells(COL_PACK_PRODUCT_NAME).Value.ToString
            'パラメータ.納入先コード
            formParameter.DeliveryCode = Me.cmbYard.SelectedValue.ToString
            'パラメータ.納入区分
            formParameter.DeliveryDivision = gridData.CurrentRow.Cells(COL_DELIVERY_DIVISION).Value.ToString
            'パラメータ.製品半製品区分
            formParameter.SemiFinishedProductDivision = productKubun.ToString

            Dim frm As New SC_Z01A()
            frm.ShowDialog()
            frm.Visible = False
            Me.Show()

        End If

    End Sub

    ''' <summary>
    ''' 　検索ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        lblSearchTime.Visible = True
        lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")

        '納入先コード
        Dim cdYard As String
        '大工程コード
        Dim cdProcess As String = String.Empty
        '品種コード
        Dim cdVariety As String = String.Empty
        '車種コード
        Dim cdVehicleType As String = String.Empty
        'ゼロデータを除く
        Dim zeroData As String = ""
        '納入区分
        Dim deliveryFormat As String = "({0})"
        Dim deliveryKubun As String = String.Empty

        '必須チェック
        '置場
        If cmbYard.Text.Equals(String.Empty) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), YARD))
            cmbYard.BackColor = Color.Red
            Return
        Else
            cmbYard.BackColor = Color.Yellow
        End If

        cdYard = cmbYard.SelectedValue
        cdProcess = cmbProcess.SelectedValue
        cdVariety = cmbVariety.SelectedValue
        cdVehicleType = cmbVehicleType.SelectedValue

        'ライン
        If chkLine.Checked = True Then
            deliveryKubun = "'L'"
        End If

        'KD
        If chkKD.Checked = True Then
            If deliveryKubun IsNot String.Empty Then
                deliveryKubun = deliveryKubun & ",'K'"
            Else
                deliveryKubun = "'K'"
            End If
        End If

        'SP
        If chkSP.Checked = True Then
            If deliveryKubun IsNot String.Empty Then
                deliveryKubun = deliveryKubun & ",'S'"
            Else
                deliveryKubun = "'S'"
            End If
        End If

        If deliveryKubun IsNot String.Empty Then
            deliveryKubun = " AND 納入区分 IN " & String.Format(deliveryFormat, deliveryKubun)
        End If

        'ゼロデータを除く
        If chkZero.Checked = True Then
            zeroData = xml.GetSQL_Str("WHERE_001")
        End If

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim strSql As String
                Dim sqlWhere As String = String.Empty
                Dim dt As New DataTable()

                If IsNothing(cdProcess) = False And String.IsNullOrWhiteSpace(cdProcess) = False Then
                    sqlWhere = " AND 工程 ='" & cdProcess & "'"
                End If

                If IsNothing(cdVariety) = False And String.IsNullOrWhiteSpace(cdVariety) = False Then
                    sqlWhere = sqlWhere & " AND 品種コード ='" & cdVariety & "'"
                End If

                If IsNothing(cdVehicleType) = False And String.IsNullOrWhiteSpace(cdVehicleType) = False Then
                    sqlWhere = sqlWhere & " AND 車種コード ='" & cdVehicleType & "'"
                End If

                sqlWhere = sqlWhere & deliveryKubun & zeroData

                strSql = xml.GetSQL_Str("SELECT_005")

                dt = clsSQLServer.GetDataTable(String.Format(strSql, businessCode, productKubun, cdYard, sqlWhere))

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

                setGrid(dt)

            End If

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try

    End Sub

    ''' <summary>
    ''' 　昇順ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click

        If sortList.Count = 0 Then
            Return
        End If

        Dim sortFile As String = ""
        For Each item As DictionaryEntry In sortList
            sortFile = item.Value & "," & sortFile
        Next

        Dim dv As DataView = gridData.DataSource.DefaultView
        dv.Sort = sortFile.Remove(sortFile.Length - 1, 1)

        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()

    End Sub

    ''' <summary>
    ''' 　降順ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click

        If sortList.Count = 0 Then
            Return
        End If

        Dim sortFile As String = ""
        For Each item As DictionaryEntry In sortList
            sortFile = item.Value & " DESC," & sortFile
        Next

        Dim dv As DataView = gridData.DataSource.DefaultView
        dv.Sort = sortFile.Remove(sortFile.Length - 1, 1)

        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()

    End Sub

    ''' <summary>
    ''' 　Excelボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If gridData.Rows.Count > 0 Then
            Dim xmlHeader As New clsGetSqlXML("ExportHeaderToExcel.xml", "SC-Z01")

            Dim strNodeList As ArrayList = xmlHeader.GetXmlNodeList("HEADER_001")

            Dim dgv As DataGridView = gridData

            Dim isOK = clsExcel.ExportToExcel(dgv, "在庫照会", strNodeList)

            If isOK = True Then
                MessageBox.Show(Me, "エクスポート完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    ''' <summary>
    ''' 製品/半製品区分
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rodProduct_CheckedChanged(sender As Object, e As EventArgs) Handles rodProduct.CheckedChanged
        If rodProduct.Checked = True Then
            productKubun = 1
        Else
            productKubun = 2
        End If
    End Sub

    ''' <summary>
    ''' 列の書式設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridData.CellFormatting
        If e.ColumnIndex > 3 And e.ColumnIndex < 12 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(e.Value, "N")
            End If
        End If
    End Sub

    ''' <summary>
    ''' ソート項目を選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridData.ColumnHeaderMouseClick

        If e.ColumnIndex > 0 Then
            If gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue Then
                sortList.Remove(e.ColumnIndex)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.LightGray
            Else
                sortList.Add(e.ColumnIndex, gridData.Columns.Item(e.ColumnIndex).Name)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue
            End If
        End If

    End Sub
End Class
