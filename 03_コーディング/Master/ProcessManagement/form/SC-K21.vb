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

    Private Const TARGET_DATE As String = "対象年月"
    Private Const ISSUES_DIVISION As String = "払出区分"
    Private Const COL_SENTAKU As String = "選択"
    Private Const COL_ISSUES_DATE As String = "払出年月日"
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
    Private Const PLANT_CODE As String = "C"
    Private Const SCID As String = "K-21"
    Private Const LOGINID As String = "管理員"
    Dim i As Integer = 0
    Private map As New Hashtable
    Dim xml As New clsGetSqlXML("SC-K21.xml", "SC-K21")

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SC_K21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        init()

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '対象年月
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt1 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbDate.DataSource = dt1
                Me.cmbDate.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmbDate.DisplayMember = dt1.Columns.Item(0).ColumnName

                '払出区分
                strSelect = xml.GetSQL_Str("SELECT_002")
                dt2 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbDivision.DataSource = dt2
                Me.cmbDivision.ValueMember = dt2.Columns.Item(0).ColumnName
                Me.cmbDivision.DisplayMember = dt2.Columns.Item(1).ColumnName
                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        btnSearch.Enabled = False

        Dim strSelect As String
        Dim dt As New DataTable

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            btnSearch.Enabled = True
            Return
        End If

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                strSelect = xml.GetSQL_Str("SELECT_003")

                dt = clsSQLServer.GetDataTable(String.Format(strSelect,
                                                                       businessCode,
                                                                       cmbDate.SelectedValue,
                                                                       cmbDivision.SelectedValue))

                clsSQLServer.Disconnect()

            End If
        Catch ex As Exception
        End Try

        If dt.Rows.Count = 0 Then
            MessageBox.Show(clsGlobal.MSG2("W0008"))
            gridData.Columns.Clear()
            Setdiable()
            btnSearch.Enabled = True
            Return
        End If

        setGrid(dt)
        lblSearchTime.Text = Format(Now, "yyyy/MM/dd HH:mm")

        Canceldiable()
        btnSearch.Enabled = True
    End Sub
    ''' <summary>
    ''' 工程別集計
    ''' </summary>
    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        ''パラメータ.対象年月
        'formParameter.TargetDate = Me.cmbDate.Text

        ''パラメータ.払出区分
        'formParameter.Division = Me.cmbDivision.Text
        'formParameter.DiviCode = Me.cmbDivision.SelectedValue

        'Dim frm As New SC_K21A()
        'frm.ShowDialog()
        'Me.Show()
    End Sub

    ''' <summary>
    ''' 品名別集計
    ''' </summary>
    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click

        ''パラメータ.対象年月
        'formParameter.TargetDate = Me.cmbDate.Text

        ''パラメータ.払出区分
        'formParameter.Division = Me.cmbDivision.Text
        'formParameter.DiviCode = Me.cmbDivision.SelectedValue

        'Dim frm As New SC_K21B()
        'frm.ShowDialog()
        'Me.Show()
    End Sub

    ''' <summary>
    ''' 工程品種別集計
    ''' </summary>
    Private Sub btnProcessvariety_Click(sender As Object, e As EventArgs) Handles btnProcessvariety.Click

        ''パラメータ.対象年月
        'formParameter.TargetDate = Me.cmbDate.Text

        ''パラメータ.払出区分
        'formParameter.Division = Me.cmbDivision.Text
        'formParameter.DiviCode = Me.cmbDivision.SelectedValue

        'Dim frm As New SC_K21C()
        'frm.ShowDialog()
        'Me.Show()
    End Sub

    ''' <summary>
    ''' 取消
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        btnCancel.Enabled = False

        Dim insertsql As String
        Dim updatesql As String
        Dim checkCount As Integer = 0
        Dim insertCount As Integer
        Dim updateCount As Integer
        insertsql = xml.GetSQL_Str("INSERT_001")
        updatesql = xml.GetSQL_Str("UPDATE_001")

        'レコードの選択有無チェック
        For Each row As DataGridViewRow In gridData.Rows
            If row.Cells("sentaku").Value = True Then
                checkCount = 1
                Exit For
            End If
        Next

        If checkCount = 0 Then
            '対象レコードを選択してください。
            MessageBox.Show(clsGlobal.MSG2("W9001"))
            btnCancel.Enabled = True
            Return
        End If

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
                                                                                  row.Cells(COL_REMARKS).Value,
                                                                                  SCID,
                                                                                  LOGINID,
                                                                                  Now
                                                                                  ))
                            If insertCount = 0 Then
                                '払出データの追加に失敗する場合、処理中止
                                clsSQLServer.Rollback()
                                MessageBox.Show(clsGlobal.MSG2("W0014"))
                                btnCancel.Enabled = True
                                Return
                            End If

                            updateCount = clsSQLServer.ExecuteQuery(String.Format(updatesql,
                                                                                  businessCode，
                                                                                  row.Cells(PRODUCT_NAME_PLANT_CODE).Value，
                                                                                  row.Cells(PACK_PRODUCT_NAME_ABBREVIATION).Value,
                                                                                  row.Cells(DELIVERY_DIVISION_CODE).Value,
                                                                                  row.Cells(DELIVERY_DIVISION).Value,
                                                                                  row.Cells(SEMI_FINISHED_PRODUCT_DIVISION).Value,
                                                                                  row.Cells(COL_ISSUES_QUANTITY).Value,
                                                                                  SCID,
                                                                                  LOGINID,
                                                                                  Now
                                                                                  ))

                            If updateCount = 0 Then
                                '在庫データの更新に失敗する場合、処理中止
                                clsSQLServer.Rollback()
                                MessageBox.Show(clsGlobal.MSG2("W0016"))
                                btnCancel.Enabled = True
                                Return
                            End If

                            '取消処理が正常に実行する。
                            clsSQLServer.Commit()
                        End If

                    Next
                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
                clsSQLServer.Rollback()
                Throw
            End Try
            MessageBox.Show(clsGlobal.MSG2("I030"))
            '正常に処理後、画面再検索
            btnSearch_Click(sender, e)
        End If
        btnCancel.Enabled = True
    End Sub

    ''' <summary>
    ''' 昇順
    ''' </summary>
    Private Sub btnAsc_Click(sender As Object, e As EventArgs) Handles btnAsc.Click
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
    ''' 降順
    ''' </summary>
    Private Sub btnDesc_Click(sender As Object, e As EventArgs) Handles btnDesc.Click
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
    ''' エクセル
    ''' </summary>
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        btnExcel.Enabled = False
        If gridData.Rows.Count > 0 Then
            Dim xmlHeader As New clsGetSqlXML("ExportHeaderToExcel.xml", "SC-K21")

            Dim strNodeList As ArrayList = xmlHeader.GetXmlNodeList("HEADER_001")

            Dim dgv As DataGridView = gridData

            Dim isOK = clsExcel.ExportToExcel(dgv, "その他払出入力伝票一覧", strNodeList)

            If isOK = True Then
                MessageBox.Show(Me, "エクスポート完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        btnExcel.Enabled = True
    End Sub

    ''' <summary>
    ''' 初期化
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

        '対象年月必須チェック
        If String.IsNullOrEmpty(cmbDate.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), TARGET_DATE))
            cmbDate.BackColor = Color.Red
            Return False
        Else
            cmbDate.BackColor = Color.Yellow
        End If

        '払出区分必須チェック
        If String.IsNullOrEmpty(cmbDivision.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DIVISION))
            cmbDivision.BackColor = Color.Red
            Return False
        Else
            cmbDivision.BackColor = Color.Yellow
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
                Case "sentaku", COL_ISSUES_DATE, COL_PROCESS_CODE
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case COL_ISSUES_QUANTITY
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    gridData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

        gridData.Columns(0).Width = 50
        gridData.Columns(1).Width = 95
        gridData.Columns(2).Width = 100
        gridData.Columns(3).Width = 180
        gridData.Columns(4).Width = 120
        gridData.Columns(5).Width = 270
        gridData.Columns(6).Width = 100
        gridData.Columns(7).Width = 365
        '品名コードを表示しない
        gridData.Columns(8).Visible = False

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

    '' <summary>
    '' 昇順や降順の項目を選択
    '' </summary>
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


    ''' <summary>
    ''' 対象年月
    ''' </summary>
    Private Sub cmbDate_TextChanged(sender As Object, e As EventArgs) Handles cmbDate.TextChanged
        Setdiable()
    End Sub

    Private Sub cmbDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDate.SelectedIndexChanged
        Setdiable()
    End Sub


    ''' <summary>
    ''' 払出区分
    ''' </summary>
    Private Sub cmbDivision_TextChanged(sender As Object, e As EventArgs) Handles cmbDivision.TextChanged
        Setdiable()
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivision.SelectedIndexChanged
        Setdiable()
    End Sub

    ''' <summary>
    ''' ボタン無効化
    ''' </summary>
    Sub Setdiable()
        btnProcess.Enabled = False
        btnProduct.Enabled = False
        btnProcessvariety.Enabled = False
        btnCancel.Enabled = False
        btnAsc.Enabled = False
        btnDesc.Enabled = False
        btnExcel.Enabled = False

    End Sub

    ''' <summary>
    ''' ボタン無効化解除
    ''' </summary>
    Sub Canceldiable()
        btnProcess.Enabled = True
        btnProduct.Enabled = True
        btnProcessvariety.Enabled = True
        btnCancel.Enabled = True
        btnAsc.Enabled = True
        btnDesc.Enabled = True
        btnExcel.Enabled = True
    End Sub

End Class