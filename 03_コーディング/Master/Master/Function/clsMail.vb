Imports System.IO
Imports System.IO.Compression
Imports System.Configuration
Imports System.Net
Imports System.Net.Mail
Imports System
Imports System.Text
Imports System.Xml
Public Class clsMail
#Region "パブリック変数"
    'メールアドレス
    Public SENDTO() As String

    Public i As Integer

#End Region

    'コンストラクタ
    Public Sub New(ByVal p_MailAddPath As String, ByVal p_MailBodyPath As String, ByVal p_MailTitle As String, ByVal p_MailSendPtn As String, _
                   ByVal p_MailBody1 As String, ByVal p_MailBody2 As String, _
                   ByVal p_MailBody3 As String, ByVal p_MailBody4 As String, ByVal p_MailBody5 As String, ByVal p_MailSendType As String)

        GetMailAddPath = p_MailAddPath
        GetMailBodyPath = p_MailBodyPath
        GetMailTitle = p_MailTitle
        GetMailSendPtn = p_MailSendPtn
        GetZipPath = ""
        GetMailBody1 = p_MailBody1
        GetMailBody2 = p_MailBody2
        GetMailBody3 = p_MailBody3
        GetMailBody4 = p_MailBody4
        GetMailBody5 = p_MailBody5
        GetMailBody6 = ""
        GetMailSendType = p_MailSendType

    End Sub

#Region "メール送信"
    ''' <summary>
    ''' メール送信を行う
    ''' </summary>>
    ''' <returns>正常:true 異常:false</returns>
    ''' <remarks>メール送信を行う</remarks>
    Public Function Send_Mail() As Boolean

        Dim msg As New System.Net.Mail.MailMessage()
        'SmtpClientオブジェクトを作成する()
        Dim sc As New System.Net.Mail.SmtpClient()

        Try
            Send_Mail = False

            '宛先の取得
            If Send_To() = False Then
                clsLogTrace.GetInstance.TraceWrite("メールアドレスの取得に失敗しました。", ClsLogString.RunState.Err)
                Exit Function
            End If

            '宛先設定ないとき
            If IsNothing(SENDTO) Then
                clsLogTrace.GetInstance.TraceWrite("メールアドレスが未設定です。", ClsLogString.RunState.Err)
                Exit Function
            End If


            Dim senderMail As String '送信者

            '件名
            msg.Subject = GetMailTitle

            '送信者
            senderMail = My.Settings.MailSender
            msg.From = New System.Net.Mail.MailAddress(senderMail.Trim)

            'メッセージ本文
            Dim sr As New StreamReader(MailBodyPath, Encoding.GetEncoding("Shift_JIS"))
            Dim Bodymsg As String = sr.ReadToEnd()
            sr.Close()
            msg.Body = String.Format(Bodymsg, GetMailBody1, GetMailBody2, GetMailBody3, GetMailBody4, GetMailBody5, GetMailBody6)

            'ファイルの添付
            If ZipPath <> "" Then
                Dim attach1 As New System.Net.Mail.Attachment(ZipPath)
                msg.Attachments.Add(attach1)
            End If


            'SMTPサーバーを指定する()
            sc.Host = My.Settings.MailHost
            sc.Port = My.Settings.MailPort

            '宛先
            Dim j = 0
            For j = 0 To UBound(SENDTO)
                msg.To.Add(New System.Net.Mail.MailAddress(SENDTO(j).Trim))
            Next

            sc.Timeout = My.Settings.MailTimeOut
            sc.EnableSsl = False
            ''メールを送信する
            sc.Send(msg)

            Send_Mail = True

        Catch ex As Exception
            Send_Mail = False
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            '後始末
            msg.Dispose()

            '後始末（.NET Framework 4.0以降）
            sc.Dispose()

        End Try
    End Function
#End Region


#Region "宛先取得"
    ''' <summary>
    ''' メールアドレスの取得を行う
    ''' </summary>>
    ''' <returns>正常:true 異常:false</returns>
    ''' <remarks>メールアドレスの取得を行う</remarks>
    Private Function Send_To() As Boolean

        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xNameList As XmlNodeList


        Try

            xDocument.Load(MailAddPath)

            'ルート要素を取得する
            xRoot = xDocument.DocumentElement 'XMLドキュメントからルート要素を取り出す

            xDataList = xRoot.GetElementsByTagName(String.Format("{0}{1}", "MAIL_SEND_TO", MailSendPtn))

            For Each xElement As XmlElement In xDataList

                xNameList = xRoot.GetElementsByTagName("CD")

                For Each xName As XmlElement In xNameList

                    i = xName.SelectSingleNode("@ID").Value.Trim

                    ReDim Preserve SENDTO(i)
                    SENDTO(i) = xName.FirstChild.Value
                Next xName

            Next xElement

            Send_To = True

        Catch ex As Exception
            Send_To = False
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function

