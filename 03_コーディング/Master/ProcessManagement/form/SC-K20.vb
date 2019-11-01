Public Class SC_K20

    Private Const FORM_NAME As String = "Other issues(その他出庫)"

    Private Sub SC_K20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMaster.Text = FORM_NAME
        Me.Text = "[" & Me.Name & "]" & FORM_NAME
    End Sub
End Class
