<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_M00
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
        Me.components = New System.ComponentModel.Container()
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimeSys = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn22 = New System.Windows.Forms.Button()
        Me.btn20 = New System.Windows.Forms.Button()
        Me.btn19 = New System.Windows.Forms.Button()
        Me.btn18 = New System.Windows.Forms.Button()
        Me.btn17 = New System.Windows.Forms.Button()
        Me.btn15 = New System.Windows.Forms.Button()
        Me.btn16 = New System.Windows.Forms.Button()
        Me.btn14 = New System.Windows.Forms.Button()
        Me.btn13 = New System.Windows.Forms.Button()
        Me.btn12 = New System.Windows.Forms.Button()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.btn11 = New System.Windows.Forms.Button()
        Me.btn01 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.grpHeader.SuspendLayout()
        Me.stsFooter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grpHeader.Location = New System.Drawing.Point(0, -6)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1352, 59)
        Me.grpHeader.TabIndex = 82
        Me.grpHeader.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(367, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(207, 24)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "(マスタ管理メニュー)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1010, 31)
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
        Me.Label1.Location = New System.Drawing.Point(1012, 10)
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
        Me.Label18.Size = New System.Drawing.Size(366, 37)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Master manage menu"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1228, 31)
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
        Me.txtLoginUser.Location = New System.Drawing.Point(1228, 10)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(120, 19)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
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
        Me.stsFooter.TabIndex = 84
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn22)
        Me.Panel1.Controls.Add(Me.btn20)
        Me.Panel1.Controls.Add(Me.btn19)
        Me.Panel1.Controls.Add(Me.btn18)
        Me.Panel1.Controls.Add(Me.btn17)
        Me.Panel1.Controls.Add(Me.btn15)
        Me.Panel1.Controls.Add(Me.btn16)
        Me.Panel1.Controls.Add(Me.btn14)
        Me.Panel1.Controls.Add(Me.btn13)
        Me.Panel1.Controls.Add(Me.btn12)
        Me.Panel1.Controls.Add(Me.btn10)
        Me.Panel1.Controls.Add(Me.btn11)
        Me.Panel1.Controls.Add(Me.btn01)
        Me.Panel1.Location = New System.Drawing.Point(35, 141)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1226, 385)
        Me.Panel1.TabIndex = 85
        '
        'btn22
        '
        Me.btn22.BackColor = System.Drawing.SystemColors.Control
        Me.btn22.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn22.Location = New System.Drawing.Point(29, 290)
        Me.btn22.Name = "btn22"
        Me.btn22.Size = New System.Drawing.Size(275, 49)
        Me.btn22.TabIndex = 23
        Me.btn22.Text = "Numbering master採番マスタ(M-22)"
        Me.btn22.UseVisualStyleBackColor = False
        '
        'btn20
        '
        Me.btn20.BackColor = System.Drawing.SystemColors.Control
        Me.btn20.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn20.Location = New System.Drawing.Point(918, 209)
        Me.btn20.Name = "btn20"
        Me.btn20.Size = New System.Drawing.Size(275, 49)
        Me.btn20.TabIndex = 22
        Me.btn20.Text = "Customer calendar master顧客カレンダーマスタ(M-20)"
        Me.btn20.UseVisualStyleBackColor = False
        '
        'btn19
        '
        Me.btn19.BackColor = System.Drawing.SystemColors.Control
        Me.btn19.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn19.Location = New System.Drawing.Point(621, 209)
        Me.btn19.Name = "btn19"
        Me.btn19.Size = New System.Drawing.Size(275, 49)
        Me.btn19.TabIndex = 20
        Me.btn19.Text = "Work table master勤務テーブルマスタ(M-19)"
        Me.btn19.UseVisualStyleBackColor = False
        '
        'btn18
        '
        Me.btn18.BackColor = System.Drawing.SystemColors.Control
        Me.btn18.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn18.Location = New System.Drawing.Point(324, 209)
        Me.btn18.Name = "btn18"
        Me.btn18.Size = New System.Drawing.Size(275, 49)
        Me.btn18.TabIndex = 19
        Me.btn18.Text = "Assistance master補助マスタ(M-18)"
        Me.btn18.UseVisualStyleBackColor = False
        '
        'btn17
        '
        Me.btn17.BackColor = System.Drawing.SystemColors.Control
        Me.btn17.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn17.Location = New System.Drawing.Point(29, 209)
        Me.btn17.Name = "btn17"
        Me.btn17.Size = New System.Drawing.Size(275, 49)
        Me.btn17.TabIndex = 18
        Me.btn17.Text = "Employee master社員マスタ(M-17)"
        Me.btn17.UseVisualStyleBackColor = False
        '
        'btn15
        '
        Me.btn15.BackColor = System.Drawing.SystemColors.Control
        Me.btn15.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn15.Location = New System.Drawing.Point(621, 130)
        Me.btn15.Name = "btn15"
        Me.btn15.Size = New System.Drawing.Size(275, 49)
        Me.btn15.TabIndex = 17
        Me.btn15.Text = "Code masterコードマスタ(M-15)"
        Me.btn15.UseVisualStyleBackColor = False
        '
        'btn16
        '
        Me.btn16.BackColor = System.Drawing.SystemColors.Control
        Me.btn16.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn16.Location = New System.Drawing.Point(918, 130)
        Me.btn16.Name = "btn16"
        Me.btn16.Size = New System.Drawing.Size(275, 49)
        Me.btn16.TabIndex = 16
        Me.btn16.Text = "Authorization master権限マスタ(M-16)"
        Me.btn16.UseVisualStyleBackColor = False
        '
        'btn14
        '
        Me.btn14.BackColor = System.Drawing.SystemColors.Control
        Me.btn14.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn14.Location = New System.Drawing.Point(324, 130)
        Me.btn14.Name = "btn14"
        Me.btn14.Size = New System.Drawing.Size(275, 49)
        Me.btn14.TabIndex = 15
        Me.btn14.Text = "IP address manage masterＩＰアドレス管理マスタ(M-14)"
        Me.btn14.UseVisualStyleBackColor = False
        '
        'btn13
        '
        Me.btn13.BackColor = System.Drawing.SystemColors.Control
        Me.btn13.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn13.Location = New System.Drawing.Point(29, 130)
        Me.btn13.Name = "btn13"
        Me.btn13.Size = New System.Drawing.Size(275, 49)
        Me.btn13.TabIndex = 14
        Me.btn13.Text = "Failure phenomena master不良現象マスタ(M-13)"
        Me.btn13.UseVisualStyleBackColor = False
        '
        'btn12
        '
        Me.btn12.BackColor = System.Drawing.SystemColors.Control
        Me.btn12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn12.Location = New System.Drawing.Point(918, 50)
        Me.btn12.Name = "btn12"
        Me.btn12.Size = New System.Drawing.Size(275, 49)
        Me.btn12.TabIndex = 13
        Me.btn12.Text = "Vehicle type master車種マスタ(M-12)"
        Me.btn12.UseVisualStyleBackColor = False
        '
        'btn10
        '
        Me.btn10.BackColor = System.Drawing.SystemColors.Control
        Me.btn10.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn10.ForeColor = System.Drawing.Color.Black
        Me.btn10.Location = New System.Drawing.Point(324, 50)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(275, 49)
        Me.btn10.TabIndex = 11
        Me.btn10.Text = "Equipment master設備マスタ(M-10)"
        Me.btn10.UseVisualStyleBackColor = False
        '
        'btn11
        '
        Me.btn11.BackColor = System.Drawing.SystemColors.Control
        Me.btn11.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn11.Location = New System.Drawing.Point(621, 50)
        Me.btn11.Name = "btn11"
        Me.btn11.Size = New System.Drawing.Size(275, 49)
        Me.btn11.TabIndex = 10
        Me.btn11.Text = "Variety master品種マスタ(M-11)"
        Me.btn11.UseVisualStyleBackColor = False
        '
        'btn01
        '
        Me.btn01.BackColor = System.Drawing.SystemColors.Control
        Me.btn01.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn01.Location = New System.Drawing.Point(29, 50)
        Me.btn01.Name = "btn01"
        Me.btn01.Size = New System.Drawing.Size(275, 49)
        Me.btn01.TabIndex = 9
        Me.btn01.Text = "Parts configuration master" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "部品構成マスタ(M-01)"
        Me.btn01.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(200, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 12)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "(マスタ管理メニュー)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 19)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Master manage menu"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(65, 115)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(321, 40)
        Me.Panel2.TabIndex = 123
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnd.BackColor = System.Drawing.SystemColors.Control
        Me.btnEnd.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnd.Location = New System.Drawing.Point(1238, 59)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(100, 49)
        Me.btnEnd.TabIndex = 124
        Me.btnEnd.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'SC_M00
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.stsFooter)
        Me.Controls.Add(Me.grpHeader)
        Me.Name = "SC_M00"
        Me.Text = "[SC_MXX]Master manage menu(マスタ管理メニュー) Ver.1.0.0"
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents TimeSys As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn13 As Button
    Friend WithEvents btn12 As Button
    Friend WithEvents btn10 As Button
    Friend WithEvents btn11 As Button
    Friend WithEvents btn01 As Button
    Friend WithEvents btn18 As Button
    Friend WithEvents btn17 As Button
    Friend WithEvents btn15 As Button
    Friend WithEvents btn16 As Button
    Friend WithEvents btn14 As Button
    Friend WithEvents btn22 As Button
    Friend WithEvents btn20 As Button
    Friend WithEvents btn19 As Button
    Friend WithEvents btnEnd As Button
End Class
