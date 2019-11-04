<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K21
    Inherits ProcessManagement.ParentTemplate

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K21))
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.DESC = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ASC = New System.Windows.Forms.Button()
        Me.Total_by_process = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Aggregation_product_name = New System.Windows.Forms.Button()
        Me.Process_type_summary = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmb_Syasyu = New System.Windows.Forms.ComboBox()
        Me.dtpWorkingYMD = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExcel.Location = New System.Drawing.Point(1055, 62)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(100, 49)
        Me.btnExcel.TabIndex = 277
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'DESC
        '
        Me.DESC.BackColor = System.Drawing.SystemColors.Control
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DESC.Location = New System.Drawing.Point(949, 61)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(100, 49)
        Me.DESC.TabIndex = 276
        Me.DESC.Text = "DESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(10, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 49)
        Me.btnSearch.TabIndex = 270
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検  索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'ASC
        '
        Me.ASC.BackColor = System.Drawing.SystemColors.Control
        Me.ASC.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ASC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ASC.Location = New System.Drawing.Point(843, 62)
        Me.ASC.Name = "ASC"
        Me.ASC.Size = New System.Drawing.Size(100, 49)
        Me.ASC.TabIndex = 271
        Me.ASC.Text = "ASC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ASC.UseVisualStyleBackColor = False
        '
        'Total_by_process
        '
        Me.Total_by_process.BackColor = System.Drawing.SystemColors.Control
        Me.Total_by_process.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Total_by_process.Location = New System.Drawing.Point(116, 61)
        Me.Total_by_process.Name = "Total_by_process"
        Me.Total_by_process.Size = New System.Drawing.Size(179, 49)
        Me.Total_by_process.TabIndex = 272
        Me.Total_by_process.Text = "Total by process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程別集計)"
        Me.Total_by_process.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cancel.Location = New System.Drawing.Point(737, 62)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(100, 49)
        Me.Cancel.TabIndex = 273
        Me.Cancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(取 消)"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Aggregation_product_name
        '
        Me.Aggregation_product_name.BackColor = System.Drawing.SystemColors.Control
        Me.Aggregation_product_name.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Aggregation_product_name.Location = New System.Drawing.Point(301, 62)
        Me.Aggregation_product_name.Name = "Aggregation_product_name"
        Me.Aggregation_product_name.Size = New System.Drawing.Size(179, 49)
        Me.Aggregation_product_name.TabIndex = 274
        Me.Aggregation_product_name.Text = "Total by product" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(品名別集計)"
        Me.Aggregation_product_name.UseVisualStyleBackColor = False
        '
        'Process_type_summary
        '
        Me.Process_type_summary.BackColor = System.Drawing.SystemColors.Control
        Me.Process_type_summary.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Process_type_summary.Location = New System.Drawing.Point(486, 62)
        Me.Process_type_summary.Name = "Process_type_summary"
        Me.Process_type_summary.Size = New System.Drawing.Size(245, 49)
        Me.Process_type_summary.TabIndex = 275
        Me.Process_type_summary.Text = "Total by process variety (工程品種別集計)"
        Me.Process_type_summary.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmb_Syasyu)
        Me.Panel4.Controls.Add(Me.dtpWorkingYMD)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(0, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1357, 128)
        Me.Panel4.TabIndex = 298
        '
        'cmb_Syasyu
        '
        Me.cmb_Syasyu.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmb_Syasyu.BackColor = System.Drawing.Color.Yellow
        Me.cmb_Syasyu.FormattingEnabled = True
        Me.cmb_Syasyu.Location = New System.Drawing.Point(325, 93)
        Me.cmb_Syasyu.Name = "cmb_Syasyu"
        Me.cmb_Syasyu.Size = New System.Drawing.Size(161, 20)
        Me.cmb_Syasyu.TabIndex = 311
        '
        'dtpWorkingYMD
        '
        Me.dtpWorkingYMD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpWorkingYMD.Location = New System.Drawing.Point(39, 93)
        Me.dtpWorkingYMD.Name = "dtpWorkingYMD"
        Me.dtpWorkingYMD.Size = New System.Drawing.Size(179, 21)
        Me.dtpWorkingYMD.TabIndex = 310
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(322, 56)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 16)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Variety"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label43.Location = New System.Drawing.Point(322, 73)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(50, 16)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(品種)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(39, 73)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(66, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(実績日)"
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
        Me.Label54.Size = New System.Drawing.Size(105, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Actual dates"
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(23, 307)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1285, 325)
        Me.gridData.TabIndex = 324
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label67.Location = New System.Drawing.Point(1149, 271)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(144, 16)
        Me.Label67.TabIndex = 323
        Me.Label67.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(956, 268)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(118, 19)
        Me.Label65.TabIndex = 321
        Me.Label65.Text = "Search time"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(960, 289)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 322
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(4, 256)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 319
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(6, 275)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 320
        Me.Label40.Text = "(検索結果)"
        '
        'SC_K21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1354, 659)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.DESC)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.ASC)
        Me.Controls.Add(Me.Total_by_process)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Aggregation_product_name)
        Me.Controls.Add(Me.Process_type_summary)
        Me.Name = "SC_K21"
        Me.Controls.SetChildIndex(Me.Process_type_summary, 0)
        Me.Controls.SetChildIndex(Me.Aggregation_product_name, 0)
        Me.Controls.SetChildIndex(Me.Cancel, 0)
        Me.Controls.SetChildIndex(Me.Total_by_process, 0)
        Me.Controls.SetChildIndex(Me.ASC, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.DESC, 0)
        Me.Controls.SetChildIndex(Me.btnExcel, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.gridData, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExcel As Button
    Friend WithEvents DESC As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents ASC As Button
    Friend WithEvents Total_by_process As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents Aggregation_product_name As Button
    Friend WithEvents Process_type_summary As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmb_Syasyu As ComboBox
    Friend WithEvents dtpWorkingYMD As DateTimePicker
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents Label67 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
End Class
