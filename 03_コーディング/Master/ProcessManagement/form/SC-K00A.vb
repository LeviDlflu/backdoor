Public Class SC_K00A

    Private Const FORM_NAME As String = "Achievement reference menu(実績参照メニュー)"
    Public Const FORM_NAME_K13 As String = "The results on today(当日実績参照)"
    Public Const FORM_NAME_K14 As String = "The results before the previous days(前日以前実績参照)"
    Public Const FORM_NAME_K16 As String = "Molding achievement reference(成形実績参照)"
    Public Const FORM_NAME_K17 As String = "Defect analysis by mold(成形金型別不良分析)"
    Public Const FORM_NAME_K20 As String = "Other issues(その他出庫)"
    Public Const FORM_NAME_K21 As String = "Other issues refer ・ cancel(その他出庫参照・取消)"

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K00A_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME

    End Sub

    ''' <summary>
    ''' GroupBox設定
    ''' </summary>
    Private Sub GroupBox2_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox2.Paint
        Dim gBox As GroupBox = sender
        e.Graphics.Clear(gBox.BackColor)
        e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Black, 7, 1)
        Dim vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font)
        e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 8, vSize.Height / 2)
        e.Graphics.DrawLine(Pens.Black, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2)
        e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 1, gBox.Height - 2)
        e.Graphics.DrawLine(Pens.Black, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2)
        e.Graphics.DrawLine(Pens.Black, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2)
    End Sub

    ''' <summary>
    ''' 当日実績参照(K-13)
    ''' </summary>
    Private Sub btnManagement_Click(sender As Object, e As EventArgs) Handles btnManagement.Click

        Dim frm As New SC_K13()
        frm.Text = "[K-13]" & FORM_NAME_K13
        frm.lblMaster.Text = FORM_NAME_K13
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 前日以前実績参照(K-14)
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frm As New SC_K14()
        frm.Text = "[K-14]" & FORM_NAME_K14
        frm.lblMaster.Text = FORM_NAME_K14
        frm.ShowDialog()
        Me.Show()

    End Sub

    ''' <summary>
    ''' 成形実績参照(K-16)
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim frm As New SC_K16()
        frm.Text = "[K-16]" & FORM_NAME_K16
        frm.lblMaster.Text = FORM_NAME_K16
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 成形金型別不良分析(K-17)
    ''' </summary>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim frm As New SC_K17()
        frm.Text = "[K-17]" & FORM_NAME_K17
        frm.lblMaster.Text = FORM_NAME_K17
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' その他出庫(K-20)
    ''' </summary>
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim frm As New SC_K20()
        frm.Text = "[K-20]" & FORM_NAME_K20
        frm.lblMaster.Text = FORM_NAME_K20
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' その他出庫参照・取消(K-21)
    ''' </summary>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim frm As New SC_K21()
        frm.Text = "[K-21]" & FORM_NAME_K21
        frm.lblMaster.Text = FORM_NAME_K21
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class
