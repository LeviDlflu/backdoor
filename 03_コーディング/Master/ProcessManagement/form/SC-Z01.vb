Public Class SC_Z01
    ''' <summary>
    ''' 列ヘッダーの行数
    ''' </summary>
    ''' <remarks></remarks>
    Private ColumnHeaderRowCount As Integer = 2

    ''' <summary>
    ''' 列ヘッダーの行の高さ
    ''' </summary>
    ''' <remarks></remarks>
    Private columnHeaderrRowHeight As Integer = 30
#Region "Structure"

    '''' <summary>
    '''' 列ヘッダーセル定義構造体
    '''' </summary>
    '''' <remarks></remarks>
    'Public Structure HeaderCell
    '    Public Row As Integer
    '    Public Column As Integer
    '    Public RowSpan As Integer
    '    Public ColumnSpan As Integer
    '    Public Text As String

    '    ''' <summary>
    '    ''' 列ヘッダーセル定義
    '    ''' </summary>
    '    ''' <param name="paramRow">行</param>
    '    ''' <param name="paramColumn">列</param>
    '    ''' <param name="paramRowSpan">結合する行数</param>
    '    ''' <param name="paramColumnSpan">結合する列数</param>
    '    ''' <param name="paramText">セルに関連付けられたテキスト</param>
    '    ''' <remarks></remarks>
    '    Sub New(ByVal paramRow As Integer, ByVal paramColumn As Integer, ByVal paramRowSpan As Integer, ByVal paramColumnSpan As Integer, ByVal paramText As String)
    '        ' TODO: Complete member initialization 
    '        Row = paramRow
    '        Column = paramColumn
    '        RowSpan = paramRowSpan
    '        ColumnSpan = paramColumnSpan
    '        Text = paramText
    '    End Sub

    'End Structure
