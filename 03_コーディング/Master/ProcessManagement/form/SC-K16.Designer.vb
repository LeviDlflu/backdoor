﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K16
    Inherits ProcessManagement.ParentTemplate

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K16))
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbMold = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.chkSimilar = New System.Windows.Forms.CheckBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.cmbProduct = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbActualMonth = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.dtpActualTo = New ProcessManagement.CustomDateTimePicker()
        Me.dtpActualFrom = New ProcessManagement.CustomDateTimePicker()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rdoRange = New System.Windows.Forms.RadioButton()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cmbVariety = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbEquipment = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.lblSearchTime = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnExcel.Location = New System.Drawing.Point(138, 66)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(117, 53)
        Me.btnExcel.TabIndex = 271
        Me.btnExcel.Text = "Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(エクセル)"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.Location = New System.Drawing.Point(15, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 53)
        Me.btnSearch.TabIndex = 270
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmbMold)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Controls.Add(Me.Label39)
        Me.Panel4.Controls.Add(Me.Label35)
        Me.Panel4.Controls.Add(Me.Label64)
        Me.Panel4.Controls.Add(Me.chkSimilar)
        Me.Panel4.Controls.Add(Me.Label59)
        Me.Panel4.Controls.Add(Me.cmbProduct)
        Me.Panel4.Controls.Add(Me.Label60)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.cmbVariety)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.cmbEquipment)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(-1, 126)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1354, 220)
        Me.Panel4.TabIndex = 296
        '
        'cmbMold
        '
        Me.cmbMold.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbMold.BackColor = System.Drawing.Color.White
        Me.cmbMold.FormattingEnabled = True
        Me.cmbMold.Location = New System.Drawing.Point(1074, 82)
        Me.cmbMold.Name = "cmbMold"
        Me.cmbMold.Size = New System.Drawing.Size(167, 21)
        Me.cmbMold.TabIndex = 328
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(1071, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 14)
        Me.Label36.TabIndex = 329
        Me.Label36.Text = "Mold"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label39.Location = New System.Drawing.Point(1071, 65)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(43, 14)
        Me.Label39.TabIndex = 330
        Me.Label39.Text = "(金型)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label35.Location = New System.Drawing.Point(18, 198)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(1126, 14)
        Me.Label35.TabIndex = 327
        Me.Label35.Text = "Note 2) Pass rate: Pass quantity / Shot quantity, Failure rate: (Failure quantity" &
    " + Adjustment quantity) / Shot quantity [注2)合格率：合格数÷ショット数、 不良率：(不良数＋調整数)÷ショット数]"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label64.Location = New System.Drawing.Point(19, 177)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(574, 14)
        Me.Label64.TabIndex = 326
        Me.Label64.Text = "Note 1) You can see the results up to the previous day.[注1)前日までの実績を見ることができます。]"
        '
        'chkSimilar
        '
        Me.chkSimilar.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.chkSimilar.Location = New System.Drawing.Point(788, 106)
        Me.chkSimilar.Name = "chkSimilar"
        Me.chkSimilar.Size = New System.Drawing.Size(400, 37)
        Me.chkSimilar.TabIndex = 324
        Me.chkSimilar.Text = "* Similar search(Search for product names start with entered)※類似検索(入力した文字で始まる品名を検" &
    "索)"
        Me.chkSimilar.UseVisualStyleBackColor = True
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label59.Location = New System.Drawing.Point(517, 125)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(43, 14)
        Me.Label59.TabIndex = 321
        Me.Label59.Text = "(品名)"
        '
        'cmbProduct
        '
        Me.cmbProduct.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbProduct.BackColor = System.Drawing.Color.White
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(517, 143)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(724, 21)
        Me.cmbProduct.TabIndex = 319
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label60.Location = New System.Drawing.Point(517, 106)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(61, 14)
        Me.Label60.TabIndex = 320
        Me.Label60.Text = "Product"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmbActualMonth)
        Me.Panel3.Controls.Add(Me.Label56)
        Me.Panel3.Controls.Add(Me.dtpActualTo)
        Me.Panel3.Controls.Add(Me.dtpActualFrom)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Controls.Add(Me.rdoRange)
        Me.Panel3.Controls.Add(Me.Label55)
        Me.Panel3.Controls.Add(Me.Label47)
        Me.Panel3.Location = New System.Drawing.Point(18, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(469, 102)
        Me.Panel3.TabIndex = 315
        '
        'cmbActualMonth
        '
        Me.cmbActualMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cmbActualMonth.FormattingEnabled = True
        Me.cmbActualMonth.Location = New System.Drawing.Point(139, 75)
        Me.cmbActualMonth.Name = "cmbActualMonth"
        Me.cmbActualMonth.Size = New System.Drawing.Size(121, 21)
        Me.cmbActualMonth.TabIndex = 334
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(284, 32)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(21, 14)
        Me.Label56.TabIndex = 278
        Me.Label56.Text = "～"
        '
        'dtpActualTo
        '
        Me.dtpActualTo.BackColor = System.Drawing.SystemColors.Window
        Me.dtpActualTo.Location = New System.Drawing.Point(307, 28)
        Me.dtpActualTo.Name = "dtpActualTo"
        Me.dtpActualTo.Size = New System.Drawing.Size(145, 21)
        Me.dtpActualTo.TabIndex = 332
        '
        'dtpActualFrom
        '
        Me.dtpActualFrom.BackColor = System.Drawing.SystemColors.Window
        Me.dtpActualFrom.Location = New System.Drawing.Point(139, 28)
        Me.dtpActualFrom.Name = "dtpActualFrom"
        Me.dtpActualFrom.Size = New System.Drawing.Size(150, 21)
        Me.dtpActualFrom.TabIndex = 331
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(27, 75)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(89, 18)
        Me.RadioButton2.TabIndex = 275
        Me.RadioButton2.Text = "(過去検索)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rdoRange
        '
        Me.rdoRange.AutoSize = True
        Me.rdoRange.Checked = True
        Me.rdoRange.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.rdoRange.Location = New System.Drawing.Point(27, 28)
        Me.rdoRange.Name = "rdoRange"
        Me.rdoRange.Size = New System.Drawing.Size(89, 18)
        Me.rdoRange.TabIndex = 274
        Me.rdoRange.TabStop = True
        Me.rdoRange.Text = "(範囲検索)"
        Me.rdoRange.UseVisualStyleBackColor = True
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label55.Location = New System.Drawing.Point(43, 9)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(98, 14)
        Me.Label55.TabIndex = 273
        Me.Label55.Text = "Range search"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.Location = New System.Drawing.Point(43, 56)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(88, 14)
        Me.Label47.TabIndex = 272
        Me.Label47.Text = "Past search"
        '
        'cmbVariety
        '
        Me.cmbVariety.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbVariety.BackColor = System.Drawing.Color.White
        Me.cmbVariety.FormattingEnabled = True
        Me.cmbVariety.Location = New System.Drawing.Point(788, 82)
        Me.cmbVariety.Name = "cmbVariety"
        Me.cmbVariety.Size = New System.Drawing.Size(226, 21)
        Me.cmbVariety.TabIndex = 300
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(785, 48)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(57, 14)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Variety"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label43.Location = New System.Drawing.Point(785, 65)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(43, 14)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(品種)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label44.Location = New System.Drawing.Point(517, 65)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(43, 14)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(設備)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label45.Location = New System.Drawing.Point(13, 28)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 19)
        Me.Label45.TabIndex = 304
        Me.Label45.Text = "(検索条件)"
        '
        'cmbEquipment
        '
        Me.cmbEquipment.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbEquipment.BackColor = System.Drawing.Color.White
        Me.cmbEquipment.FormattingEnabled = True
        Me.cmbEquipment.Location = New System.Drawing.Point(516, 82)
        Me.cmbEquipment.Name = "cmbEquipment"
        Me.cmbEquipment.Size = New System.Drawing.Size(203, 21)
        Me.cmbEquipment.TabIndex = 296
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(7, 8)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(145, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search criteria"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(517, 48)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(77, 14)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Equipment"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.gridData)
        Me.Panel1.Controls.Add(Me.lblSearchTime)
        Me.Panel1.Controls.Add(Me.Label65)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Location = New System.Drawing.Point(-2, 346)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1353, 316)
        Me.Panel1.TabIndex = 308
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(37, 59)
        Me.gridData.MergeColumnHeaderBackColor = System.Drawing.SystemColors.ControlDark
        Me.gridData.MergeColumnNames = CType(resources.GetObject("gridData.MergeColumnNames"), System.Collections.Generic.List(Of String))
        Me.gridData.Name = "gridData"
        Me.gridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.gridData.RowTemplate.Height = 23
        Me.gridData.Size = New System.Drawing.Size(1273, 254)
        Me.gridData.TabIndex = 312
        '
        'lblSearchTime
        '
        Me.lblSearchTime.AutoSize = True
        Me.lblSearchTime.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.lblSearchTime.Location = New System.Drawing.Point(1186, 24)
        Me.lblSearchTime.Name = "lblSearchTime"
        Me.lblSearchTime.Size = New System.Drawing.Size(124, 14)
        Me.lblSearchTime.TabIndex = 310
        Me.lblSearchTime.Text = "yyyy/MM/dd hh:mm"
        Me.lblSearchTime.Visible = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(1044, 22)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(136, 19)
        Me.Label65.TabIndex = 308
        Me.Label65.Text = "Search time ："
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label66.Location = New System.Drawing.Point(1048, 45)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(71, 14)
        Me.Label66.TabIndex = 309
        Me.Label66.Text = "(検索時間)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(7, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(142, 19)
        Me.Label38.TabIndex = 306
        Me.Label38.Text = "Search results"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.Label40.Location = New System.Drawing.Point(12, 24)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 19)
        Me.Label40.TabIndex = 307
        Me.Label40.Text = "(検索結果)"
        '
        'SC_K16
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K16"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnExcel, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExcel As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents chkSimilar As CheckBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label56 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents rdoRange As RadioButton
    Friend WithEvents Label55 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents lblSearchTime As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents dtpActualFrom As CustomDateTimePicker
    Friend WithEvents dtpActualTo As CustomDateTimePicker
    Friend WithEvents cmbActualMonth As ComboBox
    Friend WithEvents cmbMold As ComboBox
    Friend WithEvents cmbProduct As ComboBox
    Friend WithEvents cmbVariety As ComboBox
    Friend WithEvents cmbEquipment As ComboBox
End Class
