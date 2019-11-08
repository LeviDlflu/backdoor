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
    Private Const FORM_NAME As String = "Other issues(その他出庫)"
    Dim xml As New clsGetSqlXML("SC-K20.xml", "SC-K20")
    Dim searchResult As New DataTable
    Dim DIVISION As String = "0"
    Dim errorMessage As clsMessage

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K20_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        init()

        Dim strSelect As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable

        'データベース接続
        If clsSQLServer.Connect(clsGlobal.ConnectString) Then
            '工程コード
            strSelect = xml.GetSQL_Str("SELECT_002")
            dt1 = clsSQLServer.GetDataTable(strSelect)
            Me.cmb_Syasyu.DataSource = dt1
            Me.cmb_Syasyu.ValueMember = dt1.Columns.Item(0).ColumnName
            Me.cmb_Syasyu.DisplayMember = dt1.Columns.Item(1).ColumnName

            '払出区分
            strSelect = xml.GetSQL_Str("SELECT_001")
            dt2 = clsSQLServer.GetDataTable(strSelect)
            Me.ComboBox2.DataSource = dt2
            Me.ComboBox2.ValueMember = dt2.Columns.Item(0).ColumnName
            Me.ComboBox2.DisplayMember = dt2.Columns.Item(1).ColumnName

            '振替区分
            strSelect = xml.GetSQL_Str("SELECT_004")
            dt3 = clsSQLServer.GetDataTable(strSelect)
            Me.ComboBox3.DataSource = dt3
            Me.ComboBox3.ValueMember = dt3.Columns.Item(0).ColumnName
            Me.ComboBox3.DisplayMember = dt3.Columns.Item(1).ColumnName
            clsSQLServer.Disconnect()
        End If

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim selectSql As String

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            Return
        End If

        selectSql = xml.GetSQL_Str("SELECT_003")

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then
                searchResult = clsSQLServer.GetDataTable(String.Format(selectSql,
                                                                       businessCode,
                                                                       DIVISION,
                                                                       txtNO.Text,
                                                                       cmb_Syasyu.SelectedValue))
                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

        If searchResult.Rows.Count = 0 Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            Return
        End If

        txtProName.Text = searchResult.Rows(0).Item(5)

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

        Dim insertsql As String
        Dim updatesql As String
        Dim insertCount As Integer
        Dim updateCount As Integer

        '検索条件必須チェック
        If Not isNecessarySearch() Then
            Return
        End If

        '登録項目必須チェック
        If Not isNecessaryInsert() Then
            Return
        End If

        Try
            If clsSQLServer.Connect(clsGlobal.ConnectString) Then

                insertsql = xml.GetSQL_Str("INSERT_001")
                insertCount = clsSQLServer.ExecuteQuery(String.Format(insertsql,
                                                                      businessCode,
                                                                      txtNO.Text,
                                                                      searchResult.Rows(0).Item(0)，
                                                                      searchResult.Rows(0).Item(1)，
                                                                      searchResult.Rows(0).Item(2)，
                                                                      searchResult.Rows(0).Item(3)，
                                                                      searchResult.Rows(0).Item(4)，
                                                                      DIVISION,
                                                                      cmb_Syasyu.SelectedValue,
                                                                      dateWithdrawalDate.Value,
                                                                      "8",
                                                                      ComboBox2.SelectedValue,
                                                                      ComboBox3.SelectedValue,
                                                                      txtRemarks.Text
                                                                      ))
                If insertCount = 0 Then
                    'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
                    Return
                End If

                updatesql = xml.GetSQL_Str("UPDATE_001")
                updateCount = clsSQLServer.ExecuteQuery(String.Format(updatesql,
                                                                      searchResult.Rows(0).Item(0)，
                                                                      searchResult.Rows(0).Item(1)，
                                                                      searchResult.Rows(0).Item(2)，
                                                                      searchResult.Rows(0).Item(3)，
                                                                      searchResult.Rows(0).Item(4)，
                                                                      DIVISION,
                                                                      cmb_Syasyu.SelectedValue,
                                                                      CInt（TextBox2.Text）
                                                                      ))
                If updateCount = 0 Then
                    'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
                    Return
                End If

                '正常に処理後、画面を初期表示に戻す。
                init()

                clsSQLServer.Disconnect()
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub init()

        RadioButton1.Checked = True
        RadioButton2.Checked = False
        cmb_Syasyu.SelectedIndex = -1
        cmb_Syasyu.BackColor = Color.Yellow
        txtNO.Text = String.Empty
        txtNO.BackColor = Color.Yellow
        txtProName.Text = String.Empty
        txtProName.BackColor = Color.White
        dateWithdrawalDate.Value = Now
        ComboBox2.SelectedIndex = -1
        ComboBox2.BackColor = Color.White
        ComboBox3.SelectedIndex = -1
        ComboBox3.BackColor = Color.White
        txtRemarks.Text = String.Empty
        txtRemarks.BackColor = Color.White

    End Sub

    ''' <summary>
    ''' 検索条件必須チェック
    ''' </summary>
    Private Function isNecessarySearch() As Boolean

        '工程コード必須チェック
        If String.IsNullOrEmpty(cmb_Syasyu.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), PROCESS_CODE))
            cmb_Syasyu.BackColor = Color.Red
            Return False
        Else
            cmb_Syasyu.BackColor = Color.Yellow
        End If

        '個体NO必須チェック
        If String.IsNullOrEmpty(txtNO.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), INDIVIDUAL_NO))
            txtNO.BackColor = Color.Red
            Return False
        Else
            txtNO.BackColor = Color.Yellow
        End If

        '個体NO桁数チェック
        If txtNO.Text.Length > 14 Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0030"), INDIVIDUAL_NO, "14"))
            txtNO.BackColor = Color.Red
            Return False
        Else
            txtNO.BackColor = Color.White
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
        If String.IsNullOrEmpty(dateWithdrawalDate.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DATE))
            dateWithdrawalDate.BackColor = Color.Red
            Return False
        Else
            dateWithdrawalDate.BackColor = Color.White
        End If

        '払出区分必須チェック
        If String.IsNullOrEmpty(ComboBox2.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_DIVISION))
            ComboBox2.BackColor = Color.Red
            Return False
        Else
            ComboBox2.BackColor = Color.White
        End If

        '払出数量必須チェック
        If String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), ISSUES_QUANTITY))
            TextBox2.BackColor = Color.Red
            Return False
        Else
            TextBox2.BackColor = Color.White
        End If

        '振替区分必須チェック
        If String.IsNullOrEmpty(ComboBox3.Text) Then
            MessageBox.Show(String.Format(clsGlobal.MSG2("W0001"), TRANSFER_DIVISION))
            ComboBox3.BackColor = Color.Red
            Return False
        Else
            ComboBox3.BackColor = Color.White
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
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Then
            DIVISION = "0"
        End If

    End Sub

    ''' <summary>
    ''' 製品
    ''' </summary>
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If RadioButton2.Checked = True Then
            DIVISION = "1"
        End If

    End Sub

End Class
