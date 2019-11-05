Public Class SC_Z01A

    ''' <summary>
    ''' 列ヘッダーの行の高さ
    ''' </summary>
    ''' <remarks></remarks>
    Private columnHeaderrRowHeight As Integer = 40

    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"管理ＮＯ種別", "Management NO type" & vbCrLf & "(管理ＮＯ種別)"},
                             {"固定部", "Fixed part" & vbCrLf & "(固定部)"},
                             {"番号", "Number" & vbCrLf & "(番号)"},
                             {"変動データ部", "Fluctuation data section" & vbCrLf & "(変動データ部)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_SNOTYPE As String = "管理ＮＯ種別"
    Private Const COL_SFIXEDPART As String = "固定部"
    Private Const COL_SNUMBER As String = "番号"
    Private Const COL_SSECTION As String = "変動データ部"
    Private Const COL_SBIKOU As String = "備考"

    'Dim xml As New CmnXML("SC-Z01A.xml", "SC-Z01A")


    ''' <summary>
    ''' 　画面初期化
    ''' </summary>
    Private Sub Init()

        setManagementNoType("")

        'xml.InitUser(Me.txtLoginUser, Me.TextBox1)
        '列ヘッダーの高さの調整モード
        Me.gridDataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        '列ヘッダーの高さを行数に合わせる
        Me.gridDataList.ColumnHeadersHeight = columnHeaderrRowHeight * 1

        PattenList()

        '列ヘッダーの高さの調整モード
        Me.gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        '列ヘッダーの高さを行数に合わせる
        Me.gridData.ColumnHeadersHeight = columnHeaderrRowHeight * 1

        Patten3()

        Me.Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")

    End Sub

    ''' <summary>
    ''' 　画面項目管理NO種別初期化
    ''' </summary>
    Private Sub setManagementNoType(ByVal str As String)

        'Try

        '    If clsSQLServer.Connect(clsGlobal.ConnectString) Then

        '        Dim sqlstr As String = xml.GetSQL_Str("SELECT_001")

        '        Dim dt As New DataTable()

        '        dt = clsSQLServer.GetDataTable(sqlstr)

        '        Dim drWork As DataRow = dt.NewRow

        '        drWork(dt.Columns.Item(0).ColumnName) = "00"
        '        drWork(dt.Columns.Item(0).ColumnName) = ""
        '        dt.Rows.InsertAt(drWork, 0)

        '        Me.cmbManagementNoType.DataSource = dt

        '        ' 表示用の列を設定
        '        Me.cmbManagementNoType.DisplayMember = dt.Columns.Item(0).ColumnName
        '        ' データ用の列を設定
        '        Me.cmbManagementNoType.ValueMember = dt.Columns.Item(0).ColumnName

        '        clsSQLServer.Disconnect()

        '    End If

        '    If Not IsNothing(str) Then
        '        Me.cmbManagementNoType.Text = str
        '    End If

        'Catch ex As Exception
        '    Throw
        'End Try
    End Sub

    ''' <summary>
    ''' 　グリッドを設定する
    ''' </summary>
    ''' <param name="dtData">データソース</param>
    Private Sub setGrid(ByRef dtData As DataTable)

        gridData.Columns.Clear()

        '選択
        Dim addColSentaku As New DataGridViewCheckBoxColumn()
        addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
        addColSentaku.HeaderText = headerName(COL_SENTAKU)
        addColSentaku.Name = "sentaku"
        gridData.Columns.Add(addColSentaku)

        Dim addCol As New DataGridViewTextBoxColumn()

        For Each col As DataColumn In dtData.Columns
            addCol = New DataGridViewTextBoxColumn()
            addCol.DataPropertyName = col.ColumnName
            addCol.HeaderText = headerName(col.ColumnName)
            addCol.Name = col.ColumnName

            If col.ColumnName = COL_SNUMBER Then
                addCol.MaxInputLength = 10
            ElseIf col.ColumnName = COL_SSECTION Then
                addCol.MaxInputLength = 10
            ElseIf col.ColumnName = COL_SBIKOU Then
                addCol.MaxInputLength = 50
            End If

            gridData.Columns.Add(addCol)
        Next

        gridData.DataSource = dtData.Copy
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case COL_SFIXEDPART, COL_SBIKOU, COL_SSECTION
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case COL_SNUMBER
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        Next
        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case "sentaku"
                    col.ReadOnly = False
                    col.DefaultCellStyle.BackColor = Color.LightSkyBlue
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(0).Width = 90
        gridData.Columns(1).Width = 180
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 180
        gridData.Columns(5).Width = 200

        '複数選択不可
        gridData.MultiSelect = False
        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False
    End Sub

    ''' <summary>
    ''' 　画面Load
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub SC_M22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub PattenList()

        Dim dt As New DataTable

        dt.Columns.Add("前月残量")
        dt.Columns.Add("入庫量")
        dt.Columns.Add("売上量")
        dt.Columns.Add("その他出庫量")
        dt.Columns.Add("在庫量")
        dt.Columns.Add("引当可能残量")

        Dim dr As DataRow

        Dim num As Integer = 1

        For index = 1 To 1
            dr = dt.NewRow()
            dr.Item("前月残量") = (num + 1 + index).ToString("#.00")
            dr.Item("入庫量") = (num + 2 + index).ToString("#.00")
            dr.Item("売上量") = (num + 3 + index).ToString("#.00")
            dr.Item("その他出庫量") = (num + 4 + index).ToString("#.00")
            dr.Item("在庫量") = (num + 5 + index).ToString("#.00")
            dr.Item("引当可能残量") = (num + 6 + index).ToString("#.00")
            dt.Rows.Add(dr)
        Next

        gridDataList.DataSource = dt
        gridDataList.Columns("前月残量").HeaderText = "Last month remaining" & vbCrLf & "(前月残量)"
        gridDataList.Columns("前月残量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.Columns("入庫量").HeaderText = "Amount received" & vbCrLf & "(入庫量)"
        gridDataList.Columns("入庫量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.Columns("売上量").HeaderText = "Sales volume" & vbCrLf & "(売上量)"
        gridDataList.Columns("売上量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.Columns("その他出庫量").HeaderText = "Other issues" & vbCrLf & "(その他出庫量)"
        gridDataList.Columns("その他出庫量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.Columns("在庫量").HeaderText = "Stock quantity" & vbCrLf & "(在庫量)"
        gridDataList.Columns("在庫量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.Columns("引当可能残量").HeaderText = "Allowable balance" & vbCrLf & "(引当可能残量)"
        gridDataList.Columns("引当可能残量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDataList.AutoResizeColumns()

        gridDataList.Columns(0).Width = 140
        gridDataList.Columns(1).Width = 120
        gridDataList.Columns(2).Width = 100
        gridDataList.Columns(3).Width = 100
        gridDataList.Columns(4).Width = 100
        gridDataList.Columns(5).Width = 120
    End Sub

    Private Sub Patten3()

        Dim dt As New DataTable

        dt.Columns.Add("入出庫日")
        dt.Columns.Add("処理日")
        dt.Columns.Add("作番")
        dt.Columns.Add("入庫量")
        dt.Columns.Add("出庫量")
        dt.Columns.Add("その他払出")

        Dim dr As DataRow
        Dim num As Integer = 1

        For index = 1 To 8
            dr = dt.NewRow()
            dr.Item("入出庫日") = Now.AddDays(index).ToString("yyyy/MM/dd")
            dr.Item("処理日") = Now.AddDays(index)
            dr.Item("作番") = "E0D610" & index
            dr.Item("入庫量") = num.ToString("#.00")
            dr.Item("出庫量") = num.ToString("#.00")
            dr.Item("その他払出") = num.ToString("#.00")
            dt.Rows.Add(dr)
        Next

        gridData.DataSource = dt
        gridData.Columns("入出庫日").HeaderText = "Entry / exit date" & vbCrLf & "(入出庫日)"
        gridData.Columns("入出庫日").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns("処理日").HeaderText = "Processing date" & vbCrLf & "(処理日)"
        gridData.Columns("処理日").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns("作番").HeaderText = "Production number" & vbCrLf & "(作番)"
        gridData.Columns("作番").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.Columns("入庫量").HeaderText = "Amount received" & vbCrLf & "(入庫量)"
        gridData.Columns("入庫量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns("出庫量").HeaderText = "Issued quantity" & vbCrLf & "(出庫量)"
        gridData.Columns("出庫量").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.Columns("その他払出").HeaderText = "Other payout" & vbCrLf & "(その他払出)"
        gridData.Columns("その他払出").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridData.AutoResizeColumns()

        gridData.Columns(0).Width = 170
        gridData.Columns(1).Width = 170
        gridData.Columns(2).Width = 170
        gridData.Columns(3).Width = 170
        gridData.Columns(4).Width = 170
        gridData.Columns(5).Width = 170
    End Sub

    ''' <summary>
    ''' 　チェックボックス事件
    ''' </summary>
    Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

    End Sub

    ''' <summary>
    ''' 　昇順ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click


    End Sub

    ''' <summary>
    ''' 　降順ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class
