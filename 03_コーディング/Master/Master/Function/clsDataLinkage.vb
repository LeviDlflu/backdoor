Imports System.Text
Imports System.IO
Public Class clsInputLinkage
    Private Const CONST_HEADDER_NO As String = "0000000000"
    Private Const CONST_FOOTER_NO As String = "9999999999"
    'コンストラクタ
    Public Sub New(ByVal p_InFolder As String, ByVal p_OutFolder As String, ByVal p_ResInFolder As String, ByVal p_ResOutFolder As String, _
                   ByVal p_BkInFolder As String, ByVal p_BkOutFolder As String, ByVal p_BkResInFolder As String, ByVal p_BkResOutString As String, _
                   ByVal p_InFile As String, ByVal p_OutFile As String, ByVal p_ResInFile As String, ByVal p_ResOutFile As String)

        GetInputFolder = p_InFolder
        GetOutputFolder = p_OutFolder
        GetResInFolder = p_ResInFolder
        GetResOutFolder = p_ResOutFolder
        GetBkInputFolder = p_BkInFolder
        GetBkOutputFolder = p_BkOutFolder
        GetBkResInFolder = p_BkResInFolder
        GetBkResOutFolder = p_BkResOutString
        GetInputFile = p_InFile
        GetOutputFile = p_OutFile
        GetResInFile = p_ResInFile
        GetResOutFile = p_ResOutFile

    End Sub

#Region "フォルダチェック"
    ''' <summary>
    ''' フォルダチェックを行う
    ''' </summary>>
    ''' <returns>正常:true 異常:false</returns>
    ''' <remarks>フォルダチェックを行う</remarks>
    Public Function CheckFolder() As Boolean

        Try
            If Not (Directory.Exists(ResInFolder) And Directory.Exists(ResOutFolder) And Directory.Exists(BkResInFolder) And Directory.Exists(BkResOutFolder)) Then
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E001"), ClsLogString.RunState.Err)
                Return False
            End If

            Return True

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region

#Region "ファイルチェック"
    ''' <summary>
    ''' ファイルチェックを行う
    ''' </summary>>
    ''' <returns>正常:true 異常:false</returns>
    ''' <remarks>ファイルチェックを行う</remarks>
    Public Function CheckFile(ByVal p_folder As String, ByVal p_file As String) As Boolean

        Try

            GetFiles = System.IO.Directory.GetFiles(p_folder, p_file, System.IO.SearchOption.TopDirectoryOnly)

            Return True

        Catch ex As Exception
            clsLogTrace.GetExInstance().ExceptionWrite(ex)
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E007"), ClsLogString.RunState.Err)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region

