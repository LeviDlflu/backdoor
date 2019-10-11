Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Public Class clsSQLServer
    ''' <summary>
    ''' データベース接続クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared _oDB As clsSQLServer = Nothing
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
    ''' デフォルトデータセットテーブル名称
    ''' </summary>
    ''' <remarks>データセットのデフォルトのテーブル名称。テーブル名称でアクセスする際に使用します。</remarks>
    Private m_ConnectionString = ""                 '再接続用
    Private Shared myCon As SqlConnection = New SqlConnection
    Private Shared myCommand As SqlCommand = New SqlCommand()
    Private Shared myReader As SqlDataReader = Nothing
    Private Shared myTran As SqlTransaction
    Private Shared _TranzactionFlg As Boolean = False
    '20170310修正(HIDOC) S      BT課題[No.19]
    Private Shared myCommand2 As SqlCommand = New SqlCommand()
    Private Shared myDa As SqlDataAdapter = New SqlDataAdapter()
    Private Shared myds As DataSet = New DataSet()
    '20170310修正(HIDOC) E      BT課題[No.19]
    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
    Public Shared dt_WarMes As DataTable
    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
#Region "DB接続関連処理"
    ''' <summary>
    ''' DBへの接続文字列
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared _strDBConnectString As String = String.Empty
    ''' <summary>
    ''' データベース接続文字列
    ''' </summary>
    ''' <param name="str">DBへの接続文字列</param>
    ''' <remarks>データベース接続文字列を設定します。</remarks>
    Public Shared Sub ConnectString(ByVal str As String)
        _strDBConnectString = str

    End Sub
#End Region

#Region "DBオープン"
    ''' <summary>
    ''' DBオープン
    ''' </summary>
    ''' <param name="myConnectString">接続文字列</param>
    ''' <remarks>DBをオープンします。</remarks>
    Public Shared Function Connect(Optional ByVal myConnectString As String = "") As Boolean
        Try

            If myCon.State = System.Data.ConnectionState.Open Then
                Return True
            End If

            If myConnectString.Length = 0 Then myConnectString = String.Format(clsGlobal._conStr, My.Settings.server, My.Settings.db, My.Settings.userid, My.Settings.password)

            ConnectString(myConnectString)
            myCon.ConnectionString = _strDBConnectString

            'DBをオープンする
            myCon.Open()
            myCommand.Connection = myCon
            myCommand.CommandType = CommandType.Text

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
        Return True
    End Function
#End Region

#Region "DB切断"
    ''' <summary>
    ''' DB切断
    ''' </summary>
    ''' <remarks>DBを切断します。</remarks>
    Public Shared Function Disconnect() As Boolean
        If Not myReader Is Nothing Then
            If Not myReader.IsClosed Then
                Try
                    myReader.Close()
                Catch ex As Exception
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
                    clsLogTrace.GetExInstance().ExceptionWrite(ex)

                    '20171026修正(システムズ) S  例外処理不具合対応
                    'Return False
                    Throw
                    '20171026修正(システムズ) E  例外処理不具合対応
                End Try
            End If
        End If

        ' 接続を閉じる
        If Not myCon Is Nothing Then
            ' 接続がオープンしている場合
            If myCon.State = System.Data.ConnectionState.Open Then
                Try
                    ' 接続を閉じる
                    myCon.Close()
                Catch ex As Exception
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
                    clsLogTrace.GetExInstance().ExceptionWrite(ex)

                    '20171026修正(システムズ) S  例外処理不具合対応
                    'Return False
                    Throw
                    '20171026修正(システムズ) E  例外処理不具合対応
                End Try
            End If
        End If
        Return True
    End Function
#End Region

#Region "トランザクション開始"
    ''' <summary>
    ''' トランザクション開始
    ''' </summary>
    ''' <remarks>トランザクションを開始します。</remarks>
    Public Shared Sub BeginTransaction()

        Try
            If myCon.State = System.Data.ConnectionState.Closed Then
                clsSQLServer.Connect(myCon.ConnectionString)  '_ConnectString 
            End If
            myTran = myCon.BeginTransaction()

            _TranzactionFlg = True
            Return

        Catch ex As Exception
            myCon.Close()
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)
            Return

        End Try

    End Sub
#End Region

#Region "コミット"
    ''' <summary>
    ''' トコミット
    ''' </summary>
    ''' <remarks>コミットを開始します。</remarks>
    Public Shared Sub Commit()

        Try
            If myCon.State = System.Data.ConnectionState.Closed Then
                clsSQLServer.Connect(myCon.ConnectionString)  '_ConnectString 
            End If
            myTran.Commit()
            _TranzactionFlg = False
            Return

        Catch ex As Exception
            clsSQLServer.Rollback()
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)
            Return

        End Try

    End Sub
#End Region

#Region "ロールバック"
    ''' <summary>
    ''' ロールバック
    ''' </summary>
    ''' <remarks>ロールバックを開始します。</remarks>

    Public Shared Sub Rollback()

        Try
            If myCon.State = System.Data.ConnectionState.Closed Then
                clsSQLServer.Connect(myCon.ConnectionString)  '_ConnectString 
            End If
            myTran.Rollback()
            _TranzactionFlg = False
            Return

        Catch ex As Exception
            myCon.Close()
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

        End Try

    End Sub
#End Region

#Region "SQL発行"
    ''' <summary>
    ''' SQL発行
    ''' </summary>
    ''' <param name="pvSql">発行SQL</param>
    ''' <returns>影響を受けた行数を返します。</returns>
    ''' <remarks>戻り値はそのコマンドの影響を受ける行の数です。CREATE TABLE ステートメントおよび DROP TABLE ステートメントでは、
    ''' 戻り値は 0 です。その他の種類のステートメントでは、戻り値は -1 です。 </remarks>
    Public Shared Function ExecuteQuery(ByVal pvSql As String, Optional ByVal ComputerName As String = "", Optional ByVal ProgId As String = "") As Integer
        '接続チェック
        'ConnectCheck()

        Dim ret As Integer = 0
        Dim oc As SqlClient.SqlCommand

        If myCon.State = System.Data.ConnectionState.Closed Then
            clsSQLServer.Connect(myCon.ConnectionString)  '_ConnectString 
        End If


        If _TranzactionFlg = True Then
            oc = New SqlClient.SqlCommand(pvSql, myCon, myTran)
        Else
            oc = New SqlClient.SqlCommand(pvSql, myCon)
        End If

        'タイムアウト60秒
        oc.CommandTimeout = 60
        Try
            ret = oc.ExecuteNonQuery

        Catch ex As Exception
            Try
                'DB切断
                myCon.Close()
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
                clsLogTrace.GetExInstance().ExceptionWrite(ex)
            Catch ex2 As Exception
            End Try
            Throw New Exception(String.Format("{0}:{1}", ret, pvSql), ex)
        End Try
        Return ret
    End Function
