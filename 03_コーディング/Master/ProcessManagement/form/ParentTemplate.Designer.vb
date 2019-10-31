<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ParentTemplate
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEnvironment = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblMaster = New System.Windows.Forms.Label()
        Me.txbEnvironment = New System.Windows.Forms.TextBox()
        Me.txbLogin = New System.Windows.Forms.TextBox()
        Me.TimeSys = New System.Windows.Forms.Timer(Me.components)
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.stsFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.lblEnvironment)
        Me.GroupBox1.Controls.Add(Me.lblLogin)
        Me.GroupBox1.Controls.Add(Me.lblMaster)
        Me.GroupBox1.Controls.Add(Me.txbEnvironment)
        Me.GroupBox1.Controls.Add(Me.txbLogin)
        Me.GroupBox1.Location = New System.Drawing.Point(-2, -10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1359, 53)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        '
        'lblEnvironment
        '
        Me.lblEnvironment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnvironment.AutoSize = True
        Me.lblEnvironment.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.lblEnvironment.ForeColor = System.Drawing.Color.White
        Me.lblEnvironment.Location = New System.Drawing.Point(1022, 32)
        Me.lblEnvironment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblEnvironment.Name = "lblEnvironment"
        Me.lblEnvironment.Size = New System.Drawing.Size(208, 13)
        Me.lblEnvironment.TabIndex = 6
        Me.lblEnvironment.Text = "Connection environment(接続環境)"
        Me.lblEnvironment.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblLogin
        '
        Me.lblLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.lblLogin.ForeColor = System.Drawing.Color.White
        Me.lblLogin.Location = New System.Drawing.Point(1105, 12)
        Me.lblLogin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(125, 13)
        Me.lblLogin.TabIndex = 4
        Me.lblLogin.Text = "Login user(ログイン者)"
        Me.lblLogin.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblMaster
        '
        Me.lblMaster.AutoSize = True
        Me.lblMaster.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblMaster.ForeColor = System.Drawing.Color.White
        Me.lblMaster.Location = New System.Drawing.Point(6, 15)
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.Size = New System.Drawing.Size(253, 33)
        Me.lblMaster.TabIndex = 1
        Me.lblMaster.Text = "Parent Template"
        Me.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbEnvironment
        '
        Me.txbEnvironment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbEnvironment.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txbEnvironment.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txbEnvironment.Location = New System.Drawing.Point(1236, 30)
        Me.txbEnvironment.Name = "txbEnvironment"
        Me.txbEnvironment.ReadOnly = True
        Me.txbEnvironment.Size = New System.Drawing.Size(120, 19)
        Me.txbEnvironment.TabIndex = 5
        Me.txbEnvironment.TabStop = False
        Me.txbEnvironment.Text = "本番環境"
        '
        'txbLogin
        '
        Me.txbLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txbLogin.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txbLogin.Location = New System.Drawing.Point(1236, 10)
        Me.txbLogin.Name = "txbLogin"
        Me.txbLogin.Size = New System.Drawing.Size(120, 19)
        Me.txbLogin.TabIndex = 4
        Me.txbLogin.TabStop = False
        Me.txbLogin.Text = "ログインユーザ"
        '
        'TimeSys
        '
        Me.TimeSys.Enabled = True
        Me.TimeSys.Interval = 1000
        '
        'slblMargin
        '
        Me.slblMargin.BackColor = System.Drawing.SystemColors.Control
        Me.slblMargin.Name = "slblMargin"
        Me.slblMargin.Size = New System.Drawing.Size(1219, 19)
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
        'stsFooter
        '
        Me.stsFooter.BackColor = System.Drawing.SystemColors.Control
        Me.stsFooter.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsFooter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slblMargin, Me.slblDay, Me.slblTime})
        Me.stsFooter.Location = New System.Drawing.Point(0, 635)
        Me.stsFooter.Name = "stsFooter"
        Me.stsFooter.Size = New System.Drawing.Size(1354, 24)
        Me.stsFooter.SizingGrip = False
        Me.stsFooter.TabIndex = 234
        Me.stsFooter.Text = "StatusStrip1"
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.btnFinish.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnFinish.Location = New System.Drawing.Point(1234, 61)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(100, 49)
        Me.btnFinish.TabIndex = 269
        Me.btnFinish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnFinish.UseVisualStyleBackColor = False
        '
        'ParentTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1354, 659)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stsFooter)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ParentTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "[ParentTemplate]生産管理システム"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblEnvironment As Label
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblMaster As Label
    Friend WithEvents txbEnvironment As TextBox
    Friend WithEvents txbLogin As TextBox
    Friend WithEvents TimeSys As Timer
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents btnFinish As Button
End Class
