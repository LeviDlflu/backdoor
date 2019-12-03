Imports PUCCommon
Imports System.Text
Imports System.Reflection

Public Class SC_K21C
    Dim headerName As Hashtable = New Hashtable From {
                             {"大工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"工程略称", "Process abbreviation" & vbCrLf & "(工程略称)"},
                             {"品種名", "Variety" & vbCrLf & "(品種)"},
                             {"数量", "Payment quantity total" & vbCrLf & "(払出数量合計)"}
                            }
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_PROCESS_ABBREVIATION As String = "工程略称"
    Private Const COL_VARIETY As String = "品種"
    Private Const COL_PAYMENT_QUANTITY_TOTAL As String = "払出数量合計"

    Private Const FORM_NAME As String = "Total by process variety (工程品種別集計)"

    Dim xml As New clsGetSqlXML("SC-K21C.xml", "SC-K21C")

    Private Sub SC_K21A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub init()
        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME
        '対象年月
        'Me.txtDate.Text = formParameter.TargetDate
        ''払出区分
        'Me.txtDivision.Text = formParameter.Division

        Dim strSelect As String
        Dim dt As New DataTable

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                strSelect = xml.GetSQL_Str("SELECT_001")

                'dt = clsSQLServer.GetDataTable(String.Format(strSelect,
                '                                                       businessCode,
                '                                                       txtDate.Text,
                '                                                       formParameter.DiviCode))
                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
        End Try

        If dt.Rows.Count = 0 Then
            MessageBox.Show(clsGlobal.MSG2("W0008"))
            gridData.Columns.Clear()
            Return
        End If

        setGrid(dt)
        lblSearchTime.Text = Format(Now, "yyyy/MM/dd hh:mm")

    End Sub

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
                Case COL_PROCESS_CODE
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case COL_PAYMENT_QUANTITY_TOTAL
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
        gridData.Columns(2).Width = 250
        gridData.Columns(3).Width = 180

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
