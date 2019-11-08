Imports System.Runtime.InteropServices

Public Class ParentTemplate

    Private Const CONST_SYSTEM_NAME As String = "B／D生産管理システム"

    Structure Parameter
        ''' <summary>
        ''' 工程
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim Process As String

        ''' <summary>
        ''' 部品番号
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim PartNumber As String

        ''' <summary>
        ''' 品名略称
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim ProductName As String

        ''' <summary>
        ''' パック品名略称
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim PackProductName As String

        ''' <summary>
        ''' 納入先コード
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim DeliveryCode As String

        ''' <summary>
        ''' 納入区分
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim DeliveryDivision As String

        ''' <summary>
        ''' 製品半製品区分
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim SemiFinishedProductDivision As String

        ''' <summary>
        ''' 品名事業所コード
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Dim ProductNamePlantCode As String

    End Structure

    Public Shared formParameter As New Parameter

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