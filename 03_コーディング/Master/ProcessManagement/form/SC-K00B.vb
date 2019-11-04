Public Class SC_K00B

    Private Const FORM_NAME As String = "Inventory inquiry and progress manage menu(在庫照会と進捗管理メニュー)"

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    Private Sub SC_K00B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    ''' 在庫照会(Z-01)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStockInquiry_Click(sender As Object, e As EventArgs) Handles btnStockInquiry.Click

        Dim frm As New SC_Z01()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 進捗管理(K-12)
    ''' </summary>
    Private Sub btnManagement_Click(sender As Object, e As EventArgs) Handles btnManagement.Click

        Dim frm As New SC_K12()
        frm.ShowDialog()
        Me.Show()

    End Sub
End Class
