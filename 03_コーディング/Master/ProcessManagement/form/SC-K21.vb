Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_K21

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"受払年月日", "Payment date" & vbCrLf & "(受払年月日)"},
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"工程略称", "Process abbreviation" & vbCrLf & "(工程略称)"},
                             {"個体ＮＯ", "Individual NO" & vbCrLf & "(個体ＮＯ)"},
                             {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                             {"払出数量", "Payment quantity" & vbCrLf & "(払出数量)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_PAYMENT_DATE As String = "受払年月日"
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_PROCESS_ABBREVIATION As String = "工程略称"
    Private Const COL_LOT_NO As String = "個体ＮＯ"
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_ISSUED_QUANTITY As String = "払出数量"
    Private Const COL_REMARKS As String = "備考"

    Private Sub SC_K21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub
    Private Sub init()
        Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")
        setGrid(createGridData())
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt = New DataTable()

        dt.Columns.Add(New DataColumn(COL_PAYMENT_DATE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PROCESS_CODE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PROCESS_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_LOT_NO, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_PRODUCT_NAME_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_ISSUED_QUANTITY, GetType(System.Double)))
        dt.Columns.Add(New DataColumn(COL_REMARKS, GetType(System.String)))

        Dim dr As DataRow

        For index = 1 To 5
            dr = dt.NewRow()
            dr.Item(COL_PAYMENT_DATE) = Format(Now, "yyyy/MM/dd hh:mm")
            dr.Item(COL_PROCESS_CODE) = COL_PROCESS_CODE & index
            dr.Item(COL_PROCESS_ABBREVIATION) = COL_PROCESS_ABBREVIATION & index
            dr.Item(COL_LOT_NO) = COL_LOT_NO & index
            dr.Item(COL_PRODUCT_NAME_ABBREVIATION) = COL_PRODUCT_NAME_ABBREVIATION & index
            dr.Item(COL_ISSUED_QUANTITY) = index
            dr.Item(COL_REMARKS) = COL_REMARKS & index
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
                Case COL_PROCESS_CODE
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

        gridData.Columns(0).Width = 120
        gridData.Columns(1).Width = 200
        gridData.Columns(2).Width = 200
        gridData.Columns(3).Width = 260
        gridData.Columns(4).Width = 200
        gridData.Columns(5).Width = 200
        gridData.Columns(6).Width = 200
        gridData.Columns(7).Width = 200


        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False

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

End Class