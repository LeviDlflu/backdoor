Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Collections
Imports System.ComponentModel


Public Class clsGlobal

    Private Shared _LogPeriod As Integer = My.Settings.LogPeriod
    Public Const _conStr As String = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=120;"
    Public Const _conStr_Ora As String = "Persist Security Info=TRUE;data source={0};user id={1};password={2};"

    '20170314修正(HIDOC) S      AT課題[No.173]
    '共通関数内で事業所判別時に使用
    Public Enum DivisionID
        NAB     '名張事業所
        SAI     '埼玉事業所
        HIK     '彦根事業所
        PLA     'オート関西
    End Enum
    '20170314修正(HIDOC) S      AT課題[No.173]

    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
    Public Const conNAB = "NAB"
    Public Const conSAI = "SAI"
    Public Const conHIK = "HIK"
    Public Const conPLA = "PLA"
    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
#Region "DB接続文字列"
    <Browsable(False), Description("DB接続文字列を設定します。"), Category("入出力カテゴリ")>
    Public Shared ReadOnly Property ConnectString() As String
        Get
            Return String.Format(_conStr, My.Settings.server, My.Settings.db, My.Settings.userid, My.Settings.password)
        End Get
    End Property
#End Region

#Region "ログフォルダ"
    Private Shared _LogFolder As String
    <Browsable(False), Description("ログフォルダを設定"), Category("入出力カテゴリ")>
    Public Shared Property GetLogFolder() As String
        Get
            Return _LogFolder
        End Get
        Set(ByVal value As String)
            _LogFolder = value
        End Set
    End Property
#End Region

#Region "ログファイル"
    Private Shared _LogFile As String
    <Browsable(False), Description("ログファイルを設定"), Category("入出力カテゴリ")>
    Public Shared Property GetLogFile() As String
        Get
            Return _LogFile
        End Get
        Set(ByVal value As String)
            _LogFile = value
        End Set
    End Property
#End Region

#Region "ログ保存期間"

    <Browsable(False), Description("ログの保存期間を設定します。"), Category("入出力カテゴリ")>
    Public Shared Property LogPeriod() As Integer
        Get
            Return _LogPeriod
        End Get
        Set(ByVal value As Integer)
            _LogPeriod = value
        End Set
    End Property
#End Region

#Region "SQL文の出力有無"

    Private Shared _SqlLogFlag As Boolean
    <Browsable(False), Description("SQL文発行時の出力有無を設定します。"), Category("入出力カテゴリ")>
    Public Shared Property SqlLogFlag() As Boolean
        Get
            Return _SqlLogFlag
        End Get
        Set(ByVal value As Boolean)
            _SqlLogFlag = value
        End Set
    End Property
#End Region

#Region "InputPath"
    Public Shared Function Getfilepath() As String
        Dim path As String = System.Windows.Forms.Application.StartupPath

        Return path
    End Function
#End Region

#Region "ログファイルを削除する"

    ''' <remarks>一定保存期間を過ぎたログファイルを削除する</remarks>
    Public Shared Sub FileDelete()
        Dim LogDirectory As String = clsGlobal.Getfilepath & "\Log"
        For Each FileName As String In Directory.GetFiles(LogDirectory, "*.log")
            If Directory.GetLastWriteTime(FileName) < DateAdd(DateInterval.Day, (clsGlobal.LogPeriod) * -1, Date.Now) Then
                Try
                    File.Delete(FileName)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
#End Region

    ''' <summary>
    ''' データベース接続クラス
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _oDB As clsSQLServer = Nothing
    ''' <summary>
    ''' データベース接続クラスインスタンス
    ''' </summary>
    ''' <value>データベース接続クラス</value>
    ''' <returns>データベース接続クラス</returns>
    ''' <remarks>データベース接続クラスインスタンスの設定を行います。</remarks>
    Public Shared ReadOnly Property DataBase() As clsSQLServer
        Get
            Return _oDB
        End Get
    End Property
    ''' <summary>
    ''' メッセージ表示
    ''' </summary>
    ''' <param name="strMessageID">メッセージID</param>
    ''' <returns>メッセージ</returns>
    ''' <remarks>メッセージ表示クラスを使用してメッセージを表示します。</remarks>
    Public Shared Function MSG(ByVal strMessageID As String) As String
        '20170630修正(HIDOC) S      本番稼動後課題[No.123]
        'ERR、警告の判別のため、ID（4ケタ固定）を最初に付与する
        'Return New clsMessage(strMessageID).Show
        Dim mes As String = New clsMessage(strMessageID).Show
            Return strMessageID & mes
        '20170630修正(HIDOC) E      本番稼動後課題[No.123]
    End Function

    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
    ''' <summary>
    ''' メッセージ表示2
    ''' </summary>
    ''' <param name="strMessageID">メッセージID</param>
    ''' <returns>メッセージ2</returns>
    ''' <remarks>メッセージ表示クラスを使用してメッセージを表示します。</remarks>
    Public Shared Function MSG2(ByVal strMessageID As String) As String
        '修正前のMSG関数と同処理、新規関数とした方が改修による影響範囲が狭くなるため、関数を変更
        Return New clsMessage(strMessageID).Show
    End Function
    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
End Class
