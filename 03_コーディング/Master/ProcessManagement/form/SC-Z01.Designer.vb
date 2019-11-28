<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_Z01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_Z01))
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnDesc = New System.Windows.Forms.Button()
        Me.btnAsc = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.lblSearchTime = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkSP = New System.Windows.Forms.CheckBox()
        Me.chkKD = New System.Windows.Forms.CheckBox()
        Me.chkLine = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbVehicleType = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbVariety = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkZero = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbYard = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoSemifinished = New System.Windows.Forms.RadioButton()
        Me.rodProduct = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExcel.Location = New System.Drawing.Point(386, 66)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(117, 53)
        Me.btnExcel.TabIndex = 273
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnDesc
        '
        Me.btnDesc.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesc.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDesc.Location = New System.Drawing.Point(261, 66)
        Me.btnDesc.Name = "btnDesc"
        Me.btnDesc.Size = New System.Drawing.Size(119, 53)
        Me.btnDesc.TabIndex = 272
        Me.btnDesc.Text = "Desc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降順)"
        Me.btnDesc.UseVisualStyleBackColor = False
        '
        'btnAsc
        '
        Me.btnAsc.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsc.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAsc.Location = New System.Drawing.Point(138, 66)
        Me.btnAsc.Name = "btnAsc"
        Me.btnAsc.Size = New System.Drawing.Size(117, 53)
        Me.btnAsc.TabIndex = 271
        Me.btnAsc.Text = "Asc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇順)"
        Me.btnAsc.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(15, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 53)
        Me.btnSearch.TabIndex = 270
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.gridData)
        Me.Panel1.Controls.Add(Me.lblSearchTime)
        Me.Panel1.Controls.Add(Me.Label65)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Location = New System.Drawing.Point(-1, 331)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1353, 327)
        Me.Panel1.TabIndex = 310
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.EnableHeadersVisualStyles = False
        Me.gridData.Location = New System.Drawing.Point(37, 59)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.Color.White
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.ReadOnly = True
        Me.gridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1269, 265)
        Me.gridData.TabIndex = 312
        '
        'lblSearchTime
        '
        Me.lblSearchTime.AutoSize = True
        Me.lblSearchTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.lblSearchTime.Location = New System.Drawing.Point(1162, 15)
        Me.lblSearchTime.Name = "lblSearchTime"
        Me.lblSearchTime.Size = New System.Drawing.Size(144, 16)
        Me.lblSearchTime.TabIndex = 310
        Me.lblSearchTime.Text = "yyyy/MM/dd hh:mm"
        Me.lblSearchTime.Visible = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(1020, 12)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(136, 19)
        Me.Label65.TabIndex = 308
        Me.Label65.Text = "Search time ："
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(1028, 35)
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
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.cmbVehicleType)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.cmbVariety)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.chkZero)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmbYard)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.cmbProcess)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Location = New System.Drawing.Point(-1, 130)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1353, 201)
        Me.Panel4.TabIndex = 309
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.chkSP)
        Me.GroupBox2.Controls.Add(Me.chkKD)
        Me.GroupBox2.Controls.Add(Me.chkLine)
        Me.GroupBox2.Location = New System.Drawing.Point(576, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(441, 71)
        Me.GroupBox2.TabIndex = 338
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Packing specifications(梱包仕様)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(305, 27)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 16)
        Me.Label25.TabIndex = 284
        Me.Label25.Text = "Service Parts"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(158, 27)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 16)
        Me.Label24.TabIndex = 284
        Me.Label24.Text = "Knock Down"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(55, 27)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 16)
        Me.Label23.TabIndex = 284
        Me.Label23.Text = "Line"
        '
        'chkSP
        '
        Me.chkSP.AutoSize = True
        Me.chkSP.Checked = True
        Me.chkSP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSP.Location = New System.Drawing.Point(292, 46)
        Me.chkSP.Name = "chkSP"
        Me.chkSP.Size = New System.Drawing.Size(43, 18)
        Me.chkSP.TabIndex = 330
        Me.chkSP.Text = "SP"
        Me.chkSP.UseVisualStyleBackColor = True
        '
        'chkKD
        '
        Me.chkKD.AutoSize = True
        Me.chkKD.Checked = True
        Me.chkKD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKD.Location = New System.Drawing.Point(142, 46)
        Me.chkKD.Name = "chkKD"
        Me.chkKD.Size = New System.Drawing.Size(43, 18)
        Me.chkKD.TabIndex = 329
        Me.chkKD.Text = "KD"
        Me.chkKD.UseVisualStyleBackColor = True
        '
        'chkLine
        '
        Me.chkLine.AutoSize = True
        Me.chkLine.Checked = True
        Me.chkLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLine.Location = New System.Drawing.Point(39, 46)
        Me.chkLine.Name = "chkLine"
        Me.chkLine.Size = New System.Drawing.Size(56, 18)
        Me.chkLine.TabIndex = 328
        Me.chkLine.Text = "ライン"
        Me.chkLine.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(1060, 67)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 16)
        Me.Label20.TabIndex = 337
        Me.Label20.Text = "(車種)"
        '
        'cmbVehicleType
        '
        Me.cmbVehicleType.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbVehicleType.BackColor = System.Drawing.Color.White
        Me.cmbVehicleType.FormattingEnabled = True
        Me.cmbVehicleType.Location = New System.Drawing.Point(1063, 83)
        Me.cmbVehicleType.Name = "cmbVehicleType"
        Me.cmbVehicleType.Size = New System.Drawing.Size(200, 21)
        Me.cmbVehicleType.TabIndex = 326
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(1059, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 16)
        Me.Label22.TabIndex = 336
        Me.Label22.Text = "Vehicle type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(814, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 16)
        Me.Label13.TabIndex = 334
        Me.Label13.Text = "(品種)"
        '
        'cmbVariety
        '
        Me.cmbVariety.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbVariety.BackColor = System.Drawing.Color.White
        Me.cmbVariety.FormattingEnabled = True
        Me.cmbVariety.Location = New System.Drawing.Point(817, 83)
        Me.cmbVariety.Name = "cmbVariety"
        Me.cmbVariety.Size = New System.Drawing.Size(200, 21)
        Me.cmbVariety.TabIndex = 325
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(813, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 16)
        Me.Label17.TabIndex = 333
        Me.Label17.Text = "Variety"
        '
        'chkZero
        '
        Me.chkZero.AutoSize = True
        Me.chkZero.Checked = True
        Me.chkZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkZero.Location = New System.Drawing.Point(327, 154)
        Me.chkZero.Name = "chkZero"
        Me.chkZero.Size = New System.Drawing.Size(112, 18)
        Me.chkZero.TabIndex = 327
        Me.chkZero.Text = "ゼロデータを除く"
        Me.chkZero.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(344, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 16)
        Me.Label10.TabIndex = 330
        Me.Label10.Text = "Excluding zero data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(573, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 329
        Me.Label7.Text = "(工程)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(324, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 328
        Me.Label8.Text = "Yard"
        '
        'cmbYard
        '
        Me.cmbYard.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbYard.BackColor = System.Drawing.Color.Yellow
        Me.cmbYard.FormattingEnabled = True
        Me.cmbYard.Location = New System.Drawing.Point(327, 83)
        Me.cmbYard.Name = "cmbYard"
        Me.cmbYard.Size = New System.Drawing.Size(200, 21)
        Me.cmbYard.TabIndex = 323
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.rdoSemifinished)
        Me.GroupBox1.Controls.Add(Me.rodProduct)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 120)
        Me.GroupBox1.TabIndex = 327
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Section(区分)"
        '
        'rdoSemifinished
        '
        Me.rdoSemifinished.Location = New System.Drawing.Point(22, 88)
        Me.rdoSemifinished.Name = "rdoSemifinished"
        Me.rdoSemifinished.Size = New System.Drawing.Size(69, 17)
        Me.rdoSemifinished.TabIndex = 271
        Me.rdoSemifinished.Text = "半製品"
        Me.rdoSemifinished.UseVisualStyleBackColor = True
        '
        'rodProduct
        '
        Me.rodProduct.Checked = True
        Me.rodProduct.Location = New System.Drawing.Point(22, 49)
        Me.rodProduct.Name = "rodProduct"
        Me.rodProduct.Size = New System.Drawing.Size(55, 17)
        Me.rodProduct.TabIndex = 270
        Me.rodProduct.TabStop = True
        Me.rodProduct.Text = "製品"
        Me.rodProduct.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 16)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Semifinished product"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Product"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(325, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 16)
        Me.Label9.TabIndex = 326
        Me.Label9.Text = "(置場)"
        '
        'cmbProcess
        '
        Me.cmbProcess.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProcess.BackColor = System.Drawing.Color.White
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(576, 83)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(200, 21)
        Me.cmbProcess.TabIndex = 324
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(572, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 325
        Me.Label16.Text = "Process"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label45.Location = New System.Drawing.Point(9, 30)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 19)
        Me.Label45.TabIndex = 303
        Me.Label45.Text = "(検索条件)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(3, 10)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(145, 19)
        Me.Label53.TabIndex = 299
        Me.Label53.Text = "Search criteria"
        '
        'SC_Z01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnDesc)
        Me.Controls.Add(Me.btnAsc)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_Z01"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnAsc, 0)
        Me.Controls.SetChildIndex(Me.btnDesc, 0)
        Me.Controls.SetChildIndex(Me.btnExcel, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExcel As Button
    Friend WithEvents btnDesc As Button
    Friend WithEvents btnAsc As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents lblSearchTime As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents chkSP As CheckBox
    Friend WithEvents chkKD As CheckBox
    Friend WithEvents chkLine As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbVehicleType As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbVariety As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents chkZero As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbYard As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoSemifinished As RadioButton
    Friend WithEvents rodProduct As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbProcess As ComboBox
    Friend WithEvents Label16 As Label
End Class
