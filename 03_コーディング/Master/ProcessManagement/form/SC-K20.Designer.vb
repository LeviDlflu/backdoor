<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K20
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.gbSection = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIndividual = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProductNameAbbreviation = New System.Windows.Forms.TextBox()
        Me.dateWithdrawalDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbWithdrawalCategory = New System.Windows.Forms.ComboBox()
        Me.txtWithdrawalQuantity = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTransferIndicator = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimeSys = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.gbSection.SuspendLayout()
        Me.stsFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnd.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnd.Location = New System.Drawing.Point(1228, 69)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(100, 49)
        Me.btnEnd.TabIndex = 269
        Me.btnEnd.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'btnRegistration
        '
        Me.btnRegistration.BackColor = System.Drawing.SystemColors.Control
        Me.btnRegistration.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRegistration.Location = New System.Drawing.Point(44, 69)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(137, 49)
        Me.btnRegistration.TabIndex = 268
        Me.btnRegistration.Text = "Registration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(登録)"
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1351, 59)
        Me.GroupBox1.TabIndex = 270
        Me.GroupBox1.TabStop = False
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(630, 18)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(378, 27)
        Me.Label47.TabIndex = 7
        Me.Label47.Text = "(その他払出入力(製品・中間品)"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label48.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(1009, 31)
        Me.Label48.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(219, 19)
        Me.Label48.TabIndex = 6
        Me.Label48.Text = "Connection environment(接続環境)"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label49.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(1011, 10)
        Me.Label49.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(216, 19)
        Me.Label49.TabIndex = 4
        Me.Label49.Text = "Login user(ログイン者)"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(26, 17)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(600, 27)
        Me.Label46.TabIndex = 1
        Me.Label46.Text = "Other withdrawal input(Product・Middle product)"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox2.Location = New System.Drawing.Point(1227, 31)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(120, 21)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "本番環境"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox3.Location = New System.Drawing.Point(1227, 10)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(120, 21)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "ログインユーザ"
        '
        'gbSection
        '
        Me.gbSection.BackColor = System.Drawing.SystemColors.Window
        Me.gbSection.Controls.Add(Me.RadioButton2)
        Me.gbSection.Controls.Add(Me.RadioButton1)
        Me.gbSection.Controls.Add(Me.Label6)
        Me.gbSection.Controls.Add(Me.Label5)
        Me.gbSection.Location = New System.Drawing.Point(45, 153)
        Me.gbSection.Name = "gbSection"
        Me.gbSection.Size = New System.Drawing.Size(195, 118)
        Me.gbSection.TabIndex = 271
        Me.gbSection.TabStop = False
        Me.gbSection.Text = "Section(区分)"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(19, 81)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton2.TabIndex = 271
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "中間品"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(19, 45)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 270
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "製品"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 14)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Middle product"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 14)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Product"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(47, 306)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(41, 12)
        Me.Label35.TabIndex = 293
        Me.Label35.Text = "(工程)"
        '
        'cmbProcess
        '
        Me.cmbProcess.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProcess.BackColor = System.Drawing.Color.White
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(47, 321)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(145, 20)
        Me.cmbProcess.TabIndex = 291
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.Location = New System.Drawing.Point(45, 289)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(61, 14)
        Me.Label39.TabIndex = 292
        Me.Label39.Text = "Process"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 12)
        Me.Label1.TabIndex = 296
        Me.Label1.Text = "(個体ID)"
        '
        'cmbIndividual
        '
        Me.cmbIndividual.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbIndividual.BackColor = System.Drawing.Color.White
        Me.cmbIndividual.FormattingEnabled = True
        Me.cmbIndividual.Location = New System.Drawing.Point(258, 321)
        Me.cmbIndividual.Name = "cmbIndividual"
        Me.cmbIndividual.Size = New System.Drawing.Size(145, 20)
        Me.cmbIndividual.TabIndex = 294
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(256, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 14)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "Individual No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 384)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 12)
        Me.Label3.TabIndex = 298
        Me.Label3.Text = "(品名略称)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(190, 14)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "Product name abbreviation"
        '
        'txtProductNameAbbreviation
        '
        Me.txtProductNameAbbreviation.Location = New System.Drawing.Point(47, 399)
        Me.txtProductNameAbbreviation.Name = "txtProductNameAbbreviation"
        Me.txtProductNameAbbreviation.Size = New System.Drawing.Size(356, 21)
        Me.txtProductNameAbbreviation.TabIndex = 299
        '
        'dateWithdrawalDate
        '
        Me.dateWithdrawalDate.Location = New System.Drawing.Point(48, 475)
        Me.dateWithdrawalDate.Name = "dateWithdrawalDate"
        Me.dateWithdrawalDate.Size = New System.Drawing.Size(149, 21)
        Me.dateWithdrawalDate.TabIndex = 300
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 460)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 12)
        Me.Label7.TabIndex = 302
        Me.Label7.Text = "(払出日)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(45, 443)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 14)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "Withdrawal date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(258, 460)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 12)
        Me.Label9.TabIndex = 304
        Me.Label9.Text = "(受払区分)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(256, 443)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 14)
        Me.Label10.TabIndex = 303
        Me.Label10.Text = "Withdrawal category"
        '
        'cmbWithdrawalCategory
        '
        Me.cmbWithdrawalCategory.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbWithdrawalCategory.BackColor = System.Drawing.Color.White
        Me.cmbWithdrawalCategory.FormattingEnabled = True
        Me.cmbWithdrawalCategory.Location = New System.Drawing.Point(258, 475)
        Me.cmbWithdrawalCategory.Name = "cmbWithdrawalCategory"
        Me.cmbWithdrawalCategory.Size = New System.Drawing.Size(145, 20)
        Me.cmbWithdrawalCategory.TabIndex = 305
        '
        'txtWithdrawalQuantity
        '
        Me.txtWithdrawalQuantity.Location = New System.Drawing.Point(451, 475)
        Me.txtWithdrawalQuantity.Name = "txtWithdrawalQuantity"
        Me.txtWithdrawalQuantity.Size = New System.Drawing.Size(124, 21)
        Me.txtWithdrawalQuantity.TabIndex = 308
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(450, 460)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 12)
        Me.Label11.TabIndex = 307
        Me.Label11.Text = "(支払数量)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(448, 443)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 14)
        Me.Label12.TabIndex = 306
        Me.Label12.Text = "Withdrawal quantity"
        '
        'txtTransferIndicator
        '
        Me.txtTransferIndicator.Location = New System.Drawing.Point(633, 475)
        Me.txtTransferIndicator.Name = "txtTransferIndicator"
        Me.txtTransferIndicator.Size = New System.Drawing.Size(117, 21)
        Me.txtTransferIndicator.TabIndex = 311
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(632, 460)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 12)
        Me.Label13.TabIndex = 310
        Me.Label13.Text = "(振替区分)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(630, 443)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 14)
        Me.Label14.TabIndex = 309
        Me.Label14.Text = "Transfer indicator"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(47, 551)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(356, 21)
        Me.txtRemarks.TabIndex = 314
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(46, 536)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 313
        Me.Label15.Text = "(備考)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(44, 519)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 14)
        Me.Label16.TabIndex = 312
        Me.Label16.Text = "Remarks"
        '
        'stsFooter
        '
        Me.stsFooter.BackColor = System.Drawing.SystemColors.Control
        Me.stsFooter.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsFooter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slblMargin, Me.slblDay, Me.slblTime})
        Me.stsFooter.Location = New System.Drawing.Point(0, 665)
        Me.stsFooter.Name = "stsFooter"
        Me.stsFooter.Size = New System.Drawing.Size(1350, 24)
        Me.stsFooter.SizingGrip = False
        Me.stsFooter.TabIndex = 315
        Me.stsFooter.Text = "StatusStrip1"
        '
        'slblMargin
        '
        Me.slblMargin.BackColor = System.Drawing.SystemColors.Control
        Me.slblMargin.Name = "slblMargin"
        Me.slblMargin.Size = New System.Drawing.Size(1215, 19)
        Me.slblMargin.Spring = True
        '
        'slblDay
        '
        Me.slblDay.AutoSize = False
        Me.slblDay.BackColor = System.Drawing.SystemColors.Control
        Me.slblDay.Name = "slblDay"
        Me.slblDay.Size = New System.Drawing.Size(75, 19)
        Me.slblDay.Text = "yyyy/MM/dd"
        Me.slblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'slblTime
        '
        Me.slblTime.AutoSize = False
        Me.slblTime.BackColor = System.Drawing.SystemColors.Control
        Me.slblTime.Name = "slblTime"
        Me.slblTime.Size = New System.Drawing.Size(45, 19)
        Me.slblTime.Text = "HH:mm"
        Me.slblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeSys
        '
        Me.TimeSys.Enabled = True
        Me.TimeSys.Interval = 1000
        '
        'SC_K20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.stsFooter)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtTransferIndicator)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtWithdrawalQuantity)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbWithdrawalCategory)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dateWithdrawalDate)
        Me.Controls.Add(Me.txtProductNameAbbreviation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbIndividual)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cmbProcess)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.gbSection)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnRegistration)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SC_K20"
        Me.Text = "[SC_K20]その他払出入力(製品・中間品)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSection.ResumeLayout(False)
        Me.gbSection.PerformLayout()
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEnd As Button
    Friend WithEvents btnRegistration As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents gbSection As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents cmbProcess As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbIndividual As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProductNameAbbreviation As TextBox
    Friend WithEvents dateWithdrawalDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbWithdrawalCategory As ComboBox
    Friend WithEvents txtWithdrawalQuantity As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTransferIndicator As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents TimeSys As Timer
End Class
