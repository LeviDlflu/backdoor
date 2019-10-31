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
        Me.DESC = New System.Windows.Forms.Button()
        Me.ASC = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Process_type_summary = New System.Windows.Forms.Button()
        Me.Aggregation_product_name = New System.Windows.Forms.Button()
        Me.Total_by_process = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GridCtrl = New System.Windows.Forms.DataGridView()
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.lblHLine = New System.Windows.Forms.Label()
        Me.cmb_PaymentCD = New System.Windows.Forms.ComboBox()
        Me.SearchDateTime = New System.Windows.Forms.Label()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHeader.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DESC
        '
        Me.DESC.BackColor = System.Drawing.SystemColors.Control
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DESC.Location = New System.Drawing.Point(946, 9)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(100, 49)
        Me.DESC.TabIndex = 12
        Me.DESC.Text = "DESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = False
        '
        'ASC
        '
        Me.ASC.BackColor = System.Drawing.SystemColors.Control
        Me.ASC.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ASC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ASC.Location = New System.Drawing.Point(840, 10)
        Me.ASC.Name = "ASC"
        Me.ASC.Size = New System.Drawing.Size(100, 49)
        Me.ASC.TabIndex = 10
        Me.ASC.Text = "ASC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ASC.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cancel.Location = New System.Drawing.Point(734, 10)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(100, 49)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(取 消)"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process_type_summary
        '
        Me.Process_type_summary.BackColor = System.Drawing.SystemColors.Control
        Me.Process_type_summary.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Process_type_summary.Location = New System.Drawing.Point(483, 10)
        Me.Process_type_summary.Name = "Process_type_summary"
        Me.Process_type_summary.Size = New System.Drawing.Size(245, 49)
        Me.Process_type_summary.TabIndex = 11
        Me.Process_type_summary.Text = "Total by process variety (工程品種別集計)"
        Me.Process_type_summary.UseVisualStyleBackColor = False
        '
        'Aggregation_product_name
        '
        Me.Aggregation_product_name.BackColor = System.Drawing.SystemColors.Control
        Me.Aggregation_product_name.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Aggregation_product_name.Location = New System.Drawing.Point(298, 10)
        Me.Aggregation_product_name.Name = "Aggregation_product_name"
        Me.Aggregation_product_name.Size = New System.Drawing.Size(179, 49)
        Me.Aggregation_product_name.TabIndex = 10
        Me.Aggregation_product_name.Text = "Total by product" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(品名別集計)"
        Me.Aggregation_product_name.UseVisualStyleBackColor = False
        '
        'Total_by_process
        '
        Me.Total_by_process.BackColor = System.Drawing.SystemColors.Control
        Me.Total_by_process.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Total_by_process.Location = New System.Drawing.Point(113, 9)
        Me.Total_by_process.Name = "Total_by_process"
        Me.Total_by_process.Size = New System.Drawing.Size(179, 49)
        Me.Total_by_process.TabIndex = 10
        Me.Total_by_process.Text = "Total by process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程別集計)"
        Me.Total_by_process.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(7, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 49)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検  索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(272, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 11)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "(受払区分)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(271, 176)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 14)
        Me.Label10.TabIndex = 276
        Me.Label10.Text = "Payment division "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(20, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 11)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "(対象年月)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(19, 176)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 14)
        Me.Label7.TabIndex = 272
        Me.Label7.Text = "Target date "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 12)
        Me.Label9.TabIndex = 265
        Me.Label9.Text = "(検索条件)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.MinimumSize = New System.Drawing.Size(167, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 19)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Search results" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Target_date
        '
        Me.Target_date.CalendarFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.CalendarMonthBackground = System.Drawing.Color.Yellow
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(21, 208)
        Me.Target_date.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(191, 22)
        Me.Target_date.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GridCtrl
        '
        Me.GridCtrl.AllowUserToAddRows = False
        Me.GridCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCtrl.Location = New System.Drawing.Point(12, 333)
        Me.GridCtrl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GridCtrl.Name = "GridCtrl"
        Me.GridCtrl.RowTemplate.Height = 24
        Me.GridCtrl.Size = New System.Drawing.Size(1326, 321)
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
        Me.grpHeader.Location = New System.Drawing.Point(-1, -3)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1352, 58)
        Me.grpHeader.TabIndex = 83
        Me.grpHeader.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(3, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(571, 34)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ohter issues refer・Cancel（その他出庫参照・取消）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1010, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Connection environment(接続環境)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1013, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Login user(ログイン者)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1229, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(120, 19)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "本番環境"
        '
        'txtLoginUser
        '
        Me.txtLoginUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoginUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtLoginUser.Location = New System.Drawing.Point(1229, 10)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(120, 19)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(935, 308)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 12)
        Me.Label6.TabIndex = 269
        Me.Label6.Text = "(検索時間)"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(933, 289)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.MinimumSize = New System.Drawing.Size(112, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 19)
        Me.Label13.TabIndex = 268
        Me.Label13.Text = "Search time:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "(検索結果)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(3, 289)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.MinimumSize = New System.Drawing.Size(167, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(167, 19)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 670)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(10, 0, 1, 0)
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1352, 20)
        Me.StatusStrip1.TabIndex = 86
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.BackColor = System.Drawing.SystemColors.Control
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BottomDate.Size = New System.Drawing.Size(119, 15)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        Me.BottomDate.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExcel.Location = New System.Drawing.Point(1052, 10)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(100, 49)
        Me.btnExcel.TabIndex = 15
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Controls.Add(Me.btnFinish)
        Me.Panel2.Controls.Add(Me.lblHLine)
        Me.Panel2.Controls.Add(Me.DESC)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.ASC)
        Me.Panel2.Controls.Add(Me.Total_by_process)
        Me.Panel2.Controls.Add(Me.Cancel)
        Me.Panel2.Controls.Add(Me.Aggregation_product_name)
        Me.Panel2.Controls.Add(Me.Process_type_summary)
        Me.Panel2.Location = New System.Drawing.Point(0, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1353, 76)
        Me.Panel2.TabIndex = 278
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.btnFinish.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFinish.Location = New System.Drawing.Point(1238, 9)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(100, 49)
        Me.btnFinish.TabIndex = 6
        Me.btnFinish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnFinish.UseVisualStyleBackColor = False
        '
        'lblHLine
        '
        Me.lblHLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHLine.Location = New System.Drawing.Point(0, 70)
        Me.lblHLine.Name = "lblHLine"
        Me.lblHLine.Size = New System.Drawing.Size(1349, 2)
        Me.lblHLine.TabIndex = 5
        '
        'cmb_PaymentCD
        '
        Me.cmb_PaymentCD.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmb_PaymentCD.BackColor = System.Drawing.Color.Yellow
        Me.cmb_PaymentCD.FormattingEnabled = True
        Me.cmb_PaymentCD.Location = New System.Drawing.Point(274, 208)
        Me.cmb_PaymentCD.Name = "cmb_PaymentCD"
        Me.cmb_PaymentCD.Size = New System.Drawing.Size(185, 20)
        Me.cmb_PaymentCD.TabIndex = 279
        '
        'SearchDateTime
        '
        Me.SearchDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchDateTime.AutoSize = True
        Me.SearchDateTime.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchDateTime.Location = New System.Drawing.Point(1092, 289)
        Me.SearchDateTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SearchDateTime.MinimumSize = New System.Drawing.Size(167, 16)
        Me.SearchDateTime.Name = "SearchDateTime"
        Me.SearchDateTime.Size = New System.Drawing.Size(167, 16)
        Me.SearchDateTime.TabIndex = 267
        Me.SearchDateTime.Text = "yyyy/MM/dd hh:mm"
        '
        'SC_K21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.cmb_PaymentCD)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SearchDateTime)
        Me.Controls.Add(Me.Target_date)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.GridCtrl)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SC_K21"
        Me.Text = "Ohter issues refer・Cancel（その他出庫参照・取消）"
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GridCtrl As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents Total_by_process As Button
    Friend WithEvents Process_type_summary As Button
    Friend WithEvents Aggregation_product_name As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents DESC As Button
    Friend WithEvents ASC As Button
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BottomDate As ToolStripStatusLabel
    Friend WithEvents btnExcel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFinish As Button
    Friend WithEvents lblHLine As Label
    Friend WithEvents cmb_PaymentCD As ComboBox
    Friend WithEvents SearchDateTime As Label
End Class
