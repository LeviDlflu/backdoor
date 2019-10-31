Public Class SC_K00

    Private Const FORM_NAME As String = "My menu(仮マイメニュー)"

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K00_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    ''' 在庫照会と進捗管理
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frm As New SC_K00B()
        frm.ShowDialog()
        Me.Show()

    End Sub

    ''' <summary>
    ''' 実績参照
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim frm As New SC_K00A()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class