#End Region

#Region "データ取得しデータテーブルを返す"
    ' パラメータで与えたSQLでOlacleからデータを取得し、データテーブルに変換して返す
    Public Shared Function GetDataTable(ByVal strSQL As String, Optional ByRef strMSG As String = "") As DataTable
        Dim myDataTable As New DataTable
        myCommand.CommandText = strSQL
        If My.Settings.SqlLogFlag = True Then
            clsLogTrace.GetInstance.TraceWrite(myCommand.CommandText, ClsLogString.RunState.Msg)
        End If
        Try
            ' 接続状態の確認
            If myCon.State = System.Data.ConnectionState.Closed Then
                clsSQLServer.Connect(myCon.ConnectionString)  '_ConnectString 
            End If

            '所得したデータをデータテーブルに変換して返す
            Dim dr As SqlDataReader = myCommand.ExecuteReader
            myDataTable.Load(dr)
            Return myDataTable

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return Nothing
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応

        End Try

    End Function
#End Region

#Region "SOCIOテーブルのデータ取得"
    Public Shared Function getSocioData(ByRef dt As DataTable, Optional ConnectString As String = "") As Boolean
        Dim sql As New StringBuilder        ' SQL文
        Dim msg As String = ""          ' SQL発行時メッセージ

        Try
            sql.Append("SELECT * FROM SOCIO_コード変換")
            'データベース接続
            clsSQLServer.Connect(ConnectString)

            dt = clsSQLServer.GetDataTable(sql.ToString, msg)
            If dt Is Nothing Then
                Return False
            End If


        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            clsSQLServer.Disconnect()
        End Try
        Return True
    End Function
#End Region

