Imports System.Windows.Forms
Imports System.ComponentModel

Public Class clsMessage

    Private _MessageResult As String
    Private _MessageString As String = ""
    Private _MessageCode As String = ""

    Private Const MESSAGE_PATH As String = ""
    Private Const MESSAGE_FILE_NAME As String = "\Message.xml"
    Private Const MESSAGE_TYPE_I As String = "Information"
    Private Const MESSAGE_TYPE_W As String = "Warning"
    Private Const MESSAGE_TYPE_E As String = "Error"
    Private Const MESSAGE_ITEM_WHERE As String = "Message ID='{0}'"
    Private Const MESSAGE_ITEM_MESSAGE As String = "Text"

    Private Const CONFIG_DOC_ROOT As String = "//Configuration"
    Private Const MESSAGE_ITEM_PATH As String = "/Messages/{0}/Message[@ID='{1}']/{2}/text()"


    Private _ConfigDocument As New System.Xml.XmlDocument

    Private Shared _oDs As System.Data.DataSet = Nothing
    ''' <summary>
    ''' コンストラクタ
    ''' メッセージへの引数が無い場合
    ''' </summary>
    ''' <remarks>メッセージヘッダーを設定します。</remarks>
    Public Sub New(ByVal strMessageId As String)
        _MessageCode = strMessageId
        '_MessageGamenCode = strGamenID

        Me._MessageString = Me.GetMessage(strMessageId)
        'AddHeaderMessage()
    End Sub
    ''' <summary>
    ''' 表示
    ''' </summary>
    ''' <returns>メッセージのボタン操作結果</returns>
    ''' <remarks>メッセージを表示します。</remarks>
    Public Function Show() As String
        Me._MessageResult = _MessageString
        Return Me._MessageResult
    End Function
    ''' <summary>
    ''' メッセージ内容の取得
    ''' </summary>
    ''' <param name="strMessageId">メッセージID</param>
    ''' <returns>メッセージ内容</returns>
    ''' <remarks>メッセージ内容を取得します。</remarks>
    Private Function GetMessage(ByVal strMessageId As String) As String

        Dim MessageType As String

        Select Case strMessageId.Chars(0)
            Case "E"c
                MessageType = "Error" ''MESSAGE_TYPE_E

            Case "W"

                MessageType = MESSAGE_TYPE_W
            Case "I"
                MessageType = MESSAGE_TYPE_I
            Case Else
                MessageType = MESSAGE_TYPE_E
        End Select

        '_MessageButton.OK = 0
        '_MessageButton.OKCancel = 1
        '_MessageButton.AbortRetryIgnore = 2 (未使用)
        '_MessageButton.YesNoCancel = 3
        '_MessageButton.YesNo = 4
        '_MessageButton.RetryCancel = 5

        Dim fPath = My.Settings.Message & MESSAGE_FILE_NAME

        Me._ConfigDocument.Load(fPath)

        Return GetData(String.Format(MESSAGE_ITEM_PATH, MessageType, strMessageId, MESSAGE_ITEM_MESSAGE))

    End Function

    ''' <summary>
    ''' XMLファイルから指定されたノードの文字列を返す
    ''' </summary>
    ''' <param name="pvDataPath"></param>
    ''' <returns></returns>
    ''' <remarks>XMLファイルから指定されたノードの文字列を返す</remarks>
    Public Function GetData(ByVal pvDataPath As String) As String

        Dim retObj As Xml.XmlNode = Me._ConfigDocument.SelectSingleNode(CONFIG_DOC_ROOT & pvDataPath)
        If IsNothing(retObj) Then Return Nothing
        Return retObj.Value

    End Function

End Class
