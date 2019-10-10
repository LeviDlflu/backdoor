Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text

Public Class Conn

    Public Function fncCnOpen(ByRef cn As SqlConnection) As Boolean

        Dim strDBSource As String = ConfigurationManager.AppSettings("DataSource").ToString()
        Dim strSRC As String = ConfigurationManager.AppSettings("InitialCatalog").ToString()
        Dim StrId As String = ConfigurationManager.AppSettings("UserID").ToString()
        Dim strPw As String = ConfigurationManager.AppSettings("Password").ToString()

        Dim strConn As String = ""

        strConn = strConn & "Data Source=" & strDBSource & ";"
        strConn = strConn & "Initial Catalog=" & strSRC & ";"
        strConn = strConn & "User ID=" & StrId & ";"
        strConn = strConn & "Password=" & strPw & ";"

        cn = New SqlClient.SqlConnection(strConn)

        Try
            cn.Open()
            fncCnOpen = True
        Catch ex As Exception
            fncCnOpen = False
            Exit Function
        Finally

        End Try
    End Function

    Public Sub subCnClose(ByRef cn As SqlConnection)
        cn.Close()
    End Sub

    'Public Function SelectTable(ByRef cn As SqlConnection, ByRef xmlName As String) As SqlDataAdapter
    '    Dim da As SqlDataAdapter
    '    Dim xml As New CmnXML(xmlName)

    '    Dim sqlstr As String

    '    Dim table As String = xml.GetElement("tableId", "tableName")
    '    Dim field As String = xml.GetElementsField("tableId", "fieldId")

    '    sqlstr = "select " + field + " from " + table

    '    da = New SqlDataAdapter(sqlstr, cn)

    '    Return da
    'End Function

    'Public Function InsertStr(ByRef xmlName As String) As String

    '    Dim xml As New CmnXML(xmlName)

    '    Dim sqlstr As String = xml.GetSQL("select", "insert_001")

    '    MessageBox.Show("1111111111111:" + sqlstr)

    '    Dim sqlstr1 As String = xml.GetSQL("select", "insert_002")
    '    MessageBox.Show("222222222222:" + sqlstr1)

    '    Return sqlstr
    'End Function

    'Public Function InsertTable(ByRef cn As SqlConnection, ByRef xmlName As String) As SqlDataAdapter
    '    Dim da As SqlDataAdapter
    '    Dim xml As New CmnXML(xmlName)

    '    Dim sqlstr As String

    '    Dim table As String = xml.GetElement("tableId", "tableName")
    '    Dim field As String = xml.GetElementsField("tableId", "fieldId")

    '    sqlstr = "Insert INTO " + field + " (" + table + ") VALUES(" + ")"

    '    da = New SqlDataAdapter(sqlstr, cn)

    '    Return da
    'End Function

End Class