#Region "連携処理日データ取得"
    '20170516修正（HIDOC) S      本番稼働後課題[No.101] 連携処理日テーブル削除
    'Public Shared Function getSyoriData(ByVal Div_cd As String, ByVal MstKbn As String, ByRef dt As DataTable, Optional ConnectString As String = "") As Boolean
    '    Dim sql As New StringBuilder        ' SQL文
    '    Dim msg As String = ""          ' SQL発行時メッセージ

    '    Try
    '        sql.Append("SELECT * FROM 連携処理日 WHERE 事業所 ='" & Div_cd & "' AND マスタ区分 = '" & MstKbn & "'")
    '        'データベース接続
    '        clsSQLServer.Connect(ConnectString)

    '        dt = clsSQLServer.GetDataTable(sql.ToString, msg)
    '        If dt Is Nothing Then
    '            Return True
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
    '        clsLogTrace.GetExInstance().ExceptionWrite(ex)
    '        Return False
    '    Finally
    '        'データベース切断
    '        clsSQLServer.Disconnect()
    '    End Try
    '    Return True
    'End Function
    '20170516修正（HIDOC) E      本番稼働後課題[No.101]
#End Region

#Region "連携処理日登録更新"
    '20170516修正（HIDOC) S      本番稼働後課題[No.101] 連携処理日テーブル削除
    'Public Shared Function updSyoriData(ByVal Div_cd As String, ByVal MstKbn As String, ByVal Rec_cnt As Integer, Optional ConnectString As String = "") As Boolean
    '    Dim sql As New StringBuilder        ' SQL文
    '    Dim msg As String = ""          ' SQL発行時メッセージ

    '    Try
    '        If Rec_cnt = 0 Then
    '            sql.Append("INSERT INTO 連携処理日 VALUES ('" & Div_cd & "','" & MstKbn & "',FORMAT(GETDATE(),'yyyyMMdd'),FORMAT(GETDATE(),'HHmmss'))")
    '        Else
    '            sql.Append("UPDATE 連携処理日 SET 前回処理日=FORMAT(GETDATE(),'yyyyMMdd'),前回処理時刻=FORMAT(GETDATE(),'HHmmss') WHERE 事業所 ='" & Div_cd & "' AND マスタ区分 = '" & MstKbn & "'")
    '        End If
    '        'データベース接続
    '        clsSQLServer.Connect(ConnectString)

    '        'トランザクション
    '        BeginTransaction()

    '        'SQL実行
    '        ExecuteQuery(sql.ToString)

    '        'コミット
    '        Commit()

    '        Return True

    '    Catch ex As Exception
    '        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
    '        clsLogTrace.GetExInstance().ExceptionWrite(ex)
    '        Return False
    '    Finally
    '        'データベース切断
    '        clsSQLServer.Disconnect()
    '    End Try
    '    Return True
    'End Function
    '20170516修正（HIDOC) E      本番稼働後課題[No.101]
#End Region


#Region "SOCIOデータ変換"
    Public Shared Function convSocioData(ByVal dt As DataTable, p_divcode As String, ByVal p_item As String, ByVal p_code As String,
                                         ByVal p_ptn As String,
                                         ByRef p_socioFlg As Boolean, ByRef p_ErrMsg As String) As String

        Dim Convdata As String = ""
        Dim whereData As String = ""

        If p_ptn = "1" Then
            '20171005修正(システムズ) S [G30-001995] 類似対応
            'whereData = "事業所 = '" & p_divcode & "' AND 変換項目='" & p_item & "' AND 変換元= '" & p_code & "'"
            whereData = "事業所 = '" & p_divcode & "' AND 変換項目='" & p_item & "' AND 変換元= '" & p_code.Replace("'", "''") & "'"
            '20171005修正(システムズ) E [G30-001995] 類似対応
        Else
            '20171005修正(システムズ) S [G30-001995] 類似対応
            'whereData = "事業所 = '" & p_divcode & "' AND 変換項目='" & p_item & "' AND 変換後= '" & p_code & "'"
            whereData = "事業所 = '" & p_divcode & "' AND 変換項目='" & p_item & "' AND 変換後= '" & p_code.Replace("'", "''") & "'"
            '20171005修正(システムズ) E [G30-001995] 類似対応
        End If

        Try

            Dim rws() As DataRow = dt.Select(whereData)


            If rws.Count = 0 Then
                p_socioFlg = False
                p_ErrMsg = p_ErrMsg & " " & p_item & "；"
                Convdata = ""
            Else
                If p_ptn = "1" Then
                    Convdata = rws(0)("変換後").ToString.Trim
                Else
                    Convdata = rws(0)("変換元").ToString.Trim

                End If
            End If
            Return Convdata

        Catch ex As Exception
            p_socioFlg = False
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return Convdata
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
        Return True
    End Function
#End Region

