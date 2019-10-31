Public Class ParentTemplate

    Private Const CONST_SYSTEM_NAME As String = "生産管理システム"

    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub

    Private Sub btnMenu0_Click(sender As Object, e As EventArgs) 
        btnMenu0Click()
    End Sub

    Private Sub btnMenu1_Click(sender As Object, e As EventArgs) 
        btnMenu1Click()
    End Sub

    Private Sub btnMenu2_Click(sender As Object, e As EventArgs) 
        btnMenu2Click()
    End Sub

    Private Sub btnMenu3_Click(sender As Object, e As EventArgs) 
        btnMenu3Click()
    End Sub

    Private Sub btnMenu4_Click(sender As Object, e As EventArgs) 
        btnMenu4Click()
    End Sub

    Private Sub btnMenu5_Click(sender As Object, e As EventArgs) 
        btnMenu5Click()
    End Sub

    Private Sub btnMenu6_Click(sender As Object, e As EventArgs) 
        btnMenu6Click()
    End Sub

    Private Sub btnMenu7_Click(sender As Object, e As EventArgs) 
        btnMenu7Click()
    End Sub

    Public Overridable Sub btnMenu0Click()

    End Sub
    Public Overridable Sub btnMenu1Click()

    End Sub
    Public Overridable Sub btnMenu2Click()

    End Sub
    Public Overridable Sub btnMenu3Click()

    End Sub
    Public Overridable Sub btnMenu4Click()

    End Sub
    Public Overridable Sub btnMenu5Click()

    End Sub
    Public Overridable Sub btnMenu6Click()

    End Sub
    Public Overridable Sub btnMenu7Click()

    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnMenu8_Click(sender As Object, e As EventArgs) Handles btnMenu8.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel + vbQuestion, CONST_SYSTEM_NAME) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub
End Class