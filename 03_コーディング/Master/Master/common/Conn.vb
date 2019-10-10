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

End Class
