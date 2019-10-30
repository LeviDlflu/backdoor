<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K21
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Finish = New System.Windows.Forms.Button()
        Me.Excel = New System.Windows.Forms.Button()
        Me.DESC = New System.Windows.Forms.Button()
        Me.ASC = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Process_type_summary = New System.Windows.Forms.Button()
        Me.Aggregation_product_name = New System.Windows.Forms.Button()
        Me.Total_by_process = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Withdrawal_category = New System.Windows.Forms.ComboBox()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GridCtrl = New System.Windows.Forms.DataGridView()
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SearchDateTime = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHeader.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Finish)
        Me.Panel1.Controls.Add(Me.Excel)
        Me.Panel1.Controls.Add(Me.DESC)
        Me.Panel1.Controls.Add(Me.ASC)
        Me.Panel1.Controls.Add(Me.Cancel)
        Me.Panel1.Controls.Add(Me.Process_type_summary)
        Me.Panel1.Controls.Add(Me.Aggregation_product_name)
        Me.Panel1.Controls.Add(Me.Total_by_process)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(5, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1340, 70)
        Me.Panel1.TabIndex = 3
        '
        'Finish
        '
        Me.Finish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Finish.BackColor = System.Drawing.SystemColors.Control
        Me.Finish.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Finish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Finish.Location = New System.Drawing.Point(1239, 5)
        Me.Finish.Margin = New System.Windows.Forms.Padding(4)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(95, 60)
        Me.Finish.TabIndex = 14
        Me.Finish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.Finish.UseVisualStyleBackColor = False
        '
        'Excel
        '
        Me.Excel.BackColor = System.Drawing.SystemColors.Control
        Me.Excel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Excel.Location = New System.Drawing.Point(1119, 6)
        Me.Excel.Margin = New System.Windows.Forms.Padding(4)
        Me.Excel.Name = "Excel"
        Me.Excel.Size = New System.Drawing.Size(95, 60)
        Me.Excel.TabIndex = 13
        Me.Excel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.Excel.UseVisualStyleBackColor = False
        '
        'DESC
        '
        Me.DESC.BackColor = System.Drawing.SystemColors.Control
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DESC.Location = New System.Drawing.Point(1025, 6)
        Me.DESC.Margin = New System.Windows.Forms.Padding(4)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(95, 60)
        Me.DESC.TabIndex = 12
        Me.DESC.Text = "DESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = False
        '
        'ASC
        '
        Me.ASC.BackColor = System.Drawing.SystemColors.Control
        Me.ASC.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ASC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ASC.Location = New System.Drawing.Point(931, 6)
        Me.ASC.Margin = New System.Windows.Forms.Padding(4)
        Me.ASC.Name = "ASC"
        Me.ASC.Size = New System.Drawing.Size(95, 60)
        Me.ASC.TabIndex = 10
        Me.ASC.Text = "ASC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ASC.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cancel.Location = New System.Drawing.Point(837, 6)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(95, 60)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(取 消)"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process_type_summary
        '
        Me.Process_type_summary.BackColor = System.Drawing.SystemColors.Control
        Me.Process_type_summary.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Process_type_summary.Location = New System.Drawing.Point(588, 6)
        Me.Process_type_summary.Margin = New System.Windows.Forms.Padding(4)
        Me.Process_type_summary.Name = "Process_type_summary"
        Me.Process_type_summary.Size = New System.Drawing.Size(250, 60)
        Me.Process_type_summary.TabIndex = 11
        Me.Process_type_summary.Text = "Process type summary" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程品種別集計)"
        Me.Process_type_summary.UseVisualStyleBackColor = False
        '
        'Aggregation_product_name
        '
        Me.Aggregation_product_name.BackColor = System.Drawing.SystemColors.Control
        Me.Aggregation_product_name.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Aggregation_product_name.Location = New System.Drawing.Point(280, 6)
        Me.Aggregation_product_name.Margin = New System.Windows.Forms.Padding(4)
        Me.Aggregation_product_name.Name = "Aggregation_product_name"
        Me.Aggregation_product_name.Size = New System.Drawing.Size(310, 60)
        Me.Aggregation_product_name.TabIndex = 10
        Me.Aggregation_product_name.Text = "Aggregation by product name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(品名別集計)"
        Me.Aggregation_product_name.UseVisualStyleBackColor = False
        '
        'Total_by_process
        '
        Me.Total_by_process.BackColor = System.Drawing.SystemColors.Control
        Me.Total_by_process.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Total_by_process.Location = New System.Drawing.Point(97, 6)
        Me.Total_by_process.Margin = New System.Windows.Forms.Padding(4)
        Me.Total_by_process.Name = "Total_by_process"
        Me.Total_by_process.Size = New System.Drawing.Size(185, 60)
        Me.Total_by_process.TabIndex = 10
        Me.Total_by_process.Text = "Total by process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程別集計)"
        Me.Total_by_process.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(4, 6)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 60)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検  索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Withdrawal_category)
        Me.Panel2.Controls.Add(Me.Target_date)
        Me.Panel2.Location = New System.Drawing.Point(-1, 140)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1351, 138)
        Me.Panel2.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(237, 80)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 15)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "(受払区分)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(236, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(201, 24)
        Me.Label10.TabIndex = 276
        Me.Label10.Text = "Payment division "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 80)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "(対象年月)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(26, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 24)
        Me.Label7.TabIndex = 272
        Me.Label7.Text = "Target date "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 32)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 15)
        Me.Label9.TabIndex = 265
        Me.Label9.Text = "(検索結果)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.MinimumSize = New System.Drawing.Size(223, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 24)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Search results" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Withdrawal_category
        '
        Me.Withdrawal_category.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Withdrawal_category.FormattingEnabled = True
        Me.Withdrawal_category.Location = New System.Drawing.Point(240, 103)
        Me.Withdrawal_category.Name = "Withdrawal_category"
        Me.Withdrawal_category.Size = New System.Drawing.Size(168, 26)
        Me.Withdrawal_category.TabIndex = 3
        '
        'Target_date
        '
        Me.Target_date.CalendarFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(30, 103)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(166, 26)
        Me.Target_date.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GridCtrl
        '
        Me.GridCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCtrl.Location = New System.Drawing.Point(3, 52)
        Me.GridCtrl.Name = "GridCtrl"
        Me.GridCtrl.RowTemplate.Height = 24
        Me.GridCtrl.Size = New System.Drawing.Size(1336, 316)
        Me.GridCtrl.TabIndex = 6
        '
        'grpHeader
        '
        Me.grpHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.grpHeader.Controls.Add(Me.Label3)
        Me.grpHeader.Controls.Add(Me.Label4)
        Me.grpHeader.Controls.Add(Me.Label5)
        Me.grpHeader.Controls.Add(Me.TextBox1)
        Me.grpHeader.Controls.Add(Me.txtLoginUser)
        Me.grpHeader.Location = New System.Drawing.Point(-1, -4)
        Me.grpHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Padding = New System.Windows.Forms.Padding(4)
        Me.grpHeader.Size = New System.Drawing.Size(1351, 72)
        Me.grpHeader.TabIndex = 83
        Me.grpHeader.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(4, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(761, 43)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ohter issues refer・Cancel（その他出庫参照・取消）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(895, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(292, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Connection environment(接続環境)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(898, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Login user(ログイン者)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1186, 39)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(159, 22)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "本番環境"
        '
        'txtLoginUser
        '
        Me.txtLoginUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoginUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtLoginUser.Location = New System.Drawing.Point(1186, 12)
        Me.txtLoginUser.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(159, 22)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.SearchDateTime)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.GridCtrl)
        Me.Panel3.Location = New System.Drawing.Point(1, 284)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1345, 371)
        Me.Panel3.TabIndex = 85
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(895, 34)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 269
        Me.Label6.Text = "(検索時間)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(894, 5)
        Me.Label13.MinimumSize = New System.Drawing.Size(150, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 24)
        Me.Label13.TabIndex = 268
        Me.Label13.Text = "Search time:"
        '
        'SearchDateTime
        '
        Me.SearchDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchDateTime.AutoSize = True
        Me.SearchDateTime.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchDateTime.Location = New System.Drawing.Point(1062, 9)
        Me.SearchDateTime.MinimumSize = New System.Drawing.Size(223, 20)
        Me.SearchDateTime.Name = "SearchDateTime"
        Me.SearchDateTime.Size = New System.Drawing.Size(223, 20)
        Me.SearchDateTime.TabIndex = 267
        Me.SearchDateTime.Text = "yyyy/MM/dd hh:mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "(検索結果)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(10, 5)
        Me.Label12.MinimumSize = New System.Drawing.Size(223, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(223, 24)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Search results" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 658)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1351, 25)
        Me.StatusStrip1.TabIndex = 86
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BottomDate.Size = New System.Drawing.Size(152, 20)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        Me.BottomDate.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'SC_K21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 681)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SC_K21"
        Me.Text = "Ohter issues refer・Cancel（その他出庫参照・取消）"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents Withdrawal_category As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GridCtrl As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents Total_by_process As Button
    Friend WithEvents Process_type_summary As Button
    Friend WithEvents Aggregation_product_name As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents DESC As Button
    Friend WithEvents ASC As Button
    Friend WithEvents Excel As Button
    Friend WithEvents Finish As Button
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents SearchDateTime As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BottomDate As ToolStripStatusLabel
End Class