#Region "出力結果ファイル正常チェック"
    ''' <summary>
    ''' 出力結果ファイル
    ''' </summary>>
    ''' <returns>正常:true 異常:false</returns>
    ''' <remarks>ヘッダ情報から結果データを判断する</remarks>
    Public Function CheckResOut(ByRef Result As String) As Boolean

        Try

            ' StreamReader の新しいインスタンスを生成する
            Dim cReader As New System.IO.StreamReader(ResOutPath, System.Text.Encoding.Default)

            ' 読み込んだ結果をすべて格納するための変数を宣言する
            Dim stResult As String = String.Empty

            ' ファイルを 1 行ずつ読み込む
            Dim stBuffer As String = cReader.ReadLine()

            stBuffer = clsEtc.MidB(stBuffer, 50, 2).Trim

            ' cReader を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            cReader.Close()

            Result = stBuffer

            Return True

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region

#Region "入力連携結果メール送信処理"
    ''' <summary>
    ''' 入力連携結果メール送信処理
    ''' </summary>
    ''' <remarks>出力結果をメール送信する</remarks>
    Public Sub SendMailResOutputData(ByVal myMail As clsMail)
        Try

            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I010"), ClsLogString.RunState.Msg)

            '出力結果ファイルチェック
            If CheckFile(GetResOutFolder, GetResOutFile) = False Then
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E009"), ClsLogString.RunState.Err)
                Exit Sub
            End If

            'フォルダ内をファイル処理()
            Dim files As String() = GetFiles

            If files.Length > 0 Then

                Dim OutResult As String = ""

                For Each file In files

                    GetResOutPath = file
                    GetResOutFile = Path.GetFileName(file)
                    GetBkResOutPath = Path.Combine(GetBkResOutFolder, GetResOutFile)


                    If MailSendFlg Then

                        '出力結果が異常の値を処理
                        If CheckResOut(OutResult) And OutResult <> "N" Then
                            'logフォルダ直下にtempフォルダ作成
                            Dim tempDirPath As String = Path.Combine(clsGlobal.GetLogFolder, "Temp")

                            If (System.IO.Directory.Exists(tempDirPath)) Then
                                clsEtc.DeleteDirectory(tempDirPath)
                                Directory.CreateDirectory(tempDirPath)
                            Else
                                Directory.CreateDirectory(tempDirPath)
                            End If

                            'RESファイルコピー
                            FileCopy(GetResOutPath, Path.Combine(tempDirPath, GetResOutFile))

                            '添付ファイル圧縮作成
                            myMail.GetZipPath = clsEtc.Createzip(GetResOutFile)
                            myMail.GetMailBody6 = My.Settings.MailErrType3

                            'メール送信
                            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I101"), ClsLogString.RunState.Msg)
                            If myMail.Send_Mail() = False Then
                                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E103"), ClsLogString.RunState.Err)
                                Continue For
                            End If
                            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I103"), ClsLogString.RunState.Msg)

                        End If


                    Else
                        'メール送信フラグがfalseの場合
                        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I102"), ClsLogString.RunState.Msg)
                    End If

                    'ファイル移動
                    If moveFile(GetResOutPath, GetBkResOutPath) = False Then
                        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E008"), ClsLogString.RunState.Err)
                        Continue For
                    End If

                Next

            Else
                'ファイルが存在しない場合
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I007"), ClsLogString.RunState.Msg)
            End If


        Catch ex As Exception

            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'zipファイルを削除する
            If (System.IO.File.Exists(myMail.GetZipPath)) Then
                System.IO.File.Delete(myMail.GetZipPath)
            End If
        End Try

    End Sub

#End Region

#Region "入出力連携エラーメール送信処理"
    ''' <summary>
    ''' 入出力連携エラーメール送信処理
    ''' </summary>
    ''' <remarks>エラーファイルをメール送信する</remarks>


    Public Function SendMail(ByVal myMail As clsMail, Optional SyslogStart As Integer = 0) As Boolean
        'Public Function SendMail(ByVal myMail As clsMail) As Boolean
        Try

            Dim MailBody As String = ""
            Dim SendFileCnt As Integer = 0
            '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            Dim WarMailBody As String = ""
            Dim SendWarFileCnt As Integer = 0
            '20170614修正(HIDOC) E      本番稼動後課題[No.402]

            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I002"), ClsLogString.RunState.Msg)

            'logフォルダ直下にtempフォルダ作成
            '20170630修正(HIDOC) S      本番稼動後課題[No.123]
            'Dim tempDirPath As String = Path.Combine(clsGlobal.GetLogFolder, "Temp")
            Dim tempDirPath As String = Path.Combine(clsGlobal.GetLogFolder, "Temp_" & System.Guid.NewGuid.ToString())
            '20170630修正(HIDOC) E      本番稼動後課題[No.123]
            '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            '警告メール用tempフォルダ作成
            Dim WarDirPath As String = Path.Combine(clsGlobal.GetLogFolder, "War_" & System.Guid.NewGuid.ToString())
            '20170614修正(HIDOC) E      本番稼動後課題[No.402]

            If (System.IO.Directory.Exists(tempDirPath)) Then
                clsEtc.DeleteDirectory(tempDirPath)
                Directory.CreateDirectory(tempDirPath)
            Else
                Directory.CreateDirectory(tempDirPath)
            End If
            '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            If (System.IO.Directory.Exists(WarDirPath)) Then
                clsEtc.DeleteDirectory(WarDirPath)
                Directory.CreateDirectory(WarDirPath)
            Else
                Directory.CreateDirectory(WarDirPath)
            End If
            '20170614修正(HIDOC) E      本番稼動後課題[No.402]

            '20170630修正(HIDOC) S      本番稼動後課題[No.123]
            'If System.IO.File.Exists(GetResInPath) Then
            '    'マッピングエラーファイルコピー
            '    If myMail.GetMailSendType = "1" Then

            '        FileCopy(ResInPath, Path.Combine(tempDirPath, String.Format("{0}{1}", "RES", InputFile)))
            '    Else
            '        FileCopy(ResInPath, Path.Combine(tempDirPath, String.Format("{0}_{1}", clsInputLinkage.FileDateTime2, GetResInFile)))
            '        FileCopy(ResInPath, Path.Combine(WarDirPath, String.Format("{0}_{1}", clsInputLinkage.FileDateTime2, GetResInFile)))
            '    End If
            '    SendFileCnt = SendFileCnt + 1
            '    MailBody = MailBody & My.Settings.MailErrType1 & " "
            'End If

            'If System.IO.File.Exists(GetResCUPPath) Then
            '    'CUPファイルエラーコピー
            '    FileCopy(ResCUPPath, Path.Combine(tempDirPath, String.Format("{0}_{1}_{2}.log", clsInputLinkage.FileDateTime2, clsGlobal.GetLogFile, "CUP")))
            '    FileCopy(ResCUPPath, Path.Combine(WarDirPath, String.Format("{0}_{1}_{2}.log", clsInputLinkage.FileDateTime2, clsGlobal.GetLogFile, "CUP")))
            '    MailBody = MailBody & My.Settings.MailErrType2 & " "
            '    SendFileCnt = SendFileCnt + 1
            'End If

            '20170630修正(HIDOC) E      本番稼動後課題[No.123]

            Dim LogPath As String = String.Format(DefaultValues.LOG_FILENAME_FORMAT, clsGlobal.GetLogFolder, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile)
            Dim LogExcPath As String = String.Format(DefaultValues.EXC_FILENAME_FORMAT, clsGlobal.GetLogFolder, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile)


            '2016/12/10 
            ''--------------------------------------------------------
            ''エクセプションエラーの有無で判定すると、
            ''複数ファイルで1ファイル目にエラーの場合、
            ''後続ファイルが正常であってもメールが飛び続けるため、処理を修正
            ''--------------------------------------------------------
            ' ''エクセプションエラー存在チェック
            ''If System.IO.File.Exists(LogExcPath) Then
            ''    '存在する場合、システムエラーと一緒にコピー
            ''    FileCopy(LogPath, String.Format(DefaultValues.LOG_FILENAME_FORMAT, tempDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
            ''    FileCopy(LogExcPath, String.Format(DefaultValues.EXC_FILENAME_FORMAT, tempDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
            ''    MailBody = MailBody & My.Settings.MailErrType4
            ''    SendFileCnt = SendFileCnt + 1
            ''Else
            ''    '存在しない場合、ERRチェック
            ''    If clsEtc.CheckColmStr(LogPath, ",", "[ERR]", 1, SyslogStart) Then
            ''        FileCopy(LogPath, String.Format(DefaultValues.LOG_FILENAME_FORMAT, tempDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
            ''        SendFileCnt = SendFileCnt + 1
            ''        MailBody = MailBody & My.Settings.MailErrType4
            ''    End If
            ''End If

            'システムエラーログ内のERRチェック
            If clsEtc.CheckColmStr(LogPath, ",", "[ERR]", 1, SyslogStart) Then
                FileCopy(LogPath, String.Format(DefaultValues.LOG_FILENAME_FORMAT, tempDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
                SendFileCnt = SendFileCnt + 1
                MailBody = MailBody & My.Settings.MailErrType4

                'エクセプションエラー存在チェック
                If System.IO.File.Exists(LogExcPath) Then
                    '存在する場合、システムエラーと一緒にコピー
                    FileCopy(LogExcPath, String.Format(DefaultValues.EXC_FILENAME_FORMAT, tempDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
                    SendFileCnt = SendFileCnt + 1
                End If
                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                If System.IO.File.Exists(GetResInPath) Then
                    'マッピングエラーファイルコピー
                    If myMail.GetMailSendType = "1" Then
                        FileCopy(ResInPath, Path.Combine(tempDirPath, String.Format("{0}{1}", "RES", InputFile)))
                    Else
                        FileCopy(ResInPath, Path.Combine(tempDirPath, String.Format("{0}_{1}", clsInputLinkage.FileDateTime2, GetResInFile)))
                    End If
                    SendFileCnt = SendFileCnt + 1
                    MailBody = MailBody & My.Settings.MailErrType1 & " "
                End If

                If System.IO.File.Exists(GetResCUPPath) Then
                    'CUPファイルエラーコピー
                    FileCopy(ResCUPPath, Path.Combine(tempDirPath, String.Format("{0}_{1}_{2}.log", clsInputLinkage.FileDateTime2, clsGlobal.GetLogFile, "CUP")))
                    MailBody = MailBody & My.Settings.MailErrType2 & " "
                    SendFileCnt = SendFileCnt + 1
                End If
                '20170630修正(HIDOC) E      本番稼動後課題[No.123]
            End If

            '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            'システムエラーログ内のWARチェック
            If clsEtc.CheckColmStr(LogPath, ",", "[WAR]", 1, SyslogStart) Then
                FileCopy(LogPath, String.Format(DefaultValues.LOG_FILENAME_FORMAT, WarDirPath, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile))
                SendWarFileCnt = SendWarFileCnt + 1
                WarMailBody = "ワーニングエラー"

                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                If System.IO.File.Exists(GetResInPath) Then
                    'マッピングエラーファイルコピー
                    If myMail.GetMailSendType = "1" Then
                        FileCopy(ResInPath, Path.Combine(WarDirPath, String.Format("{0}{1}", "RES", InputFile)))
                    Else
                        FileCopy(ResInPath, Path.Combine(WarDirPath, String.Format("{0}_{1}", clsInputLinkage.FileDateTime2, GetResInFile)))
                    End If
                    SendWarFileCnt = SendWarFileCnt + 1
                End If

                    If System.IO.File.Exists(GetResCUPPath) Then
                        'CUPファイルエラーコピー
                        FileCopy(ResCUPPath, Path.Combine(WarDirPath, String.Format("{0}_{1}_{2}.log", clsInputLinkage.FileDateTime2, clsGlobal.GetLogFile, "CUP")))
                        SendWarFileCnt = SendWarFileCnt + 1
                    End If
                    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
                End If
            '20170614修正(HIDOC) E      本番稼動後課題[No.402]

            'tempフォルダに1件以上存在する場合、メールを送信する
            If SendFileCnt > 0 Then

                'マッピング移行の処理まで流れた場合はコピー
                If Not (InputPath = Nothing) Then
                    FileCopy(InputPath, Path.Combine(tempDirPath, InputFile))
                End If
                'tempフォルダに1つでもファイルが存在する場合、inputファイルをコピーしてメール送信
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I101"), ClsLogString.RunState.Msg)

                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                '先に警告メールを送信していた場合、タイトルをエラーにする
                'myMail.GetMailTitle = String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString)
                If clsEtc.MidB(myMail.GetMailTitle, 1, 3) = "ERR" Then
                    myMail.GetMailTitle = String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString)
                ElseIf clsEtc.MidB(myMail.GetMailTitle, 1, 4) = "警告" Then
                    myMail.GetMailTitle = Replace(String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString), "警告", "ERR", 1, 1)
                Else
                    myMail.GetMailTitle = "ERR_" & String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString)
                End If
                '20170630修正(HIDOC) E      本番稼動後課題[No.123]
                myMail.GetMailBody6 = MailBody

                '添付ファイル圧縮作成
                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                'myMail.GetZipPath = clsEtc.Createzip(myMail.GetMailBody4)
                myMail.GetZipPath = clsEtc.Createzip(myMail.GetMailBody4, tempDirPath)
                '20170630修正(HIDOC) E      本番稼動後課題[No.123]

                'メール送信
                If myMail.Send_Mail() = False Then
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E103"), ClsLogString.RunState.Err)
                Else
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I103"), ClsLogString.RunState.Msg)
                End If

            Else
                'tempフォルダ削除
                clsEtc.DeleteDirectory(tempDirPath)
            End If

            '20170614修正(HIDOC) S      本番稼動後課題[No.402]
            'War（警告）ログフォルダに1件以上存在する場合、警告メールを送信する
            If SendWarFileCnt > 0 Then

                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                'マッピング移行の処理まで流れた場合はコピー
                If Not (InputPath = Nothing) Then
                    FileCopy(InputPath, Path.Combine(WarDirPath, InputFile))
                End If
                '20170630修正(HIDOC) E      本番稼動後課題[No.123]
                'War（警告）ログフォルダに1つでもファイルが存在する場合、メール送信
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I104"), ClsLogString.RunState.Msg)

                'メールタイトルはERRを警告に置き換える。
                '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                If clsEtc.MidB(myMail.GetMailTitle, 1, 4) = "警告" Then
                    myMail.GetMailTitle = String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString)
                ElseIf clsEtc.MidB(myMail.GetMailTitle, 1, 3) = "ERR" Then
                    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
                    myMail.GetMailTitle = Replace(String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString), "ERR", "警告", 1, 1)
                Else
                    myMail.GetMailTitle = "警告_" & String.Format(myMail.GetMailTitle, Format(Now, "yyyyMMdd").ToString)
                End If
                myMail.GetMailBody6 = WarMailBody

                '添付ファイル圧縮作成
                myMail.GetZipPath = clsEtc.Createzip(myMail.GetMailBody4, WarDirPath)

                'メール送信
                If myMail.Send_Mail() = False Then
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E103"), ClsLogString.RunState.Err)
                Else
                    clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I105"), ClsLogString.RunState.Msg)
                End If

            Else
                'tempフォルダ削除
                clsEtc.DeleteDirectory(WarDirPath)
            End If
                '20170614修正(HIDOC) E      本番稼動後課題[No.402]

                Return True

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            'zipファイルを削除する
            If (System.IO.File.Exists(myMail.GetZipPath)) Then
                System.IO.File.Delete(myMail.GetZipPath)
            End If
        End Try

    End Function

#End Region

#Region "受信ファイル読込処理"
    ''' <summary>
    ''' 受信ファイル読込処理
    ''' </summary>>
    ''' <returns></returns>
    ''' <remarks>txtファイルを読み込みDataSetに格納する</remarks>
    Public Function inputCSVToDataSet(ByRef dtCSV As DataTable, Optional ByVal zigyousyoFlg As String = "") As Boolean
        Try
            Dim sFileExt As String = Path.GetExtension(InputPath)

            '20170418(HIDOC)修正 S
            Dim sFileName As String = Path.GetFileName(InputPath)
            '20170418(HIDOC)修正 E

            'If Not (sFileExt = ".txt" Or sFileExt = ".DAT") Then Return False

            '名張事業所
            If zigyousyoFlg = "" Then
                If sFileExt = ".txt" Then
                    ' txtファイルからデータを取得しDataTableへ
                    If clsCSV.CSVtoDataTable(dtCSV, True, InputPath, , True) = False Then
                        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E003"), ClsLogString.RunState.Err)
                        Return False
                    End If
                Else
                    ' DATファイルからデータを取得しDataTable2へ
                    If clsCSV.CSVtoDataTable2(dtCSV, False, InputPath, ";", False) = False Then
                        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E003"), ClsLogString.RunState.Err)
                        Return False
                    End If

                End If

            ElseIf zigyousyoFlg = "1" Then    '埼玉事業所
                If sFileExt = ".DAT" Then
                    '20170418(HIDOC)修正 S
                    '埼玉_出庫データのみTRIMしない
                    If sFileName.Substring(sFileName.Length - 9, 9) = "SYUKO.DAT" Then
                        ' 「DataTable3」使用
                        If clsCSV.CSVtoDataTable3(dtCSV, False, InputPath, ";", False) = False Then
                            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E003"), ClsLogString.RunState.Err)
                            Return False
                        End If
                    Else
                        '20170418(HIDOC)修正 E

                        ' DATファイルからデータを取得しDataTable2へ
                        If clsCSV.CSVtoDataTable2(dtCSV, False, InputPath, ";", False) = False Then
                            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E003"), ClsLogString.RunState.Err)
                            Return False
                        End If
                        '20170418(HIDOC)修正 S
                    End If
                    '20170418(HIDOC)修正 E

                Else    '拡張子なし（入力連携用）
                    ' txtファイルからデータを取得しDataTableへ
                    If clsCSV.CSVtoDataTable(dtCSV, False, InputPath, , True) = False Then
                        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E003"), ClsLogString.RunState.Err)
                        Return False
                    End If

                End If

            ElseIf zigyousyoFlg = "2" Then    '彦根事業所

            ElseIf zigyousyoFlg = "3" Then    'オート関西事業所

            End If

            '取得件数が0件の場合(正常値として扱う）
            If dtCSV.Rows.Count = 0 Then
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("I018"), ClsLogString.RunState.Msg)
            End If

            Return True

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function
#End Region

