Imports System.Xml
Imports System.Text

Public Class CmnXML

    Private Const SQL_TYPE_S As String = "Selects"
    Private Const SQL_TYPE_W As String = "Wheres"
    Private Const SQL_TYPE_U As String = "Updates"
    Private Const SQL_TYPE_I As String = "Inserts"
    Private Const SQL_TYPE_D As String = "Deletes"
    Private Const SQL_TYPE_E As String = "Error"
    Private Const SQL_ITEM_TEXT As String = "Text"

    Private Const CONFIG_DOC_ROOT As String = "//Configuration"
    Private Const MESSAGE_ITEM_PATH As String = "/{0}/{1}/SQL[@ID='{2}']/{3}/text()"

    Dim SQLXml As New clsXML
    Dim FUNID As String


    Public Sub New(ByVal File As String, ByVal ID As String)
        SQLXml.LoadXML(File)
        Me.FUNID = ID
    End Sub

    Public Function GetElement(ByVal node As String, ByVal element As String) As String
        Dim mXmlNode As XmlNode = SQLXml.m_xmlDoc.SelectSingleNode("//" + node)
        Dim xmlNode As XmlNode = mXmlNode.SelectSingleNode(element)
        Return xmlNode.InnerText.ToString
    End Function

    Public Function GetElementsField(ByVal node As String, ByVal element As String) As String

        Dim root As XmlElement

        root = SQLXml.m_xmlDoc.DocumentElement

        Dim sqlstr As New StringBuilder

        Dim elementList As XmlNodeList = SQLXml.m_xmlDoc.GetElementsByTagName(element)
        Dim ht_value As String
        For i = 0 To elementList.Count - 1

            ht_value = elementList.ItemOf(i).InnerText.Trim()

            If i <> elementList.Count - 1 Then
                sqlstr.Append(ht_value + ",")
            Else
                sqlstr.Append(ht_value)
            End If
        Next

        Return sqlstr.ToString
    End Function

    Public Function GetSQL(ByVal element As String, ByVal SQL_ID As String) As String

        Dim sqlstr As String = ""

        Dim nodeList As XmlNodeList = SQLXml.m_xmlDoc.GetElementsByTagName(element)

        'Dim node As XmlNode = mXmlDoc.GetElementsByTagName(element)
        For Each node In nodeList

            If node IsNot Nothing Then
                If node.Attributes(0).Value = SQL_ID Then
                    sqlstr = node.InnerText.Trim()
                End If
            End If
        Next

        Return sqlstr
    End Function

    Public Function GetSQL_Str(ByVal SQL_ID As String) As String

        Dim SQLType As String

        Select Case SQL_ID.Chars(0)
            Case "S"c
                SQLType = SQL_TYPE_S
            Case "W"c
                SQLType = SQL_TYPE_W
            Case "U"c
                SQLType = SQL_TYPE_U
            Case "I"c
                SQLType = SQL_TYPE_I
            Case "D"c
                SQLType = SQL_TYPE_D
            Case Else
                SQLType = SQL_TYPE_E
        End Select

        Return GetData(String.Format(MESSAGE_ITEM_PATH, Me.FUNID, SQLType, SQL_ID, SQL_ITEM_TEXT))

    End Function
    Public Function GetData(ByVal pvDataPath As String) As String

        Dim retObj As Xml.XmlNode = SQLXml.m_xmlDoc.SelectSingleNode(CONFIG_DOC_ROOT & pvDataPath)
        If IsNothing(retObj) Then Return Nothing
        Return retObj.Value

    End Function

    Public Function GetMessage(ByVal MESSAGE_ID As String) As String

        Dim messagestr As String = ""

        Dim nodeList As XmlNodeList = SQLXml.m_xmlDoc.GetElementsByTagName("messageid")

        'Dim node As XmlNode = mXmlDoc.GetElementsByTagName(element)
        For Each node In nodeList

            If node IsNot Nothing Then
                If node.Attributes(0).Value = MESSAGE_ID Then
                    messagestr = node.InnerText.Trim()
                End If
            End If
        Next

        Return messagestr
    End Function

    Public Sub InitUser(loginUser As Object, loginEnv As Object)

        Dim userXML As New CmnXML("user.xml", "")

        loginUser.Text = userXML.GetElement("UserInf", "LoginUser")
        loginUser.ReadOnly = True

        loginEnv.Text = userXML.GetElement("UserInf", "LoginEnv")
        loginEnv.ReadOnly = True

    End Sub

End Class
