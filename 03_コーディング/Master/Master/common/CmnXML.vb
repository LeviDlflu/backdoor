Imports System.Xml
Imports System.Text

Public Class CmnXML
    Dim mXmlDoc As New XmlDocument
    Public XmlFile As String

    Public Sub New(ByVal File As String)
        MyClass.XmlFile = File
        MyClass.mXmlDoc.Load(MyClass.XmlFile)
    End Sub

    Public Function GetElement(ByVal node As String, ByVal element As String) As String
        Dim mXmlNode As XmlNode = mXmlDoc.SelectSingleNode("//" + node)
        Dim xmlNode As XmlNode = mXmlNode.SelectSingleNode(element)
        Return xmlNode.InnerText.ToString
    End Function

    Public Function GetElementsField(ByVal node As String, ByVal element As String) As String

        Dim root As XmlElement

        root = mXmlDoc.DocumentElement

        Dim sqlstr As New StringBuilder

        Dim elementList As XmlNodeList = mXmlDoc.GetElementsByTagName(element)
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

        Dim nodeList As XmlNodeList = mXmlDoc.GetElementsByTagName(element)

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

    Public Function GetMessage(ByVal MESSAGE_ID As String) As String

        Dim messagestr As String = ""

        Dim nodeList As XmlNodeList = mXmlDoc.GetElementsByTagName("messageid")

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

        Dim userXML As New CmnXML("user.xml")

        loginUser.Text = userXML.GetElement("UserInf", "LoginUser")
        loginUser.ReadOnly = True

        loginEnv.Text = userXML.GetElement("UserInf", "LoginEnv")
        loginEnv.ReadOnly = True

    End Sub

End Class