#End Region

#Region "MailAddressパス"
    Private MailAddPath As String
    Public Property GetMailAddPath() As String
        Get
            Return MailAddPath
        End Get
        Set(ByVal value As String)
            MailAddPath = value
        End Set
    End Property
#End Region

#Region "MailTitle"
    Private MailTitle As String
    Public Property GetMailTitle() As String
        Get
            Return MailTitle
        End Get
        Set(ByVal value As String)
            MailTitle = value
        End Set
    End Property
#End Region

#Region "MailBodyパス"
    Private MailBodyPath As String
    Public Property GetMailBodyPath() As String
        Get
            Return MailBodyPath
        End Get
        Set(ByVal value As String)
            MailBodyPath = value
        End Set
    End Property
#End Region

#Region "MailSendPtn"
    Private MailSendPtn As String
    Public Property GetMailSendPtn() As String
        Get
            Return MailSendPtn
        End Get
        Set(ByVal value As String)
            MailSendPtn = value
        End Set
    End Property
#End Region

#Region "ZipPath"
    Private ZipPath As String
    Public Property GetZipPath() As String
        Get
            Return ZipPath
        End Get
        Set(ByVal value As String)
            ZipPath = value
        End Set
    End Property
#End Region

#Region "MailBody項目1"
    Private MailBody1 As String
    Public Property GetMailBody1() As String
        Get
            Return MailBody1
        End Get
        Set(ByVal value As String)
            MailBody1 = value
        End Set
    End Property
#End Region

#Region "MailBody項目2"
    Private MailBody2 As String
    Public Property GetMailBody2() As String
        Get
            Return MailBody2
        End Get
        Set(ByVal value As String)
            MailBody2 = value
        End Set
    End Property
#End Region

#Region "MailBody項目3"
    Private MailBody3 As String
    Public Property GetMailBody3() As String
        Get
            Return MailBody3
        End Get
        Set(ByVal value As String)
            MailBody3 = value
        End Set
    End Property
#End Region

#Region "MailBody項目4"
    Private MailBody4 As String
    Public Property GetMailBody4() As String
        Get
            Return MailBody4
        End Get
        Set(ByVal value As String)
            MailBody4 = value
        End Set
    End Property
#End Region

#Region "MailBody項目5"
    Private MailBody5 As String
    Public Property GetMailBody5() As String
        Get
            Return MailBody5
        End Get
        Set(ByVal value As String)
            MailBody5 = value
        End Set
    End Property
#End Region

#Region "MailBody項目6"
    Private MailBody6 As String
    Public Property GetMailBody6() As String
        Get
            Return MailBody6
        End Get
        Set(ByVal value As String)
            MailBody6 = value
        End Set
    End Property
#End Region

#Region "メール送信タイプ"
    Private MailSendType As String
    Public Property GetMailSendType() As String
        Get
            Return MailSendType
        End Get
        Set(ByVal value As String)
            MailSendType = value
        End Set
    End Property
#End Region

End Class
