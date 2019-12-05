<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SC_K16A
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SC_K16A))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtMoneyType = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbJudgment = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridData = New ProcessManagement.DataGridViewMerge()
        Me.lblSearchTime = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtWorkingFrom = New System.Windows.Forms.TextBox()
        Me.txtWorkingTo = New System.Windows.Forms.TextBox()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.Location = New System.Drawing.Point(15, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(117, 53)
        Me.btnSearch.TabIndex = 271
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtWorkingTo)
        Me.Panel4.Controls.Add(Me.txtWorkingFrom)
        Me.Panel4.Controls.Add(Me.txtMoneyType)
        Me.Panel4.Controls.Add(Me.txtProductName)
        Me.Panel4.Controls.Add(Me.txtEquipment)
        Me.Panel4.Controls.Add(Me.Label41)
        Me.Panel4.Controls.Add(Me.Label56)
        Me.Panel4.Controls.Add(Me.Label42)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Controls.Add(Me.Label39)
        Me.Panel4.Controls.Add(Me.Label59)
        Me.Panel4.Controls.Add(Me.Label60)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.cmbJudgment)
        Me.Panel4.Controls.Add(Me.Label53)
        Me.Panel4.Controls.Add(Me.Label54)
        Me.Panel4.Location = New System.Drawing.Point(-1, 125)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1353, 224)
        Me.Panel4.TabIndex = 297
        '
        'txtMoneyType
        '
        Me.txtMoneyType.BackColor = System.Drawing.SystemColors.Control
        Me.txtMoneyType.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.txtMoneyType.Location = New System.Drawing.Point(899, 170)
        Me.txtMoneyType.Name = "txtMoneyType"
        Me.txtMoneyType.ReadOnly = True
        Me.txtMoneyType.Size = New System.Drawing.Size(138, 21)
        Me.txtMoneyType.TabIndex = 335
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductName.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.txtProductName.Location = New System.Drawing.Point(506, 170)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(362, 21)
        Me.txtProductName.TabIndex = 334
        '
        'txtEquipment
        '
        Me.txtEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.txtEquipment.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.txtEquipment.Location = New System.Drawing.Point(318, 171)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.ReadOnly = True
        Me.txtEquipment.Size = New System.Drawing.Size(154, 21)
        Me.txtEquipment.TabIndex = 333
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(28, 135)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(74, 14)
        Me.Label41.TabIndex = 331
        Me.Label41.Text = "Work data"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(140, 174)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(21, 14)
        Me.Label56.TabIndex = 278
        Me.Label56.Text = "～"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label42.Location = New System.Drawing.Point(28, 153)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(57, 14)
        Me.Label42.TabIndex = 332
        Me.Label42.Text = "(作業日)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(896, 135)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 14)
        Me.Label36.TabIndex = 329
        Me.Label36.Text = "Mold"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label39.Location = New System.Drawing.Point(896, 153)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(43, 14)
        Me.Label39.TabIndex = 330
        Me.Label39.Text = "(金型)"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label59.Location = New System.Drawing.Point(503, 153)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(43, 14)
        Me.Label59.TabIndex = 321
        Me.Label59.Text = "(品名)"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label60.Location = New System.Drawing.Point(503, 135)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(61, 14)
        Me.Label60.TabIndex = 320
        Me.Label60.Text = "Product"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(315, 135)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(77, 14)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Equipment"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label43.Location = New System.Drawing.Point(315, 153)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(43, 14)
        Me.Label43.TabIndex = 306
        Me.Label43.Text = "(設備)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label44.Location = New System.Drawing.Point(31, 79)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(43, 14)
        Me.Label44.TabIndex = 305
        Me.Label44.Text = "(判定)"
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
        'cmbJudgment
        '
        Me.cmbJudgment.AutoCompleteCustomSource.AddRange(New String() {"01：Mﾊﾞｯｸﾄﾞｱ"})
        Me.cmbJudgment.BackColor = System.Drawing.Color.Yellow
        Me.cmbJudgment.FormattingEnabled = True
        Me.cmbJudgment.Location = New System.Drawing.Point(30, 101)
        Me.cmbJudgment.Name = "cmbJudgment"
        Me.cmbJudgment.Size = New System.Drawing.Size(165, 21)
        Me.cmbJudgment.TabIndex = 296
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label53.Location = New System.Drawing.Point(7, 8)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(162, 19)
        Me.Label53.TabIndex = 295
        Me.Label53.Text = "Search condition"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.Location = New System.Drawing.Point(28, 60)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(72, 14)
        Me.Label54.TabIndex = 297
        Me.Label54.Text = "Judgment"
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
        Me.Panel1.Location = New System.Drawing.Point(-1, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1354, 311)
        Me.Panel1.TabIndex = 310
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
        Me.gridData.Size = New System.Drawing.Size(1272, 249)
        Me.gridData.TabIndex = 312
        '
        'lblSearchTime
        '
        Me.lblSearchTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearchTime.AutoSize = True
        Me.lblSearchTime.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.lblSearchTime.Location = New System.Drawing.Point(1185, 24)
        Me.lblSearchTime.Name = "lblSearchTime"
        Me.lblSearchTime.Size = New System.Drawing.Size(124, 14)
        Me.lblSearchTime.TabIndex = 310
        Me.lblSearchTime.Text = "yyyy/MM/dd hh:mm"
        '
        'Label65
        '
        Me.Label65.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label65.Location = New System.Drawing.Point(1043, 21)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(136, 19)
        Me.Label65.TabIndex = 308
        Me.Label65.Text = "Search time ："
        '
        'Label66
        '
        Me.Label66.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.Label66.Location = New System.Drawing.Point(1047, 44)
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
        'txtWorkingFrom
        '
        Me.txtWorkingFrom.Location = New System.Drawing.Point(31, 170)
        Me.txtWorkingFrom.Name = "txtWorkingFrom"
        Me.txtWorkingFrom.ReadOnly = True
        Me.txtWorkingFrom.Size = New System.Drawing.Size(100, 21)
        Me.txtWorkingFrom.TabIndex = 336
        '
        'txtWorkingTo
        '
        Me.txtWorkingTo.Location = New System.Drawing.Point(167, 170)
        Me.txtWorkingTo.Name = "txtWorkingTo"
        Me.txtWorkingTo.ReadOnly = True
        Me.txtWorkingTo.Size = New System.Drawing.Size(100, 21)
        Me.txtWorkingTo.TabIndex = 336
        '
        'SC_K16A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 689)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "SC_K16A"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
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

    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtMoneyType As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtEquipment As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents cmbJudgment As ComboBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridData As DataGridViewMerge
    Friend WithEvents lblSearchTime As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents txtWorkingTo As TextBox
    Friend WithEvents txtWorkingFrom As TextBox
End Class
