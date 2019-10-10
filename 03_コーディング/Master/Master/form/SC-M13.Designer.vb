<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_M13
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbHinsyu = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gridData = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblHLine = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDefectName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDefect = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.grpHeader.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.stsFooter.SuspendLayout()
        Me.SuspendLayout()
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 19)
        Me.Label12.TabIndex = 158
        Me.Label12.Text = "Search results"
        '
        'cmbHinsyu
        '
        Me.cmbHinsyu.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbHinsyu.BackColor = System.Drawing.Color.White
        Me.cmbHinsyu.FormattingEnabled = True
        Me.cmbHinsyu.Location = New System.Drawing.Point(7, 171)
        Me.cmbHinsyu.Name = "cmbHinsyu"
        Me.cmbHinsyu.Size = New System.Drawing.Size(180, 20)
        Me.cmbHinsyu.TabIndex = 154
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 14)
        Me.Label16.TabIndex = 156
        Me.Label16.Text = "Process code"
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
        Me.grpHeader.Location = New System.Drawing.Point(-3, -5)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1355, 53)
        Me.grpHeader.TabIndex = 152
        Me.grpHeader.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(560, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(238, 24)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "(不良現象マスタメンテ)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1013, 31)
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
        Me.Label1.Location = New System.Drawing.Point(1015, 10)
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
        Me.Label18.Size = New System.Drawing.Size(547, 37)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Defect phenomena Maintenance"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1231, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(120, 21)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "本番環境"
        '
        'txtLoginUser
        '
        Me.txtLoginUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoginUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtLoginUser.Location = New System.Drawing.Point(1231, 10)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(120, 21)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnd.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnd.Location = New System.Drawing.Point(1238, 9)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(100, 49)
        Me.btnEnd.TabIndex = 9
        Me.btnEnd.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 19)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Search criteria"
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.AllowUserToDeleteRows = False
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(11, 222)
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 21
        Me.gridData.Size = New System.Drawing.Size(1326, 368)
        Me.gridData.TabIndex = 151
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.btnInsert)
        Me.Panel1.Controls.Add(Me.btnEnd)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.lblHLine)
        Me.Panel1.Location = New System.Drawing.Point(-1, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1353, 76)
        Me.Panel1.TabIndex = 150
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(331, 9)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(102, 49)
        Me.btnDelete.TabIndex = 129
        Me.btnDelete.Text = "Delete" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(削除)"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdate.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(223, 9)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(102, 49)
        Me.btnUpdate.TabIndex = 128
        Me.btnUpdate.Text = "Update" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(更新)"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnInsert
        '
        Me.btnInsert.BackColor = System.Drawing.SystemColors.Control
        Me.btnInsert.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnInsert.Location = New System.Drawing.Point(117, 9)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(100, 49)
        Me.btnInsert.TabIndex = 127
        Me.btnInsert.Text = "Insert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(追加)"
        Me.btnInsert.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClear.Location = New System.Drawing.Point(439, 9)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 49)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(クリア)"
        Me.btnClear.UseVisualStyleBackColor = False
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
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(193, 175)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(17, 11)
        Me.Label19.TabIndex = 171
        Me.Label19.Text = "～"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(109, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 11)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "(工程コード)"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(114, 641)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 11)
        Me.Label14.TabIndex = 169
        Me.Label14.Text = "(工程コード)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(150, 206)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 12)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "(検索結果)"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(80, 609)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "(追加)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(153, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 12)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "(検索条件)"
        '
        'txtDefectName
        '
        Me.txtDefectName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDefectName.Location = New System.Drawing.Point(996, 637)
        Me.txtDefectName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDefectName.Name = "txtDefectName"
        Me.txtDefectName.Size = New System.Drawing.Size(152, 21)
        Me.txtDefectName.TabIndex = 163
        Me.txtDefectName.Text = "XXXXXXXXXXXXXX"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 639)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 14)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "Process code"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 603)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 19)
        Me.Label5.TabIndex = 159
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
        Me.stsFooter.TabIndex = 149
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
        Me.Label17.Location = New System.Drawing.Point(918, 641)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 11)
        Me.Label17.TabIndex = 167
        Me.Label17.Text = "(不良現象名)"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(735, 639)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(177, 13)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "Defect phenomenon name"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(527, 641)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 11)
        Me.Label20.TabIndex = 174
        Me.Label20.Text = "(不良コード)"
        '
        'txtDefect
        '
        Me.txtDefect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDefect.Location = New System.Drawing.Point(597, 637)
        Me.txtDefect.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDefect.Name = "txtDefect"
        Me.txtDefect.Size = New System.Drawing.Size(76, 21)
        Me.txtDefect.TabIndex = 173
        Me.txtDefect.Text = "XX"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(430, 639)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 14)
        Me.Label21.TabIndex = 172
        Me.Label21.Text = "Defect Code"
        '
        'cmbProcess
        '
        Me.cmbProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbProcess.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProcess.BackColor = System.Drawing.Color.White
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Items.AddRange(New Object() {"参照", "追加", "修正", "削除"})
        Me.cmbProcess.Location = New System.Drawing.Point(185, 637)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(180, 20)
        Me.cmbProcess.TabIndex = 175
        '
        'SC_M13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.cmbProcess)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtDefect)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbHinsyu)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDefectName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.stsFooter)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Name = "SC_M13"
        Me.Text = "[SC_M13]Defect phenomena Maintenance(不良現象マスタメンテ) V1.0.0"
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSearch As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbHinsyu As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents btnEnd As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents gridData As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents lblHLine As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDefectName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents Label17 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtDefect As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbProcess As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnInsert As Button
End Class