#Region "SYSTEMログ件数取得"

    ''' <summary>
    ''' SYSTEMログ件数取得
    ''' </summary>>
    ''' <returns></returns>
    ''' <remarks>システムログの件数取得</remarks>
    Public Function GetSyslogCnt() As Integer
        Try
            Dim LogPath As String = String.Format(DefaultValues.LOG_FILENAME_FORMAT, clsGlobal.GetLogFolder, clsInputLinkage.GetFileDateTime, clsGlobal.GetLogFile)
            Dim CNT As Integer = 0

            If System.IO.File.Exists(LogPath) = False Then Return 0

            ' StreamReader の新しいインスタンスを生成する
            Dim cReader As New System.IO.StreamReader(LogPath, System.Text.Encoding.Default)

            ' 読み込みできる文字がなくなるまで繰り返す
            While (cReader.Peek() >= 0)

                cReader.ReadLine()

                CNT = CNT + 1

            End While

            ' cReader を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            cReader.Close()

            Return CNT
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return 0
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function
#End Region

#Region "ファイル出力"
    ''' <summary>
    ''' ファイル出力処理
    ''' </summary>>
    ''' <returns></returns>
    ''' <remarks>DataSetのデータを固定長ファイルに出力する</remarks>
    Public Function outputDataSetToFile(ByVal p_dt As DataTable) As Boolean
        Dim bRet As Boolean
        Try

            'ヘッダ、フッタ作成
            Dim HeaderData As String = String.Format("{0}{1}{2}{3}{4}{5}", CONST_HEADDER_NO, IdentNum, FileDateTime2, clsEtc.PadRightB(OutputFile, 24, " "), "  ", ";")
            Dim FooterData As String = String.Format("{0}{1}{2}", CONST_FOOTER_NO, clsEtc.PadLeftB(RecCnt.ToString, 10, "0"), ";")

            'CSV出力
            bRet = clsCSV.ConvertDataTableToFixedLengthDataFile(p_dt, OutputPath, HeaderData, FooterData, False)
            If bRet = False Then
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E007"), ClsLogString.RunState.Err)
                Return False
            End If
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function
#End Region

