Imports PUCCommon
Public Class SC_K20

    Private Const PROCESS_CODE As String = "工程コード"
    Private Const INDIVIDUAL_NO As String = "個体NO"
    Private Const PRODUCT_ABBREVIATION As String = "品名略称"
    Private Const ISSUES_DATE As String = "払出年月日"
    Private Const ISSUES_DIVISION As String = "払出区分"
    Private Const ISSUES_QUANTITY As String = "払出数量"
    Private Const TRANSFER_DIVISION As String = "振替区分"
    Private Const REMARKS As String = "備考"
    Private Const PLANT_CODE As String = "C"
    Private Const SCID As String = "K-20"
    Private Const LOGINID As String = "管理員"
    Dim xml As New clsGetSqlXML("SC-K20.xml", "SC-K20")
    Dim searchResult As New DataTable
    Dim dt5 As New DataTable

    Dim DIVISION As String = "1"
    Dim errorMessage As clsMessage

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K20_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSelect As String
        '工程コード
        Dim dt1 As New DataTable
        '払出区分
        Dim dt2 As New DataTable
        '振替区分
        Dim dt3 As New DataTable

        Try
            'データベース接続
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                '払出区分
                strSelect = xml.GetSQL_Str("SELECT_003")
                dt2 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbDivision.DataSource = dt2
                Me.cmbDivision.ValueMember = dt2.Columns.Item(0).ColumnName
                Me.cmbDivision.DisplayMember = dt2.Columns.Item(1).ColumnName

                '振替区分
                strSelect = xml.GetSQL_Str("SELECT_004")
                dt1 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbTransfer.DataSource = dt1
                Me.cmbTransfer.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmbTransfer.DisplayMember = dt1.Columns.Item(1).ColumnName

                '工程コード
                strSelect = xml.GetSQL_Str("SELECT_001")
                dt1 = clsSQLServer.GetDataTable(strSelect)
                Me.cmbProcess.DataSource = dt1
                Me.cmbProcess.ValueMember = dt1.Columns.Item(0).ColumnName
                Me.cmbProcess.DisplayMember = dt1.Columns.Item(1).ColumnName

                clsSQLServer.Disconnect()
            End If
        Catch ex As Exception
            Throw
        End Try

        '払出年月日
        Dim dt4 As New DataTable
        Dim dr As DataRow

        dt4.Columns.Add(New DataColumn(ISSUES_DATE, GetType(System.String)))

        '過去一週間の日付を取得する
        For index = 0 To 6
            dr = dt4.NewRow()
            dr.Item(ISSUES_DATE) = Format(Now().AddDays(-index), "yyyy/MM/dd")
            dt4.Rows.Add(dr)
        Next

        Me.cmbDate.DataSource = dt4
        Me.cmbDate.ValueMember = dt4.Columns.Item(0).ColumnName
        Me.cmbDate.DisplayMember = dt4.Columns.Item(0).ColumnName

        init()

    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        btnSearch.Enabled = False

        Dim selectSql As String

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            btnSearch.Enabled = True
            Return
        End If

        selectSql = xml.GetSQL_Str("SELECT_005")

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                searchResult = clsSQLServer.GetDataTable(String.Format(selectSql,
                                                                       businessCode,
                                                                       DIVISION,
                                                                       cmbIndividual.SelectedValue,
                                                                       cmbProcess.SelectedValue))
                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        If searchResult.Rows.Count = 0 Then
            MessageBox.Show(clsGlobal.MSG2("W0008"))
            btnSearch.Enabled = True
            Return
        End If

        '品名略称存在チェック
        If searchResult.Rows(0).Item(5) Is DBNull.Value Then
            MessageBox.Show(clsGlobal.MSG2("W0067"))
            txtProName.Text = String.Empty
            btnSearch.Enabled = True
            Return
        Else
            txtProName.Text = searchResult.Rows(0).Item(6)
        End If

        cmbIndividual.BackColor = Color.Yellow
        txtProName.BackColor = Color.White
        cmbDate.BackColor = Color.White
        cmbDivision.BackColor = Color.White
        txtQuantity.BackColor = Color.LightGray
        cmbTransfer.BackColor = Color.White
        txtRemarks.BackColor = Color.White

        btnSearch.Enabled = True

    End Sub

    ''' <summary>
    ''' クリア
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        init()
    End Sub

    ''' <summary>
    ''' 登録
    ''' </summary>
    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click

        btnRegistration.Enabled = False

        Dim insertsql As String
        Dim updatesql As String
        Dim insertCount As Integer
        Dim updateCount As Integer

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            btnRegistration.Enabled = True
            Return
        End If

        '登録項目必須チェック
        If Not isNecessaryInsert() Then
            btnRegistration.Enabled = True
            Return
        End If

        If MsgBox(String.Format(clsGlobal.MSG2("I028")),
                 vbOKCancel + vbQuestion,
                 systemName) = DialogResult.OK Then
            Try
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    clsSQLServer.BeginTransaction()
                    insertsql = xml.GetSQL_Str("INSERT_001")

                    insertCount = clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                                          businessCode,
                                                                          searchResult.Rows(0).Item(0)，
                                                                          cmbIndividual.SelectedValue,
                                                                          searchResult.Rows(0).Item(1)，
                                                                          searchResult.Rows(0).Item(2)，
                                                                          searchResult.Rows(0).Item(3)，
                                                                          searchResult.Rows(0).Item(4)，
                                                                          searchResult.Rows(0).Item(5)，
                                                                          DIVISION,
                                                                          cmbProcess.SelectedValue,
                                                                          cmbDate.SelectedValue,
                                                                          "8",
                                                                          cmbDivision.SelectedValue,
                                                                          cmbTransfer.SelectedValue,
                                                                          txtRemarks.Text,
                                                                          SCID,
                                                                          LOGINID,
                                                                          Now
                                                                          ))
                    If insertCount = 0 Then
                        '払出データの追加に失敗する場合、処理中止
                        clsSQLServer.Rollback()
                        clsSQLServer.Disconnect()
                        MessageBox.Show(clsGlobal.MSG2("W0015"))
                        clsSQLServer.Disconnect()
                        btnRegistration.Enabled = True
                        Return
                    End If

                    updatesql = xml.GetSQL_Str("UPDATE_001")

                    updateCount = clsSQLServer.ExecuteQuery(String.Format(updatesql,
                                                                          businessCode，
                                                                          searchResult.Rows(0).Item(2)，
                                                                          searchResult.Rows(0).Item(3)，
                                                                          searchResult.Rows(0).Item(4)，
                                                                          searchResult.Rows(0).Item(5)，
                                                                          DIVISION,
                                                                          CInt（txtQuantity.Text）,
                                                                          SCID,
                                                                          LOGINID,
                                                                          Now
                                                                          ))

                    If updateCount = 0 Then
                        '在庫データの更新に失敗する場合、処理中止
                        clsSQLServer.Rollback()
                        clsSQLServer.Disconnect()
                        MessageBox.Show(clsGlobal.MSG2("W0016"))
                        btnRegistration.Enabled = True
                        Return
                    End If

                    '払出処理が正常に実行する。
                    clsSQLServer.Commit()

                    '正常に処理後、画面を初期表示に戻す。
                    txtQuantity.BackColor = Color.LightGray
                    init()

                    clsSQLServer.Disconnect()
                End If

            Catch ex As Exception
                clsSQLServer.Rollback()
                Throw
            End Try
            MessageBox.Show(clsGlobal.MSG2("I029"))

        End If
        btnRegistration.Enabled = True
    End Sub

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub init()

        rdoSemi.Checked = False
        rdoFinish.Checked = True
        cmbProcess.SelectedIndex = -1
        cmbProcess.BackColor = Color.Yellow
        cmbIndividual.SelectedIndex = -1
        cmbIndividual.BackColor = Color.Yellow
        txtProName.Text = String.Empty
        txtProName.BackColor = Color.White
        cmbDate.SelectedIndex = 0
        cmbDate.BackColor = Color.White
        cmbDivision.SelectedIndex = -1
        cmbDivision.BackColor = Color.White
        cmbTransfer.SelectedIndex = -1
        cmbTransfer.BackColor = Color.White
        txtRemarks.Text = String.Empty
        txtRemarks.BackColor = Color.White

    End Sub

    ''' <summary>
    ''' 検索条件必須チェック
    ''' </summary>
    Private Function isNecessarySearch() As Boolean

        '工程コード必須チェック
        If String.IsNullOrEmpty(cmbProcess.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), PROCESS_CODE))
            cmbProcess.BackColor = Color.Red
            Return False
        Else
            cmbProcess.BackColor = Color.Yellow
        End If

        '個体NO必須チェック
        If String.IsNullOrEmpty(cmbIndividual.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), INDIVIDUAL_NO))
            cmbIndividual.BackColor = Color.Red
            Return False
        Else
            cmbIndividual.BackColor = Color.Yellow
        End If

        '個体NO桁数チェック
        If cmbIndividual.Text.Length > 14 Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0030"), INDIVIDUAL_NO, "14"))
            cmbIndividual.BackColor = Color.Red
            Return False
        Else
            cmbIndividual.BackColor = Color.Yellow
        End If

        Return True
    End Function

    ''' <summary>
    ''' 登録項目必須チェック
    ''' </summary>
    Private Function isNecessaryInsert() As Boolean

        '品名略称必須チェック
        If String.IsNullOrEmpty(txtProName.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), PRODUCT_ABBREVIATION))
            txtProName.BackColor = Color.Red
            Return False
        Else
            txtProName.BackColor = Color.White
        End If

        '払出年月日必須チェック
        If String.IsNullOrEmpty(cmbDate.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DATE))
            cmbDate.BackColor = Color.Red
            Return False
        Else
            cmbDate.BackColor = Color.White
        End If

        '払出区分必須チェック
        If String.IsNullOrEmpty(cmbDivision.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DIVISION))
            cmbDivision.BackColor = Color.Red
            Return False
        Else
            cmbDivision.BackColor = Color.White
        End If

        '払出数量必須チェック
        If String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_QUANTITY))
            txtQuantity.BackColor = Color.Red
            Return False
        Else
            txtQuantity.BackColor = Color.LightGray
        End If

        '振替区分必須チェック
        If String.IsNullOrEmpty(cmbTransfer.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), TRANSFER_DIVISION))
            cmbTransfer.BackColor = Color.Red
            Return False
        Else
            cmbTransfer.BackColor = Color.White
        End If

        '個体NO桁数チェック
        If txtRemarks.Text.Length > 100 Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0030"), REMARKS, "100"))
            txtRemarks.BackColor = Color.Red
            Return False
        Else
            txtRemarks.BackColor = Color.White
        End If

        Return True
    End Function

    ''' <summary>
    ''' 半製品
    ''' </summary>
    Private Sub rdoSemi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSemi.CheckedChanged

        If rdoSemi.Checked = True Then
            DIVISION = "0"
        End If
        Dim Selectsql As String
        If String.IsNullOrEmpty(cmbProcess.Text) Then
        Else
            Try
                'データベース接続
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    '個体NO
                    Selectsql = xml.GetSQL_Str("SELECT_002")
                    dt5 = clsSQLServer.GetDataTable(String.Format(Selectsql,
                                                                       DIVISION,
                                                                       cmbProcess.SelectedValue))
                    Me.cmbIndividual.DataSource = dt5
                    Me.cmbIndividual.ValueMember = dt5.Columns.Item(0).ColumnName
                    Me.cmbIndividual.DisplayMember = dt5.Columns.Item(0).ColumnName

                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
        txtProName.Text = String.Empty
    End Sub

    ''' <summary>
    ''' 製品
    ''' </summary>
    Private Sub rdoFinish_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFinish.CheckedChanged

        If rdoFinish.Checked = True Then
            DIVISION = "1"
        End If
        Dim Selectsql As String
        If String.IsNullOrEmpty(cmbProcess.Text) Then
        Else
            Try
                'データベース接続
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    '個体NO
                    Selectsql = xml.GetSQL_Str("SELECT_002")
                    dt5 = clsSQLServer.GetDataTable(String.Format(Selectsql,
                                                                       DIVISION,
                                                                       cmbProcess.SelectedValue))
                    Me.cmbIndividual.DataSource = dt5
                    Me.cmbIndividual.ValueMember = dt5.Columns.Item(0).ColumnName
                    Me.cmbIndividual.DisplayMember = dt5.Columns.Item(0).ColumnName

                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
                Throw
            End Try
        End If
        txtProName.Text = String.Empty
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub cmbProcess_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcess.SelectedIndexChanged
        Dim Selectsql As String

        If String.IsNullOrEmpty(cmbProcess.Text) Then
        Else
            Try
                'データベース接続
                If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                    '個体NO
                    Selectsql = xml.GetSQL_Str("SELECT_002")
                    dt5 = clsSQLServer.GetDataTable(String.Format(Selectsql,
                                                                       DIVISION,
                                                                       cmbProcess.SelectedValue))
                    Me.cmbIndividual.DataSource = dt5
                    Me.cmbIndividual.ValueMember = dt5.Columns.Item(0).ColumnName
                    Me.cmbIndividual.DisplayMember = dt5.Columns.Item(0).ColumnName

                    clsSQLServer.Disconnect()
                End If
            Catch ex As Exception
                Throw
            End Try
        End If

        txtProName.Text = String.Empty

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub cmbIndividual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIndividual.SelectedIndexChanged
        txtProName.Text = String.Empty
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub cmbIndividual_TextChanged(sender As Object, e As EventArgs) Handles cmbIndividual.TextChanged
        txtProName.Text = String.Empty
    End Sub

    '払出年月日手入力禁止
    Private Sub cmbDate_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDate.KeyDown
        If (e.KeyValue = Keys.C AndAlso e.Modifiers = Keys.Control AndAlso cmbDate.SelectedText.Length > 0) Then
            Clipboard.SetText(cmbDate.SelectedText)
        End If
    End Sub
    '払出年月日手入力禁止
    Private Sub cmbDate_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles cmbDate.KeyPress
        e.Handled = True
    End Sub

    '払出区分手入力禁止
    Private Sub cmbDivision_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDivision.KeyDown
        If (e.KeyValue = Keys.C AndAlso e.Modifiers = Keys.Control AndAlso cmbDivision.SelectedText.Length > 0) Then
            Clipboard.SetText(cmbDivision.SelectedText)
        End If
    End Sub
    '払出区分手入力禁止
    Private Sub cmbDivision_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles cmbDivision.KeyPress
        e.Handled = True
    End Sub

    '振替区分手入力禁止
    Private Sub cmbTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTransfer.KeyDown
        If (e.KeyValue = Keys.C AndAlso e.Modifiers = Keys.Control AndAlso cmbTransfer.SelectedText.Length > 0) Then
            Clipboard.SetText(cmbTransfer.SelectedText)
        End If
    End Sub
    '振替区分手入力禁止
    Private Sub cmbTransfer_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles cmbTransfer.KeyPress
        e.Handled = True
    End Sub

    '工程コード手入力禁止
    Private Sub cmbProcess_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProcess.KeyDown
        If (e.KeyValue = Keys.C AndAlso e.Modifiers = Keys.Control AndAlso cmbProcess.SelectedText.Length > 0) Then
            Clipboard.SetText(cmbProcess.SelectedText)
        End If
    End Sub
    '工程コード手入力禁止
    Private Sub cmbProcess_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles cmbProcess.KeyPress
        e.Handled = True
    End Sub

End Class
