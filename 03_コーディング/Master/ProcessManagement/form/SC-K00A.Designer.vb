<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K00A
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnK15 = New System.Windows.Forms.Button()
        Me.btnK19 = New System.Windows.Forms.Button()
        Me.btnK18 = New System.Windows.Forms.Button()
        Me.btnK17 = New System.Windows.Forms.Button()
        Me.btnK16 = New System.Windows.Forms.Button()
        Me.btnK14 = New System.Windows.Forms.Button()
        Me.btnK13 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox2.Controls.Add(Me.btnK15)
        Me.GroupBox2.Controls.Add(Me.btnK19)
        Me.GroupBox2.Controls.Add(Me.btnK18)
        Me.GroupBox2.Controls.Add(Me.btnK17)
        Me.GroupBox2.Controls.Add(Me.btnK16)
        Me.GroupBox2.Controls.Add(Me.btnK14)
        Me.GroupBox2.Controls.Add(Me.btnK13)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1318, 448)
        Me.GroupBox2.TabIndex = 272
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Achievement reference menu(実績参照メニュー)"
        '
        'btnK15
        '
        Me.btnK15.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK15.Location = New System.Drawing.Point(680, 66)
        Me.btnK15.Name = "btnK15"
        Me.btnK15.Size = New System.Drawing.Size(270, 53)
        Me.btnK15.TabIndex = 8
        Me.btnK15.Text = "  Achievement reference by period   期間別実績照会(K-15)"
        Me.btnK15.UseVisualStyleBackColor = True
        '
        'btnK19
        '
        Me.btnK19.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK19.Location = New System.Drawing.Point(680, 166)
        Me.btnK19.Name = "btnK19"
        Me.btnK19.Size = New System.Drawing.Size(270, 53)
        Me.btnK19.TabIndex = 5
        Me.btnK19.Text = "        Achievement management          実績管理(K-19)"
        Me.btnK19.UseVisualStyleBackColor = True
        '
        'btnK18
        '
        Me.btnK18.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK18.Location = New System.Drawing.Point(360, 166)
        Me.btnK18.Name = "btnK18"
        Me.btnK18.Size = New System.Drawing.Size(270, 53)
        Me.btnK18.TabIndex = 4
        Me.btnK18.Text = "    Assembly progress management     組立進度管理(K-18)"
        Me.btnK18.UseVisualStyleBackColor = True
        '
        'btnK17
        '
        Me.btnK17.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK17.Location = New System.Drawing.Point(40, 166)
        Me.btnK17.Name = "btnK17"
        Me.btnK17.Size = New System.Drawing.Size(270, 53)
        Me.btnK17.TabIndex = 3
        Me.btnK17.Text = "        Defect analysis by mold          成形金型別不良分析(K-17)"
        Me.btnK17.UseVisualStyleBackColor = True
        '
        'btnK16
        '
        Me.btnK16.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK16.Location = New System.Drawing.Point(1000, 66)
        Me.btnK16.Name = "btnK16"
        Me.btnK16.Size = New System.Drawing.Size(270, 53)
        Me.btnK16.TabIndex = 2
        Me.btnK16.Text = "    Molding achievement reference    成形実績参照(K-16)"
        Me.btnK16.UseVisualStyleBackColor = True
        '
        'btnK14
        '
        Me.btnK14.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK14.Location = New System.Drawing.Point(360, 66)
        Me.btnK14.Name = "btnK14"
        Me.btnK14.Size = New System.Drawing.Size(270, 53)
        Me.btnK14.TabIndex = 1
        Me.btnK14.Text = "The results before the previous days前日以前実績参照(K-14)"
        Me.btnK14.UseVisualStyleBackColor = True
        '
        'btnK13
        '
        Me.btnK13.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK13.Location = New System.Drawing.Point(40, 66)
        Me.btnK13.Name = "btnK13"
        Me.btnK13.Size = New System.Drawing.Size(270, 53)
        Me.btnK13.TabIndex = 0
        Me.btnK13.Text = "           The results on today              当日実績参照(K-13)"
        Me.btnK13.UseVisualStyleBackColor = True
        '
        'SC_K00A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "SC_K00A"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnK14 As Button
    Friend WithEvents btnK13 As Button
    Friend WithEvents btnK17 As Button
    Friend WithEvents btnK16 As Button
    Friend WithEvents btnK15 As Button
    Friend WithEvents btnK19 As Button
    Friend WithEvents btnK18 As Button
End Class
