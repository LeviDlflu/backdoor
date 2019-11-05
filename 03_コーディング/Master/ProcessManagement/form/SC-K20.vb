Imports PUCCommon
Public Class SC_K20

    Private Const FORM_NAME As String = "Other issues(その他出庫)"
    Dim xml As New clsGetSqlXML("SC-K20.xml", "SC-K20")

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SC_K20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub init()

        RadioButton1.Checked = True
        RadioButton2.Checked = False
        cmb_Syasyu.SelectedIndex = -1
        txtNO.Text = String.Empty
        txtProName.Text = String.Empty
        dateWithdrawalDate.Value = Now
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        txtRemarks.Text = String.Empty

        Dim strSelect As String
        Dim dt1 As New DataTable

        'データベース接続
        If clsSQLServer.Connect(clsGlobal.ConnectString) Then
            '工程コード
            strSelect = xml.GetSQL_Str("SELECT_002")
            dt1 = clsSQLServer.GetDataTable(strSelect)
            Me.cmb_Syasyu.DataSource = dt1
            Me.cmb_Syasyu.ValueMember = dt1.Columns.Item(0).ColumnName
            Me.cmb_Syasyu.DisplayMember = dt1.Columns.Item(1).ColumnName
        End If

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

    End Sub

    ''' <summary>
    ''' 検索条件必須チェック
    ''' </summary>
    Private Function isNecessarySearch() As Boolean
        '工程コード
        If String.IsNullOrEmpty(cmb_Syasyu.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            cmb_Syasyu.BackColor = Color.Red
            Return False
        Else
            cmb_Syasyu.BackColor = Color.Yellow
        End If

        '個体NO
        If String.IsNullOrEmpty(txtNO.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            txtNO.BackColor = Color.Red
            Return False
        Else
            txtNO.BackColor = Color.Yellow
        End If

        Return True
    End Function

    ''' <summary>
    ''' 登録項目必須チェック
    ''' </summary>
    Private Function isNecessaryInsert() As Boolean
        '品名略称
        If String.IsNullOrEmpty(txtProName.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            txtProName.BackColor = Color.Red
            Return False
        Else
            txtProName.BackColor = Color.White
        End If

        '受払年月日
        If String.IsNullOrEmpty(dateWithdrawalDate.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            dateWithdrawalDate.BackColor = Color.Red
            Return False
        Else
            dateWithdrawalDate.BackColor = Color.White
        End If

        '受払区分
        If String.IsNullOrEmpty(ComboBox2.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            ComboBox2.BackColor = Color.Red
            Return False
        Else
            ComboBox2.BackColor = Color.White
        End If

        '受払数量
        If String.IsNullOrEmpty(TextBox2.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            TextBox2.BackColor = Color.Red
            Return False
        Else
            TextBox2.BackColor = Color.White
        End If

        '振替区分
        If String.IsNullOrEmpty(ComboBox3.Text) Then
            'MessageBox.Show(cmnUtil.GetMessageStr("W0001", ITEM_KOUTEI))
            ComboBox3.BackColor = Color.Red
            Return False
        Else
            ComboBox3.BackColor = Color.White
        End If
        Return True

    End Function

End Class
