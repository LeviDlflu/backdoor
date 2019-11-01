<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K12A
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K12A))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDesc = New System.Windows.Forms.Button()
        Me.btnAsc = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cmb_Kbn = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(21, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 49)
        Me.btnSearch.TabIndex = 276
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnDesc
        '
        Me.btnDesc.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesc.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDesc.Location = New System.Drawing.Point(258, 61)
        Me.btnDesc.Name = "btnDesc"
        Me.btnDesc.Size = New System.Drawing.Size(100, 49)
        Me.btnDesc.TabIndex = 308
        Me.btnDesc.Text = "Desc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降順)"
        Me.btnDesc.UseVisualStyleBackColor = False
        '
        'btnAsc
        '
        Me.btnAsc.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsc.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAsc.Location = New System.Drawing.Point(141, 61)
        Me.btnAsc.Name = "btnAsc"
        Me.btnAsc.Size = New System.Drawing.Size(100, 49)
        Me.btnAsc.TabIndex = 309
        Me.btnAsc.Text = "Asc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇順)"
        Me.btnAsc.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TextBox3)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.cmb_Kbn)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(0, 116)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1357, 197)
        Me.Panel4.TabIndex = 310
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(39, 73)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(50, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(判定)"
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
        Me.Label53.Size = New System.Drawing.Size(145, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search criteria"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(36, 56)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(88, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Judgment "
        '
        'cmb_Kbn
        '
        Me.cmb_Kbn.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmb_Kbn.BackColor = System.Drawing.Color.Yellow
        Me.cmb_Kbn.FormattingEnabled = True
        Me.cmb_Kbn.Location = New System.Drawing.Point(39, 93)
        Me.cmb_Kbn.Name = "cmb_Kbn"
        Me.cmb_Kbn.Size = New System.Drawing.Size(136, 20)
        Me.cmb_Kbn.TabIndex = 311
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.TextBox1.Location = New System.Drawing.Point(39, 159)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(180, 21)
        Me.TextBox1.TabIndex = 313
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(36, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 311
        Me.Label1.Text = "Work number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(36, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 312
        Me.Label2.Text = "(作番)"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.TextBox2.Location = New System.Drawing.Point(344, 159)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(234, 21)
        Me.TextBox2.TabIndex = 316
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(341, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 16)
        Me.Label3.TabIndex = 314
        Me.Label3.Text = "Goods abbreviation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(341, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 315
        Me.Label4.Text = "(品名略称)"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.TextBox3.Location = New System.Drawing.Point(644, 159)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(81, 21)
        Me.TextBox3.TabIndex = 316
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(641, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Mold"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(641, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 315
        Me.Label6.Text = "(金型)"
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(31, 369)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1285, 263)
        Me.gridData.TabIndex = 319
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label68.Location = New System.Drawing.Point(1113, 333)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(16, 16)
        Me.Label68.TabIndex = 318
        Me.Label68.Text = "："
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label67.Location = New System.Drawing.Point(1157, 333)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(144, 16)
        Me.Label67.TabIndex = 317
        Me.Label67.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(964, 330)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(118, 19)
        Me.Label65.TabIndex = 315
        Me.Label65.Text = "Search time"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(968, 351)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 316
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(5, 318)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 313
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(9, 337)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 314
        Me.Label40.Text = "(検索結果)"
        '
        'SC_K12A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1354, 659)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnDesc)
        Me.Controls.Add(Me.btnAsc)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K12A"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnAsc, 0)
        Me.Controls.SetChildIndex(Me.btnDesc, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.gridData, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSearch As Button
    Friend WithEvents btnDesc As Button
    Friend WithEvents btnAsc As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents cmb_Kbn As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents Label68 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
End Class
