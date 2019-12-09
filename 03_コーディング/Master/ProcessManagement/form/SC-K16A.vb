Imports PUCCommon
Imports System.Text

Public Class SC_K16A
    Dim headerName As Hashtable = New Hashtable From {
                                {"個体NO", "Individual NO" & vbCrLf & "(個体NO)"},
                                {"判定日付・時間", "Judgment date・time" & vbCrLf & "(判定日付・時間)"},
                                {"数量", "Count" & vbCrLf & "(数量)"},
                                {"不良原因", "Failure reason" & vbCrLf & "(不良原因)"},
                                {"作業者", "Worker" & vbCrLf & "(作業者)"},
                                {"キャビ", "Caviar" & vbCrLf & "(キャビ)"}
                            }
    Private Const COL_INDIVIDUAL_NO As String = "個体NO"
    Private Const COL_JUDGMENT_DATE_TIME As String = "判定日付・時間"
    Private Const COL_COUNT As String = "数量"
    Private Const COL_FAILURE_REASON As String = "不良原因"
    Private Const COL_WORKER As String = "作業者"
    Private Const COL_KYABI As String = "キャビ"

    Private Const CONST_SYSTEM_NAME As String = "成形実績明細画面"
    Private Const FORM_NAME As String = "Molding achievement reference details(成形実績参照詳細)"

    Dim xml As New clsGetSqlXML("SC-K16A.xml", "SC-K16A")
    Private searchInfo As String

    '検索条件
    Public Property WhereInfo() As String
        Get
            Return searchInfo
        End Get
        Set(ByVal Value As String)
            searchInfo = Value
        End Set
    End Property

    '個体NO
    Public Property Individual() As String
        Get
            Return lblIndividual.Text
        End Get
        Set(ByVal Value As String)
            lblIndividual.Text = Value
        End Set
    End Property

    '設備
    Public Property Equipment() As String
        Get
            Return txtEquipment.Text
        End Get
        Set(ByVal Value As String)
            txtEquipment.Text = Value
        End Set
    End Property

    '品名
    Public Property Product() As String
        Get
            Return txtProductName.Text
        End Get
        Set(ByVal Value As String)
            txtProductName.Text = Value
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

    '検索開始日
    Public Property WorkingFrom() As String
        Get
            Return txtWorkingFrom.Text
        End Get
        Set(ByVal Value As String)
            txtWorkingFrom.Text = Value
        End Set
    End Property

    '検索終了日
    Public Property WorkingTo() As String
        Get
            Return txtWorkingTo.Text
        End Get
        Set(ByVal Value As String)
            txtWorkingTo.Text = Value
        End Set
    End Property

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K16A_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

        Me.lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")
        Me.btnFinish.Text = "Return" & vbCrLf & "(戻る)"

        Dim dt As New DataTable

        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        '判定
        dt.Rows.Add("6", "ショット")
        dt.Rows.Add("3", "合格")
        dt.Rows.Add("4", "不良")
        dt.Rows.Add("C", "調整")

        Me.cmbJudgment.DataSource = dt
        Me.cmbJudgment.ValueMember = dt.Columns.Item(0).ColumnName
        Me.cmbJudgment.DisplayMember = dt.Columns.Item(1).ColumnName

        'データを検索する
        Search(0)

    End Sub


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

        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            col.ReadOnly = True
            col.SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case col.Name
                Case COL_JUDGMENT_DATE_TIME
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case COL_COUNT
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select
        Next

        gridData.Columns(COL_INDIVIDUAL_NO).Width = 150
        gridData.Columns(COL_JUDGMENT_DATE_TIME).Width = 200
        gridData.Columns(COL_COUNT).Width = 120
        gridData.Columns(COL_FAILURE_REASON).Width = 450
        gridData.Columns(COL_WORKER).Width = 150
        gridData.Columns(COL_KYABI).Width = 140

        '判定より、表示項目の設定
        Select Case cmbJudgment.SelectedValue
            Case "6", "C"
                gridData.Columns(COL_FAILURE_REASON).Visible = False
                gridData.Columns(COL_KYABI).Visible = False
            Case "3"
                gridData.Columns(COL_FAILURE_REASON).Visible = False
        End Select

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
        'データを検索する
        Search(1)
    End Sub

    ''' <summary>
    ''' データを検索する
    ''' </summary>
    ''' <param name="intPartten">0:画面初期化 1:検索ボタン押下する</param>
    Private Sub Search(intPartten As Integer)

        Try

            Dim dt As New DataTable
            Dim strSelect As String
            Dim sqlFilter As New StringBuilder

            Me.lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                If String.IsNullOrEmpty(Individual) Then
                    '検索条件より再検索
                    strSelect = xml.GetSQL_Str("SELECT_001")
                    sqlFilter.Append(WhereInfo)
                Else
                    'ビュー
                    strSelect = xml.GetSQL_Str("SELECT_001")
                    sqlFilter.Append(String.Format(xml.GetSQL_Str("WHERE_001"), Individual))
                End If
                dt = clsSQLServer.GetDataTable(String.Format(strSelect, businessCode, cmbJudgment.SelectedValue, sqlFilter.ToString))

                If dt.Rows.Count = 0 Then

                    gridData.Columns.Clear()

                    If intPartten.Equals(1) Then
                        '検索ボタン押下する場合
                        MsgBox(String.Format(clsGlobal.MSG2("W0008")),
                               vbExclamation,
                               systemName)
                    End If

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
End Class