#Region "出力連携ファイル移動"
    ''' <summary>
    ''' ファイル移動
    ''' </summary>>
    ''' <returns></returns>
    ''' <remarks>入力ファイルをバックアップフォルダに移動する</remarks>
    Public Function moveFile_out() As Boolean
        Try

            'Inputファイルバックアップ
            If System.IO.File.Exists(InputPath) Then
                My.Computer.FileSystem.MoveFile(InputPath, BkInputPath, True)
            End If

            'マッピングファイルバックアップ
            If System.IO.File.Exists(ResInPath) Then
                My.Computer.FileSystem.MoveFile(ResInPath, BkResInPath, True)
            End If

            'CUPファイルバックアップ
            If System.IO.File.Exists(ResCUPPath) Then
                My.Computer.FileSystem.MoveFile(ResCUPPath, BkResCupPath, True)
            End If

            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function
#End Region

#Region "ファイル移動"
    ''' <summary>
    ''' ファイル移動
    ''' </summary>>
    ''' <returns></returns>
    ''' <remarks>入力ファイルをバックアップフォルダに移動する</remarks>
    Public Function moveFile(ByVal p_path1 As String, ByVal p_path2 As String) As Boolean
        Try
            Dim stParentName As String = System.IO.Path.GetDirectoryName(p_path2)

            If System.IO.File.Exists(p_path2) Then
                Dim di As New DirectoryInfo(stParentName)
                clsEtc.RemoveReadonlyAttribute(di)
                My.Computer.FileSystem.DeleteFile(p_path2)
            End If

            My.Computer.FileSystem.MoveFile(p_path1, p_path2, True)
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try
    End Function
