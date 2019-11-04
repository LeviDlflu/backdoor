<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K21B
    Inherits ProcessManagement.ParentTemplate

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K21B))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Withdrawal_category = New System.Windows.Forms.ComboBox()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ACS = New System.Windows.Forms.Button()
        Me.DESC = New System.Windows.Forms.Button()
        Me.Panel4.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Withdrawal_category)
        Me.Panel4.Controls.Add(Me.Target_date)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(0, 116)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1357, 65)
        Me.Panel4.TabIndex = 297
        '
        'Withdrawal_category
        '
        Me.Withdrawal_category.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Withdrawal_category.FormattingEnabled = True
        Me.Withdrawal_category.Location = New System.Drawing.Point(687, 12)
        Me.Withdrawal_category.Margin = New System.Windows.Forms.Padding(2)
        Me.Withdrawal_category.Name = "Withdrawal_category"
        Me.Withdrawal_category.Size = New System.Drawing.Size(112, 24)
        Me.Withdrawal_category.TabIndex = 298
        '
        'Target_date
        '
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(200, 13)
        Me.Target_date.Margin = New System.Windows.Forms.Padding(2)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(117, 23)
        Me.Target_date.TabIndex = 298
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(490, 20)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(104, 16)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Payment CD"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label43.Location = New System.Drawing.Point(600, 20)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(82, 16)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(受払区分)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(113, 20)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(82, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(対象年月)"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(3, 20)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(104, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Target date "
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(25, 239)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1285, 386)
        Me.gridData.TabIndex = 326
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label68.Location = New System.Drawing.Point(1107, 203)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(16, 16)
        Me.Label68.TabIndex = 325
        Me.Label68.Text = "："
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label67.Location = New System.Drawing.Point(1151, 203)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(144, 16)
        Me.Label67.TabIndex = 324
        Me.Label67.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(958, 200)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(118, 19)
        Me.Label65.TabIndex = 322
        Me.Label65.Text = "Search time"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(962, 221)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 323
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(-1, 188)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 320
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(3, 207)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 321
        Me.Label40.Text = "(検索結果)"
        '
        'ACS
        '
        Me.ACS.BackColor = System.Drawing.SystemColors.Control
        Me.ACS.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ACS.Location = New System.Drawing.Point(11, 62)
        Me.ACS.Margin = New System.Windows.Forms.Padding(2)
        Me.ACS.Name = "ACS"
        Me.ACS.Size = New System.Drawing.Size(100, 49)
        Me.ACS.TabIndex = 327
        Me.ACS.Text = "Asc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ACS.UseVisualStyleBackColor = False
        '
        'DESC
        '
        Me.DESC.BackColor = System.Drawing.SystemColors.Control
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.DESC.Location = New System.Drawing.Point(170, 61)
        Me.DESC.Margin = New System.Windows.Forms.Padding(2)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(100, 49)
        Me.DESC.TabIndex = 328
        Me.DESC.Text = "Desc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = False
        '
        'SC_K21B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1354, 659)
        Me.Controls.Add(Me.DESC)
        Me.Controls.Add(Me.ACS)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "SC_K21B"
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.gridData, 0)
        Me.Controls.SetChildIndex(Me.ACS, 0)
        Me.Controls.SetChildIndex(Me.DESC, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Withdrawal_category As ComboBox
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents Label68 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents ACS As Button
    Friend WithEvents DESC As Button
End Class
