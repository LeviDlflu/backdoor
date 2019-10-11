Imports System.Drawing

Public Module DefaultValues

    Public Const LOG_OUTPUT_PATH As String = ".\"
    Public ReadOnly LOG_ENCODING As System.Text.Encoding = System.Text.Encoding.GetEncoding(932)

    Public Const EXC_FILENAME_FORMAT As String = "{0}\{1}_{2}_EXCEPTION.log"
    Public Const LOG_FILENAME_FORMAT As String = "{0}\{1}_{2}_SYSTEM.log"
 

End Module

