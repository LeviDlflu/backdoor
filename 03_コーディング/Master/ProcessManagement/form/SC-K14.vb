Imports System.Reflection

Public Class SC_K14
    Dim headerName As Hashtable = New Hashtable From {
                             {"品名略称", "Product name abbreviation" & vbCrLf & "品名略称"},
                             {"区分", "Section" & vbCrLf & "区分"},
                             {"分類", "Classification" & vbCrLf & "分類"},
                             {"合計", "Total" & vbCrLf & "合計"}
                            }
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_SECTION As String = "区分"
    Private Const COL_CLASSIFICATION As String = "分類"
    Private Const COL_TOTAL As String = "合計"

    Private Const CONST_SYSTEM_NAME As String = "前日以前実績参照"
    Private Const FORM_NAME As String = "The results before the previous days(前日以前実績参照)"

    Public judgmentCategory As String = String.Empty
    Public judgmentClassification As String = String.Empty

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbProcess.Text = String.Empty
        Me.cmbVariety.Text = String.Empty
        Me.cmbSection.Text = String.Empty
        Me.cmbVehicleType.Text = String.Empty
        Me.cmbSalesVarieties.Text = String.Empty
        Me.cmbProductName.Text = String.Empty

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

        Dim dt As New DataTable

        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Rows.Add("0", "成形")
        dt.Rows.Add("1", "塗装")
        dt.Rows.Add("2", "組立")

        '自動ラベルフラグ
        Me.cmbProcess.DataSource = dt
        Me.cmbProcess.ValueMember = dt.Columns.Item(0).ColumnName
        Me.cmbProcess.DisplayMember = dt.Columns.Item(1).ColumnName

        Dim type As Type = gridData.GetType()
        Dim pi As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(gridData, True, Nothing)

    End Sub


    ''' <summary>
    ''' 　・行ヘッダーに行番号書き込み
    ''' </summary>
    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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
        Dim PARAM_CODE As String = Me.cmbProcess.Text

        Dim code1 As String = "成形"
        Dim code2 As String = "塗装"
        Dim code3 As String = "組立"

        dt.Columns.Add(New DataColumn(COL_PRODUCT_NAME_ABBREVIATION, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_SECTION, GetType(System.String)))
        If cmbProcess.Text = code2 Then
            '分類
            dt.Columns.Add(New DataColumn(COL_CLASSIFICATION, GetType(System.String)))
        End If
        dt.Columns.Add(New DataColumn(COL_TOTAL, GetType(System.String)))
        For j As Integer = 1 To 31
            Dim headName As String = Now.Month & "/" & j

            dt.Columns.Add(New DataColumn(headName, GetType(System.String)))
        Next

        For item As Integer = 0 To 2
            Select Case PARAM_CODE
                Case code1

                    For i As Integer = 0 To 3
                        Dim addRow As DataRow = dt.NewRow
                        addRow(COL_PRODUCT_NAME_ABBREVIATION) = "SMD" & item
                        addRow(COL_TOTAL) = "1000"

                        Select Case i
                            Case 0
                                addRow(COL_SECTION) = "ショット"
                            Case 1
                                addRow(COL_SECTION) = "合格"
                            Case 2
                                addRow(COL_SECTION) = "不良"
                            Case 3
                                addRow(COL_SECTION) = "調整"

                        End Select
                        For j As Integer = 1 To 31
                            Dim headName As String = Now.Month & "/" & j
                            addRow(headName) = j
                        Next

                        dt.Rows.Add(addRow)
                    Next

                Case code2

                    For i As Integer = 0 To 9
                        Dim addRow As DataRow = dt.NewRow
                        addRow(COL_PRODUCT_NAME_ABBREVIATION) = "TPH" & item
                        addRow(COL_TOTAL) = "1000"

                        Select Case i
                            Case 0
                                addRow(COL_SECTION) = "塗装投入"
                                addRow(COL_CLASSIFICATION) = "生地"
                            Case 1
                                addRow(COL_SECTION) = "塗装投入"
                                addRow(COL_CLASSIFICATION) = "再塗装"
                            Case 2
                                addRow(COL_SECTION) = "合格"
                                addRow(COL_CLASSIFICATION) = "生地品"
                            Case 3
                                addRow(COL_SECTION) = "合格"
                                addRow(COL_CLASSIFICATION) = "再塗装品"
                            Case 4
                                addRow(COL_SECTION) = "合格"
                                addRow(COL_CLASSIFICATION) = "合格計"
                            Case 5
                                addRow(COL_SECTION) = "リペア判定"
                            Case 6
                                addRow(COL_SECTION) = "再塗装判定"
                            Case 7
                                addRow(COL_SECTION) = "不良"
                            Case 8
                                addRow(COL_SECTION) = "生地不良"
                                addRow(COL_CLASSIFICATION) = "成形"
                            Case 9
                                addRow(COL_SECTION) = "生地不良"
                                addRow(COL_CLASSIFICATION) = "仕上"

                        End Select
                        For j As Integer = 1 To 31
                            Dim headName As String = Now.Month & "/" & j
                            addRow(headName) = j
                        Next

                        dt.Rows.Add(addRow)
                    Next

                Case code3

                    For i As Integer = 0 To 2
                        Dim addRow As DataRow = dt.NewRow
                        addRow(COL_PRODUCT_NAME_ABBREVIATION) = "TAS" & item
                        addRow(COL_TOTAL) = "1000"

                        Select Case i
                            Case 0
                                addRow(COL_SECTION) = "着手"
                            Case 1
                                addRow(COL_SECTION) = "合格"
                            Case 2
                                addRow(COL_SECTION) = "不良"

                        End Select
                        For j As Integer = 1 To 31
                            Dim headName As String = Now.Month & "/" & j
                            addRow(headName) = j
                        Next

                        dt.Rows.Add(addRow)
                    Next
            End Select
        Next

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
            If headerName(col.ColumnName) IsNot Nothing Then
                addCol.HeaderText = headerName(col.ColumnName)
            Else
                addCol.HeaderText = col.ColumnName
            End If
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

        For i As Integer = 0 To gridData.DisplayedColumnCount(True)
            Select Case i
                Case 0
                    gridData.Columns(i).Width = 200
                Case 1
                    gridData.Columns(i).Width = 80
                Case 2
                    gridData.Columns(i).Width = 70
                Case Else
                    gridData.Columns(i).Width = 50
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
    ''' 検索ボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")

        setGrid(createGridData())

        gridData.MergeColumnNames.Add(COL_PRODUCT_NAME_ABBREVIATION)

    End Sub

    Private Sub gridData_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentDoubleClick
        If e.ColumnIndex > -1 Then
            Dim gridCells As DataGridViewCellCollection = gridData.Rows(e.RowIndex).Cells
            judgmentCategory = gridCells(COL_SECTION).Value
            If Me.cmbProcess.Text = "塗装" Then
                judgmentClassification = gridCells(COL_CLASSIFICATION).Value
            End If

            Dim frm As New SC_K14A()
            frm.ShowDialog()
            Me.Show()
        End If
    End Sub

    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

End Class