#End Region

#Region "FileDateTime"
    Private Shared FileDateTime As String
    Public Shared Property GetFileDateTime() As String
        Get
            Return FileDateTime
        End Get
        Set(ByVal value As String)
            FileDateTime = value
        End Set
    End Property
#End Region

#Region "FileDateTime2"
    Private Shared FileDateTime2 As String
    Public Shared Property GetFileDateTime2() As String
        Get
            Return FileDateTime2
        End Get
        Set(ByVal value As String)
            FileDateTime2 = value
        End Set
    End Property
#End Region

#Region "Files"
    Private Files As String()
    Public Property GetFiles() As String()
        Get
            Return Files
        End Get
        Set(ByVal value As String())
            Files = value
        End Set
    End Property
#End Region

#Region "Inputフォルダ"
    Private InputFolder As String
    Public Property GetInputFolder() As String
        Get
            Return InputFolder
        End Get
        Set(ByVal value As String)
            InputFolder = value
        End Set
    End Property
#End Region

#Region "Outputフォルダ"
    Private OutputFolder As String
    Public Property GetOutputFolder() As String
        Get
            Return OutputFolder
        End Get
        Set(ByVal value As String)
            OutputFolder = value
        End Set
    End Property
#End Region

#Region "ResInフォルダ"
    Private ResInFolder As String
    Public Property GetResInFolder() As String
        Get
            Return ResInFolder
        End Get
        Set(ByVal value As String)
            ResInFolder = value
        End Set
    End Property
