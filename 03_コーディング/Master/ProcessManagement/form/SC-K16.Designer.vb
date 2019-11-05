<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K16
    Inherits ProcessManagement.ParentTemplate

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K16))
        Me.btnDesc = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbMoneyType = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.cmbProductName = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpWorkingYMD = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cmbVariety = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDesc
        '
        Me.btnDesc.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesc.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnDesc.Location = New System.Drawing.Point(173, 66)
        Me.btnDesc.Name = "btnDesc"
        Me.btnDesc.Size = New System.Drawing.Size(117, 53)
        Me.btnDesc.TabIndex = 271
        Me.btnDesc.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnDesc.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.Location = New System.Drawing.Point(24, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 53)
        Me.btnSearch.TabIndex = 270
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmbMoneyType)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Controls.Add(Me.Label39)
        Me.Panel4.Controls.Add(Me.Label35)
        Me.Panel4.Controls.Add(Me.Label64)
        Me.Panel4.Controls.Add(Me.CheckBox2)
        Me.Panel4.Controls.Add(Me.Label59)
        Me.Panel4.Controls.Add(Me.cmbProductName)
        Me.Panel4.Controls.Add(Me.Label60)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.cmbVariety)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.cmbProcess)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(-1, 126)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1354, 248)
        Me.Panel4.TabIndex = 296
        '
        'cmbMoneyType
        '
        Me.cmbMoneyType.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbMoneyType.BackColor = System.Drawing.Color.White
        Me.cmbMoneyType.FormattingEnabled = True
        Me.cmbMoneyType.Location = New System.Drawing.Point(845, 93)
        Me.cmbMoneyType.Name = "cmbMoneyType"
        Me.cmbMoneyType.Size = New System.Drawing.Size(55, 21)
        Me.cmbMoneyType.TabIndex = 328
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(843, 52)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(43, 16)
        Me.Label36.TabIndex = 329
        Me.Label36.Text = "Mold"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label39.Location = New System.Drawing.Point(843, 71)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(50, 16)
        Me.Label39.TabIndex = 330
        Me.Label39.Text = "(金型)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(35, 220)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(1223, 15)
        Me.Label35.TabIndex = 327
        Me.Label35.Text = "Note 2) Pass rate: Pass quantity / Shot quantity, Failure rate: (Failure quantity" &
    " + Adjustment quantity) / Shot quantity [注2)合格率：合格数÷ショット数、 不良率：(不良数＋調整数)÷ショット数]"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label64.Location = New System.Drawing.Point(34, 192)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(625, 15)
        Me.Label64.TabIndex = 326
        Me.Label64.Text = "Note 1) You can see the results up to the previous day.[注1)前日までの実績を見ることができます。]"
        '
        'CheckBox2
        '
        Me.CheckBox2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.CheckBox2.Location = New System.Drawing.Point(515, 129)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(343, 30)
        Me.CheckBox2.TabIndex = 324
        Me.CheckBox2.Text = "* Similar search(Search for product names start with entered)※類似検索(入力した文字で始まる品名を検" &
    "索)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label59.Location = New System.Drawing.Point(450, 143)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(50, 16)
        Me.Label59.TabIndex = 321
        Me.Label59.Text = "(品名)"
        '
        'cmbProductName
        '
        Me.cmbProductName.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProductName.BackColor = System.Drawing.Color.White
        Me.cmbProductName.FormattingEnabled = True
        Me.cmbProductName.Location = New System.Drawing.Point(450, 164)
        Me.cmbProductName.Name = "cmbProductName"
        Me.cmbProductName.Size = New System.Drawing.Size(244, 21)
        Me.cmbProductName.TabIndex = 319
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label60.Location = New System.Drawing.Point(446, 120)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(69, 16)
        Me.Label60.TabIndex = 320
        Me.Label60.Text = "Product"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.DateTimePicker2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label56)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.dtpWorkingYMD)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.Label55)
        Me.Panel3.Controls.Add(Me.Label47)
        Me.Panel3.Location = New System.Drawing.Point(18, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(410, 123)
        Me.Panel3.TabIndex = 315
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.CustomFormat = "yyyy/MM"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(154, 90)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(110, 21)
        Me.DateTimePicker2.TabIndex = 279
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(266, 36)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(21, 14)
        Me.Label56.TabIndex = 278
        Me.Label56.Text = "～"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(287, 32)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(110, 21)
        Me.DateTimePicker1.TabIndex = 277
        '
        'dtpWorkingYMD
        '
        Me.dtpWorkingYMD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpWorkingYMD.CustomFormat = "yyyy/MM/dd"
        Me.dtpWorkingYMD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWorkingYMD.Location = New System.Drawing.Point(154, 32)
        Me.dtpWorkingYMD.Name = "dtpWorkingYMD"
        Me.dtpWorkingYMD.Size = New System.Drawing.Size(110, 21)
        Me.dtpWorkingYMD.TabIndex = 276
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(16, 93)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton2.TabIndex = 275
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "過去検索"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(16, 34)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton1.TabIndex = 274
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "範囲検索"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label55.Location = New System.Drawing.Point(33, 12)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(111, 16)
        Me.Label55.TabIndex = 273
        Me.Label55.Text = "Range search"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.Location = New System.Drawing.Point(33, 72)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(100, 16)
        Me.Label47.TabIndex = 272
        Me.Label47.Text = "Past search"
        '
        'cmbVariety
        '
        Me.cmbVariety.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbVariety.BackColor = System.Drawing.Color.White
        Me.cmbVariety.FormattingEnabled = True
        Me.cmbVariety.Location = New System.Drawing.Point(632, 93)
        Me.cmbVariety.Name = "cmbVariety"
        Me.cmbVariety.Size = New System.Drawing.Size(180, 21)
        Me.cmbVariety.TabIndex = 300
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(630, 52)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 16)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Variety"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label43.Location = New System.Drawing.Point(630, 71)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(50, 16)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(品種)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(451, 71)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(50, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(設備)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label45.Location = New System.Drawing.Point(9, 35)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 19)
        Me.Label45.TabIndex = 304
        Me.Label45.Text = "(検索条件)"
        '
        'cmbProcess
        '
        Me.cmbProcess.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProcess.BackColor = System.Drawing.Color.White
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(449, 93)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(150, 21)
        Me.cmbProcess.TabIndex = 296
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(3, 14)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(162, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search condition"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(447, 52)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(87, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Equipment"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.gridData)
        Me.Panel1.Controls.Add(Me.Label67)
        Me.Panel1.Controls.Add(Me.Label65)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Location = New System.Drawing.Point(-2, 374)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1353, 286)
        Me.Panel1.TabIndex = 308
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(37, 59)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.ControlDark
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1269, 225)
        Me.gridData.TabIndex = 312
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label67.Location = New System.Drawing.Point(1142, 19)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(144, 16)
        Me.Label67.TabIndex = 310
        Me.Label67.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(1000, 16)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(136, 19)
        Me.Label65.TabIndex = 308
        Me.Label65.Text = "Search time ："
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(1004, 39)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 309
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(7, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 306
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(12, 24)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 307
        Me.Label40.Text = "(検索結果)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(244, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 332
        Me.Label1.Text = "(実績日)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(151, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 331
        Me.Label2.Text = "Actual date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(262, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 334
        Me.Label3.Text = "(実績月)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(154, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 333
        Me.Label4.Text = "Actual month"
        '
        'SC_K16
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnDesc)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K16"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnDesc, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDesc As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbMoneyType As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label59 As Label
    Friend WithEvents cmbProductName As ComboBox
    Friend WithEvents Label60 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label56 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents dtpWorkingYMD As DateTimePicker
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label55 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents cmbVariety As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents cmbProcess As ComboBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents Label67 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