#Region "シーケンシャル取得"
    Public Shared Function getSeq(ByVal strSQL As String, Optional ConnectString As String = "") As Long
        Dim sql As New StringBuilder        ' SQL文
        Dim myDataTable As New DataTable
        Dim msg As String = ""          ' SQL発行時メッセージ

        Try
            sql.Append(strSQL)

            'データベース接続
            clsSQLServer.Connect(ConnectString)

            myDataTable = clsSQLServer.GetDataTable(sql.ToString, msg)
            If myDataTable Is Nothing Then
                Return False
            End If

            Return Long.Parse(myDataTable.Rows(0).Item(0).ToString)

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return -1
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            'clsSQLServer.Disconnect()
        End Try
        Return True
    End Function
#End Region

    '20170310修正(HIDOC) S      BT課題[No.19]
#Region "DBオープン"
    ''' <summary>
    ''' DBオープン
    ''' </summary>
    ''' <param name="myConnectString">接続文字列</param>
    ''' <remarks>DBをオープンします。</remarks>
    Public Shared Function Connect2(Optional ByVal myConnectString As String = "") As Boolean
        Try

            If myCon.State = System.Data.ConnectionState.Open Then
                Return True
            End If

            If myConnectString.Length = 0 Then myConnectString = String.Format(clsGlobal._conStr, My.Settings.server, My.Settings.db, My.Settings.userid, My.Settings.password)

            ConnectString(myConnectString)
            myCon.ConnectionString = _strDBConnectString

            'DBをオープンする
            myCon.Open()
            myCommand2.Connection = myCon
            myCommand2.CommandType = CommandType.Text

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
        Return True
    End Function
#End Region

#Region "前日情報格納用テーブル取得"
    Public Shared Function getBef_ALLData(ByVal mst As String, ByRef dt As DataTable, ByRef Div As String, Optional ConnectString As String = "") As Boolean
        Dim sql As New StringBuilder        ' SQL文
        Dim msg As String = ""              ' SQL発行時メッセージ
        'Dim ds As DataSet = New DataSet()

        Try
            sql.Append("SELECT * FROM 前日情報_" & mst & " WHERE 事業所 = '" & Div & "'")
            'データベース接続
            clsSQLServer.Connect2(ConnectString)

            'SQL文設定
            myCommand2.CommandText = sql.ToString

            ' データアダプタの作成
            myDa.SelectCommand = myCommand2

            ' データセットへの読み込み
            myDa.Fill(myds, "前日情報_" & mst)
            'myDa.Fill(dt)

            dt = myds.Tables("前日情報_" & mst)
            If dt.Rows.Count = 0 Then
                'データ未取得
                Return False
            End If

            ' 主キーの設定
            If mst = "資材マスタ" Then
                dt.PrimaryKey = New DataColumn() {dt.Columns("事業所"), dt.Columns("工場コード"), dt.Columns("資材コード"), dt.Columns("取引先コード")}
            Else
                dt.PrimaryKey = New DataColumn() {dt.Columns("事業所"), dt.Columns("取引先コード")}
            End If
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)
            clsSQLServer.Disconnect2()

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            'clsSQLServer.Disconnect2()
        End Try
        Return True
    End Function
#End Region

#Region "前日情報更新"
    Public Shared Function UpdateBefData(ByRef dt As DataTable, ByVal strmst As String, Optional ConnectString As String = "") As Boolean

        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(myDa)
        Dim result As Integer

        Try
            ' データベースの更新
            builder.GetUpdateCommand()
            'result = myDa.Update(dt)
            result = myDa.Update(myds, "前日情報_" & strmst)

            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            clsLogTrace.GetInstance.TraceWrite(String.Format(clsGlobal.MSG("I023"), "前日情報", result), ClsLogString.RunState.Msg)
            '20170526修正(HIDOC) E      本番稼動後課題[No.102]

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)
            clsSQLServer.Disconnect2()

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            clsSQLServer.Disconnect2()
        End Try
        Return True
    End Function
#End Region

#Region "SqlDataAdapter用DB切断"
    Public Shared Function Disconnect2() As Boolean
        If Not myDa Is Nothing Then
            Try
                myDa.Dispose()
            Catch ex As Exception
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
                clsLogTrace.GetExInstance().ExceptionWrite(ex)

                '20171026修正(システムズ) S  例外処理不具合対応
                'Return False
                Throw
                '20171026修正(システムズ) E  例外処理不具合対応
            End Try
        End If

        ' 接続を閉じる
        If Not myCon Is Nothing Then
            ' 接続がオープンしている場合
            If myCon.State = System.Data.ConnectionState.Open Then
                Try
                    ' 接続を閉じる
                    myCon.Close()
                Catch ex As Exception
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
                    clsLogTrace.GetExInstance().ExceptionWrite(ex)

                    '20171026修正(システムズ) S  例外処理不具合対応
                    'Return False
                    Throw
                    '20171026修正(システムズ) E  例外処理不具合対応
                End Try
            End If
        End If
        Return True
    End Function
#End Region
    '20170310修正(HIDOC) E      BT課題[No.19]
    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
#Region "警告メッセージ管理テーブルのデータ取得"
    Public Shared Function getWarningMessage(ByVal p_divcode As String, Optional ConnectString As String = "") As Boolean
        Dim sql As New StringBuilder        ' SQL文
        Dim msg As String = ""              ' SQL発行時メッセージ

        Try
            sql.Append("SELECT * FROM 警告メッセージ管理 WHERE 事業所 = '" & p_divcode & "'")
            'データベース接続
            clsSQLServer.Connect(ConnectString)

            dt_WarMes = clsSQLServer.GetDataTable(sql.ToString, msg)
            If dt_WarMes Is Nothing Then
                Return False
            End If


        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            clsSQLServer.Disconnect()
        End Try
        Return True
    End Function
#End Region

#Region "警告メッセージ管理テーブルの該当データ取得"
    Public Shared Function getWarMes_Data(ByVal ErrMes As String, ByVal FlgType As Integer) As Boolean
        Try
            Dim rws() As DataRow
            Dim strSQL As String = ""

            If FlgType = 1 Then
                strSQL = "メッセージＩＤ = '" & ErrMes.Trim() & "'"
            Else
                '20171005修正(システムズ) S [G30-001995] 類似対応
                'strSQL = "メッセージ = '" & ErrMes.Trim() & "'"
                strSQL = "メッセージ = '" & ErrMes.Trim().Replace("'", "''") & "'"
                '20171005修正(システムズ) E [G30-001995] 類似対応
            End If
            '20171026修正(システムズ) S  例外処理不具合対応
            'rws = dt_WarMes.Select(strSQL)
            '20171026修正(システムズ) E  例外処理不具合対応

            If Not IsNothing(dt_WarMes) Then
                rws = dt_WarMes.Select(strSQL)
                If IsNothing(rws) OrElse rws.Count = 0 Then
                    '該当レコードなし
                    Return False
                End If
            Else
                '警告メッセージ管理テーブルにレコードなし
                Return False
            End If

        Catch ex As Exception
            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            '20171026修正(システムズ) E  例外処理不具合対応

            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return True

    End Function
#End Region

    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
    '20171004修正(システムズ) S 本番稼動後課題[No.535]
#Region "連携対象外資材マスタテーブルのデータ取得"
    Public Shared Function getExcludedSizaiMst(ByRef dt As DataTable, Optional ConnectString As String = "") As Boolean
        Dim sql As New StringBuilder        ' SQL文
        Dim msg As String = ""              ' SQL発行時メッセージ

        Try
            sql.Append("SELECT * FROM 連携対象外資材マスタ")
            'データベース接続
            clsSQLServer.Connect(ConnectString)

            dt = clsSQLServer.GetDataTable(sql.ToString, msg)
            If dt Is Nothing Then
                Return False
            End If

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'データベース切断
            clsSQLServer.Disconnect()
        End Try
        Return True
    End Function
#End Region
#Region "連携対象外資材マスタテーブルの該当データ取得"
    Public Shared Function getExcludedSizaiMst_Data(ByVal dt As DataTable, ByVal p_divcode As String, ByVal p_sizaicode As String, ByVal p_toricode As String) As Boolean
        Try
            Dim rws() As DataRow
            Dim strSQL As String = ""

            strSQL = "事業所 = '" & p_divcode.Trim() & "' AND 資材コード = '" & p_sizaicode.Trim().Replace("'", "''") & "' AND 取引先コード = '" & p_toricode.Trim() & "'"
            '20171026修正(システムズ) S  例外処理不具合対応
            'rws = dt.Select(strSQL)
            '20171026修正(システムズ) E  例外処理不具合対応

            If Not IsNothing(dt) Then
                rws = dt.Select(strSQL)
                If IsNothing(rws) OrElse rws.Count = 0 Then
                    '該当レコードなし
                    Return False
                End If
            Else
                '連携対象外資材マスタテーブルにレコードなし
                Return False
            End If

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return True

    End Function
#End Region
    '20171004修正(システムズ) E 本番稼動後課題[No.535]
End Class

