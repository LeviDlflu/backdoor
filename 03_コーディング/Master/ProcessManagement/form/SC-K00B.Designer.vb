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
        Me.btnK21 = New System.Windows.Forms.Button()
        Me.btnZ01 = New System.Windows.Forms.Button()
        Me.btnK20 = New System.Windows.Forms.Button()
        Me.btnK12 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox2.Controls.Add(Me.btnK21)
        Me.GroupBox2.Controls.Add(Me.btnZ01)
        Me.GroupBox2.Controls.Add(Me.btnK20)
        Me.GroupBox2.Controls.Add(Me.btnK12)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1318, 443)
        Me.GroupBox2.TabIndex = 271
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inventory and progress menu(在庫照会と進捗管理メニュー)"
        '
        'btnK21
        '
        Me.btnK21.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK21.Location = New System.Drawing.Point(1000, 66)
        Me.btnK21.Name = "btnK21"
        Me.btnK21.Size = New System.Drawing.Size(270, 53)
        Me.btnK21.TabIndex = 273
        Me.btnK21.Text = "        Other issues refer ・ cancel        その他出庫参照・取消(K-21)"
        Me.btnK21.UseVisualStyleBackColor = True
        '
        'btnZ01
        '
        Me.btnZ01.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnZ01.Location = New System.Drawing.Point(360, 66)
        Me.btnZ01.Name = "btnZ01"
        Me.btnZ01.Size = New System.Drawing.Size(270, 53)
        Me.btnZ01.TabIndex = 1
        Me.btnZ01.Text = "               Stock inquiry                  在庫照会(Z-01)"
        Me.btnZ01.UseVisualStyleBackColor = True
        '
        'btnK20
        '
        Me.btnK20.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK20.Location = New System.Drawing.Point(680, 66)
        Me.btnK20.Name = "btnK20"
        Me.btnK20.Size = New System.Drawing.Size(270, 53)
        Me.btnK20.TabIndex = 272
        Me.btnK20.Text = "                 Other issues                   " & Global.Microsoft.VisualBasic.ChrW(9) & "その他出庫(K-20)"
        Me.btnK20.UseVisualStyleBackColor = True
        '
        'btnK12
        '
        Me.btnK12.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnK12.Location = New System.Drawing.Point(40, 66)
        Me.btnK12.Name = "btnK12"
        Me.btnK12.Size = New System.Drawing.Size(270, 53)
        Me.btnK12.TabIndex = 0
        Me.btnK12.Text = "    Process progress management       進捗管理(K-12)"
        Me.btnK12.UseVisualStyleBackColor = True
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
    Friend WithEvents btnK12 As Button
    Friend WithEvents btnZ01 As Button
    Friend WithEvents btnK21 As Button
    Friend WithEvents btnK20 As Button
End Class