#End Region

#Region "ResOutフォルダ"
    Private ResOutFolder As String
    Public Property GetResOutFolder() As String
        Get
            Return ResOutFolder
        End Get
        Set(ByVal value As String)
            ResOutFolder = value
        End Set
    End Property
#End Region

#Region "BkInputフォルダ"
    Private BkInputFolder As String
    Public Property GetBkInputFolder() As String
        Get
            Return BkInputFolder
        End Get
        Set(ByVal value As String)
            BkInputFolder = value
        End Set
    End Property
#End Region

#Region "BkOutputフォルダ"
    Private BkOutputFolder As String
    Public Property GetBkOutputFolder() As String
        Get
            Return BkOutputFolder
        End Get
        Set(ByVal value As String)
            BkOutputFolder = value
        End Set
    End Property
#End Region

#Region "BkResInフォルダ"
    Private BkResInFolder As String
    Public Property GetBkResInFolder() As String
        Get
            Return BkResInFolder
        End Get
        Set(ByVal value As String)
            BkResInFolder = value
        End Set
    End Property
#End Region

#Region "BkResOutフォルダ"
    Private BkResOutFolder As String
    Public Property GetBkResOutFolder() As String
        Get
            Return BkResOutFolder
        End Get
        Set(ByVal value As String)
            BkResOutFolder = value
        End Set
    End Property
