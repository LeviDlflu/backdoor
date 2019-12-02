Public Class SC_K00B

    Private Const FORM_NAME As String = "Inventory and progress menu(在庫照会と進捗管理メニュー)"
    Public Const FORM_NAME_Z01 As String = "Stock inquiry(在庫照会)"
    Private Const FORM_NAME_K12 As String = "Process progress management(工程進捗管理)"
    Public Const FORM_NAME_K20 As String = "Other issues(その他出庫)"
    Public Const FORM_NAME_K21 As String = "Other issues refer ・ cancel(その他出庫参照・取消)"

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
    ''' 進捗管理(K-12)
    ''' </summary>
    Private Sub btnK12_Click(sender As Object, e As EventArgs) Handles btnK12.Click

        Dim frm As New SC_K12()
        frm.Text = "[K-12]" & FORM_NAME_K12
        frm.lblMaster.Text = FORM_NAME_K12
        frm.ShowDialog()
        Me.Show()

    End Sub

    ''' <summary>
    ''' 在庫照会(Z-01)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnZ01_Click(sender As Object, e As EventArgs) Handles btnZ01.Click

        Dim frm As New SC_Z01()
        frm.Text = "[Z-01]" & FORM_NAME_Z01
        frm.lblMaster.Text = FORM_NAME_Z01
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' その他出庫(K-20)
    ''' </summary>
    Private Sub btnK20_Click(sender As Object, e As EventArgs) Handles btnK20.Click

        Dim frm As New SC_K20()
        frm.Text = "[K-20]" & FORM_NAME_K20
        frm.lblMaster.Text = FORM_NAME_K20
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' その他出庫参照・取消(K-21)
    ''' </summary>
    Private Sub btnK21_Click(sender As Object, e As EventArgs) Handles btnK21.Click

        Dim frm As New SC_K21()
        frm.Text = "[K-21]" & FORM_NAME_K21
        frm.lblMaster.Text = FORM_NAME_K21
        frm.ShowDialog()
        Me.Show()
    End Sub

End Class
