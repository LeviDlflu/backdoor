Imports System.IO
Imports Master

Public Class clsLogTrace

    Inherits StreamWriter

    Enum LogType
        ''' <summary>
        ''' Trace
        ''' </summary>
        ''' <remarks></remarks>
        Trace
        ''' <summary>
        ''' Exception
        ''' </summary>
        ''' <remarks></remarks>
        Exception
    End Enum

    Enum LogLevel
        ''' <summary>
        ''' 全て出力
        ''' </summary>
        ''' <remarks></remarks>
        All = 0
        ''' <summary>
        ''' インフォメーション + エラーメッセージ
        ''' </summary>
        ''' <remarks></remarks>
        Infomation = 1
        ''' <summary>
        ''' エラーメッセージのみ
        ''' </summary>
        ''' <remarks></remarks>
        Err = 2
    End Enum

    Private Shared _logStream As clsLogTrace
    Private Shared _excStream As clsLogTrace
    Private _LogString As ClsLogString
    Private _Level As LogLevel = LogLevel.All

    ''' <remarks>バッチ操作ログのインスタンス取得します。</remarks>
    Public Shared Function GetInstance() As clsLogTrace
        Try
            If IsNothing(_logStream) Then
                _logStream = New clsLogTrace(LogType.Trace)
            End If
        Catch ex As Exception
            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
        Return _logStream
    End Function
    ''' <remarks>Exceptionログのインスタンスを取得します。</remarks>
    Public Shared Function GetExInstance() As clsLogTrace
        Try
            If IsNothing(_excStream) Then
                _excStream = New clsLogTrace(LogType.Exception)
            End If
        Catch ex As Exception
            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
        Return _excStream
    End Function


    ''' <remarks>ログ出力を終了します。</remarks>
    Public Shared Sub CloseInstance()
        Try
            If Not IsNothing(_logStream) Then
                _logStream.Close()
                _logStream = Nothing
            End If
            If Not IsNothing(_excStream) Then
                _excStream.Close()
                _excStream = Nothing
            End If
        Catch ex As Exception
            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Sub


    Public Sub New(ByVal type As LogType)
        MyBase.New(GetFileName(type), True, DefaultValues.LOG_ENCODING)
    End Sub

    ''' <summary>
    ''' <remarks>バッチ操作ログを出力する。</remarks>
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="Level"></param>

    Public Sub TraceWrite(ByVal Message As String, ByVal RunState As ClsLogString.RunState, Optional ByVal Level As LogLevel = LogLevel.All)
        '20170630修正(HIDOC) S      本番稼動後課題[No.123]
        '出力するメッセージの判別（エラー、警告）を行い、それを出力する
        '_LogString = New ClsLogString(RunState, Message)
        Dim ErrID As String = ""
        Dim ErrMes As String = ""
        ErrID = Mid(Message, 1, 4)
        ErrMes = Mid(Message, 5)
        If RunState = ClsLogString.RunState.Err Then
            _LogString = New ClsLogString(clsEtc.GetLogType(ErrID, 1, 1), ErrMes)
        Else
            _LogString = New ClsLogString(RunState, ErrMes)
        End If
        '20170630修正(HIDOC) E      本番稼動後課題[No.123]

        TraceWrite(_LogString, Level)
    End Sub

    ''' <remarks>バッチ操作ログを出力する。</remarks>
    Public Sub TraceWrite(ByVal value As ClsLogString, Optional ByVal Level As LogLevel = LogLevel.All)
        If Level >= _Level Then
            Me.WriteLine(value.GetLogString)
            Me.Flush()
        End If
        CloseInstance()
    End Sub

    ''' <remarks>Exceptionの内容をログに出力する。</remarks>
    Public Sub ExceptionWrite(ByVal ex As Exception)
        Me.WriteLine("###############################################")
        Me.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        Me.WriteLine("Message:" & ex.Message)
        If Not IsNothing(ex.InnerException) Then
            Me.WriteLine("InnerMessage:" & ex.InnerException.Message)
            Me.WriteLine(ex.InnerException.StackTrace)
        End If
        Me.WriteLine(ex.StackTrace)
        Me.WriteLine("###############################################")
        Me.Flush()
        CloseInstance()

    End Sub

    Private Shared Function GetFileName(ByVal type As LogType) As String

        Dim LogDate As String = clsInputLinkage.GetFileDateTime
        Dim LogDirectory As String = clsGlobal.GetLogFolder
        Dim LogFile As String = clsGlobal.GetLogFile

        Dim FilePath As String

        If Not Directory.Exists(LogDirectory) Then
            Try
                Directory.CreateDirectory(LogDirectory)
            Catch ex As Exception
                FilePath = DefaultValues.LOG_OUTPUT_PATH
                '20171026修正(システムズ) S  例外処理不具合対応
                Throw
                '20171026修正(システムズ) E  例外処理不具合対応
            End Try
        End If

        If type = LogType.Trace Then
            FilePath = String.Format(My.Settings.LogFileFormat, LogDirectory, LogDate, LogFile)
        Else
            FilePath = String.Format(My.Settings.ExcFileFormat, LogDirectory, LogDate, LogFile)
        End If

        Return FilePath
    End Function

    ''' <remarks>一定保存期間を過ぎたログファイルを削除する</remarks>
    Public Shared Sub FileDelete(ByVal LogPeriod As Double)
        Dim LogDirectory As String = clsGlobal.Getfilepath & "\Log"
        For Each FileName As String In Directory.GetFiles(LogDirectory, "*.log")
            If Directory.GetLastWriteTime(FileName) < DateAdd(DateInterval.Day, (LogPeriod) * -1, Date.Now) Then
                Try
                    File.Delete(FileName)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub

    ''' <remarks>一定保存期間を過ぎたログファイルを削除する</remarks>
    Public Shared Sub ZipFileDelete(ByVal LogPeriod As Double)
        Dim LogDirectory As String = clsGlobal.Getfilepath & "\Log"
        For Each FileName As String In Directory.GetFiles(LogDirectory, "*.zip")
            If Directory.GetLastWriteTime(FileName) < DateAdd(DateInterval.Day, (LogPeriod) * -1, Date.Now) Then
                Try
                    File.Delete(FileName)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub

End Class

''' <remarks>ログ出力用の文字列操作クラス。</remarks>
Public Class ClsLogString
    ''' <summary>
    ''' 実行区分
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RunState
        ''' <summary>
        ''' Begin Of Job
        ''' </summary>
        ''' <remarks></remarks>
        Begin
        ''' <summary>
        ''' End Of Job
        ''' </summary>
        ''' <remarks></remarks>
        [End]
        ''' <summary>
        ''' 処理状況メッセージ
        ''' </summary>
        ''' <remarks></remarks>
        Msg
        ''' <summary>
        ''' エラーメッセージ
        ''' </summary>
        ''' <remarks></remarks>
        Err
        ''' <summary>
        ''' エラーException
        ''' </summary>
        ''' <remarks></remarks>
        Exception
        '20170614修正(HIDOC) S      本番稼動後課題[No.402]
        ''' <summary>
        ''' エラーWarning
        ''' </summary>
        ''' <remarks></remarks>
        Warning
        '20170614修正(HIDOC) E      本番稼動後課題[No.402]
    End Enum
    Private m_RunKbn As RunState
    Private m_TerminalNo As String
    Private m_SyoriId As String
    Private m_SoukoCd As String
    Private m_Name As String
    Private m_Location As String
    Private m_SyouhinCd As String
    Private m_DenpyoNo As String
    Private m_GyoNo As String
    Private m_EdaNo As String
    Private m_OriconNo As String
    Private m_ToiawaseNo As String
    Private m_TanaNo As String
    Private m_TekiyoCd As String
    Private m_HachuNo As String
    Private m_Message As String

    Private Const DelimiterString = ","


    ''' <summary>
    ''' 実行区分文字列取得
    ''' </summary>
    ''' <value>実行区分文字列取得</value>
    ''' <returns>実行区分文字列取得</returns>
    ''' <remarks>実行区分文字列を取得します。</remarks>
    Public ReadOnly Property RunString()
        Get
            Return GetStateName()
        End Get
    End Property

    ''' <summary>
    ''' インスタンス生成
    ''' </summary>
    ''' <param name="Message">メッセージ</param>
    ''' <remarks>インスタンスを生成します。</remarks>
    Public Sub New(ByVal RunKbn As ClsLogString.RunState, ByVal Message As String)

        m_RunKbn = RunKbn
        'm_TerminalNo = TerminalNo
        'm_SyoriId = SyoriId
        m_Message = Message.Replace(ControlChars.Cr, " ").Replace(ControlChars.Lf, " ")


    End Sub
    ''' <remarks>カンマ区切りのログ出力文字列を生成する。</remarks>
    Public Function GetLogString() As String
        Dim LogString As New System.Text.StringBuilder

        With LogString
            .Append("[" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "]" & DelimiterString)
            .Append("[" & GetStateName() & "]" & DelimiterString)
            .Append(m_Message)
        End With

        Return LogString.ToString
    End Function

    ''' <remarks>実行区分文字列を取得します。</remarks>
    Private Function GetStateName() As String
        Dim RetVal As String

        Select Case m_RunKbn
            Case RunState.Begin
                RetVal = "BOJ"
            Case RunState.End
                RetVal = "EOJ"
            Case RunState.Err
                RetVal = "ERR"
            Case RunState.Exception
                RetVal = "EXC"
            Case RunState.Msg
                RetVal = "MSG"
                '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            Case RunState.Warning
                RetVal = "WAR"
                '20170614修正(HIDOC) E      本番稼動後課題[No.402]
            Case Else
                RetVal = ""
        End Select

        Return RetVal
    End Function
End Class