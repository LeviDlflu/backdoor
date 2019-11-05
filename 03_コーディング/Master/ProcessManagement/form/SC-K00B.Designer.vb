<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K00B
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
        Me.btnStockInquiry = New System.Windows.Forms.Button()
        Me.btnManagement = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox2.Controls.Add(Me.btnStockInquiry)
        Me.GroupBox2.Controls.Add(Me.btnManagement)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1318, 443)
        Me.GroupBox2.TabIndex = 271
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inventory inquiry and progress manage menu(在庫照会と進捗管理メニュー)"
        '
        'btnStockInquiry
        '
        Me.btnStockInquiry.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnStockInquiry.Location = New System.Drawing.Point(396, 66)
        Me.btnStockInquiry.Name = "btnStockInquiry"
        Me.btnStockInquiry.Size = New System.Drawing.Size(270, 53)
        Me.btnStockInquiry.TabIndex = 1
        Me.btnStockInquiry.Text = "               Stock inquiry                  在庫照会(Z-01)"
        Me.btnStockInquiry.UseVisualStyleBackColor = True
        '
        'btnManagement
        '
        Me.btnManagement.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnManagement.Location = New System.Drawing.Point(40, 66)
        Me.btnManagement.Name = "btnManagement"
        Me.btnManagement.Size = New System.Drawing.Size(270, 53)
        Me.btnManagement.TabIndex = 0
        Me.btnManagement.Text = "          Progress management          進捗管理(K-12)"
        Me.btnManagement.UseVisualStyleBackColor = True
        '
        'SC_K00B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "SC_K00B"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnManagement As Button
    Friend WithEvents btnStockInquiry As Button
End Class
