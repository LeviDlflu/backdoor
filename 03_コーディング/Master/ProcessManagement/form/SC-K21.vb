Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Public Class SC_K21
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Total_by_process.Click

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BottomDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    End Sub
End Class