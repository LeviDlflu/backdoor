Public Class SC_K20
    Private Const CONST_SYSTEM_NAME As String = "B/D生産管理システム"



    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub SC_K20_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

End Class