#End Region

    '''' <summary>
    '''' 列ヘッダーセル定義
    '''' </summary>
    '''' <remarks></remarks>
    'Public HeaderCells As HeaderCell()

    ''' <summary>
    ''' 　画面一覧のヘッダ部初期化
    ''' </summary>
    Dim headerName As Hashtable = New Hashtable From {
                             {"詳細", "Details" & vbCrLf & "詳細"},
                             {"工程", "Process" & vbCrLf & "工程"},
                             {"品名略称", "Product name abbreviation" & vbCrLf & "品名略称"},
                             {"部品番号", "Part number" & vbCrLf & "部品番号"},
                             {"前月末残", "Fluctuation data section" & vbCrLf & "前月" & vbCrLf & "末残"},
                             {"当月累計", "Cumulative month" & vbCrLf & "当月累計"},
                             {"受入", "Acceptance" & vbCrLf & "受入"},
                             {"払出", "Withdrawaln" & vbCrLf & "払出"},
                             {"その他払出", "Other payout" & vbCrLf & "その他払出"},
                             {"当日", "On the day" & vbCrLf & "当日"},
                             {"在庫残", "Stock balance" & vbCrLf & "在庫残"}
                            }

    Private Const COL_DETAILS As String = "詳細"
    Private Const COL_PROCESS As String = "工程"
    Private Const COL_PRODUCT_NAME As String = "品名略称"
    Private Const COL_PART_NUMBER As String = "部品番号"
    Private Const COL_FLUCTUATION_DATA As String = "前月末残"
    Private Const COL_CUMULATIVE_MONTH As String = "当月累計"
    Private Const COL_ACCEPTANCE As String = "受入"
    Private Const COL_WITHDRAWALN As String = "払出"
    Private Const COL_OTHER As String = "その他払出"
    Private Const COL_CUMULATIVE_ACCEPTANCE As String = "当月累計_受入"
    Private Const COL_CUMULATIVE_WITHDRAWALN As String = "当月累計_払出"
    Private Const COL_CUMULATIVE_OTHER As String = "当月累計_その他払出"
    Private Const COL_DAY As String = "当日"
    Private Const COL_DAY_ACCEPTANCE As String = "当日_受入"
    Private Const COL_DAY_WITHDRAWALN As String = "当日_払出"
    Private Const COL_DAY_OTHER As String = "当日_その他払出"
    Private Const COL_STOCK_BALANCE As String = "在庫残"

    Dim PATTEN_1 As String() = {COL_PROCESS,
                                COL_PRODUCT_NAME,
                                COL_PART_NUMBER,
                                COL_FLUCTUATION_DATA,
                                COL_CUMULATIVE_ACCEPTANCE,
                                COL_CUMULATIVE_WITHDRAWALN,
                                COL_CUMULATIVE_OTHER,
                                COL_DAY_ACCEPTANCE,
                                COL_DAY_WITHDRAWALN,
                                COL_DAY_OTHER,
                                COL_STOCK_BALANCE}

    Dim dt As New DataTable

    'Dim xml As New CmnXML("SC-Z01.xml", "SC-Z01")


    ''' <summary>
    ''' 　画面初期化
    ''' </summary>
    Private Sub Init()

        setManagementNoType("")

        'xml.InitUser(Me.txtLoginUser, Me.TextBox1)


        'ちらつき防止
        'Dim myType As Type = GetType(DataGridView)
        'Dim myPropInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        'myPropInfo.SetValue(Me.gridData, True, Nothing)

        '列ヘッダーの高さの調整モード
        'Me.gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        ''列ヘッダーの高さを行数に合わせる
        'Me.gridData.ColumnHeadersHeight = columnHeaderrRowHeight * ColumnHeaderRowCount

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

    '''' <summary>
    '''' 　グリッドを設定する
    '''' </summary>
    '''' <param name="dtData">データソース</param>
    'Private Sub setGrid(ByRef dtData As DataTable)

    '    gridData.Columns.Clear()

    '    '選択
    '    Dim addColSentaku As New DataGridViewCheckBoxColumn()
    '    addColSentaku.DataPropertyName = headerName(COL_SENTAKU)
    '    addColSentaku.HeaderText = headerName(COL_SENTAKU)
    '    addColSentaku.Name = "sentaku"
    '    gridData.Columns.Add(addColSentaku)

    '    Dim addCol As New DataGridViewTextBoxColumn()

    '    For Each col As DataColumn In dtData.Columns
    '        addCol = New DataGridViewTextBoxColumn()
    '        addCol.DataPropertyName = col.ColumnName
    '        addCol.HeaderText = headerName(col.ColumnName)
    '        addCol.Name = col.ColumnName

    '        If col.ColumnName = COL_SNUMBER Then
    '            addCol.MaxInputLength = 10
    '        ElseIf col.ColumnName = COL_SSECTION Then
    '            addCol.MaxInputLength = 10
    '        ElseIf col.ColumnName = COL_SBIKOU Then
    '            addCol.MaxInputLength = 50
    '        End If

    '        gridData.Columns.Add(addCol)
    '    Next

    '    gridData.DataSource = dtData.Copy
    '    gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    For i As Integer = 0 To gridData.Columns.Count - 1
    '        gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

    '        '横位置
    '        Select Case gridData.Columns(i).Name
    '            Case COL_SFIXEDPART, COL_SBIKOU, COL_SSECTION
    '                gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '            Case COL_SNUMBER
    '                gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            Case Else
    '                gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        End Select
    '    Next
    '    gridData.AutoResizeColumns()

    '    For Each col As DataGridViewColumn In gridData.Columns
    '        Select Case col.Name
    '            Case "sentaku"
    '                col.ReadOnly = False
    '                col.DefaultCellStyle.BackColor = Color.LightSkyBlue
    '            Case Else
    '                col.ReadOnly = True
    '        End Select
    '    Next

    '    gridData.Columns(0).Width = 90
    '    gridData.Columns(1).Width = 180
    '    gridData.Columns(2).Width = 180
    '    gridData.Columns(3).Width = 180
    '    gridData.Columns(4).Width = 180
    '    gridData.Columns(5).Width = 200

    '    '複数選択不可
    '    gridData.MultiSelect = False
    '    '編集不可
    '    gridData.AllowUserToDeleteRows = False
    '    gridData.AllowUserToAddRows = False
    '    gridData.AllowUserToResizeRows = False
    'End Sub

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
    ''' 　画面Load
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub SC_M22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    ''' <summary>
    ''' 　検索ボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'Try

        '    If clsSQLServer.Connect(clsGlobal.ConnectString) Then

        '        Dim sqlstr As String
        '        Dim dt As New DataTable()

        '        If Me.cmbManagementNoType.Text.Equals(String.Empty) Then
        '            sqlstr = xml.GetSQL_Str("SELECT_002")
        '        Else
        '            sqlstr = xml.GetSQL_Str("SELECT_003")
        '            sqlstr = String.Format(sqlstr, cmbManagementNoType.Text)
        '        End If

        '        dt = clsSQLServer.GetDataTable(sqlstr)

        '        If dt.Rows.Count = 0 Then

        '            gridData.Columns.Clear()

        '            MsgBox(String.Format(clsGlobal.MSG2("W0008")),
        '                   vbExclamation,
        '                   My.Settings.systemName)

        '            clsSQLServer.Disconnect()

        '            Return

        '        End If


        '        sqlstr = xml.GetSQL_Str("SELECT_004")
        '        sqlstr = String.Format(sqlstr, cmbManagementNoType.Text)

        '        dt = clsSQLServer.GetDataTable(sqlstr)

        '        setGrid(dt)

        '        clsSQLServer.Disconnect()

        '    End If

        'Catch ex As Exception
        '    Throw
        'Finally
        '    clsSQLServer.Disconnect()
        'End Try
        gridData.Columns.Clear()
        Patten3()
    End Sub

#Region "二重タイトル表示用"

    '''' <summary>
    '''' コントロールを再描画する時
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub gridData_Paint(ByVal sender As System.Object,
    '                                ByVal e As System.Windows.Forms.PaintEventArgs) Handles gridData.Paint

    '    '列が無い場合
    '    If Me.gridData.ColumnCount = 0 Then
    '        Exit Sub
    '    End If

    '    '行が無い場合
    '    If Me.gridData.RowCount = 0 Then
    '        Exit Sub
    '    End If

    '    '列ヘッダーの行の高さの取得
    '    Dim rowHeight As Integer = Me.gridData.ColumnHeadersHeight / ColumnHeaderRowCount

    '    Dim lineWidth As Integer = 1

    '    '列ヘッダーを指定された行数にセル表示する
    '    For columuns = 0 To Me.gridData.ColumnCount - 1

    '        For rows = 0 To ColumnHeaderRowCount - 1

    '            '列ヘッダーの表示領域の取得
    '            Dim rect As Rectangle = Me.gridData.GetCellDisplayRectangle(columuns, -1, True)

    '            ''列ヘッダーの描画領域の底部の座標を保存
    '            Dim btm As Integer = rect.Bottom

    '            'セルの描画領域のY座標
    '            Select Case Me.gridData.BorderStyle
    '                Case Windows.Forms.BorderStyle.None
    '                    rect.Y = rowHeight * rows
    '                Case Windows.Forms.BorderStyle.FixedSingle
    '                    rect.Y = rowHeight * rows + lineWidth
    '                Case Windows.Forms.BorderStyle.Fixed3D
    '                    rect.Y = rowHeight * rows + (lineWidth * 2)
    '            End Select

    '            'セルの描画領域のX座標
    '            rect.X -= lineWidth

    '            'セルの描画領域の高さ
    '            rect.Height = rowHeight

    '            '最下行の場合高さを調整
    '            If rows = Me.ColumnHeaderRowCount - 1 Then
    '                rect.Height = btm - rect.Y - lineWidth
    '            End If

    '            Dim gridPen As New Pen(Me.gridData.GridColor)
    '            e.Graphics.DrawRectangle(gridPen, rect)

    '            'セルの背景色の領域
    '            rect.Y += lineWidth
    '            rect.X += lineWidth
    '            rect.Height -= lineWidth
    '            rect.Width -= lineWidth

    '            '背景色
    '            Dim backBrash As New SolidBrush(Me.gridData.BackColor)

    '            e.Graphics.FillRectangle(backBrash, rect)

    '            '見出しを最下列に表示
    '            If rows = Me.ColumnHeaderRowCount - 1 Then

    '                Dim text As String = Me.gridData.Columns(columuns).HeaderText
    '                Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

    '                TextRenderer.DrawText(e.Graphics, text, Me.gridData.ColumnHeadersDefaultCellStyle.Font,
    '                                      rect, Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor,
    '                                      formatFlg)
    '            End If

    '            'リソースの解放
    '            gridPen.Dispose()
    '            backBrash.Dispose()
    '        Next
    '    Next

    '    '列ヘッダーセル定義の処理
    '    For i = 0 To Me.HeaderCells.Count - 1

    '        'セルの結合の開始行がヘッダーの行数より大きい場合は除外
    '        If HeaderCells(i).Row > Me.ColumnHeaderRowCount - 1 Then
    '            Continue For
    '        End If

    '        'セルの結合の開始列の列インデックスが列数より大きい場合は除外
    '        If HeaderCells(i).Column > Me.gridData.ColumnCount - 1 Then
    '            Continue For
    '        End If

    '        '描画領域の設定
    '        Dim rect As Rectangle = Nothing

    '        '結合する列中のソート状態
    '        Dim sortText As String = String.Empty

    '        '結合するセルの幅の取得
    '        For j = Me.HeaderCells(i).Column To Me.HeaderCells(i).Column + Me.HeaderCells(i).ColumnSpan - 1

    '            If Me.gridData.Columns(j).Displayed = False Then
    '                Continue For
    '            End If

    '            If rect = Nothing Then
    '                rect = Me.gridData.GetCellDisplayRectangle(j, -1, True)
    '            Else
    '                rect.Width += Me.gridData.GetCellDisplayRectangle(j, -1, True).Width
    '            End If
    '        Next

    '        '結合するセルが画面中に無い場合
    '        If rect = Nothing Then
    '            Continue For
    '        End If

    '        '結合する行がヘッダー行数より大きい場合
    '        Dim rowSapn As Integer = Me.HeaderCells(i).RowSpan
    '        If rowSapn > ColumnHeaderRowCount Then
    '            rowSapn = ColumnHeaderRowCount
    '        End If

    '        '列ヘッダーの描画領域の底部の座標を保存
    '        Dim btm As Integer = rect.Bottom

    '        '結合するセルの描画領域のY座標
    '        Select Case Me.gridData.BorderStyle
    '            Case Windows.Forms.BorderStyle.None
    '                rect.Y = rowHeight * (Me.HeaderCells(i).Row)
    '            Case Windows.Forms.BorderStyle.FixedSingle
    '                rect.Y = rowHeight * (Me.HeaderCells(i).Row) + lineWidth
    '            Case Windows.Forms.BorderStyle.Fixed3D
    '                rect.Y = rowHeight * (Me.HeaderCells(i).Row) + (lineWidth * 2)
    '        End Select

    '        '結合するセルの描画領域のX座標
    '        rect.X -= lineWidth

    '        '結合するセルの描画領域の高さ
    '        rect.Height = rowHeight * rowSapn

    '        '最下行の場合は描画領域の高さを調整する
    '        If Me.HeaderCells(i).Row + rowSapn = Me.ColumnHeaderRowCount Then
    '            rect.Height = btm - rect.Y - lineWidth
    '        End If

    '        'グッリドの線
    '        Dim gridPen As New Pen(Me.gridData.GridColor)

    '        '背景色の取得
    '        Dim backgroundColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.BackColor

    '        '背景色
    '        Dim backBrash As New SolidBrush(backgroundColor)

    '        'くぼみ線
    '        Dim whiteBrash As New SolidBrush(Color.White)

    '        '枠線の描画
    '        e.Graphics.DrawRectangle(gridPen, rect)

    '        '結合セルの背景色の描画領域の設定
    '        rect.Y += lineWidth
    '        rect.X += lineWidth
    '        rect.Height -= lineWidth
    '        rect.Width -= lineWidth

    '        '背景色の描画
    '        e.Graphics.FillRectangle(backBrash, rect)

    '        'テキストの描画
    '        Dim foreColor As System.Drawing.Color = Me.gridData.ColumnHeadersDefaultCellStyle.ForeColor
    '        Dim formatFlg As TextFormatFlags = GetTextFormatFlags(Me.gridData.ColumnHeadersDefaultCellStyle.Alignment)

    '        TextRenderer.DrawText(e.Graphics, Me.HeaderCells(i).Text & sortText,
    '                              Me.gridData.ColumnHeadersDefaultCellStyle.Font,
    '                              rect, foreColor, formatFlg)
    '        'リソースの解放
    '        gridPen.Dispose()
    '        backBrash.Dispose()
    '        whiteBrash.Dispose()
    '    Next

    'End Sub

    '''' <summary>
    '''' 結合元のセルの文字位置から結合後の文字位置を取得する
    '''' </summary>
    '''' <param name="alignment">テキストの配置</param>
    '''' <remarks></remarks>
    'Private Function GetTextFormatFlags(ByVal alignment As DataGridViewContentAlignment) As TextFormatFlags
    '    Try
    '        ''文字の描画
    '        Dim formatFlg As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis

    '        '表示位置
    '        Select Case alignment
    '            Case DataGridViewContentAlignment.BottomCenter
    '                formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.BottomLeft
    '                formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.BottomRight
    '                formatFlg = TextFormatFlags.Bottom Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.MiddleCenter
    '                formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.MiddleLeft
    '                formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.MiddleRight
    '                formatFlg = TextFormatFlags.VerticalCenter Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.TopCenter
    '                formatFlg = TextFormatFlags.Top Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.TopLeft
    '                formatFlg = TextFormatFlags.Top Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
    '            Case DataGridViewContentAlignment.TopRight
    '                formatFlg = TextFormatFlags.Top Or TextFormatFlags.Right Or TextFormatFlags.EndEllipsis
    '        End Select

    '        Return formatFlg

    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    '''' <summary>
    '''' 列ヘッダーの描画領域の無効化
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub InvalidateUnitColumns()
    '    Try

    '        If Me.gridData.RowCount > 0 Then
    '            Dim hRect As Rectangle = Me.gridData.DisplayRectangle
    '            'hRect.Height = Me.gridData.ColumnHeadersHeight
    '            Me.gridData.Invalidate(hRect)
    '        End If

    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub

    '''' <summary>
    '''' 列の幅が変更された時
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub gridData_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles gridData.ColumnWidthChanged
    '    InvalidateUnitColumns()
    'End Sub

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
    ''' コントロールのサイズが変更された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridData.SizeChanged
        gridData.InvalidateUnitColumns()
    End Sub

    '''' <summary>
    '''' マウスのボタンが押された時
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub gridData_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles gridData.MouseDown

    '    Try
    '        ''列幅、行高を調整するドラグ線を見えるようにするためにダブルバッファを解除する
    '        'ちらつき防止
    '        Dim myType As Type = GetType(DataGridView)
    '        Dim myPropInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
    '        myPropInfo.SetValue(Me.gridData, False, Nothing)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub

    ''' <summary>
    ''' マウスのボタンが離された時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles gridData.MouseUp

        Try
            ''OnMouseDownイベントで解除されたダブルバッファを適用する
            Dim myType As Type = GetType(DataGridView)
            Dim myPropInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            myPropInfo.SetValue(Me.gridData, True, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub gridData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellContentClick

        If gridData.Columns(e.ColumnIndex).Name = "詳細" And e.RowIndex >= 0 Then
            Dim frm As New SC_Z01A()
            frm.ShowDialog()
            Me.Show()
        End If

    End Sub

#End Region

    Private Sub Patten3()

        dt = New DataTable

        For i As Integer = 0 To PATTEN_1.Length - 1
            dt.Columns.Add(New DataColumn(PATTEN_1(i), GetType(System.String)))
        Next

        Dim dr As DataRow
        Dim num As Integer = 1

        For index = 1 To 8
            dr = dt.NewRow()
            'dr.Item("詳細") = "詳細" & index
            dr.Item("工程") = "工程" & index
            dr.Item("品名略称") = "品名略称" & index
            dr.Item("部品番号") = "ABC610" & index

            dr.Item("前月末残") = (num + 3 + index).ToString("#.00")

            dr.Item("当月累計_受入") = (num + 3 + index).ToString("#.00")
            dr.Item("当月累計_払出") = (num + 3 + index).ToString("#.00")
            dr.Item("当月累計_その他払出") = (num + 3 + index).ToString("#.00")

            dr.Item("当日_受入") = (num + 3 + index).ToString("#.00")
            dr.Item("当日_払出") = (num + 3 + index).ToString("#.00")
            dr.Item("当日_その他払出") = (num + 3 + index).ToString("#.00")

            dr.Item("在庫残") = (num + 3 + index).ToString("#.00")
            dt.Rows.Add(dr)
        Next

        Dim btn As New DataGridViewButtonColumn()
        btn.Name = COL_DETAILS
        btn.HeaderText = headerName(COL_DETAILS)
        btn.DefaultCellStyle.NullValue = COL_DETAILS
        gridData.Columns.Add(btn)

        For Each col As DataColumn In dt.Columns

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

        gridData.DataSource = dt.Copy
        gridData.ColumnHeadersHeight = 70
        gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        gridData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridData.AddSpanHeader(5, 3, headerName(COL_CUMULATIVE_MONTH))
        gridData.AddSpanHeader(8, 3, headerName(COL_DAY))

        gridData.Columns(COL_CUMULATIVE_ACCEPTANCE).HeaderText = headerName(COL_ACCEPTANCE)
        gridData.Columns(COL_CUMULATIVE_WITHDRAWALN).HeaderText = headerName(COL_WITHDRAWALN)
        gridData.Columns(COL_CUMULATIVE_OTHER).HeaderText = headerName(COL_OTHER)
        gridData.Columns(COL_DAY_ACCEPTANCE).HeaderText = headerName(COL_ACCEPTANCE)
        gridData.Columns(COL_DAY_WITHDRAWALN).HeaderText = headerName(COL_WITHDRAWALN)
        gridData.Columns(COL_DAY_OTHER).HeaderText = headerName(COL_OTHER)


        'HeaderCells = {
        '    New HeaderCell(0, 0, 2, 1, "Details" & vbCrLf & "(詳細)"),
        '    New HeaderCell(0, 1, 2, 1, "Process" & vbCrLf & "(工程)"),
        '    New HeaderCell(0, 2, 2, 1, "Product name abbreviation" & vbCrLf & "(品名略称)"),
        '    New HeaderCell(0, 3, 2, 1, "Part number" & vbCrLf & "(部品番号)"),
        '    New HeaderCell(0, 4, 2, 1, "Last month" & vbCrLf & "balance" & vbCrLf & "(前月" & vbCrLf & "末残)"),
        '    New HeaderCell(0, 5, 1, 3, "Cumulative month" & vbCrLf & "(当月累計)"),
        '    New HeaderCell(0, 8, 1, 3, "On the day" & vbCrLf & "(当日)"),
        '    New HeaderCell(0, 11, 2, 1, "Stock balance" & vbCrLf & "(在庫残)")}


        'Dim btn As New DataGridViewButtonColumn()
        'btn.Name = "詳細"
        'btn.HeaderText = "来歴"
        'btn.DefaultCellStyle.NullValue = "来歴"
        'gridData.Columns.Add(btn)

        ''dt.Columns.Add("詳細")
        'dt.Columns.Add("工程")
        'dt.Columns.Add("品名略称")
        'dt.Columns.Add("部品番号")
        'dt.Columns.Add("前月末残")
        'dt.Columns.Add("当月累計_受入")
        'dt.Columns.Add("当月累計_払出")
        'dt.Columns.Add("当月累計_その他払出")
        'dt.Columns.Add("当日_受入")
        'dt.Columns.Add("当日_払出")
        'dt.Columns.Add("当日_その他払出")
        'dt.Columns.Add("在庫残")

        'Dim dr As DataRow
        'Dim num As Integer = 1

        'For index = 1 To 8
        '    dr = dt.NewRow()
        '    'dr.Item("詳細") = "詳細" & index
        '    dr.Item("工程") = "工程" & index
        '    dr.Item("品名略称") = "品名略称" & index
        '    dr.Item("部品番号") = "ABC610" & index

        '    dr.Item("前月末残") = (num + 3 + index).ToString("#.00")

        '    dr.Item("当月累計_受入") = (num + 3 + index).ToString("#.00")
        '    dr.Item("当月累計_払出") = (num + 3 + index).ToString("#.00")
        '    dr.Item("当月累計_その他払出") = (num + 3 + index).ToString("#.00")

        '    dr.Item("当日_受入") = (num + 3 + index).ToString("#.00")
        '    dr.Item("当日_払出") = (num + 3 + index).ToString("#.00")
        '    dr.Item("当日_その他払出") = (num + 3 + index).ToString("#.00")

        '    dr.Item("在庫残") = (num + 3 + index).ToString("#.00")
        '    dt.Rows.Add(dr)
        'Next

        'gridData.DataSource = dt
        'gridData.Columns("工程").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'gridData.Columns("品名略称").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'gridData.Columns("部品番号").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'gridData.Columns("前月末残").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'gridData.Columns("当月累計_受入").HeaderText = "Acceptance" & vbCrLf & "(受入)"
        'gridData.Columns("当月累計_受入").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridData.Columns("当月累計_払出").HeaderText = "Withdrawal" & vbCrLf & "(払出)"
        'gridData.Columns("当月累計_払出").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridData.Columns("当月累計_その他払出").HeaderText = "Other payout" & vbCrLf & "(その他払出)"
        'gridData.Columns("当月累計_その他払出").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'gridData.Columns("当日_受入").HeaderText = "Acceptance" & vbCrLf & "(受入)"
        'gridData.Columns("当日_受入").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridData.Columns("当日_払出").HeaderText = "Withdrawal" & vbCrLf & "(払出)"
        'gridData.Columns("当日_払出").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridData.Columns("当日_その他払出").HeaderText = "Other payout" & vbCrLf & "(その他払出)"
        'gridData.Columns("当日_その他払出").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'gridData.Columns("在庫残").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridData.AutoResizeColumns()

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 63
        gridData.Columns(2).Width = 180
        gridData.Columns(3).Width = 120
        gridData.Columns(4).Width = 120
        gridData.Columns(5).Width = 100
        gridData.Columns(6).Width = 100
        gridData.Columns(7).Width = 100
        gridData.Columns(8).Width = 100
        gridData.Columns(9).Width = 100
        gridData.Columns(10).Width = 100
        gridData.Columns(11).Width = 150
    End Sub

    '''' <summary>
    '''' 　チェックボックス事件
    '''' </summary>
    'Private Sub gridData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles gridData.CurrentCellDirtyStateChanged

    '    If TypeOf gridData.CurrentCell Is DataGridViewCheckBoxCell Then
    '        gridData.EndEdit()
    '        Dim Checked As Boolean = CType(gridData.CurrentCell.Value, Boolean)
    '        If Checked Then

    '            For i As Integer = 3 To 5
    '                gridData.CurrentRow.Cells(i).Style.BackColor = Color.Yellow

    '                gridData.CurrentRow.Cells(i).ReadOnly = False
    '            Next
    '        Else

    '            For i As Integer = 3 To 5

    '                gridData.CurrentRow.Cells(i).Style.BackColor = Color.White

    '                gridData.CurrentRow.Cells(i).ReadOnly = True

    '            Next
    '        End If
    '    End If

    'End Sub

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

    ''' <summary>
    ''' 　Excelボタン押下
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">e</param>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        'Dim headers As clsExcel.HeaderCell()


        'headers = {
        '    New clsExcel.HeaderCell(1, 1, 2, 1, "工程"),
        '    New clsExcel.HeaderCell(1, 2, 2, 2, "品名略称"),
        '    New clsExcel.HeaderCell(1, 3, 2, 3, "部品番号"),
        '    New clsExcel.HeaderCell(1, 4, 2, 4, "前月末残"),
        '    New clsExcel.HeaderCell(1, 5, 1, 7, "当月累計"),
        '    New clsExcel.HeaderCell(2, 5, 2, 5, "受入"),
        '    New clsExcel.HeaderCell(2, 6, 2, 6, "払出"),
        '    New clsExcel.HeaderCell(2, 7, 2, 7, "その他払出"),
        '    New clsExcel.HeaderCell(1, 8, 1, 10, "当日"),
        '    New clsExcel.HeaderCell(2, 8, 2, 8, "受入"),
        '    New clsExcel.HeaderCell(2, 9, 2, 9, "払出"),
        '    New clsExcel.HeaderCell(2, 10, 2, 10, "その他払出"),
        '    New clsExcel.HeaderCell(1, 11, 2, 11, "在庫残")}

        'clsExcel.ExportExcel2(dt, headers, ColumnHeaderRowCount, "SC-Z01")
    End Sub
End Class
