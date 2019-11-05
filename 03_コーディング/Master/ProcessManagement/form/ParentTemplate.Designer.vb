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
        Me.TimeSys = New System.Windows.Forms.Timer(Me.components)
        Me.slblMargin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsFooter = New System.Windows.Forms.StatusStrip()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.grpHead = New System.Windows.Forms.GroupBox()
        Me.lblEnvironment = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblMaster = New System.Windows.Forms.Label()
        Me.txbEnvironment = New System.Windows.Forms.TextBox()
        Me.txbLogin = New System.Windows.Forms.TextBox()
        Me.stsFooter.SuspendLayout()
        Me.grpHead.SuspendLayout()
        Me.SuspendLayout()
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
        Me.slblMargin.Size = New System.Drawing.Size(1438, 21)
        Me.slblMargin.Spring = True
        '
        'slblDay
        '
        Me.slblDay.AutoSize = False
        Me.slblDay.BackColor = System.Drawing.SystemColors.Control
        Me.slblDay.Name = "slblDay"
        Me.slblDay.Size = New System.Drawing.Size(75, 21)
        Me.slblDay.Text = "yyyy/MM/dd"
        Me.slblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'slblTime
        '
        Me.slblTime.AutoSize = False
        Me.slblTime.BackColor = System.Drawing.SystemColors.Control
        Me.slblTime.Name = "slblTime"
        Me.slblTime.Size = New System.Drawing.Size(45, 21)
        Me.slblTime.Text = "HH:mm"
        Me.slblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stsFooter
        '
        Me.stsFooter.BackColor = System.Drawing.SystemColors.Control
        Me.stsFooter.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsFooter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slblMargin, Me.slblDay, Me.slblTime})
        Me.stsFooter.Location = New System.Drawing.Point(0, 720)
        Me.stsFooter.Name = "stsFooter"
        Me.stsFooter.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.stsFooter.Size = New System.Drawing.Size(1575, 26)
        Me.stsFooter.SizingGrip = False
        Me.stsFooter.TabIndex = 234
        Me.stsFooter.Text = "StatusStrip1"
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.btnFinish.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnFinish.Location = New System.Drawing.Point(1436, 66)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(117, 53)
        Me.btnFinish.TabIndex = 269
        Me.btnFinish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.btnFinish.UseVisualStyleBackColor = False
        '
        'grpHead
        '
        Me.grpHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.grpHead.Controls.Add(Me.lblEnvironment)
        Me.grpHead.Controls.Add(Me.lblLogin)
        Me.grpHead.Controls.Add(Me.lblMaster)
        Me.grpHead.Controls.Add(Me.txbEnvironment)
        Me.grpHead.Controls.Add(Me.txbLogin)
        Me.grpHead.Location = New System.Drawing.Point(-2, -11)
        Me.grpHead.Name = "grpHead"
        Me.grpHead.Size = New System.Drawing.Size(1581, 57)
        Me.grpHead.TabIndex = 267
        Me.grpHead.TabStop = False
        '
        'lblEnvironment
        '
        Me.lblEnvironment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnvironment.AutoSize = True
        Me.lblEnvironment.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.lblEnvironment.ForeColor = System.Drawing.Color.White
        Me.lblEnvironment.Location = New System.Drawing.Point(1188, 35)
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
        Me.lblLogin.Location = New System.Drawing.Point(1284, 13)
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
        Me.lblMaster.Location = New System.Drawing.Point(7, 16)
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
        Me.txbEnvironment.Location = New System.Drawing.Point(1437, 33)
        Me.txbEnvironment.Name = "txbEnvironment"
        Me.txbEnvironment.ReadOnly = True
        Me.txbEnvironment.Size = New System.Drawing.Size(139, 19)
        Me.txbEnvironment.TabIndex = 5
        Me.txbEnvironment.TabStop = False
        Me.txbEnvironment.Text = "本番環境"
        '
        'txbLogin
        '
        Me.txbLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txbLogin.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txbLogin.Location = New System.Drawing.Point(1437, 11)
        Me.txbLogin.Name = "txbLogin"
        Me.txbLogin.Size = New System.Drawing.Size(139, 19)
        Me.txbLogin.TabIndex = 4
        Me.txbLogin.TabStop = False
        Me.txbLogin.Text = "ログインユーザ"
        '
        'ParentTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1575, 746)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.grpHead)
        Me.Controls.Add(Me.stsFooter)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "ParentTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "B／D生産管理システム"
        Me.stsFooter.ResumeLayout(False)
        Me.stsFooter.PerformLayout()
        Me.grpHead.ResumeLayout(False)
        Me.grpHead.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimeSys As Timer
    Friend WithEvents slblMargin As ToolStripStatusLabel
    Friend WithEvents slblDay As ToolStripStatusLabel
    Friend WithEvents slblTime As ToolStripStatusLabel
    Friend WithEvents stsFooter As StatusStrip
    Friend WithEvents btnFinish As Button
    Friend WithEvents grpHead As GroupBox
    Friend WithEvents lblEnvironment As Label
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblMaster As Label
    Friend WithEvents txbEnvironment As TextBox
    Friend WithEvents txbLogin As TextBox
End Class
