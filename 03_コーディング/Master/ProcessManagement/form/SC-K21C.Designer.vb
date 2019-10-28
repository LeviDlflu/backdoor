<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K21C
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
        Me.GridCtrl = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.Finish = New System.Windows.Forms.Button()
        Me.Withdrawal_category = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.grpHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridCtrl
        '
        Me.GridCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCtrl.Location = New System.Drawing.Point(5, 184)
        Me.GridCtrl.Name = "GridCtrl"
        Me.GridCtrl.RowTemplate.Height = 24
        Me.GridCtrl.Size = New System.Drawing.Size(922, 372)
        Me.GridCtrl.TabIndex = 11
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(762, 559)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(169, 25)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.Size = New System.Drawing.Size(152, 20)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        '
        'Timer1
        '
        '
        'grpHeader
        '
        Me.grpHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.grpHeader.Controls.Add(Me.Label6)
        Me.grpHeader.Controls.Add(Me.Label4)
        Me.grpHeader.Controls.Add(Me.Label5)
        Me.grpHeader.Controls.Add(Me.TextBox1)
        Me.grpHeader.Controls.Add(Me.txtLoginUser)
        Me.grpHeader.Location = New System.Drawing.Point(-2, -5)
        Me.grpHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Padding = New System.Windows.Forms.Padding(4)
        Me.grpHeader.Size = New System.Drawing.Size(935, 72)
        Me.grpHeader.TabIndex = 89
        Me.grpHeader.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(5, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(260, 34)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "工程品種別集計"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(479, 39)
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
        Me.Label5.Location = New System.Drawing.Point(482, 12)
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
        Me.TextBox1.Location = New System.Drawing.Point(770, 39)
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
        Me.txtLoginUser.Location = New System.Drawing.Point(770, 12)
        Me.txtLoginUser.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(159, 22)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'Finish
        '
        Me.Finish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Finish.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Finish.Location = New System.Drawing.Point(789, 77)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(105, 57)
        Me.Finish.TabIndex = 90
        Me.Finish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(完 了)"
        Me.Finish.UseVisualStyleBackColor = True
        '
        'Withdrawal_category
        '
        Me.Withdrawal_category.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Withdrawal_category.FormattingEnabled = True
        Me.Withdrawal_category.Location = New System.Drawing.Point(762, 149)
        Me.Withdrawal_category.Name = "Withdrawal_category"
        Me.Withdrawal_category.Size = New System.Drawing.Size(148, 28)
        Me.Withdrawal_category.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(439, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(295, 20)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Withdrawal category(払出区分)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 20)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Target date(対象年月)"
        '
        'Target_date
        '
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(253, 149)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(155, 27)
        Me.Target_date.TabIndex = 97
        '
        'SC_K21C
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 586)
        Me.Controls.Add(Me.Withdrawal_category)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Target_date)
        Me.Controls.Add(Me.Finish)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GridCtrl)
        Me.Name = "SC_K21C"
        Me.Text = "工程品種別集計"
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridCtrl As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BottomDate As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents Finish As Button
    Friend WithEvents Withdrawal_category As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Target_date As DateTimePicker
End Class
