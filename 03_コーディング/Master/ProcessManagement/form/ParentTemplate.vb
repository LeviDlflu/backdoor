Public Class ParentTemplate

    Private Const CONST_SYSTEM_NAME As String = "B／D生産管理システム"

    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnMenu8_Click(sender As Object, e As EventArgs) Handles btnFinish.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub ParentTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnFinish.Location = New Point(Me.Size.Width - 155, btnFinish.Location.Y)
        grpHead.Width = Me.Size.Width - 12
    End Sub
End Class