#End Region

#Region "InputFile"
    Private InputFile As String
    Public Property GetInputFile() As String
        Get
            Return InputFile
        End Get
        Set(ByVal value As String)
            InputFile = value
        End Set
    End Property
#End Region

#Region "OutputFile"
    Private OutputFile As String
    Public Property GetOutputFile() As String
        Get
            Return OutputFile
        End Get
        Set(ByVal value As String)
            OutputFile = value
        End Set
    End Property
#End Region

#Region "ResInFile"
    Private ResInFile As String
    Public Property GetResInFile() As String
        Get
            Return ResInFile
        End Get
        Set(ByVal value As String)
            ResInFile = value
        End Set
    End Property
#End Region

#Region "ResOutFile"
    Private ResOutFile As String
    Public Property GetResOutFile() As String
        Get
            Return ResOutFile
        End Get
        Set(ByVal value As String)
            ResOutFile = value
        End Set
    End Property
#End Region

#Region "Inputパス"
    Private InputPath As String
    Public Property GetInputPath() As String
        Get
            Return InputPath
        End Get
        Set(ByVal value As String)
            InputPath = value
        End Set
    End Property
#End Region

#Region "Outputパス"
    Private OutputPath As String
    Public Property GetOutputPath() As String
        Get
            Return OutputPath
        End Get
        Set(ByVal value As String)
            OutputPath = value
        End Set
    End Property
