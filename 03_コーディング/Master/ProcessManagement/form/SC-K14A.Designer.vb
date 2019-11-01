<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K14A
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K14A))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDesc = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtJudgmentClassification = New System.Windows.Forms.TextBox()
        Me.txtJudgmentCategory = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(291, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 49)
        Me.Button1.TabIndex = 272
        Me.Button1.Text = "Desc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降順)"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnDesc
        '
        Me.btnDesc.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesc.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnDesc.Location = New System.Drawing.Point(24, 61)
        Me.btnDesc.Name = "btnDesc"
        Me.btnDesc.Size = New System.Drawing.Size(100, 49)
        Me.btnDesc.TabIndex = 271
        Me.btnDesc.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnDesc.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.Location = New System.Drawing.Point(157, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 49)
        Me.btnSearch.TabIndex = 270
        Me.btnSearch.Text = "Asｃ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇順)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtJudgmentClassification)
        Me.Panel4.Controls.Add(Me.txtJudgmentCategory)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(-1, 116)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1357, 135)
        Me.Panel4.TabIndex = 296
        '
        'txtJudgmentClassification
        '
        Me.txtJudgmentClassification.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtJudgmentClassification.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.txtJudgmentClassification.Location = New System.Drawing.Point(298, 92)
        Me.txtJudgmentClassification.Name = "txtJudgmentClassification"
        Me.txtJudgmentClassification.ReadOnly = True
        Me.txtJudgmentClassification.Size = New System.Drawing.Size(180, 21)
        Me.txtJudgmentClassification.TabIndex = 308
        '
        'txtJudgmentCategory
        '
        Me.txtJudgmentCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtJudgmentCategory.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.txtJudgmentCategory.Location = New System.Drawing.Point(39, 92)
        Me.txtJudgmentCategory.Name = "txtJudgmentCategory"
        Me.txtJudgmentCategory.ReadOnly = True
        Me.txtJudgmentCategory.Size = New System.Drawing.Size(180, 21)
        Me.txtJudgmentCategory.TabIndex = 307
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(295, 56)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(187, 16)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Judgment classification"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label43.Location = New System.Drawing.Point(295, 73)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(82, 16)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(判定分類)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(39, 73)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(82, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(判定区分)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label45.Location = New System.Drawing.Point(8, 32)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 19)
        Me.Label45.TabIndex = 304
        Me.Label45.Text = "(検索条件)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(3, 13)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(162, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search condition"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(36, 56)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(155, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Judgment category"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.gridData)
        Me.Panel1.Controls.Add(Me.Label68)
        Me.Panel1.Controls.Add(Me.Label67)
        Me.Panel1.Controls.Add(Me.Label65)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Location = New System.Drawing.Point(-1, 251)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1357, 381)
        Me.Panel1.TabIndex = 308
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(32, 54)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1285, 324)
        Me.gridData.TabIndex = 312
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label68.Location = New System.Drawing.Point(1114, 18)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(16, 16)
        Me.Label68.TabIndex = 311
        Me.Label68.Text = "："
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label67.Location = New System.Drawing.Point(1158, 18)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(144, 16)
        Me.Label67.TabIndex = 310
        Me.Label67.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(965, 15)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(118, 19)
        Me.Label65.TabIndex = 308
        Me.Label65.Text = "Search time"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(969, 36)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 309
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(6, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 306
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(10, 22)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 307
        Me.Label40.Text = "(検索結果)"
        '
        'SC_K14A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1354, 659)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDesc)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K14A"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnDesc, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents btnDesc As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtJudgmentClassification As TextBox
    Friend WithEvents txtJudgmentCategory As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents Label68 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
End Class
