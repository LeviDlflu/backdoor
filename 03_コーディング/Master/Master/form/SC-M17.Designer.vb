<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_M17
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNameCD = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblHLine = New System.Windows.Forms.Label()
        Me.gridData = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFullNM = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.stsFooter.SuspendLayout()
        Me.grpHeader.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(98, 733)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 11)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "(氏名コード)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(151, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 12)
        Me.Label11.TabIndex = 143
        Me.Label11.Text = "(検索結果)"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(81, 701)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 142
        Me.Label13.Text = "(追加)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(154, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 12)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "(検索条件)"
        '
        'txtFullName
        '
        Me.txtFullName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFullName.Location = New System.Drawing.Point(242, 747)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(197, 19)
        Me.txtFullName.TabIndex = 140
        Me.txtFullName.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(239, 731)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 139
        Me.Label10.Text = "Full name"
        '
        'txtNameCD
        '
        Me.txtNameCD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNameCD.Location = New System.Drawing.Point(14, 747)
        Me.txtNameCD.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNameCD.Name = "txtNameCD"
        Me.txtNameCD.Size = New System.Drawing.Size(149, 19)
        Me.txtNameCD.TabIndex = 138
        Me.txtNameCD.Text = "XX"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 731)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 14)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Name code"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 695)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 19)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Add To"
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
        Me.stsFooter.TabIndex = 126
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
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(315, 733)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 11)
        Me.Label17.TabIndex = 144
        Me.Label17.Text = "(氏名)"
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnd.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnd.Location = New System.Drawing.Point(1236, 9)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(100, 49)
        Me.btnEnd.TabIndex = 9
        Me.btnEnd.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 19)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Search results"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 19)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Search criteria"
        '
        'grpHeader
        '
        Me.grpHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.grpHeader.Controls.Add(Me.Label15)
        Me.grpHeader.Controls.Add(Me.Label2)
        Me.grpHeader.Controls.Add(Me.Label1)
        Me.grpHeader.Controls.Add(Me.Label18)
        Me.grpHeader.Controls.Add(Me.TextBox1)
        Me.grpHeader.Controls.Add(Me.txtLoginUser)
        Me.grpHeader.Location = New System.Drawing.Point(-2, -3)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1351, 53)
        Me.grpHeader.TabIndex = 129
        Me.grpHeader.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(407, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(188, 24)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "(社員マスタメンテ)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1009, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Connection environment(接続環境)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1011, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Login user(ログイン者)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(6, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(395, 37)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Employee maintenance"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1227, 31)
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
        Me.txtLoginUser.Location = New System.Drawing.Point(1227, 10)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(120, 19)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(12, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 49)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'lblHLine
        '
        Me.lblHLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHLine.Location = New System.Drawing.Point(1, 72)
        Me.lblHLine.Name = "lblHLine"
        Me.lblHLine.Size = New System.Drawing.Size(1347, 2)
        Me.lblHLine.TabIndex = 5
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.AllowUserToDeleteRows = False
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(12, 224)
        Me.gridData.Name = "gridData"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridData.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridData.RowTemplate.Height = 21
        Me.gridData.Size = New System.Drawing.Size(1330, 295)
        Me.gridData.TabIndex = 128
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.btnInsert)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.btnEnd)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.lblHLine)
        Me.Panel1.Location = New System.Drawing.Point(0, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1351, 76)
        Me.Panel1.TabIndex = 127
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(332, 9)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(102, 49)
        Me.btnDelete.TabIndex = 126
        Me.btnDelete.Text = "Delete" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(削除)"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdate.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(224, 9)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(102, 49)
        Me.btnUpdate.TabIndex = 125
        Me.btnUpdate.Text = "Update" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(更新)"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnInsert
        '
        Me.btnInsert.BackColor = System.Drawing.SystemColors.Control
        Me.btnInsert.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnInsert.Location = New System.Drawing.Point(118, 9)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(100, 49)
        Me.btnInsert.TabIndex = 124
        Me.btnInsert.Text = "Insert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(追加)"
        Me.btnInsert.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExcel.Location = New System.Drawing.Point(440, 9)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(100, 49)
        Me.btnExcel.TabIndex = 10
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClear.Location = New System.Drawing.Point(545, 9)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 49)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(クリア)"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(109, 579)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 11)
        Me.Label20.TabIndex = 179
        Me.Label20.Text = "(氏名コード)"
        '
        'txtName
        '
        Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(25, 595)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(159, 19)
        Me.txtName.TabIndex = 178
        Me.txtName.Text = "XXXX"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 577)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 14)
        Me.Label21.TabIndex = 177
        Me.Label21.Text = "Name code"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(99, 534)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "(追加)"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 528)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "Add To"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(304, 579)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 11)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "(氏名)"
        '
        'txtFullNM
        '
        Me.txtFullNM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFullNM.Location = New System.Drawing.Point(229, 595)
        Me.txtFullNM.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFullNM.Name = "txtFullNM"
        Me.txtFullNM.Size = New System.Drawing.Size(179, 19)
        Me.txtFullNM.TabIndex = 181
        Me.txtFullNM.Text = "XXXXXXXXXXXXXXXXXXXX"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(226, 577)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 14)
        Me.Label16.TabIndex = 180
        Me.Label16.Text = "Full name"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(523, 579)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 11)
        Me.Label19.TabIndex = 185
        Me.Label19.Text = "(備考)"
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Location = New System.Drawing.Point(456, 595)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(381, 19)
        Me.txtRemarks.TabIndex = 184
        Me.txtRemarks.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(453, 577)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 14)
        Me.Label22.TabIndex = 183
        Me.Label22.Text = "Remarks"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(102, 157)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 11)
        Me.Label29.TabIndex = 209
        Me.Label29.Text = "(氏名コード)"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 156)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(81, 14)
        Me.Label30.TabIndex = 208
        Me.Label30.Text = "Name code"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(198, 177)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(17, 11)
        Me.Label24.TabIndex = 210
        Me.Label24.Text = "～"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 173)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(180, 20)
        Me.ComboBox1.TabIndex = 211
        '
        'SC_M17
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFullNM)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNameCD)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.stsFooter)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SC_M17"
        Me.Text = "[SC_M17]Employee maintenance (社員マスタメンテ)Ver1.0.0"
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNameCD As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents Label17 As Label
    Friend WithEvents btnEnd As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblHLine As Label
    Friend WithEvents gridData As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFullNM As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
