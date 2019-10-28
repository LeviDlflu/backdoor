<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SC_K21
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.title = New System.Windows.Forms.Label()
        Me.SearchTImeLabel = New System.Windows.Forms.Label()
        Me.SearchDateTime = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Finish = New System.Windows.Forms.Button()
        Me.Excel = New System.Windows.Forms.Button()
        Me.DESC = New System.Windows.Forms.Button()
        Me.ASC = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Process_type_summary = New System.Windows.Forms.Button()
        Me.Aggregation_product_name = New System.Windows.Forms.Button()
        Me.Total_by_process = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Withdrawa_lcategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Target_date = New System.Windows.Forms.DateTimePicker()
        Me.yeardate = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BottomDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.title.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.title.Location = New System.Drawing.Point(8, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(489, 43)
        Me.title.TabIndex = 0
        Me.title.Text = "その他払出入力伝票参照・取消"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SearchTImeLabel
        '
        Me.SearchTImeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchTImeLabel.AutoSize = True
        Me.SearchTImeLabel.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchTImeLabel.Location = New System.Drawing.Point(1031, 21)
        Me.SearchTImeLabel.Name = "SearchTImeLabel"
        Me.SearchTImeLabel.Size = New System.Drawing.Size(107, 22)
        Me.SearchTImeLabel.TabIndex = 1
        Me.SearchTImeLabel.Text = "検索時間:"
        '
        'SearchDateTime
        '
        Me.SearchDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchDateTime.AutoSize = True
        Me.SearchDateTime.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchDateTime.Location = New System.Drawing.Point(1144, 21)
        Me.SearchDateTime.Name = "SearchDateTime"
        Me.SearchDateTime.Size = New System.Drawing.Size(72, 22)
        Me.SearchDateTime.TabIndex = 2
        Me.SearchDateTime.Text = "Empty"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Finish)
        Me.Panel1.Controls.Add(Me.Excel)
        Me.Panel1.Controls.Add(Me.DESC)
        Me.Panel1.Controls.Add(Me.ASC)
        Me.Panel1.Controls.Add(Me.Cancel)
        Me.Panel1.Controls.Add(Me.Process_type_summary)
        Me.Panel1.Controls.Add(Me.Aggregation_product_name)
        Me.Panel1.Controls.Add(Me.Total_by_process)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(5, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1340, 92)
        Me.Panel1.TabIndex = 3
        '
        'Finish
        '
        Me.Finish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Finish.BackColor = System.Drawing.SystemColors.Control
        Me.Finish.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Finish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Finish.Location = New System.Drawing.Point(1235, 6)
        Me.Finish.Margin = New System.Windows.Forms.Padding(4)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(100, 80)
        Me.Finish.TabIndex = 14
        Me.Finish.Text = "Finish" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(終了)"
        Me.Finish.UseVisualStyleBackColor = False
        '
        'Excel
        '
        Me.Excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Excel.BackColor = System.Drawing.SystemColors.Control
        Me.Excel.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Excel.Location = New System.Drawing.Point(1134, 6)
        Me.Excel.Margin = New System.Windows.Forms.Padding(4)
        Me.Excel.Name = "Excel"
        Me.Excel.Size = New System.Drawing.Size(100, 80)
        Me.Excel.TabIndex = 13
        Me.Excel.Text = "EXCEL"
        Me.Excel.UseVisualStyleBackColor = False
        '
        'DESC
        '
        Me.DESC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DESC.BackColor = System.Drawing.SystemColors.Control
        Me.DESC.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DESC.Location = New System.Drawing.Point(1018, 6)
        Me.DESC.Margin = New System.Windows.Forms.Padding(4)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(100, 80)
        Me.DESC.TabIndex = 12
        Me.DESC.Text = "DESC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(降 順)"
        Me.DESC.UseVisualStyleBackColor = False
        '
        'ASC
        '
        Me.ASC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ASC.BackColor = System.Drawing.SystemColors.Control
        Me.ASC.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ASC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ASC.Location = New System.Drawing.Point(918, 6)
        Me.ASC.Margin = New System.Windows.Forms.Padding(4)
        Me.ASC.Name = "ASC"
        Me.ASC.Size = New System.Drawing.Size(100, 80)
        Me.ASC.TabIndex = 10
        Me.ASC.Text = "ASC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(昇 順)"
        Me.ASC.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cancel.Location = New System.Drawing.Point(803, 6)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(100, 80)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "Cancel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(取 消)"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process_type_summary
        '
        Me.Process_type_summary.BackColor = System.Drawing.SystemColors.Control
        Me.Process_type_summary.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Process_type_summary.Location = New System.Drawing.Point(568, 6)
        Me.Process_type_summary.Margin = New System.Windows.Forms.Padding(4)
        Me.Process_type_summary.Name = "Process_type_summary"
        Me.Process_type_summary.Size = New System.Drawing.Size(221, 80)
        Me.Process_type_summary.TabIndex = 11
        Me.Process_type_summary.Text = "Process type summary" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程品種別集計)"
        Me.Process_type_summary.UseVisualStyleBackColor = False
        '
        'Aggregation_product_name
        '
        Me.Aggregation_product_name.BackColor = System.Drawing.SystemColors.Control
        Me.Aggregation_product_name.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Aggregation_product_name.Location = New System.Drawing.Point(380, 6)
        Me.Aggregation_product_name.Margin = New System.Windows.Forms.Padding(4)
        Me.Aggregation_product_name.Name = "Aggregation_product_name"
        Me.Aggregation_product_name.Size = New System.Drawing.Size(188, 80)
        Me.Aggregation_product_name.TabIndex = 10
        Me.Aggregation_product_name.Text = "Aggregation by product name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(品名別集計)"
        Me.Aggregation_product_name.UseVisualStyleBackColor = False
        '
        'Total_by_process
        '
        Me.Total_by_process.BackColor = System.Drawing.SystemColors.Control
        Me.Total_by_process.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Total_by_process.Location = New System.Drawing.Point(192, 6)
        Me.Total_by_process.Margin = New System.Windows.Forms.Padding(4)
        Me.Total_by_process.Name = "Total_by_process"
        Me.Total_by_process.Size = New System.Drawing.Size(188, 80)
        Me.Total_by_process.TabIndex = 10
        Me.Total_by_process.Text = "Total by process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(工程別集計)"
        Me.Total_by_process.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(4, 6)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(188, 80)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(検  索)"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Withdrawa_lcategory)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Target_date)
        Me.Panel2.Controls.Add(Me.yeardate)
        Me.Panel2.Location = New System.Drawing.Point(5, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1340, 51)
        Me.Panel2.TabIndex = 4
        '
        'Withdrawa_lcategory
        '
        Me.Withdrawa_lcategory.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Withdrawa_lcategory.FormattingEnabled = True
        Me.Withdrawa_lcategory.Location = New System.Drawing.Point(733, 18)
        Me.Withdrawa_lcategory.Name = "Withdrawa_lcategory"
        Me.Withdrawa_lcategory.Size = New System.Drawing.Size(168, 26)
        Me.Withdrawa_lcategory.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(419, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Withdrawal category (払出区分)"
        '
        'Target_date
        '
        Me.Target_date.CalendarFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.CustomFormat = "yyyy/MM"
        Me.Target_date.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Target_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Target_date.Location = New System.Drawing.Point(247, 17)
        Me.Target_date.Name = "Target_date"
        Me.Target_date.Size = New System.Drawing.Size(166, 26)
        Me.Target_date.TabIndex = 1
        '
        'yeardate
        '
        Me.yeardate.AutoSize = True
        Me.yeardate.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.yeardate.Location = New System.Drawing.Point(16, 22)
        Me.yeardate.Name = "yeardate"
        Me.yeardate.Size = New System.Drawing.Size(215, 19)
        Me.yeardate.TabIndex = 0
        Me.yeardate.Text = "Target date (対象年月)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BottomDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(1178, 657)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(169, 25)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BottomDate
        '
        Me.BottomDate.Name = "BottomDate"
        Me.BottomDate.Size = New System.Drawing.Size(152, 20)
        Me.BottomDate.Text = "ToolStripStatusLabel1"
        '
        'Timer1
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 210)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1321, 444)
        Me.DataGridView1.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel3.Controls.Add(Me.title)
        Me.Panel3.Controls.Add(Me.SearchTImeLabel)
        Me.Panel3.Controls.Add(Me.SearchDateTime)
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1345, 58)
        Me.Panel3.TabIndex = 7
        '
        'SC_K21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 681)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SC_K21"
        Me.Text = "その他払出入力伝票参照・取消"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents title As Label
    Friend WithEvents SearchTImeLabel As Label
    Friend WithEvents SearchDateTime As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Target_date As DateTimePicker
    Friend WithEvents yeardate As Label
    Friend WithEvents Withdrawa_lcategory As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents Total_by_process As Button
    Friend WithEvents Process_type_summary As Button
    Friend WithEvents Aggregation_product_name As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents DESC As Button
    Friend WithEvents ASC As Button
    Friend WithEvents Excel As Button
    Friend WithEvents Finish As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BottomDate As ToolStripStatusLabel
End Class
