<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K17
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K17))
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkSimilar = New System.Windows.Forms.CheckBox()
        Me.cmbProduct = New System.Windows.Forms.ComboBox()
        Me.cmbVariety = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdoMold = New System.Windows.Forms.RadioButton()
        Me.rdoProduct = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.lblSearchTime = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.griData = New ProcessManagement.DataGridViewMerge()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.griData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExcel.Location = New System.Drawing.Point(137, 66)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(117, 53)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(14, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 53)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.chkSimilar)
        Me.Panel4.Controls.Add(Me.cmbProduct)
        Me.Panel4.Controls.Add(Me.cmbVariety)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label35)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Controls.Add(Me.dtpDateTo)
        Me.Panel4.Controls.Add(Me.dtpDateFrom)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(-5, 131)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1370, 150)
        Me.Panel4.TabIndex = 297
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label11.Location = New System.Drawing.Point(669, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(376, 14)
        Me.Label11.TabIndex = 311
        Me.Label11.Text = " * Similar search (Search for product names start with entered)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(42, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(474, 14)
        Me.Label10.TabIndex = 311
        Me.Label10.Text = "Note 2) Rate : Failure reason total / mold total [注2)率：不良現象計 ÷ 金型計]"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label9.Location = New System.Drawing.Point(42, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(578, 14)
        Me.Label9.TabIndex = 314
        Me.Label9.Text = "Note 1) You can see the results up to the previous day. [注1)前日までの実績を見ることができます。]"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(669, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(276, 14)
        Me.Label8.TabIndex = 310
        Me.Label8.Text = "※類似検索(入力した文字で始まる品名を検索)"
        '
        'chkSimilar
        '
        Me.chkSimilar.AutoSize = True
        Me.chkSimilar.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkSimilar.Location = New System.Drawing.Point(652, 61)
        Me.chkSimilar.Name = "chkSimilar"
        Me.chkSimilar.Size = New System.Drawing.Size(15, 14)
        Me.chkSimilar.TabIndex = 9
        Me.chkSimilar.UseVisualStyleBackColor = True
        '
        'cmbProduct
        '
        Me.cmbProduct.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProduct.BackColor = System.Drawing.Color.White
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(534, 84)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(453, 21)
        Me.cmbProduct.TabIndex = 8
        '
        'cmbVariety
        '
        Me.cmbVariety.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbVariety.BackColor = System.Drawing.Color.White
        Me.cmbVariety.FormattingEnabled = True
        Me.cmbVariety.Location = New System.Drawing.Point(378, 84)
        Me.cmbVariety.Name = "cmbVariety"
        Me.cmbVariety.Size = New System.Drawing.Size(122, 21)
        Me.cmbVariety.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(531, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 307
        Me.Label1.Text = "Product name"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.Location = New System.Drawing.Point(182, 89)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(22, 14)
        Me.Label35.TabIndex = 312
        Me.Label35.Text = "～"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(534, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 308
        Me.Label2.Text = "(品名)"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.rdoMold)
        Me.GroupBox2.Controls.Add(Me.rdoProduct)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(1075, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(209, 88)
        Me.GroupBox2.TabIndex = 298
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Aggregate unit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(142, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 310
        Me.Label7.Text = "(品名)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(46, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "(金型)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(7, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 309
        Me.Label3.Text = "(集計単位)"
        '
        'rdoMold
        '
        Me.rdoMold.Checked = True
        Me.rdoMold.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.rdoMold.Location = New System.Drawing.Point(22, 50)
        Me.rdoMold.Name = "rdoMold"
        Me.rdoMold.Size = New System.Drawing.Size(16, 29)
        Me.rdoMold.TabIndex = 10
        Me.rdoMold.TabStop = True
        Me.rdoMold.UseVisualStyleBackColor = True
        '
        'rdoProduct
        '
        Me.rdoProduct.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.rdoProduct.Location = New System.Drawing.Point(120, 50)
        Me.rdoProduct.Name = "rdoProduct"
        Me.rdoProduct.Size = New System.Drawing.Size(22, 29)
        Me.rdoProduct.TabIndex = 11
        Me.rdoProduct.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 14)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Mold"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(140, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 14)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Product"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Location = New System.Drawing.Point(206, 84)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(135, 21)
        Me.dtpDateTo.TabIndex = 6
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Location = New System.Drawing.Point(45, 84)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(135, 21)
        Me.dtpDateFrom.TabIndex = 5
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(375, 46)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 16)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Variety"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label43.Location = New System.Drawing.Point(378, 64)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(50, 16)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(品種)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label44.Location = New System.Drawing.Point(45, 64)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(66, 16)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(実績日)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label45.Location = New System.Drawing.Point(9, 23)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 19)
        Me.Label45.TabIndex = 304
        Me.Label45.Text = "(検索条件)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(9, 4)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(162, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search condition"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(42, 46)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(105, 16)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Actual dates"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(5, 284)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 313
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(5, 303)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 314
        Me.Label40.Text = "(検索結果)"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label68.Location = New System.Drawing.Point(1173, 309)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(16, 16)
        Me.Label68.TabIndex = 330
        Me.Label68.Text = "："
        '
        'lblSearchTime
        '
        Me.lblSearchTime.AutoSize = True
        Me.lblSearchTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.lblSearchTime.Location = New System.Drawing.Point(1188, 309)
        Me.lblSearchTime.Name = "lblSearchTime"
        Me.lblSearchTime.Size = New System.Drawing.Size(144, 16)
        Me.lblSearchTime.TabIndex = 329
        Me.lblSearchTime.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(1060, 307)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(118, 19)
        Me.Label65.TabIndex = 327
        Me.Label65.Text = "Search time"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label66.Location = New System.Drawing.Point(1061, 329)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 16)
        Me.Label66.TabIndex = 328
        Me.Label66.Text = "(検索時間)"
        '
        'griData
        '
        Me.griData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griData.Location = New System.Drawing.Point(10, 348)
        Me.griData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control
        Me.griData.MergeColumnNames = CType(resources.GetObject("griData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.griData.Name = "griData"
        Me.griData.RowTemplate.Height = 23
        Me.griData.Size = New System.Drawing.Size(1320, 317)
        Me.griData.TabIndex = 331
        '
        'SC_K17
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.griData)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.lblSearchTime)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K17"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnExcel, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.lblSearchTime, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.griData, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.griData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExcel As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label35 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdoMold As RadioButton
    Friend WithEvents rdoProduct As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbVariety As ComboBox
    Friend WithEvents cmbProduct As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chkSimilar As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents lblSearchTime As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents griData As DataGridViewMerge
End Class
