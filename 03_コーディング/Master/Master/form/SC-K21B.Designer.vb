<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K21B
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Back = New System.Windows.Forms.Button()
        Me.Print = New System.Windows.Forms.Button()
        Me.Withdrawal_category = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.DESC = New System.Windows.Forms.Button()
        Me.ACS = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GridCtrl = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(312, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "品名別集計"
        '
        'Back
        '
        Me.Back.Location = New System.Drawing.Point(123, 72)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(90, 27)
        Me.Back.TabIndex = 4
        Me.Back.Text = "戻　る"
        Me.Back.UseVisualStyleBackColor = True
        '
        'Print
        '
        Me.Print.Location = New System.Drawing.Point(24, 72)
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(90, 27)
        Me.Print.TabIndex = 3
        Me.Print.Text = "印　刷"
        Me.Print.UseVisualStyleBackColor = True
        '
        'Withdrawal_category
        '
        Me.Withdrawal_category.FormattingEnabled = True
        Me.Withdrawal_category.Location = New System.Drawing.Point(277, 112)
        Me.Withdrawal_category.Name = "Withdrawal_category"
        Me.Withdrawal_category.Size = New System.Drawing.Size(148, 23)
        Me.Withdrawal_category.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "払出区分"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "対象年月"
        '
        'Target_date
        '
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(93, 112)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(97, 22)
        Me.Target_date.TabIndex = 7
        '
        'DESC
        '
        Me.DESC.Location = New System.Drawing.Point(602, 109)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(90, 27)
        Me.DESC.TabIndex = 12
        Me.DESC.Text = "降  順"
        Me.DESC.UseVisualStyleBackColor = True
        '
        'ACS
        '
        Me.ACS.Location = New System.Drawing.Point(504, 109)
        Me.ACS.Name = "ACS"
        Me.ACS.Size = New System.Drawing.Size(90, 27)
        Me.ACS.TabIndex = 11
        Me.ACS.Text = "昇  順"
        Me.ACS.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(543, 531)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(169, 25)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.Size = New System.Drawing.Size(152, 20)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        Me.BottomDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        '
        'GridCtrl
        '
        Me.GridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCtrl.Location = New System.Drawing.Point(12, 142)
        Me.GridCtrl.Name = "GridCtrl"
        Me.GridCtrl.RowTemplate.Height = 24
        Me.GridCtrl.Size = New System.Drawing.Size(690, 386)
        Me.GridCtrl.TabIndex = 14
        '
        'SC_K21B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 553)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridCtrl)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DESC)
        Me.Controls.Add(Me.ACS)
        Me.Controls.Add(Me.Withdrawal_category)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Target_date)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.Print)
        Me.MaximumSize = New System.Drawing.Size(730, 600)
        Me.MinimumSize = New System.Drawing.Size(730, 600)
        Me.Name = "SC_K21B"
        Me.Text = "品名別集計"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Back As Button
    Friend WithEvents Print As Button
    Friend WithEvents Withdrawal_category As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents DESC As Button
    Friend WithEvents ACS As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GridCtrl As DataGridView
    Friend WithEvents BottomDate As ToolStripStatusLabel
End Class
