Public Class CustomDateTimePicker
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox1.Text = DateTimePicker1.Text
    End Sub

    Private Sub CustomDateTimePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = DateTimePicker1.Text
    End Sub
End Class
