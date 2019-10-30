<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K21B
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grpHeader = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.GridCtrl = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Finish = New System.Windows.Forms.Button()
        Me.DESC = New System.Windows.Forms.Button()
        Me.ACS = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Withdrawal_category = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SearchDateTime = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpHeader.SuspendLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grpHeader.Location = New System.Drawing.Point(-2, -4)
        Me.grpHeader.Name = "grpHeader"
        Me.grpHeader.Size = New System.Drawing.Size(1013, 58)
        Me.grpHeader.TabIndex = 83
        Me.grpHeader.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(4, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(381, 27)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Total by product (品名別集計)"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(671, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Connection environment(接続環境)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(674, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Login user(ログイン者)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(890, 31)
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
        Me.txtLoginUser.Location = New System.Drawing.Point(890, 10)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(120, 19)
        Me.txtLoginUser.TabIndex = 4
        Me.txtLoginUser.TabStop = False
        Me.txtLoginUser.Text = "ログインユーザ"
        '
        'GridCtrl
        '
        Me.GridCtrl.AllowUserToAddRows = False
        Me.GridCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCtrl.Location = New System.Drawing.Point(4, 198)
        Me.GridCtrl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GridCtrl.Name = "GridCtrl"
        Me.GridCtrl.RowTemplate.Height = 24
        Me.GridCtrl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCtrl.Size = New System.Drawing.Size(750, 323)
        Me.GridCtrl.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Finish)
        Me.Panel1.Controls.Add(Me.DESC)
        Me.Panel1.Controls.Add(Me.ACS)
        Me.Panel1.Location = New System.Drawing.Point(-2, 50)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 62)
        Me.Panel1.TabIndex = 97
        '
        'Finish
        '
        Me.Finish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Finish.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Finish.Location = New System.Drawing.Point(929, 8)
        Me.Finish.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(79, 46)
        Me.Finish.TabIndex = 97
        Me.Finish.Text = "Back" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(戻 る)"
        Me.Finish.UseVisualStyleBackColor = True
        '
        'DESC
        '
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DESC.Location = New System.Drawing.Point(101, 8)
        Me.DESC.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(79, 46)
        Me.DESC.TabIndex = 94
        Me.DESC.Text = "DESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = True
        '
        'ACS
        '
        Me.ACS.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ACS.Location = New System.Drawing.Point(8, 8)
        Me.ACS.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ACS.Name = "ACS"
        Me.ACS.Size = New System.Drawing.Size(79, 46)
        Me.ACS.TabIndex = 95
        Me.ACS.Text = "ASC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ACS.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Withdrawal_category)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Target_date)
        Me.Panel2.Location = New System.Drawing.Point(-2, 112)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1014, 43)
        Me.Panel2.TabIndex = 98
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(470, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 12)
        Me.Label8.TabIndex = 269
        Me.Label8.Text = "(受払区分)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 12)
        Me.Label3.TabIndex = 268
        Me.Label3.Text = "(対象年月)"
        '
        'Withdrawal_category
        '
        Me.Withdrawal_category.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Withdrawal_category.FormattingEnabled = True
        Me.Withdrawal_category.Location = New System.Drawing.Point(538, 6)
        Me.Withdrawal_category.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Withdrawal_category.Name = "Withdrawal_category"
        Me.Withdrawal_category.Size = New System.Drawing.Size(112, 24)
        Me.Withdrawal_category.TabIndex = 267
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(311, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 19)
        Me.Label1.TabIndex = 266
        Me.Label1.Text = "Payment division "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(4, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 19)
        Me.Label7.TabIndex = 265
        Me.Label7.Text = "Target date "
        '
        'Target_date
        '
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(185, 8)
        Me.Target_date.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(117, 23)
        Me.Target_date.TabIndex = 264
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(10, 0, 1, 0)
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1013, 20)
        Me.StatusStrip1.TabIndex = 273
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BottomDate.Size = New System.Drawing.Size(119, 15)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        Me.BottomDate.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(304, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 12)
        Me.Label12.TabIndex = 279
        Me.Label12.Text = "(検索時間)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(304, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 12)
        Me.Label11.TabIndex = 278
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(304, 162)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.MinimumSize = New System.Drawing.Size(112, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 19)
        Me.Label10.TabIndex = 277
        Me.Label10.Text = "Search time:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 12)
        Me.Label9.TabIndex = 276
        Me.Label9.Text = "(検索結果)"
        '
        'SearchDateTime
        '
        Me.SearchDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchDateTime.AutoSize = True
        Me.SearchDateTime.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchDateTime.Location = New System.Drawing.Point(428, 166)
        Me.SearchDateTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SearchDateTime.MinimumSize = New System.Drawing.Size(167, 16)
        Me.SearchDateTime.Name = "SearchDateTime"
        Me.SearchDateTime.Size = New System.Drawing.Size(167, 16)
        Me.SearchDateTime.TabIndex = 275
        Me.SearchDateTime.Text = "yyyy/MM/dd hh:mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(4, 162)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.MinimumSize = New System.Drawing.Size(167, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 19)
        Me.Label2.TabIndex = 274
        Me.Label2.Text = "Search results" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'SC_K21B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 551)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SearchDateTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpHeader)
        Me.Controls.Add(Me.GridCtrl)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MinimumSize = New System.Drawing.Size(1028, 590)
        Me.Name = "SC_K21B"
        Me.Text = "[K-21B]Total by product (品名別集計) Ver.1.0.0"
        Me.grpHeader.ResumeLayout(False)
        Me.grpHeader.PerformLayout()
        CType(Me.GridCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents grpHeader As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents GridCtrl As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DESC As Button
    Friend WithEvents ACS As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Finish As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BottomDate As ToolStripStatusLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Withdrawal_category As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents SearchDateTime As Label
    Friend WithEvents Label2 As Label
End Class
