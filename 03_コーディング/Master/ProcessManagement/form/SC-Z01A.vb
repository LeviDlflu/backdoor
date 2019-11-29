Imports System.Text
Imports PUCCommon

Public Class SC_Z01A

    Private Const FORM_NAME As String = "Entry / Exit history info(入出庫来歴照会)"

    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
    Dim VIEW_HEADER As Hashtable = New Hashtable From {
                                {"前月残量", "Last month remaining" & vbCrLf & "(前月残量)"},
                                {"入庫量", "Amount received" & vbCrLf & "(入庫量)"},
                                {"売上量", "Sales volume" & vbCrLf & "(売上量)"},
                                {"その他出庫量", "Other issues" & vbCrLf & "(その他出庫量)"},
                                {"在庫量", "Stock quantity" & vbCrLf & "(在庫量)"},
                                {"引当可能残量", "Allowable balance" & vbCrLf & "(引当可能残量)"}
                            }

    Dim DETAIL_HEADER As Hashtable = New Hashtable From {
                                {"入出庫日", "Entry / exit date" & vbCrLf & "(入出庫日)"},
                                {"処理日", "Processing date" & vbCrLf & "(処理日)"},
                                {"作番", "Production number" & vbCrLf & "(作番)"},
                                {"入庫量", "Amount received" & vbCrLf & "(入庫量)"},
                                {"出庫量", "Issued quantity" & vbCrLf & "(出庫量)"},
                                {"その他払出", "Other payout" & vbCrLf & "(その他払出)"}
                            }

    Private Const COL_AMOUNT_RECEIVED As String = "入庫量"
    Private Const COL_ISSUED_QUANTITY As String = "出庫量"
    Private Const COL_OTHER_PAYOUT As String = "その他払出"

    Private sortList As New Hashtable

    Dim xml As New clsGetSqlXML("SC-Z01A.xml", "SC-Z01A")

    ''' <summary>
    ''' 　画面Load
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub SC_Z01A_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMaster.Text = FORM_NAME
        Me.Text = "[Z-01A]" & FORM_NAME

        lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")

        Me.btnFinish.Text = "Return" & vbCrLf & "(戻る)"

        '工程
        Me.txtProcess.Text = formParameter.Process
        '部品番号
        Me.txtPartNumber.Text = formParameter.PartNumber
        '品名略称
        Me.txtProductNameAbbreviation.Text = formParameter.ProductName

        Init()

    End Sub

    ''' <summary>
    ''' データ設定
    ''' </summary>
    Private Sub Init()

        Try

            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                Dim sqlstr As String

                Dim dt As New DataTable()

                '一覧部
                sqlstr = xml.GetSQL_Str("SELECT_001")
                dt = clsSQLServer.GetDataTable(String.Format(sqlstr,
                                                             businessCode,
                                                             formParameter.ProductNamePlantCode,
                                                             formParameter.PackProductName,
                                                             formParameter.DeliveryCode,
                                                             formParameter.DeliveryDivision,
                                                             formParameter.SemiFinishedProductDivision))

                If dt.Rows.Count > 0 Then
                    SetGridToView(dt)
                Else
                    gridDataList.Columns.Clear()
                End If

                '明細部
                sqlstr = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(String.Format(sqlstr,
                                                             businessCode,
                                                             formParameter.ProductNamePlantCode,
                                                             formParameter.PackProductName,
                                                             formParameter.DeliveryCode,
                                                             formParameter.DeliveryDivision,
                                                             formParameter.SemiFinishedProductDivision))

                If dt.Rows.Count = 0 Then

                    gridData.Columns.Clear()

                    MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                           vbExclamation,
                           systemName)
                    Me.Close()
                    Return

                ElseIf dt.Rows.Count > 1000 Then

                    MsgBox(String.Format(clsGlobal.MSG2("W9004"), 1000),
                           vbExclamation,
                           systemName)

                End If

                SetGridToDetail(dt)

                Me.Visible = True

            End If

        Catch ex As Exception
            Throw
        Finally
            clsSQLServer.Disconnect()
        End Try
    End Sub

    ''' <summary>
    ''' 一覧部設定
    ''' </summary>
    Private Sub SetGridToView(ByRef dtData As DataTable)

        gridDataList.Columns.Clear()

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = VIEW_HEADER(col.ColumnName)
            addCol.Name = col.ColumnName

            gridDataList.Columns.Add(addCol)
        Next

        gridDataList.DataSource = dtData.Copy
        gridDataList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        gridDataList.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray

        For Each col As DataGridViewColumn In gridDataList.Columns
            col.ReadOnly = True
            'ソート
            col.SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        gridDataList.AutoResizeColumns()

        gridDataList.Columns(0).Width = 140
        gridDataList.Columns(1).Width = 120
        gridDataList.Columns(2).Width = 100
        gridDataList.Columns(3).Width = 100
        gridDataList.Columns(4).Width = 100
        gridDataList.Columns(5).Width = 120

    End Sub

    ''' <summary>
    ''' 明細部設定
    ''' </summary>
    Private Sub SetGridToDetail(ByRef dtData As DataTable)

        gridData.Columns.Clear()
        sortList.Clear()

        For Each col As DataColumn In dtData.Columns

            Dim addCol As New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = DETAIL_HEADER(col.ColumnName)
            addCol.Name = col.ColumnName

            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray

        For Each col As DataGridViewColumn In gridData.Columns
            col.ReadOnly = True
            'ソート
            col.SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case col.Name
                Case COL_AMOUNT_RECEIVED, COL_ISSUED_QUANTITY, COL_OTHER_PAYOUT
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        Next

        gridData.AutoResizeColumns()

        gridData.Columns(0).Width = 170
        gridData.Columns(1).Width = 170
        gridData.Columns(2).Width = 290
        gridData.Columns(3).Width = 190
        gridData.Columns(4).Width = 190
        gridData.Columns(5).Width = 190
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
    ''' ソート項目を選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridData.ColumnHeaderMouseClick

        If gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue Then
            sortList.Remove(e.ColumnIndex)
            gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.LightGray
        Else
            sortList.Add(e.ColumnIndex, gridData.Columns.Item(e.ColumnIndex).Name)
            gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue
        End If

    End Sub

    ''' <summary>
    ''' 一覧部、列の書式設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridDataList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDataList.CellFormatting

        If IsDBNull(e.Value) = False Then
            e.Value = Format(e.Value, "N")
        End If

    End Sub

    ''' <summary>
    ''' 明細部、列の書式設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gridData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridData.CellFormatting

        If e.ColumnIndex = 1 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(e.Value, "yyyy/MM/dd HH:mm:ss")
            End If
        ElseIf e.ColumnIndex > 2 Then
            If IsDBNull(e.Value) = False Then
                e.Value = Format(e.Value, "N")
            End If
        End If


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
End Class
