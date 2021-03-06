﻿Public Class SC_K13A
    Dim headerName As Hashtable = New Hashtable From {
                             {"個体No", "Individual No" & vbCrLf & "(個体No)"},
                             {"数量", "Quantity" & vbCrLf & "(数量)"},
                             {"日付・時間", "Date / Time" & vbCrLf & "(日付・時間)"},
                             {"不良原因", "Cause of failure" & vbCrLf & "(不良原因)"},
                             {"キャビ", "Caviar" & vbCrLf & "(キャビ)"}
                            }

    Private Const COL_NO_ID As String = "項番"
    Private Const COL_INDIVISUAL_NO As String = "個体No"
    Private Const COL_QUANTITY As String = "数量"
    Private Const COL_DATETIME As String = "日付・時間"
    Private Const COL_CAUSE_FAILURE As String = "不良原因"
    Private Const COL_CAVIAR As String = "キャビ"

    Private CMB_JUDGMENT As String()
    Private KEY_PRODUCT_PLANT As String
    Private KEY_PACK_PRODUCT As String
    Private KEY_DELIVERY_CODE As String
    Private KEY_DELIVERY_DIVISION As String
    Private KEY_SEMI_PRODUCT As String

    '工程
    Public Property Process() As String
        Get
            Return txtProcess.Text
        End Get
        Set(ByVal Value As String)
            txtProcess.Text = Value
        End Set
    End Property

    '設備
    Public Property Facility() As String
        Get
            Return txtFacility.Text
        End Get
        Set(ByVal Value As String)
            txtFacility.Text = Value
        End Set
    End Property

    '品名
    Public Property Product() As String
        Get
            Return txtProduct.Text
        End Get
        Set(ByVal Value As String)
            txtProduct.Text = Value
        End Set
    End Property

    '金型
    Public Property Mold() As String
        Get
            Return txtMold.Text
        End Get
        Set(ByVal Value As String)
            txtMold.Text = Value
        End Set
    End Property

    '判定
    Public Property Judgment() As String()
        Get
            Return CMB_JUDGMENT
        End Get
        Set(ByVal Value As String())
            CMB_JUDGMENT = Value
        End Set
    End Property

    '品名事業所コード
    Public Property ProductPlant() As String
        Get
            Return KEY_PRODUCT_PLANT
        End Get
        Set(ByVal Value As String)
            KEY_PRODUCT_PLANT = Value
        End Set
    End Property

    'パック品名略称
    Public Property PackProduct() As String
        Get
            Return KEY_PACK_PRODUCT
        End Get
        Set(ByVal Value As String)
            KEY_PACK_PRODUCT = Value
        End Set
    End Property

    '納入先コード
    Public Property DeliveryDivision() As String
        Get
            Return KEY_DELIVERY_CODE
        End Get
        Set(ByVal Value As String)
            KEY_DELIVERY_CODE = Value
        End Set
    End Property

    '納入区分
    Public Property DeliveryCode() As String
        Get
            Return KEY_DELIVERY_DIVISION
        End Get
        Set(ByVal Value As String)
            KEY_DELIVERY_DIVISION = Value
        End Set
    End Property

    '製品半製品区分
    Public Property SemiProduct() As String
        Get
            Return KEY_SEMI_PRODUCT
        End Get
        Set(ByVal Value As String)
            KEY_SEMI_PRODUCT = Value
        End Set
    End Property

    '初期処理
    Private Sub Init()
        Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")

        Select Case Process.Substring(0, Process.IndexOf(":"))
            Case "10", "20"
                txtMold.Visible = False
                Label14.Visible = False
                Label17.Visible = False
        End Select

    End Sub


    Private Sub gridData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridData.RowPostPaint

    End Sub

    Private Sub SC_K13A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        setGrid(createGridData())
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)
        If gridData.Rows.Count > 0 Then
            'gridData.Rows.Clear()
            gridData.Columns.Clear()
        End If
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
                Case COL_INDIVISUAL_NO, COL_CAUSE_FAILURE, COL_CAVIAR
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_QUANTITY
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

        gridData.Columns(0).Width = 100
        gridData.Columns(1).Width = 150
        gridData.Columns(2).Width = 150
        gridData.Columns(3).Width = 400
        gridData.Columns(4).Width = 400

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　グリッド用のデータを作成
    ''' </summary>
    Private Function createGridData() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn(COL_INDIVISUAL_NO, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_QUANTITY, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_DATETIME, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CAUSE_FAILURE, GetType(System.String)))
        dt.Columns.Add(New DataColumn(COL_CAVIAR, GetType(System.String)))

        For i As Integer = 0 To 6
            Dim addRow As DataRow = dt.NewRow
            Select Case i
                Case 0
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "1"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 1
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "1"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 2
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "2"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 3
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "11"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 4
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "31"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 5
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "5"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"
                Case 6
                    addRow(COL_INDIVISUAL_NO) = "9000001"
                    addRow(COL_QUANTITY) = "7"
                    addRow(COL_DATETIME) = "2019/01/01 12:09"
                    addRow(COL_CAUSE_FAILURE) = "不良200001"
                    addRow(COL_CAVIAR) = "30000001"

            End Select
            dt.Rows.Add(addRow)
        Next

        Return dt

    End Function
End Class
