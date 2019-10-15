Public Class SC_MXX


    Private Sub SC_MXX_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn01.Text = "Parts configuration master" + Environment.NewLine + "部品構成マスタ(M-01)"
        btn10.Text = "Facility master" + Environment.NewLine + "設備マスタ(M-10)"
        btn11.Text = "Variety master" + Environment.NewLine + "品種マスタ(M-11)"
        btn12.Text = "Vehicle type master" + Environment.NewLine + "車種マスタ(M-12)"
        btn13.Text = "Defect phenomena master" + Environment.NewLine + "不良現象マスタ(M-13)"
        btn14.Text = "IP address manage master" + Environment.NewLine + "ＩＰアドレス管理マスタ(M-14)"
        btn15.Text = "Code master" + Environment.NewLine + "コードマスタ(M-15)"
        btn16.Text = "Authority master" + Environment.NewLine + "権限マスタ(M-16)"
        btn17.Text = "Employee master" + Environment.NewLine + "社員マスタ(M-17)"
        btn18.Text = "Assistance master" + Environment.NewLine + "補助マスタ(M-18)"
        btn19.Text = "Work table master" + Environment.NewLine + "勤務テーブルマスタ(M-19)"
        btn20.Text = "Customer calendar master" + Environment.NewLine + "顧客カレンダーマスタ(M-20)"
        'btn21.Text = "Message master" + Environment.NewLine + "メッセージマスタ(M-21)"
        btn22.Text = "Picking master" + Environment.NewLine + "採番マスタ(M-22)"

    End Sub


    ''' <summary>
    ''' １秒毎に発生するイベント
    ''' </summary>
    Private Sub TimeSys_Tick(sender As Object, e As EventArgs) Handles TimeSys.Tick
        slblDay.Text = Format(Now, "yyyy/MM/dd")
        slblTime.Text = Format(Now, "HH:mm")
    End Sub


    '' <summary>
    '' 部品構成マスタ(M-01)
    '' </summary>
    Private Sub btn01_Click(sender As Object, e As EventArgs) Handles btn01.Click
        'Dim frm As New SC_M01()
        'frm.ShowDialog()
        'Me.Show()
    End Sub

    '' <summary>
    '' 設備マスタ(M-10)
    '' </summary>
    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        Dim frm As New SC_M10()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 品種マスタ(M-11)
    '' </summary>
    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        Dim frm As New SC_M11()
        frm.ShowDialog()
        Me.Show()
    End Sub


    '' <summary>
    '' 車種マスタ(M-12)
    '' </summary>
    Private Sub btn12_Click(sender As Object, e As EventArgs) Handles btn12.Click
        Dim frm As New SC_M12()
        frm.ShowDialog()
        Me.Show()
    End Sub


    '' <summary>
    '' 不良現象マスタ(M-13)
    '' </summary>
    Private Sub btn13_Click(sender As Object, e As EventArgs) Handles btn13.Click
        Dim frm As New SC_M13()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' ＩＰアドレス管理マスタ(M-14)
    '' </summary>
    Private Sub btn14_Click(sender As Object, e As EventArgs) Handles btn14.Click
        Dim frm As New SC_M14()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' コードマスタ(M-15)
    '' </summary>
    Private Sub btn15_Click(sender As Object, e As EventArgs) Handles btn15.Click
        Dim frm As New SC_M15()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 権限マスタ(M-16)
    '' </summary>
    Private Sub btn16_Click(sender As Object, e As EventArgs) Handles btn16.Click
        Dim frm As New SC_M16()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 社員マスタ(M-17)
    '' </summary>
    Private Sub btn17_Click(sender As Object, e As EventArgs) Handles btn17.Click
        Dim frm As New SC_M17()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 補助マスタ(M-18)
    '' </summary>
    Private Sub btn18_Click(sender As Object, e As EventArgs) Handles btn18.Click
        Dim frm As New SC_M18()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 勤務テーブルマスタ(M-19)
    '' </summary>
    Private Sub btn19_Click(sender As Object, e As EventArgs) Handles btn19.Click
        Dim frm As New SC_M19()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' 顧客カレンダーマスタ(M-20)
    '' </summary>
    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        Dim frm As New SC_M20()
        frm.ShowDialog()
        Me.Show()
    End Sub

    '' <summary>
    '' メッセージマスタ(M-21)
    '' </summary>
    'Private Sub btn21_Click(sender As Object, e As EventArgs)
    '    'Dim frm As New SC_M21()
    '    'frm.ShowDialog()
    '    'Me.Show()
    'End Sub

    '' <summary>
    '' 採番マスタ(M-22)
    '' </summary>
    Private Sub btn22_Click(sender As Object, e As EventArgs) Handles btn22.Click
        Dim frm As New SC_M22()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ''' <summary>
    ''' 　終了ボタン押下
    ''' </summary>
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click

        If MsgBox("画面を閉じてよろしいですか？", vbOKCancel, "生産管理システム") Then
            Me.Close()
        End If

    End Sub





End Class