#End Region

#Region "ResInパス"
    Private ResInPath As String
    Public Property GetResInPath() As String
        Get
            Return ResInPath
        End Get
        Set(ByVal value As String)
            ResInPath = value
        End Set
    End Property
#End Region

#Region "ResCUPパス"
    Private ResCUPPath As String
    Public Property GetResCUPPath() As String
        Get
            Return ResCUPPath
        End Get
        Set(ByVal value As String)
            ResCUPPath = value
        End Set
    End Property
#End Region

#Region "ResOutパス"
    Private ResOutPath As String
    Public Property GetResOutPath() As String
        Get
            Return ResOutPath
        End Get
        Set(ByVal value As String)
            ResOutPath = value
        End Set
    End Property
#End Region

#Region "BkInputパス"
    Private BkInputPath As String
    Public Property GetBkInputPath() As String
        Get
            Return BkInputPath
        End Get
        Set(ByVal value As String)
            BkInputPath = value
        End Set
    End Property
#End Region

#Region "BkOutputパス"
    Private BkOutputPath As String
    Public Property GetBkOutputPath() As String
        Get
            Return BkOutputPath
        End Get
        Set(ByVal value As String)
            BkOutputPath = value
        End Set
    End Property
#End Region

#Region "BkResInパス"
    Private BkResInPath As String
    Public Property GetBkResInPath() As String
        Get
            Return BkResInPath
        End Get
        Set(ByVal value As String)
            BkResInPath = value
        End Set
    End Property
#End Region

#Region "BkResCUPパス"
    Private BkResCupPath As String
    Public Property GetBkResCupPath() As String
        Get
            Return BkResCupPath
        End Get
        Set(ByVal value As String)
            BkResCupPath = value
        End Set
    End Property
#End Region


#Region "BkResOutパス"
    Private BkResOutPath As String
    Public Property GetBkResOutPath() As String
        Get
            Return BkResOutPath
        End Get
        Set(ByVal value As String)
            BkResOutPath = value
        End Set
    End Property
#End Region

#Region "メール送信フラグ"
    Private MailSendFlg As String
    Public Property GetMailSendFlg() As String
        Get
            Return MailSendFlg
        End Get
        Set(ByVal value As String)
            MailSendFlg = value
        End Set
    End Property
#End Region



#Region "データ件数"
    Private RecCnt As Long
    Public Property GetRecCnt() As Long
        Get
            Return RecCnt
        End Get
        Set(ByVal value As Long)
            RecCnt = value
        End Set
    End Property
#End Region

#Region "識別番号"
    Private IdentNum As Long
    Public Property GetIdentNum() As Long
        Get
            Return IdentNum
        End Get
        Set(ByVal value As Long)
            IdentNum = value
        End Set
    End Property
#End Region

End Class
