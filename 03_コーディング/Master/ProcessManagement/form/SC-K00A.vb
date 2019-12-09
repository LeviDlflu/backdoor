Public Class SC_K00A

    Private Const FORM_NAME As String = "Achievement reference menu(実績参照メニュー)"
    Public Const FORM_NAME_K13 As String = "The results on today(当日実績参照)"
    Public Const FORM_NAME_K16 As String = "Molding achievement reference(成形実績参照)"
    Public Const FORM_NAME_K17 As String = "Defect analysis by mold(成形金型別不良分析)"


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
    Private Sub btnK13_Click(sender As Object, e As EventArgs) Handles btnK13.Click

        Dim frm As New SC_K13()
        frm.Text = "[K-13]" & FORM_NAME_K13
        frm.lblMaster.Text = FORM_NAME_K13
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 成形実績参照(K-16)
    ''' </summary>
    Private Sub btnK16_Click(sender As Object, e As EventArgs) Handles btnK16.Click

        Dim frm As New SC_K16()
        frm.Text = "[K-16]" & FORM_NAME_K16
        frm.lblMaster.Text = FORM_NAME_K16
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 成形金型別不良分析(K-17)
    ''' </summary>
    Private Sub btnK17_Click(sender As Object, e As EventArgs) Handles btnK17.Click

        Dim frm As New SC_K17()
        frm.Text = "[K-17]" & FORM_NAME_K17
        frm.lblMaster.Text = FORM_NAME_K17
        frm.ShowDialog()
        Me.Show()
    End Sub

End Class
