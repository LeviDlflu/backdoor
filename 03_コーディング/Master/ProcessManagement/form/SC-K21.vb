Imports PUCCommon
Imports System.Text
Imports System.Reflection
Public Class SC_K21

    Dim headerName As Hashtable = New Hashtable From {
                             {"選択", "Select" & vbCrLf & "(選択)"},
                             {"払出年月日", "Issues date" & vbCrLf & "(払出年月日)"},
                             {"工程コード", "Process code" & vbCrLf & "(工程コード)"},
                             {"工程略称", "Process abbreviation" & vbCrLf & "(工程略称)"},
                             {"個体NO", "Individual NO" & vbCrLf & "(個体NO)"},
                             {"品名略称", "Product abbreviation" & vbCrLf & "(品名略称)"},
                             {"払出数量", "Issues quantity" & vbCrLf & "(払出数量)"},
                             {"備考", "Remarks" & vbCrLf & "(備考)"},
                             {"品名コード", "Product code" & vbCrLf & "(品名コード)"}
                            }

    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_ISSUES_DATE As String = "払出年月日"
    Private Const ISSUES_DIVISION As String = "払出区分"
    Private Const COL_PROCESS_CODE As String = "工程コード"
    Private Const COL_PROCESS_ABBREVIATION As String = "工程略称"
    Private Const COL_LOT_NO As String = "個体NO"
    Private Const COL_PRODUCT_NAME_ABBREVIATION As String = "品名略称"
    Private Const COL_ISSUES_QUANTITY As String = "払出数量"
    Private Const COL_REMARKS As String = "備考"
    Private Const COL_PRODUCT_CODE As String = "品名コード"
    Private Const PRODUCT_NAME_PLANT_CODE As String = "品名事業所コード"
    Private Const PACK_PRODUCT_NAME_ABBREVIATION As String = "パック品名略称"
    Private Const DELIVERY_DIVISION As String = "納入区分"
    Private Const DELIVERY_DIVISION_CODE As String = "納入先コード"
    Private Const SEMI_FINISHED_PRODUCT_DIVISION As String = "製品半製品区分"
    Private Const TRANSFER_DIVISION As String = "振替区分"
    Dim i As Integer = 0
    Private map As New Hashtable
    Dim xml As New clsGetSqlXML("SC-K21.xml", "SC-K21")

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SC_K21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim dt1 As New DataTable

        init()

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                '払出区分
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt1 = clsSQLServer.GetDataTable(strSelect)
                Me.cmb_Syasyu.DataSource = dt1
                Me.cmb_Syasyu.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmb_Syasyu.DisplayMember = dt1.Columns.Item(1).ColumnName
                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strSelect As String
        Dim dt As New DataTable

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            Return
        End If

        Try

            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                strSelect = xml.GetSQL_Str("SELECT_002")
                dt = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                       businessCode,
                                                                       Format(Target_date.Value, "yyyy-MM"),
                                                                       cmb_Syasyu.SelectedValue))

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
        Label67.Text = Format(Now, "yyyy/MM/dd HH:mm")
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Total_by_process_Click(sender As Object, e As EventArgs) Handles Total_by_process.Click
        Dim frm As New SC_K21A()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Aggregation_product_name_Click(sender As Object, e As EventArgs) Handles Aggregation_product_name.Click
        Dim frm As New SC_K21B()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Process_type_summary_Click(sender As Object, e As EventArgs) Handles Process_type_summary.Click
        Dim frm As New SC_K21C()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim insertsql As String
        Dim updatesql As String
        Dim insertCount As Integer
        Dim updateCount As Integer
        insertsql = xml.GetSQL_Str("INSERT_001")
        updatesql = xml.GetSQL_Str("UPDATE_001")

        If MsgBox(String.Format(clsGlobal.MSG2("I028")),
                 vbOKCancel + vbQuestion,
                 systemName) = DialogResult.OK Then
            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    clsSQLServer.BeginTransaction()

                    For Each row As DataGridViewRow In gridData.Rows
                        If row.Cells("sentaku").Value = True Then
                            insertCount = clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                                                  businessCode,
                                                                                  row.Cells(COL_LOT_NO).Value,
                                                                                  row.Cells(COL_PRODUCT_CODE).Value,
                                                                                  row.Cells(PRODUCT_NAME_PLANT_CODE).Value,
                                                                                  row.Cells(PACK_PRODUCT_NAME_ABBREVIATION).Value,
                                                                                  row.Cells(DELIVERY_DIVISION_CODE).Value,
                                                                                  row.Cells(DELIVERY_DIVISION).Value,
                                                                                  row.Cells(SEMI_FINISHED_PRODUCT_DIVISION).Value,
                                                                                  row.Cells(COL_PROCESS_CODE).Value,
                                                                                  row.Cells(COL_ISSUES_DATE).Value,
                                                                                  "A",
                                                                                  row.Cells(ISSUES_DIVISION).Value,
                                                                                  row.Cells(TRANSFER_DIVISION).Value,
                                                                                  row.Cells(COL_REMARKS).Value
                                                                                  ))
                            If insertCount = 0 Then
                                MessageBox.Show(clsGlobal.MSG2("W0014"))
                                Return
                            End If

                            updateCount = clsSQLServer.ExecuteQuery(String.Format(updatesql,
                                                                                  businessCode，
                                                                                  row.Cells(PRODUCT_NAME_PLANT_CODE).Value，
                                                                                  row.Cells(PACK_PRODUCT_NAME_ABBREVIATION).Value,
                                                                                  row.Cells(DELIVERY_DIVISION_CODE).Value,
                                                                                  row.Cells(DELIVERY_DIVISION).Value,
                                                                                  row.Cells(SEMI_FINISHED_PRODUCT_DIVISION).Value,
                                                                                  row.Cells(COL_ISSUES_QUANTITY).Value
                                                                                  ))

                            If updateCount = 0 Then
                                MessageBox.Show(clsGlobal.MSG2("W0015"))
                                Return
                            End If
                            clsSQLServer.Commit()
                        End If
                    Next
                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
                clsSQLServer.Rollback()
                Throw
            End Try
            MessageBox.Show(clsGlobal.MSG2("I029"))

        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ASC_Click(sender As Object, e As EventArgs) Handles ASC.Click
        Dim sortsql As String = String.Empty
        If map.Count = 0 Then
            Return
        End If

        For Each de As DictionaryEntry In map
            sortsql = de.Value & " ASC," & sortsql
        Next de
        Dim dtable As DataTable = gridData.DataSource
        Dim dv As DataView = dtable.DefaultView
        dv.Sort = sortsql.Remove(sortsql.Length - 1, 1)
        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub DESC_Click(sender As Object, e As EventArgs) Handles DESC.Click
        Dim sortsql As String = String.Empty
        If map.Count = 0 Then
            Return
        End If

        For Each de As DictionaryEntry In map
            sortsql = de.Value & " DESC," & sortsql
        Next de
        Dim dtable As DataTable = gridData.DataSource
        Dim dv As DataView = dtable.DefaultView
        dv.Sort = sortsql.Remove(sortsql.Length - 1, 1)
        Dim dt As New DataTable
        dt = dv.ToTable
        gridData.DataSource = dt
        gridData.Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If gridData.Rows.Count > 0 Then
            Dim xmlHeader As New clsGetSqlXML("ExportHeaderToExcel.xml", "SC-K21")

            Dim strNodeList As ArrayList = xmlHeader.GetXmlNodeList("HEADER_001")

            Dim dgv As DataGridView = gridData

            Dim isOK = clsExcel.ExportToExcel(dgv, "その他払出入力伝票一覧", strNodeList)

            If isOK = True Then
                MessageBox.Show(Me, "エクスポート完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub init()
        Dim type As Type = gridData.GetType()
        Dim pi As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(gridData, True, Nothing)
    End Sub

    ''' <summary>
    ''' 検索条件必須チェック
    ''' </summary>
    Private Function isNecessarySearch() As Boolean

        '払出区分必須チェック
        If String.IsNullOrEmpty(cmb_Syasyu.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DIVISION))
            cmb_Syasyu.BackColor = Color.Red
            Return False
        Else
            cmb_Syasyu.BackColor = Color.Yellow
        End If

        Return True
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
        gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray

        For i As Integer = 0 To gridData.Columns.Count - 1
            gridData.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            '横位置
            Select Case gridData.Columns(i).Name
                Case "sentaku"
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select

            If i > 8 Then
                gridData.Columns(i).Visible = False
            End If

        Next

        gridData.AutoResizeColumns()

        For Each col As DataGridViewColumn In gridData.Columns
            Select Case col.Name
                Case "sentaku"
                    col.ReadOnly = False
                Case Else
                    col.ReadOnly = True
            End Select
        Next

        gridData.Columns(0).Width = 80
        gridData.Columns(1).Width = 200
        gridData.Columns(2).Width = 200
        gridData.Columns(3).Width = 260
        gridData.Columns(4).Width = 200
        gridData.Columns(5).Width = 200
        gridData.Columns(6).Width = 200
        gridData.Columns(7).Width = 200
        gridData.Columns(8).Width = 200


        '編集不可
        gridData.AllowUserToDeleteRows = False
        gridData.AllowUserToAddRows = False
        gridData.AllowUserToResizeRows = False

    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
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
    ''' 
    ''' </summary>
    Private Sub gridData_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridData.ColumnHeaderMouseClick
        If e.ColumnIndex > 0 Then
            If gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue Then
                map.Remove(e.ColumnIndex)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.LightGray
                i -= 1
            Else
                If i > 4 Then
                    Return
                End If
                map.Add(e.ColumnIndex, gridData.Columns.Item(e.ColumnIndex).Name)
                gridData.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.SkyBlue
                i += 1
            End If
        End If
    End Sub

End Class