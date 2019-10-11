Imports System.Text
Imports System.IO
Imports System.IO.Compression
Public Class clsEtc

#Region "圧縮ファイル作成"
    '20170614修正(HIDOC) S      本番稼動後課題[No.402]
    ''' <summary>
    ''' 圧縮ファイルを作成する
    ''' </summary>>
    ''' <param name="sourceFileName">データテーブル行データ(Out)</param>
    ''' <param name="WarPath">一時格納用ログフォルダパス</param>
    ''' <returns>圧縮ファイルのパス</returns>
    ''' <remarks>圧縮ファイルを作成する</remarks>
    Public Shared Function Createzip(ByVal sourceFileName As String, Optional ByVal WarPath As String = "") As String
        'Public Shared Function Createzip(ByVal sourceFileName As String) As String
        '20170614修正(HIDOC) E      本番稼動後課題[No.402]


        '20170614修正(HIDOC) S      本番稼動後課題[No.402]
        'Dim startPath As String = Path.Combine(clsGlobal.GetLogFolder, "Temp")
        Dim startPath As String
        If WarPath = "" Then
            startPath = Path.Combine(clsGlobal.GetLogFolder, "Temp")
        Else
            startPath = WarPath
        End If
        '20170614修正(HIDOC) E      本番稼動後課題[No.402]
        Dim zipFilePath As String = String.Format("{0}.zip", Path.Combine(clsGlobal.GetLogFolder, sourceFileName))


        '同名ファイルが存在していたら消す
        If (System.IO.File.Exists(zipFilePath)) Then
            System.IO.File.Delete(zipFilePath)
        End If

        ZipFile.CreateFromDirectory(startPath, zipFilePath)


        'tempフォルダ削除
        If (System.IO.Directory.Exists(startPath)) Then
            DeleteDirectory(startPath)
        End If


        Return zipFilePath

    End Function
#End Region

#Region "フォルダ削除"
    ''' <summary>
    ''' フォルダを削除する（ReadOnlyでも削除）
    ''' </summary>
    ''' <param name="dir">削除するフォルダ</param>
    Public Shared Sub DeleteDirectory(ByVal dir As String)
        'DirectoryInfoオブジェクトの作成
        Dim di As New DirectoryInfo(dir)

        'フォルダ以下のすべてのファイル、フォルダの属性を削除
        RemoveReadonlyAttribute(di)

        'フォルダを根こそぎ削除
        di.Delete(True)
    End Sub
#End Region

#Region "フォルダ属性変更"
    Public Shared Sub RemoveReadonlyAttribute( _
            ByVal dirInfo As DirectoryInfo)
        '基のフォルダの属性を変更
        If (dirInfo.Attributes And FileAttributes.ReadOnly) =
            FileAttributes.ReadOnly Then
            dirInfo.Attributes = FileAttributes.Normal
        End If
        'フォルダ内のすべてのファイルの属性を変更
        Dim fi As FileInfo
        For Each fi In dirInfo.GetFiles()
            If (fi.Attributes And FileAttributes.ReadOnly) =
                FileAttributes.ReadOnly Then
                fi.Attributes = FileAttributes.Normal
            End If
        Next fi
        'サブフォルダの属性を回帰的に変更
        Dim di As DirectoryInfo
        For Each di In dirInfo.GetDirectories()
            RemoveReadonlyAttribute(di)
        Next di
    End Sub
#End Region

#Region "　LenB メソッド　"
    ''' <summary>
    ''' バイト数チェック
    ''' </summary>>
    '''<param name="stTarget">バイト数取得の対象となる文字列</param>
    '''<returns>半角 1 バイト、全角 2 バイトでカウントされたバイト数。</returns>
    ''' <remarks>バイト数と位置を指定して文字列を切り抜く</remarks>
    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

#End Region

#Region "全角半角チェック"
    ''' <summary>
    ''' 全角半角チェック
    ''' </summary>>
    '''<param name="stTarget">全角半角チェックの対象となる文字列</param>
    '''<returns>全角のみ：vbWide(4) 半角のみ：vbNarrow(8) 混在：-1</returns>
    ''' <remarks>全角または半角が含まれているかをチェックする</remarks>
    Public Shared Function CheckZenHan(ByVal stTarget As String) As Integer
        Static Encode_JIS As Encoding = Encoding.GetEncoding("Shift_JIS")
        Dim Str_Count As Integer = stTarget.Length
        Dim ByteCount = Encode_JIS.GetByteCount(stTarget)

        If Str_Count = ByteCount Then
            Return vbNarrow '8
        ElseIf Str_Count * 2 = ByteCount Then
            Return vbWide '4
        Else
            Return -1
        End If
    End Function

#End Region

#Region "文字切り取り"
    ''' <summary>
    ''' バイト数と位置を指定して文字列を切り抜く
    ''' </summary>>
    '''<param name="str">対象の文字列</param>
    ''' <param name="Start">開始位置</param>
    ''' <param name="Length">切り抜くバイト数</param>
    ''' <returns></returns>
    ''' <remarks>バイト数と位置を指定して文字列を切り抜く</remarks>
    Public Shared Function MidB(ByVal str As String, ByVal Start As Integer, Optional ByVal Length As Integer = 0) As String
        Dim RestLength As Integer
        Dim SJIS As System.Text.Encoding
        Dim B() As Byte
        Dim st1 As String
        Dim ResultLength As Integer

        If str = "" Then
            Return ""
        End If

        RestLength = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

        If Length = 0 OrElse Length > RestLength Then
            Length = RestLength
        End If

        If Length < 0 Then
            Return ""
        End If

        SJIS = System.Text.Encoding.GetEncoding("Shift-JIS")
        B = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

        Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

        st1 = SJIS.GetString(B)

        '切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。
        ResultLength = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

        If st1 = "" Then

            Return st1

        ElseIf (Asc(Strings.Right(st1, 1)) = 0) Or (Length = ResultLength - 1) Then
            '最後の１バイトが全角の半分の時
            Return st1.Substring(0, st1.Length - 1)
        Else
            'その他の場合
            Return st1
        End If

    End Function
#End Region

#Region "右文字埋め"
    ''' <summary>
    ''' 指定桁数まで文字埋め
    ''' </summary>>
    '''<param name="str">対象の文字列</param>
    ''' <param name="p_Byte">指定桁数</param>
    ''' <returns></returns>
    ''' <remarks>指定桁数まで文字埋め(右空白)</remarks>
    Public Shared Function PadRightB(ByVal str As String, ByVal p_Byte As Integer, ByVal p_char As String) As String

        Dim ByteLength As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(str)

        '●入力できる桁数を超えた場合文字を削る
        If p_Byte < ByteLength Then

            str = MidB(str, 1, p_Byte)
            ByteLength = System.Text.Encoding.GetEncoding(932).GetByteCount(str)

        End If

        Dim MojiLength As Integer = str.Length
        Dim Resultst1 As String = str.PadRight(p_Byte - (ByteLength - MojiLength), p_char)

        Return Resultst1

    End Function

#End Region

#Region "左文字埋め"
    ''' <summary>
    ''' 指定桁数まで文字埋め
    ''' </summary>>
    '''<param name="str">対象の文字列</param>
    ''' <param name="p_Byte">指定桁数</param>
    ''' <returns></returns>
    ''' <remarks>指定桁数まで文字埋め(左空白)</remarks>
    Public Shared Function PadLeftB(ByVal str As String, ByVal p_Byte As Integer, ByVal p_char As String) As String

        Dim ByteLength As Integer = System.Text.Encoding.GetEncoding(932).GetByteCount(str)
        Dim MojiLength As Integer = str.Length

        Dim Resultst1 As String = str.PadLeft(p_Byte - (ByteLength - MojiLength), p_char)

        Return Resultst1

    End Function

#End Region

#Region "特定文字抽出(資材マスタ用）"
    Public Shared Function getText(ByVal targetMoji As String,
                                ByVal kensakuKakkoNo As Integer,
                                ByVal mojiken_s As String,
                                ByVal mojiken_e As String, ByRef HitFlg As Boolean) As String

        Dim retMoji As String = ""

        kensakuKakkoNo = kensakuKakkoNo

        'targetMojiに「[」(mojiken)がない時
        If targetMoji.IndexOf(mojiken_s) < 0 Then
            Return retMoji
        End If

        '始めの位置を探す
        Dim StartIndex As Integer = targetMoji.IndexOf(mojiken_s)
        Dim EndIndex As Integer = targetMoji.IndexOf(mojiken_e)
        Dim loopnum As Integer = 1
        While 0 <= StartIndex

            If loopnum = kensakuKakkoNo Then
                HitFlg = True
                Exit While
            End If
            loopnum = loopnum + 1

            '次の検索文字
            If EndIndex + 1 < targetMoji.Length Then

                If StartIndex > EndIndex Then
                    StartIndex = targetMoji.IndexOf(mojiken_s, StartIndex)
                Else
                    StartIndex = targetMoji.IndexOf(mojiken_s, StartIndex + 1)
                End If

                'If StartIndex <> EndIndex + 1 And StartIndex > EndIndex Then

                '    Dim mojiSearch As String = ""

                '    mojiSearch = targetMoji.Substring(EndIndex + 1, StartIndex - (EndIndex + 1))

                '    If mojiSearch.Where(Function(c) c = mojiken_s).Count() > 0 Or mojiSearch.Where(Function(c) c = mojiken_e).Count() > 0 Then
                '        retMoji = ""
                '        HitFlg = False


                '    Else

                '        EndIndex = targetMoji.IndexOf(mojiken_e, StartIndex + 1)
                '        If StartIndex < 0 Then
                '            Return retMoji
                '        End If


                '    End If

                'Else
                '    EndIndex = targetMoji.IndexOf(mojiken_e, StartIndex + 1)
                '    If StartIndex < 0 Then
                '        Return retMoji
                '    End If


                'End If


                EndIndex = targetMoji.IndexOf(mojiken_e, StartIndex + 1)
                If StartIndex < 0 Then
                    Return retMoji
                End If
            Else

                Return retMoji
            End If

        End While

        If (StartIndex >= 0 And EndIndex > 0) And StartIndex < EndIndex Then


            retMoji = targetMoji.Substring(StartIndex + 1, EndIndex - StartIndex - 1)

            If retMoji.Where(Function(c) c = mojiken_s).Count() > 0 Or retMoji.Where(Function(c) c = mojiken_e).Count() > 0 Then
                retMoji = ""
                HitFlg = False
                Return retMoji
            End If

        Else
            retMoji = ""
            HitFlg = False

        End If
        '文字カットはやめる　そのまま返す
        'If mojiketa > 0 Then
        'retMoji = MidB(retMoji, 1, mojiketa)
        'End If

        Return retMoji

    End Function

#End Region

#Region "システムログ正常チェック"
    ''' <summary>
    ''' システムログファイル
    ''' </summary>>
    ''' <param name="pFile">読み込むファイル</param>
    ''' <param name="pSplit">区切り文字</param>
    ''' <param name="pStr">比較文字列</param>
    ''' <param name="iNum">項目順</param>
    ''' <param name="pStartLine">システムログ行の開始位置</param>
    ''' <returns>正常:検索文字あり 異常:検索文字なし</returns>
    ''' <remarks>指定された項目の値に比較文字列が存在する場合、Trueを返す</remarks>
    Public Shared Function CheckColmStr(ByRef pFile As String, ByRef pSplit As String, ByRef pStr As String, ByRef iNum As Integer, ByVal pStartLine As Integer) As Boolean
        '20171031修正(システムズ) S  例外処理不具合対応
        Dim cReader As System.IO.StreamReader = Nothing
        Dim iCnt As Integer = 1
        '20171031修正(システムズ) S  例外処理不具合対応
        Try
            ' StreamReader の新しいインスタンスを生成する
            '20171031修正(システムズ) S  例外処理不具合対応
            'Dim cReader As New System.IO.StreamReader(pFile, System.Text.Encoding.Default)
            'Dim iCnt As Integer = 1
            cReader = New System.IO.StreamReader(pFile, System.Text.Encoding.Default)
            '20171031修正(システムズ) E  例外処理不具合対応

            ' 読み込みできる文字がなくなるまで繰り返す
            While (cReader.Peek() >= 0)
                ' カンマ区切りファイルを 1 行ずつ読み込む
                Dim stBuffer() As String = Split(cReader.ReadLine(), pSplit)

                If iCnt > pStartLine Then
                    ' 指定したカラム値を検索する
                    If stBuffer(iNum) = pStr Then
                        cReader.Close()
                        Return True
                    End If
                End If

                iCnt += 1
            End While

            ' cReader を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            cReader.Close()

            Return False

        Catch ex As Exception
            '20171031修正(システムズ) S  例外処理不具合対応
            ' cReader を閉じる
            If Not cReader Is Nothing Then cReader.Close()
            '20171031修正(システムズ) E  例外処理不具合対応

            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region

#Region "数値編集・右寄せ"
    ''' <summary>
    ''' 指定桁で編集
    ''' </summary>>
    '''<param name="str">対象の文字列</param>
    ''' <param name="p_Byte">指定桁数</param>
    ''' <param name="p_Seido">精度</param>
    ''' <param name="p_sign">符号指定</param>
    ''' <param name="p_abs">絶対値指定</param>
    ''' <param name="p_syosunasi">小数切捨指定</param>
    ''' <returns></returns>
    ''' <remarks>指定桁数に数値を文字変換</remarks>
    Public Shared Function NumRightB(ByVal str As String, ByVal p_Byte As Integer, ByVal p_Seido As Integer, _
                                     Optional ByVal p_sign As Boolean = True, Optional ByVal p_abs As Boolean = False, Optional ByVal p_syosunasi As Boolean = False, _
                                     Optional ByVal p_SeisuByte As Integer = 0, Optional ByVal p_Round As Boolean = True) As String

        Dim l_str As String = ""
        Dim l_str2 As String = ""
        Dim l_pos As Integer = 0
        Dim l_sign As String = ""
        Dim l_byte As Integer = 0

        l_byte = p_Byte
        Try
            '空文字
            If str.ToString.Trim = "" Then
                Return l_str
            End If

            '数値以外
            If IsNumeric(str.ToString.Trim) = False Then
                Return l_str
            End If
            '精度別（0～2位まで）
            Select Case p_Seido
                Case 0
                    If p_abs Then
                        l_str2 = Format(Math.Abs(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero)), "0")
                    Else
                        l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0")
                    End If
                    If p_Round = False Then
                        l_str2 = Format(Math.Truncate(Double.Parse(str.ToString.Trim)), "0")
                    End If
                Case 1
                    l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0.0")
                Case 2
                    l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0.00")

                    '小数切捨指定の場合、小数がなければ整数部のみに変更
                    If p_syosunasi Then
                        l_pos = l_str2.ToString.Trim.IndexOf(".") + 1
                        If l_pos > 0 Then
                            If clsEtc.MidB(l_str2, l_pos + 1, 2) = "00" Then
                                l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0")
                                '整数桁数を指定されている場合は、指定桁を変更
                                If p_SeisuByte <> 0 Then
                                    l_byte = p_SeisuByte
                                End If
                            End If
                        End If
                    End If
            End Select

            '指定桁までは調整不要
            If l_byte >= l_str2.ToString.Length Then
                Return l_str2
            End If

            If p_abs = False Then
                If Double.Parse(str.ToString.Trim) < 0 Then
                    l_byte = l_byte - 1
                End If
            End If

            l_pos = l_str2.ToString.Length - l_byte + 1

            If p_abs = False Then
                If Double.Parse(str.ToString.Trim) < 0 Then
                    l_pos = l_pos + 1
                End If
            End If

            '符号ありでマイナスの場合は、符号を付与し設定桁を-1
            If p_sign = True And Double.Parse(str.ToString.Trim) < 0 Then
                l_sign = "-"
                l_pos = l_pos - 1
            End If

            l_str = clsEtc.MidB(l_str2, l_pos, l_byte)
            l_str = String.Format("{0}{1}", l_sign, l_str)

        Catch ex As Exception
            l_str = ""

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return l_str

    End Function

#End Region

#Region "数値編集・整数・小数分解"
    ''' <summary>
    ''' 指定桁で編集
    ''' </summary>>
    '''<param name="str">対象の文字列</param>
    ''' <param name="p_Byte">指定桁数</param>
    ''' <param name="p_Seido">精度</param>
    ''' <param name="p_round">直接指定</param>
    ''' <returns></returns>
    ''' <remarks>指定桁数に数値を文字変換</remarks>
    Public Shared Function NumRightSeisu(ByVal str As String, ByVal p_Byte As Integer, ByVal p_Seido As Integer, ByRef p_syosu As String, Optional ByVal p_round As Boolean = True) As String

        Dim l_str As String = ""
        Dim l_str2 As String = ""
        Dim l_sta As Integer = 0
        Dim l_pos As Integer = 0
        Dim l_len As Integer = 0

        p_syosu = ""

        Try
            '空文字
            If str.ToString.Trim = "" Then
                Return l_str
            End If

            '数値以外
            If IsNumeric(str.ToString.Trim) = False Then
                Return l_str
            End If

            If p_round Then
                '精度別（1～2位まで）
                Select Case p_Seido
                    Case 1
                        l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0.0")
                    Case 2
                        l_str2 = Format(Math.Round(Double.Parse(str.ToString.Trim), p_Seido, MidpointRounding.AwayFromZero), "0.00")
                End Select

                l_pos = l_str2.ToString.Trim.IndexOf(".") + 1
                l_len = l_pos - 1
                l_sta = 1
                If l_len > p_Byte Then
                    l_sta = l_len - p_Byte + 1
                    l_len = p_Byte
                End If
                l_str = clsEtc.MidB(l_str2.ToString.Trim, l_sta, l_len)
                If l_pos > 0 Then
                    p_syosu = clsEtc.MidB(l_str2.ToString.Trim, l_pos + 1, p_Seido)
                End If

            Else

                l_pos = str.ToString.Trim.IndexOf(".") + 1
                If l_pos > 0 Then
                    p_syosu = clsEtc.MidB(str.ToString.Trim, l_pos + 1, p_Seido)
                End If

                l_str2 = Format(Math.Truncate(Double.Parse(str.ToString.Trim)), "0")

                l_len = l_str2.ToString.Trim.Length
                l_sta = 1
                If l_len > p_Byte Then
                    l_sta = l_len - p_Byte + 1
                    l_len = p_Byte
                End If
                l_str = clsEtc.MidB(l_str2.ToString.Trim, l_sta, l_len)

            End If

        Catch ex As Exception
            l_str = ""

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return l_str

    End Function

#End Region

    '20170306修正(HIDOC) S      BT課題[No.24]
#Region "発注残出力連携・連携データ判断"
    ''' <summary>
    ''' 発注依頼区分・発注決定区分・情報コードから連携可否を判断する
    ''' </summary>>
    '''<param name="Kbn">発注依頼区分</param>
    ''' <param name="Kettei">発注決定区分</param>
    ''' <param name="Zyoho">情報コード</param>
    ''' <returns>連携可否（""：例外エラー、"0"：連携対象、"1"：連携対象外（ログ出力なし）、"2"：連携対象外（ログ出力））</returns>
    ''' <remarks>発注依頼区分・発注決定区分・情報コードから連携可否を判断する</remarks>
    Public Shared Function HaccyuData(ByVal Kbn As String, ByVal Kettei As String, ByVal Zyoho As String) As String

        Dim FlgData As String = ""

        HaccyuData = ""

        Try
            If Kbn = "1" And Kettei = "" And Zyoho = "K0" Then
                '発注依頼区分=新規、発注決定区分=未決定、情報コード=新規
                '連携対象外（ログ出力なし）
                FlgData = "1"
            ElseIf Kbn = "1" And Kettei = "1" And Zyoho = "K0" Then
                '発注依頼区分=新規、発注決定区分=確定発注、情報コード=新規
                '連携対象
                FlgData = "0"
            ElseIf Kbn = "1" And Kettei = "3" And Zyoho = "K0" Then
                '発注依頼区分=新規、発注決定区分=内示発注、情報コード=新規
                '連携対象
                FlgData = "0"
            ElseIf Kbn = "2" And Kettei = "" And (Zyoho = "K2" Or Zyoho = "Kﾙ") Then
                '発注依頼区分=新規、発注決定区分=未決定、情報コード=訂正または金額訂正
                '連携対象外（ログ出力なし）
                FlgData = "1"
            ElseIf Kbn = "2" And Kettei = "1" And (Zyoho = "K2" Or Zyoho = "Kﾙ") Then
                '発注依頼区分=新規、発注決定区分=未決定、情報コード=訂正または金額訂正
                '連携対象
                FlgData = "0"
            ElseIf Kbn = "2" And Kettei = "3" And (Zyoho = "K2" Or Zyoho = "Kﾙ") Then
                '発注依頼区分=新規、発注決定区分=未決定、情報コード=訂正または金額訂正
                '連携対象
                FlgData = "0"
            ElseIf Kbn = "3" And Kettei = "" And Zyoho = "K2" Then
                '発注依頼区分=新規、発注決定区分=未決定、情報コード=訂正
                '連携対象
                FlgData = "0"
            Else
                '上記以外
                '連携対象外（ログ出力）
                FlgData = "2"
            End If

        Catch ex As Exception
            FlgData = ""

            '20171026修正(システムズ) S  例外処理不具合対応
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return FlgData

    End Function
#End Region
    '20170306修正(HIDOC) E      BT課題[No.24]

    '20170313修正(HIDOC) S      AT課題[No.173]
    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
#Region "発注残出力連携・事業所発注残比較"
    ''' <summary>
    ''' 発注残訂正出力連携項目「資材略称」「取引先コード」を事業所発注残と対比し、相違の有無を返す
    ''' </summary>
    ''' <param name="InputDataRow">入力ファイルのDataRow</param>
    ''' <param name="ZigyousyoDataRow">事業所発注残のDataRow</param>
    ''' <param name="DivisionID">事業所判断識別子</param>
    ''' <param name="ErrorMessage">エラーメッセージ格納用</param>
    ''' <param name="MapErrFlg">エラーフラグ</param>
    ''' <param name="MapWarningErrFlg">ワーニングフラグ</param>
    ''' <returns>True:相違なし,False:相違あり</returns>
    ''' <remarks></remarks>
    Public Shared Function InputAndZigyousyoCheck(ByVal InputDataRow As DataRow, ByVal ZigyousyoDataRow As DataRow, ByVal DivisionID As clsGlobal.DivisionID, ByRef ErrorMessage As String, ByRef MapErrFlg As Boolean, ByRef MapWarningErrFlg As Boolean, Optional ByVal Cnt_msiz As Integer = 0) As Boolean
        'Public Shared Function InputAndZigyousyoCheck(ByVal InputDataRow As DataRow, ByVal ZigyousyoDataRow As DataRow, ByVal DivisionID As clsGlobal.DivisionID, ByRef ErrorMessage As String, Optional ByVal Cnt_msiz As Integer = 0) As Boolean
        '20170630修正(HIDOC) E      本番稼動後課題[No.123]
        Dim InputHinmei As String = ""                  '入力ファイル「資材略称」を格納
        Dim InputTorihiki As String = ""                '入力ファイル「取引先ｺｰﾄﾞ」を格納
        Dim ZigyousyoHinmei As String = ""              '事業所発注残「品名」を格納
        Dim ZigyousyoTorihiki As String = ""            '事業所発注残「取引先」を格納
        Dim ZigyousyoHinmeiColName As String = ""       '事業所発注残「品名」設定のためのカラム名
        Dim ZigyousyoTorihikiColName As String = ""     '事業所発注残「取引先」設定のためのカラム名
        Dim HinmeiErrFlg As Boolean = True              '品名エラーフラグ(エラーあり:False)
        Dim TorihikiErrFlg As Boolean = True            '取引先エラーフラグ(エラーあり:False)

        '事業所によって「品名」「取引先」のカラム名は異なる
        'DivisionIDにより事業所別にカラム名を設定
        If DivisionID = clsGlobal.DivisionID.NAB Then
            '名張
            ZigyousyoHinmeiColName = "パック品名"
            ZigyousyoTorihikiColName = "取引先略号"
        ElseIf DivisionID = clsGlobal.DivisionID.SAI Then
            '埼玉
            ZigyousyoHinmeiColName = "品名略称"
            ZigyousyoTorihikiColName = "取引先略称"
        ElseIf DivisionID = clsGlobal.DivisionID.HIK Then
            '彦根
            ZigyousyoHinmeiColName = "品名"
            ZigyousyoTorihikiColName = "取引先"
        ElseIf DivisionID = clsGlobal.DivisionID.PLA Then
            'オート関西
            ZigyousyoHinmeiColName = "品名"
            ZigyousyoTorihikiColName = "取引先"
        End If

        '品名のチェック
        If InputDataRow.IsNull(20) = False Then
            '入力ファイルの「資材略称」項目を取得
            InputHinmei = InputDataRow(20).ToString()
            InputHinmei = Trim(InputHinmei)
            '名張については、パック化して比較する必要あり
            If DivisionID = clsGlobal.DivisionID.NAB Then
                InputHinmei = InputHinmei.ToString.Replace("(", "").Replace(")", "").Replace(" ", "").Trim()

                '20170324 S     BT課題[No.37]
                '資材マスタチェック
                'ret = clsNabCommon.getNAB_MSIZ_Data(p_dt_msiz, rws2, InputHinmei, "")      'rws2の結果のみ引数で渡している
                If Cnt_msiz > 0 Then
                    InputHinmei = InputHinmei
                Else
                    InputHinmei = InputDataRow(20).ToString().Trim
                End If
                '20170324 S     BT課題[No.37]
                '名張事業書は、先頭19桁で比較する(事業所発注残「品名」が19桁)
                If LenB(InputHinmei) > 19 Then
                    InputHinmei = MidB(InputHinmei, 1, 19)
                End If
                '20170330修正(HIDOC) S      BT課題[No.37]
                '不要ロジックのためコメントアウト
                'ElseIf DivisionID = clsGlobal.DivisionID.SAI Then
                '    Dim l_kojo_code As String
                '    l_kojo_code = clsEtc.MidB(InputDataRow(0).ToString.Trim, 11, 1)
                '    If l_kojo_code <> "8" Then
                '        '埼玉機器の場合
                '        If clsEtc.LenB(InputDataRow(12).ToString.Trim) > 3 Then
                '            InputHinmei = InputDataRow(12).ToString.Trim
                '        End If
                '    End If

                '    '20170324 S     BT課題[No.37]
                '20170330修正(HIDOC) E      BT課題[No.37]
            End If

            '20170405修正(HIDOC) S      システム課題[No.K1610-0415]
            '彦根　特殊文字の変換
            If DivisionID = clsGlobal.DivisionID.HIK Then
                InputHinmei = InputHinmei.ToString.Replace("ｰ", "-").Trim
            End If
            'オート関西　特殊文字の変換
            If DivisionID = clsGlobal.DivisionID.PLA Then
                InputHinmei = InputHinmei.ToString.Replace("ｰ", "-").Replace("""", " ").Replace(",", " ").Replace("'", " ").Trim
            End If
            '20170405修正(HIDOC) E      システム課題[No.K1610-0415]

        End If
        If ZigyousyoDataRow.IsNull(ZigyousyoHinmeiColName) = False Then
            '事業所発注残の「品名」を取得
            ZigyousyoHinmei = ZigyousyoDataRow(ZigyousyoHinmeiColName).ToString()
            ZigyousyoHinmei = Trim(ZigyousyoHinmei)
        End If
        If InputHinmei <> ZigyousyoHinmei Then
            '入力ファイルと事業所の品名が異なるのでエラー
            'エラーメッセージを設定
            '20170630修正(HIDOC) S      本番稼動後課題[No.123]
            'ErrorMessage = ErrorMessage & "品名：入力ファイルと事業所発注残相違あり"
            'ErrorMessage = ErrorMessage & "(入力ファイル「" & InputHinmei & "」,"
            'ErrorMessage = ErrorMessage & "事業所発注残「" & ZigyousyoHinmei & "」)"
            ErrorMessage = ErrorMessage & clsEtc.GetLogType("E026", 1, 2, MapErrFlg, MapWarningErrFlg) & String.Format(clsGlobal.MSG2("E026"), ZigyousyoHinmeiColName, InputHinmei, ZigyousyoHinmei)
            '20170630修正(HIDOC) E      本番稼動後課題[No.123]
            HinmeiErrFlg = False
        End If

        '取引先のチェック
        'オート関西は、取引先のチェックは実施しない
        'オート関西以外の事業所について、チェックを実行
        If DivisionID <> clsGlobal.DivisionID.PLA Then
            If InputDataRow.IsNull(13) = False Then
                '入力ファイルの「取引先ｺｰﾄﾞ」項目を取得
                InputTorihiki = InputDataRow(13).ToString()
                InputTorihiki = Trim(InputTorihiki)
            End If
            If ZigyousyoDataRow.IsNull(ZigyousyoTorihikiColName) = False Then
                '事業所発注残の「取引先」を取得
                ZigyousyoTorihiki = ZigyousyoDataRow(ZigyousyoTorihikiColName).ToString()
                ZigyousyoTorihiki = Trim(ZigyousyoTorihiki)
            End If
            If InputTorihiki <> ZigyousyoTorihiki Then
                '入力ファイルと事業所の取引先が異なるのでエラー
                '20171002修正(システムズ) S 本番稼動後課題[No.524]
                If DivisionID = clsGlobal.DivisionID.NAB Then
                    '名張の場合はシステムログファイルにメッセージを出力し、エラーとしない
                    clsLogTrace.GetInstance.TraceWrite(String.Format(clsGlobal.MSG("E043"), ZigyousyoTorihiki, InputTorihiki, InputDataRow(1).ToString().Trim), ClsLogString.RunState.Err)
                Else
                    '20171002修正(システムズ) E 本番稼動後課題[No.524]
                    'エラーメッセージを設定
                    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
                    'ErrorMessage = ErrorMessage & "取引先：入力ファイルと事業所発注残相違あり"
                    'ErrorMessage = ErrorMessage & "(入力ファイル「" & InputTorihiki & "」,"
                    'ErrorMessage = ErrorMessage & "事業所発注残「" & ZigyousyoTorihiki & "」)"
                    ErrorMessage = ErrorMessage & clsEtc.GetLogType("E027", 1, 2, MapErrFlg, MapWarningErrFlg) & String.Format(clsGlobal.MSG2("E027"), ZigyousyoTorihikiColName, InputTorihiki, ZigyousyoTorihiki)
                    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
                    TorihikiErrFlg = False
                    '20171002修正(システムズ) S 本番稼動後課題[No.524]
                End If
                '20171002修正(システムズ) E 本番稼動後課題[No.524]
            End If
        End If


        If HinmeiErrFlg AndAlso TorihikiErrFlg Then
            'すべてのチェックにおいてエラーとならなければ正常終了
            Return True
        Else
            'どちらかでエラーフラグが立っていた場合、異常終了
            Return False
        End If
    End Function

#End Region
    '20170313修正(HIDOC) E      AT課題[No.173]

    '20170310修正(HIDOC) S      BT課題[No.19]
#Region "連携条件（資材マスタ共通）"
    '20170516修正（HIDOC) S      本番稼働後課題[No.101] 連携処理日テーブル削除
    ''' <summary>
    ''' 各レコードが連携対象か確認を行う（資材マスタ共通）
    ''' </summary>>
    '''<param name="p_syoriDate">連携処理日.前回処理日</param>
    ''' <param name="TourokuDay">登録年月日</param>
    ''' <param name="TeiseiDay">訂正年月日</param>
    ''' <param name="csTourokuDay">CS登録年月日</param>
    ''' <param name="csTeiseiDay">CS修正年月日</param>
    ''' <returns>連携可否（true（連携対象）,FALSE（連携対象外））</returns>
    ''' <remarks>各レコードが連携対象か確認を行う（共通）</remarks>
    'Public Shared Function CheackRenkei_Sizai(ByVal p_syoriDate As String, ByVal TourokuDay As String, ByVal TeiseiDay As String, ByVal csTourokuDay As String, ByVal csTeiseiDay As String) As Boolean

    '    CheackRenkei_Sizai = False

    '    Try
    '        '連携処理日.前回処理日 <= 登録年月日
    '        If clsEtc.MidB(p_syoriDate, 3, 6) <= TourokuDay Then
    '            Return True
    '        End If

    '        '連携処理日.前回処理日 <= 訂正年月日
    '        If clsEtc.MidB(p_syoriDate, 3, 6) <= TeiseiDay Then
    '            Return True
    '        End If

    '        '連携処理日.前回処理日 <= cs登録年月日
    '        If p_syoriDate <= csTourokuDay Then
    '            Return True
    '        End If

    '        '連携処理日.前回処理日 <= cs訂正年月日
    '        If p_syoriDate <= csTeiseiDay Then
    '            Return True
    '        End If

    '    Catch ex As Exception
    '        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
    '        clsLogTrace.GetExInstance().ExceptionWrite(ex)
    '        Return False

    '    End Try

    '    Return False

    'End Function
    '20170516修正（HIDOC) E      本番稼働後課題[No.101]
#End Region

#Region "連携条件（取引先マスタ共通）"
    '20170516修正（HIDOC) S      本番稼働後課題[No.101] 連携処理日テーブル削除
    ''' <summary>
    ''' 各レコードが連携対象か確認を行う（取引先マスタ共通）
    ''' </summary>>
    '''<param name="p_syoriDate">連携処理日.前回処理日</param>
    ''' <param name="TourokuDay">登録年月日</param>
    ''' <param name="TeiseiDay">修正年月日</param>
    ''' <returns>連携可否（true（連携対象）,FALSE（連携対象外））</returns>
    ''' <remarks>各レコードが連携対象か確認を行う（共通）</remarks>
    'Public Shared Function CheackRenkei_Tori(ByVal p_syoriDate As String, ByVal TourokuDay As String, ByVal TeiseiDay As String) As Boolean

    '    CheackRenkei_Tori = False

    '    Try
    '        '20170508修正（HIDOC) S      本番稼働後課題[No.86]
    '        '連携処理日.前回処理日 <= 登録年月日
    '        'If p_syoriDate) <= TourokuDay Then
    '        If MidB(p_syoriDate, 1, 8) <= MidB(TourokuDay, 1, 8) Then
    '            Return True
    '        End If

    '        '連携処理日.前回処理日 <= 修正年月日
    '        'If p_syoriDate <= TeiseiDay Then
    '        If MidB(p_syoriDate, 1, 8) <= MidB(TeiseiDay, 1, 8) Then
    '            Return True
    '        End If
    '        '20170508修正（HIDOC) E      本番稼働後課題[No.86]
    '    Catch ex As Exception
    '        clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
    '        clsLogTrace.GetExInstance().ExceptionWrite(ex)
    '        Return False

    '    End Try

    '    Return False

    'End Function
    '20170516修正（HIDOC) E      本番稼働後課題[No.101]
#End Region

#Region "データ検索（資材マスタ）"
    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
    ''' <summary>
    ''' データテーブルに該当データが存在するか確認する
    ''' </summary>>
    ''' <param name="Dt">データテーブル</param>
    ''' <param name="Dr">該当データ</param>
    ''' <param name="Div">事業所</param>
    ''' <param name="l_kojo_code">工場コード</param>
    ''' <param name="CodeSizai">資材コード</param>
    ''' <param name="CodeTori">取引先コード</param>
    ''' <param name="Sizai">資材略称（資材略称で検索する場合のみ設定）</param>
    ''' <returns></returns>
    ''' <remarks>データテーブルに入力ファイルの該当データが存在するか確認する</remarks>
    Public Shared Function ExitData_Sizai(ByVal Dt As DataTable, ByRef Dr As DataRow, ByVal Div As String, ByVal l_kojo_code As String, ByVal CodeSizai As String, ByVal CodeTori As String, Optional ByVal Sizai As String = "") As Boolean
        'Public Shared Function ExitData_Sizai(ByVal Dt As DataTable, ByRef Dr As DataRow, ByVal Div As String, ByVal l_kojo_code As String, ByVal CodeSizai As String, ByVal CodeTori As String) As Boolean
        '20170526修正(HIDOC) E      本番稼動後課題[No.102]

        ExitData_Sizai = False

        Dim key() As Object = New Object(3) {}

        Try

            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            If Sizai = "" Then
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                key(0) = Div
                key(1) = l_kojo_code
                key(2) = CodeSizai
                key(3) = CodeTori

                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                '資材マスタを資材略称で検索させる場合
            Else
                ReDim key(0)
                key(0) = Sizai

            End If
            '20170526修正(HIDOC) E      本番稼動後課題[No.102]

            Dr = Dt.Rows.Find(key)

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

#Region "データ検索（取引先マスタ）"
    ''' <summary>
    ''' データテーブルに該当データが存在するか確認する
    ''' </summary>>
    ''' <param name="Dt">データテーブル</param>
    ''' <param name="Dr">該当データ</param>
    ''' <param name="Div">事業所</param>
    ''' <param name="CodeTori">取引先コード</param>
    ''' <returns></returns>
    ''' <remarks>データテーブルに入力ファイルの該当データが存在するか確認する</remarks>
    Public Shared Function ExitData_Tori(ByVal Dt As DataTable, ByRef Dr As DataRow, ByVal Div As String, ByVal CodeTori As String) As Boolean

        ExitData_Tori = False

        Dim key() As Object = New Object(1) {}

        Try
            key(0) = Div
            key(1) = CodeTori

            Dr = Dt.Rows.Find(key)

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

#Region "同一ファイル内検索（資材マスタ）"
    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
    ''' <summary>
    ''' 同一ファイル内検索（資材マスタ）
    ''' </summary>>
    ''' <param name="Dt">CUP連携用データテーブル</param>
    ''' <param name="Key">キー情報</param>
    ''' <returns></returns>
    ''' <remarks>同一ファイル内に同キーのレコードがないか検索する</remarks>
    Public Shared Function ExitInData_Sizai(ByVal Dt As DataTable, ByVal Key As String) As Boolean
        '   Public Shared Function ExitInData_Sizai(ByVal Dt As DataTable, ByVal Div As String, ByVal l_kojo_code As String, ByVal CodeSizai As String, ByVal CodeTori As String) As Boolean
        '20170526修正(HIDOC) E      本番稼動後課題[No.102]

        ExitInData_Sizai = False

        Dim strKey As String = ""
        Dim dr() As DataRow = Nothing

        Try

            '資材マスタ
            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            'strKey = strKey & Div & vbTab                      '事業所
            'strKey = strKey & l_kojo_code & vbTab              '工場コード
            'strKey = strKey & CodeSizai & vbTab                '資材コード
            'strKey = strKey & CodeTori                         '取引先コード

            'dr = Dt.Select("入力情報（キー） = '" & strKey & "' and チェック='OK' ")

            strKey = Key            'キー

            '20171005修正(システムズ) S [G30-001995] 類似対応
            'dr = Dt.Select("入力情報（レガシーキー） = '" & strKey & "' and チェック='OK' ")
            dr = Dt.Select("入力情報（レガシーキー） = '" & strKey.Replace("'", "''") & "' and チェック='OK' ")
            '20171005修正(システムズ) E [G30-001995] 類似対応
            '20170526修正(HIDOC) E      本番稼動後課題[No.102]

            If dr.Length >= 1 Then
                '同一キーのレコードあり
                Return True
            End If

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return False

    End Function
#End Region

#Region "同一ファイル内検索（取引先マスタ）"
    ''' <summary>
    ''' 同一ファイル内検索（取引先マスタ）
    ''' </summary>>
    ''' <param name="Dt">CUP連携用データテーブル</param>
    ''' <param name="Div">事業所</param>
    ''' <param name="CodeTori">取引先コード</param>
    ''' <returns></returns>
    ''' <remarks>同一ファイル内に同キーのレコードがないか検索する</remarks>
    Public Shared Function ExitInData_Tori(ByVal Flg_Mst As String, ByVal Dt As DataTable, ByVal Div As String, ByVal CodeTori As String) As Boolean

        ExitInData_Tori = False

        Dim strKey As String = ""
        Dim dr() As DataRow = Nothing

        Try
            '取引先マスタ
            strKey = strKey & Div & vbTab                      '事業所
            strKey = strKey & CodeTori                         '取引先コード

            dr = Dt.Select("入力情報（キー） = '" & strKey & "' and チェック='OK' ")

            If dr.Length >= 1 Then
                '同一キーのレコードあり
                Return True
            End If

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

        Return False

    End Function
#End Region

#Region "同一キーレコードの連携結果確認"
    ''' <summary>
    ''' 同一キーレコードの連携結果確認
    ''' </summary>>
    ''' <param name="Flg_Mst">マスタフラグ（1:資材マスタ、2：取引先マスタ、3:資材マスタ(資材略称））</param>
    ''' <param name="dt">連携結果用データテーブル</param>
    ''' <param name="row">連携データ</param>
    ''' <returns></returns>
    ''' <remarks>同一キーレコードの連携結果を確認する</remarks>
    Public Shared Function CheackResult(ByVal Flg_Mst As String, ByVal dt As DataTable, ByVal row As Object) As String

        CheackResult = False

        Dim KeyData() As String = Nothing
        Dim stArrayData() As String = Nothing
        Dim nr As DataRow = Nothing
        Dim strResult As String = ""

        Try
            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            'KeyData = row("入力情報（キー）").ToString.Split(vbTab)
            '資材マスタ(資材略称）の時はキー項目が「入力情報（レガシーキー）」
            If Flg_Mst = "3" Then
                KeyData = row("入力情報（レガシーキー）").ToString.Split(vbTab)
            Else
                KeyData = row("入力情報（キー）").ToString.Split(vbTab)
            End If
            '20170526修正(HIDOC) E      本番稼動後課題[No.102]
            stArrayData = row("入力情報").ToString.Split(vbTab)

            '同一キー検索
            If Flg_Mst = "1" Then
                ExitData_Sizai(dt, nr, KeyData(0), KeyData(1), KeyData(2), KeyData(3))
                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                'Else
            ElseIf Flg_Mst = "2" Then
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                ExitData_Tori(dt, nr, KeyData(0), KeyData(1))
                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            ElseIf Flg_Mst = "3" Then
                ExitData_Sizai(dt, nr, "", "", "", "", KeyData(0))
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
            End If

            If IsNothing(nr) Then
                'レコードなし（データテーブルに追加）
                nr = dt.NewRow
                If Flg_Mst = "1" Then
                    nr("事業所") = KeyData(0)
                    nr("工場コード") = KeyData(1)
                    nr("資材コード") = KeyData(2)
                    nr("取引先コード") = KeyData(3)

                    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                    'Else
                ElseIf Flg_Mst = "2" Then
                    '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                    nr("事業所") = KeyData(0)
                    nr("取引先コード") = KeyData(1)

                    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                ElseIf Flg_Mst = "3" Then
                    nr("資材略称") = KeyData(0)

                    '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                End If

                nr("更新内容") = stArrayData(0)
                nr("連携結果") = ""
                dt.Rows.Add(nr)
            Else
                'レコードあり
                If nr("連携結果").ToString = "OK" Then
                    '更新処理
                    strResult = "2"
                Else
                    '同一キーのデータが連携失敗、更新内容="1"（登録）なら"1"（登録）を戻す
                    If nr("更新内容").ToString = "1" Then
                        strResult = "1"
                    Else
                        strResult = "2"
                    End If
                End If
            End If

            Return strResult

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return strResult
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region

#Region "前日情報用データ作成（資材マスタ）"
    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
    ''' <summary>
    ''' 前日情報用データ作成（資材マスタ）
    ''' </summary>>
    ''' <param name="DR">連携データ</param>
    ''' <param name="row">入力ファイル情報（配列）</param>
    ''' <param name="ptn">更新パターン</param>
    ''' <param name="Div">事業所</param>
    ''' <param name="l_kojo_code">工場コード</param>
    ''' <param name="Sizai">資材略称</param>
    ''' <returns></returns>
    ''' <remarks>入力ファイルから前日情報用データをTab区切りで1行にまとめて作成する（資材マスタ）</remarks>
    Public Shared Function createInput_Sizai(ByRef DR As DataRow, ByVal row As Object, ByVal ptn As String, ByVal Div As String, ByVal l_kojo_code As String, Optional ByVal Sizai As String = "") As Boolean
        'Public Shared Function createInput_Sizai(ByRef DR As DataRow, ByVal row As Object, ByVal ptn As String, ByVal Div As String, ByVal l_kojo_code As String) As Boolean
        '20170526修正(HIDOC) E      本番稼動後課題[No.102]
        createInput_Sizai = False

        Dim Indata As String = ""

        Try
            '入力情報（キー）
            Indata = ""
            Indata = Indata & Div & vbTab                      '事業所
            Indata = Indata & l_kojo_code & vbTab              '工場コード
            Indata = Indata & row(1).ToString.Trim & vbTab     '資材コード
            Indata = Indata & row(2).ToString.Trim             '取引先コード
            DR("入力情報（キー）") = Indata

            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            If Sizai <> "" Then
                Indata = ""
                Indata = Sizai                   '資材略称
                DR("入力情報（レガシーキー）") = Indata
            End If
            '20170526修正(HIDOC) E      本番稼動後課題[No.102]

            '入力情報
            Indata = ""
            Indata = Indata & ptn & vbTab                      '更新区分
            Indata = Indata & row(3).ToString.Trim & vbTab     '資材略称
            Indata = Indata & row(4).ToString.Trim & vbTab     '在庫区分
            Indata = Indata & row(5).ToString.Trim & vbTab     '購買区分
            Indata = Indata & row(6).ToString.Trim & vbTab     '購買担当者
            Indata = Indata & row(10).ToString.Trim & vbTab    '標準納期
            Indata = Indata & row(11).ToString.Trim & vbTab    '最短納期
            Indata = Indata & row(12).ToString.Trim & vbTab    '検査要否
            Indata = Indata & row(14).ToString.Trim & vbTab    '標準発注ロット
            Indata = Indata & row(19).ToString.Trim & vbTab    '標準納入ロット
            Indata = Indata & row(21).ToString.Trim & vbTab    '発注点(生産点)
            Indata = Indata & row(24).ToString.Trim & vbTab    '購入単位略号
            Indata = Indata & row(29).ToString.Trim & vbTab    '当月払出予算＠
            Indata = Indata & row(31).ToString.Trim & vbTab    '翌期払出予算＠
            Indata = Indata & row(35).ToString.Trim & vbTab    '支給＠
            Indata = Indata & row(38).ToString.Trim & vbTab    '管理勘定
            Indata = Indata & row(44).ToString.Trim & vbTab    '備考(図＃)
            Indata = Indata & row(49).ToString.Trim & vbTab    'ベース＠
            Indata = Indata & row(51).ToString.Trim & vbTab    '登録年月日
            Indata = Indata & row(52).ToString.Trim & vbTab    '訂正年月日
            Indata = Indata & row(56).ToString.Trim & vbTab    '振区
            Indata = Indata & row(67).ToString.Trim & vbTab    '荷姿単位コード
            Indata = Indata & row(72).ToString.Trim & vbTab    '受渡場所コード
            Indata = Indata & row(75).ToString.Trim & vbTab    '一般共通品名
            Indata = Indata & row(76).ToString.Trim & vbTab    '統計単位略号
            Indata = Indata & row(77).ToString.Trim & vbTab    '購入仕様書No
            Indata = Indata & row(78).ToString.Trim & vbTab    '統計単位換算係数
            Indata = Indata & row(96).ToString.Trim & vbTab    'CS登録年月日
            Indata = Indata & row(97).ToString.Trim & vbTab    'CS修正年月日
            Indata = Indata & row(103).ToString.Trim & vbTab   '重要度区分
            Indata = Indata & row(141).ToString.Trim & vbTab   '当社の用途
            Indata = Indata & row(54).ToString.Trim            '現場材料管理区分
            DR("入力情報") = Indata

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

#Region "前日情報用データ作成（取引先マスタ）"
    ''' <summary>
    ''' 前日情報用データ作成（取引先マスタ）
    ''' </summary>>
    ''' <param name="DR">連携データ</param>
    ''' <param name="row">入力ファイル情報（配列）</param>
    ''' <param name="ptn">更新パターン</param>
    ''' <param name="Div">事業所</param>
    ''' <param name="ToriCd">取引先コード</param>
    ''' <returns></returns>
    ''' <remarks>入力ファイルから前日情報用データをTab区切りで1行にまとめて作成する（資材マスタ）</remarks>
    Public Shared Function createInput_Tori(ByRef DR As DataRow, ByVal row As Object, ByVal ptn As String, ByVal Div As String, ByVal ToriCd As String) As Boolean

        createInput_Tori = False

        Dim Indata As String = ""

        Try
            '入力情報（キー）
            Indata = ""
            Indata = Indata & Div & vbTab                      '事業所
            Indata = Indata & ToriCd                           '取引先コード
            DR("入力情報（キー）") = Indata

            '入力情報
            Indata = ""
            Indata = Indata & ptn & vbTab                      '更新区分
            Indata = Indata & row(1).ToString.Trim & vbTab     '取引先名（漢字）
            Indata = Indata & row(2).ToString.Trim & vbTab     '取引先名（カナ）
            Indata = Indata & row(3).ToString.Trim & vbTab     '取引先区分
            Indata = Indata & row(4).ToString.Trim & vbTab     '税区分
            Indata = Indata & row(11).ToString.Trim & vbTab    '窓口部署名（カナ）
            Indata = Indata & row(16).ToString.Trim & vbTab    '窓口住所（カナ）１
            Indata = Indata & row(17).ToString.Trim & vbTab    '窓口住所（カナ）２
            Indata = Indata & row(18).ToString.Trim & vbTab    '窓口電話番号
            Indata = Indata & row(19).ToString.Trim & vbTab    '窓口ＦＡＸ番号
            Indata = Indata & row(20).ToString.Trim & vbTab    '窓口郵便番号
            Indata = Indata & row(21).ToString.Trim & vbTab    '窓口担当者
            Indata = Indata & row(31).ToString.Trim & vbTab    '除外ＳＹ
            Indata = Indata & row(34).ToString.Trim & vbTab    '登録年月日
            Indata = Indata & row(35).ToString.Trim            '修正年月日
            DR("入力情報") = Indata

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

#Region "前日情報と比較（資材マスタ）"
    ''' <summary>
    ''' 入力ファイルと前日情報の比較を行う（資材マスタ）
    ''' </summary>>
    ''' <param name="row">入力ファイル情報</param>
    ''' <param name="Dr">前日情報</param>
    ''' <returns></returns>
    ''' <remarks>入力ファイルと前日情報の比較を行う（資材マスタ）</remarks>
    Public Shared Function IsDiff_Sizai(ByVal row As Object, ByRef Dr As DataRow, ByVal Div As String, ByVal l_kojo_code As String) As Boolean

        IsDiff_Sizai = False

        Dim ArrBefData As Object = Nothing
        Dim ArrTodayData As Object = Nothing

        Try
            '前日情報
            ArrBefData = Dr.ItemArray
            '日付は対象外とする
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrBefData(0) = PadRightB(ArrBefData(0), 20, " ")
            ArrBefData(1) = PadRightB(ArrBefData(1), 1, " ")
            ArrBefData(2) = PadRightB(ArrBefData(2), 10, " ")
            ArrBefData(3) = PadRightB(ArrBefData(3), 6, " ")
            ArrBefData(4) = PadRightB(ArrBefData(4), 25, " ")
            ArrBefData(5) = PadRightB(ArrBefData(5), 1, " ")
            ArrBefData(6) = PadRightB(ArrBefData(6), 1, " ")
            ArrBefData(7) = PadRightB(ArrBefData(7), 1, " ")
            ArrBefData(8) = PadRightB(ArrBefData(8), 3, " ")
            ArrBefData(9) = PadRightB(ArrBefData(9), 3, " ")
            ArrBefData(10) = PadRightB(ArrBefData(10), 1, " ")
            ArrBefData(11) = PadRightB(ArrBefData(11), 13, " ")
            ArrBefData(12) = PadRightB(ArrBefData(12), 13, " ")
            ArrBefData(13) = PadRightB(ArrBefData(13), 13, " ")
            ArrBefData(14) = PadRightB(ArrBefData(14), 2, " ")
            '20180409修正(HISYS) S      懸案管理[No.G30-002246]
            If Div = "K05" Or Div = "K06" Or Div = "K07" Then
                ArrBefData(15) = "             "            '当月払出予算@
                ArrBefData(16) = "             "            '翌期払出予算@
            Else
                ArrBefData(15) = PadRightB(ArrBefData(15), 13, " ")
                ArrBefData(16) = PadRightB(ArrBefData(16), 13, " ")
            End If
            '20180409修正(HISYS) E      懸案管理[No.G30-002246]
            ArrBefData(17) = PadRightB(ArrBefData(17), 13, " ")
            ArrBefData(18) = PadRightB(ArrBefData(18), 1, " ")
            ArrBefData(19) = PadRightB(ArrBefData(19), 15, " ")
            '20180409修正(HISYS) S      懸案管理[No.G30-002246]
            If Div = "K05" Or Div = "K06" Or Div = "K07" Then
                ArrBefData(20) = "             "            'ベース@
            Else
                ArrBefData(20) = PadRightB(ArrBefData(20), 13, " ")
            End If
            '20180409修正(HISYS) E      懸案管理[No.G30-002246]
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]
            ArrBefData(21) = "      "                      '登録年月日
            ArrBefData(22) = "      "                      '訂正年月日
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrBefData(23) = PadRightB(ArrBefData(23), 1, " ")
            ArrBefData(24) = PadRightB(ArrBefData(24), 3, " ")
            ArrBefData(25) = PadRightB(ArrBefData(25), 2, " ")
            ArrBefData(26) = PadRightB(ArrBefData(26), 30, " ")
            ArrBefData(27) = PadRightB(ArrBefData(27), 2, " ")
            ArrBefData(28) = PadRightB(ArrBefData(28), 19, " ")
            ArrBefData(29) = PadRightB(ArrBefData(29), 13, " ")
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]
            ArrBefData(30) = "              "                   'CS登録年月日
            ArrBefData(31) = "              "                   'CS修正年月日
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrBefData(32) = PadRightB(ArrBefData(32), 1, " ")
            ArrBefData(33) = PadRightB(ArrBefData(33), 40, " ")
            ArrBefData(34) = PadRightB(ArrBefData(34), 1, " ")
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]

            ReDim ArrTodayData(34)
            '入力ファイル
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrTodayData(0) = PadRightB(Div, 20, " ")
            ArrTodayData(1) = PadRightB(l_kojo_code, 1, " ")
            ArrTodayData(2) = PadRightB(row(1).ToString, 10, " ")
            ArrTodayData(3) = PadRightB(row(2).ToString, 6, " ")
            ArrTodayData(4) = PadRightB(row(3).ToString, 25, " ")
            ArrTodayData(5) = PadRightB(row(4).ToString, 1, " ")
            ArrTodayData(6) = PadRightB(row(5).ToString, 1, " ")
            ArrTodayData(7) = PadRightB(row(6).ToString, 1, " ")
            ArrTodayData(8) = PadRightB(row(10).ToString, 3, " ")
            ArrTodayData(9) = PadRightB(row(11).ToString, 3, " ")
            ArrTodayData(10) = PadRightB(row(12).ToString, 1, " ")
            ArrTodayData(11) = PadRightB(row(14).ToString, 13, " ")
            ArrTodayData(12) = PadRightB(row(19).ToString, 13, " ")
            ArrTodayData(13) = PadRightB(row(21).ToString, 13, " ")
            ArrTodayData(14) = PadRightB(row(24).ToString, 2, " ")
            '20180409修正(HISYS) S      懸案管理[No.G30-002246]
            If Div = "K05" Or Div = "K06" Or Div = "K07" Then
                ArrTodayData(15) = "             "            '当月払出予算@
                ArrTodayData(16) = "             "            '翌期払出予算@
            Else
                ArrTodayData(15) = PadRightB(row(29).ToString, 13, " ")
                ArrTodayData(16) = PadRightB(row(31).ToString, 13, " ")
            End If
            '20180409修正(HISYS) E      懸案管理[No.G30-002246]
            ArrTodayData(17) = PadRightB(row(35).ToString, 13, " ")
            ArrTodayData(18) = PadRightB(row(38).ToString, 1, " ")
            ArrTodayData(19) = PadRightB(row(44).ToString, 15, " ")
            '20180409修正(HISYS) S      懸案管理[No.G30-002246]
            If Div = "K05" Or Div = "K06" Or Div = "K07" Then
                ArrTodayData(20) = "             "            'ベース@
            Else
                ArrTodayData(20) = PadRightB(row(49).ToString, 13, " ")
            End If
            '20180409修正(HISYS) E      懸案管理[No.G30-002246]
            'ArrTodayData(21) = row(51).ToString.Trim    '登録年月日
            'ArrTodayData(22) = row(52).ToString.Trim    '訂正年月日
            ArrTodayData(21) = "      "
            ArrTodayData(22) = "      "
            ArrTodayData(23) = PadRightB(row(56).ToString, 1, " ")
            ArrTodayData(24) = PadRightB(row(67).ToString, 3, " ")
            ArrTodayData(25) = PadRightB(row(72).ToString, 2, " ")
            ArrTodayData(26) = PadRightB(row(75).ToString, 30, " ")
            ArrTodayData(27) = PadRightB(row(76).ToString, 2, " ")
            ArrTodayData(28) = PadRightB(row(77).ToString, 19, " ")
            ArrTodayData(29) = PadRightB(row(78).ToString, 13, " ")
            'ArrTodayData(30) = row(96).ToString.Trim    'CS登録年月日
            'ArrTodayData(31) = row(97).ToString.Trim    'CS修正年月日
            ArrTodayData(30) = "              "
            ArrTodayData(31) = "              "
            ArrTodayData(32) = PadRightB(row(103).ToString, 1, " ")
            ArrTodayData(33) = PadRightB(row(141).ToString, 40, " ")
            ArrTodayData(34) = PadRightB(row(54).ToString, 1, " ")
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]

            'Return ArrTodayData.SequenceEqual(ArrBefData)
            Return DirectCast(ArrTodayData, IStructuralEquatable).Equals(ArrBefData, StructuralComparisons.StructuralEqualityComparer)

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

#Region "前日情報と比較（取引先マスタ）"
    ''' <summary>
    ''' 入力ファイルと前日情報の比較を行う（取引先マスタ）
    ''' </summary>>
    ''' <param name="row">入力ファイル情報</param>
    ''' <param name="Dr">前日情報</param>
    ''' <returns></returns>
    ''' <remarks>入力ファイルと前日情報の比較を行う（取引先マスタ）</remarks>
    Public Shared Function IsDiff_Tori(ByVal row As Object, ByRef Dr As DataRow, ByVal Div As String, ByVal ToriCd As String) As Boolean

        IsDiff_Tori = False

        Dim ArrBefData As Object = Nothing
        Dim ArrTodayData As Object = Nothing

        Try
            '前日情報
            ArrBefData = Dr.ItemArray
            '日付は対象外とする
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrBefData(0) = PadRightB(ArrBefData(0), 20, " ")
            ArrBefData(1) = PadRightB(ArrBefData(1), 6, " ")
            ArrBefData(2) = PadRightB(ArrBefData(2), 50, " ")
            ArrBefData(3) = PadRightB(ArrBefData(3), 15, " ")
            ArrBefData(4) = PadRightB(ArrBefData(4), 1, " ")
            ArrBefData(5) = PadRightB(ArrBefData(5), 1, " ")
            ArrBefData(6) = PadRightB(ArrBefData(6), 30, " ")
            ArrBefData(7) = PadRightB(ArrBefData(7), 30, " ")
            ArrBefData(8) = PadRightB(ArrBefData(8), 30, " ")
            ArrBefData(9) = PadRightB(ArrBefData(9), 12, " ")
            ArrBefData(10) = PadRightB(ArrBefData(10), 12, " ")
            ArrBefData(11) = PadRightB(ArrBefData(11), 8, " ")
            ArrBefData(12) = PadRightB(ArrBefData(12), 14, " ")
            ArrBefData(13) = PadRightB(ArrBefData(13), 1, " ")
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]
            ArrBefData(14) = "              "           '登録年月日
            ArrBefData(15) = "              "           '訂正年月日

            ReDim ArrTodayData(15)
            '入力ファイル
            '20170410修正(HIDOC) S      システム課題[No.K1610-0429]
            ArrTodayData(0) = PadRightB(Div, 20, " ")
            ArrTodayData(1) = PadRightB(ToriCd, 6, " ")
            ArrTodayData(2) = PadRightB(row(1).ToString, 50, " ")
            ArrTodayData(3) = PadRightB(row(2).ToString, 15, " ")
            ArrTodayData(4) = PadRightB(row(3).ToString, 1, " ")
            ArrTodayData(5) = PadRightB(row(4).ToString, 1, " ")
            ArrTodayData(6) = PadRightB(row(11).ToString, 30, " ")
            ArrTodayData(7) = PadRightB(row(16).ToString, 30, " ")
            ArrTodayData(8) = PadRightB(row(17).ToString, 30, " ")
            ArrTodayData(9) = PadRightB(row(18).ToString, 12, " ")
            ArrTodayData(10) = PadRightB(row(19).ToString, 12, " ")
            ArrTodayData(11) = PadRightB(row(20).ToString, 8, " ")
            ArrTodayData(12) = PadRightB(row(21).ToString, 14, " ")
            ArrTodayData(13) = PadRightB(row(31).ToString, 1, " ")
            'ArrTodayData(14) = row(51).ToString.Trim    '登録年月日
            'ArrTodayData(15) = row(52).ToString.Trim    '修正年月日
            ArrTodayData(14) = "              "         '登録年月日
            ArrTodayData(15) = "              "         '修正年月日
            '20170410修正(HIDOC) E      システム課題[No.K1610-0429]

            'Return ArrTodayData.SequenceEqual(ArrBefData)
            Return DirectCast(ArrTodayData, IStructuralEquatable).Equals(ArrBefData, StructuralComparisons.StructuralEqualityComparer)

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

#Region "前日情報データテーブルに当日データを追加・編集"
    ''' <summary>
    ''' 前日情報データテーブルに当日データを追加・編集
    ''' </summary>>
    ''' <param name="Flg_Mst">マスタフラグ（1:資材マスタ、2：取引先マスタ、3：資材マスタ（資材略称））</param>
    ''' <param name="Dt">前日情報データテーブル</param>
    ''' <param name="row">入力情報</param>
    ''' <param name="result">CUP連携結果データテーブル</param>
    ''' <returns></returns>
    ''' <remarks>前日情報データテーブルに当日データを追加・編集（資材マスタ）</remarks>
    Public Shared Function EditBeforData(ByVal Flg_Mst As String, ByRef Dt As DataTable, ByVal row As Object, ByRef result As DataTable) As Boolean

        EditBeforData = False

        Dim nr As DataRow = Nothing
        Dim nr2 As DataRow = Nothing
        Dim keyData As String()
        Dim stArrayData As String()

        Try
            keyData = row("入力情報（キー）").ToString.Split(vbTab)
            stArrayData = row("入力情報").ToString.Split(vbTab)

            'データ検索
            '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            'If Flg_Mst = "1" Then
            If Flg_Mst = "1" Or Flg_Mst = "3" Then
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                ExitData_Sizai(Dt, nr, keyData(0), keyData(1), keyData(2), keyData(3))
            Else
                ExitData_Tori(Dt, nr, keyData(0), keyData(1))
            End If

            If IsNothing(nr) Then
                'データなし
                'キー設定
                nr = Dt.NewRow
                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                'If Flg_Mst = "1" Then
                If Flg_Mst = "1" Or Flg_Mst = "3" Then
                    '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                    nr("事業所") = keyData(0)
                    nr("工場コード") = keyData(1)
                    nr("資材コード") = keyData(2)
                    nr("取引先コード") = keyData(3)
                    'レコード設定
                    SetBeforData_Sizai(nr, stArrayData)

                Else
                    nr("事業所") = keyData(0)
                    nr("取引先コード") = keyData(1)
                    'レコード設定
                    SetBeforData_Tori(nr, stArrayData)

                End If

                'レコード追加
                Dt.Rows.Add(nr)

            Else
                '1:新規作成、2:更新、3:削除
                'データあり
                If stArrayData(0) = "1" Or stArrayData(0) = "2" Then
                    'レコード変更
                    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                    'If Flg_Mst = "1" Then
                    If Flg_Mst = "1" Or Flg_Mst = "3" Then
                        '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                        SetBeforData_Sizai(nr, stArrayData)
                    Else
                        SetBeforData_Tori(nr, stArrayData)
                    End If


                ElseIf stArrayData(0) = "3" Then
                    'データの削除
                    nr.Delete()

                Else
                    Return False

                End If

            End If

            'CUP連携結果格納
            'レコード検索
            If Flg_Mst = "1" Then
                ExitData_Sizai(result, nr2, keyData(0), keyData(1), keyData(2), keyData(3))
                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
                'Else
            ElseIf Flg_Mst = "2" Then
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
                ExitData_Tori(result, nr2, keyData(0), keyData(1))
                '20170526修正(HIDOC) S      本番稼動後課題[No.102]
            ElseIf Flg_Mst = "3" Then
                ExitData_Sizai(result, nr2, "", "", "", "", row("入力情報（レガシーキー）").ToString)
                '20170526修正(HIDOC) E      本番稼動後課題[No.102]
            End If

            If IsNothing(nr2) Then
                'データなし
                Return False
            Else
                '結果格納
                nr2("更新内容") = stArrayData(0).ToString
                nr2("連携結果") = "OK"
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

#Region "前日情報データテーブルのレコード設定（資材マスタ）"
    ''' <summary>
    ''' 前日情報データテーブルのレコード設定（資材マスタ）
    ''' </summary>>
    ''' <param name="Dr">前日情報データテーブル</param>
    ''' <param name="row">入力情報</param>
    ''' <returns></returns>
    ''' <remarks>前日情報データテーブルに当日データを追加・編集（資材マスタ）</remarks>
    Public Shared Function SetBeforData_Sizai(ByRef Dr As DataRow, ByVal row As Object) As Boolean

        SetBeforData_Sizai = False

        Try
            Dr("資材略称") = row(1)
            Dr("在庫区分") = row(2)
            Dr("購買区分") = row(3)
            Dr("購買担当者") = row(4)
            Dr("標準納期") = row(5)
            Dr("最短納期") = row(6)
            Dr("検査要否") = row(7)
            Dr("標準発注ロット") = row(8)
            Dr("標準納入ロット") = row(9)
            Dr("発注点（生産点）") = row(10)
            Dr("購入単位略号") = row(11)
            Dr("当月払出予算＠") = row(12)
            Dr("翌期払出予算＠") = row(13)
            Dr("支給＠") = row(14)
            Dr("管理勘定") = row(15)
            Dr("備考（図＃）") = row(16)
            Dr("ベース＠") = row(17)
            Dr("登録年月日") = row(18)
            Dr("訂正年月日") = row(19)
            Dr("振区") = row(20)
            Dr("荷姿単位コード") = row(21)
            Dr("受渡場所コード") = row(22)
            Dr("一般共通品名") = row(23)
            Dr("統計単位略号") = row(24)
            Dr("購入仕様書Ｎｏ") = row(25)
            Dr("統計単位換算係数") = row(26)
            Dr("ＣＳ登録年月日") = row(27)
            Dr("ＣＳ修正年月日") = row(28)
            Dr("重要度区分") = row(29)
            Dr("当社の用途") = row(30)
            Dr("現場材料管理区分") = row(31)

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

#Region "前日情報データテーブルのレコード設定（取引先マスタ）"
    ''' <summary>
    ''' 前日情報データテーブルのレコード設定（取引先マスタ）
    ''' </summary>>
    ''' <param name="Dr">前日情報データテーブル</param>
    ''' <param name="row">入力情報</param>
    ''' <returns></returns>
    ''' <remarks>前日情報データテーブルに当日データを追加・編集（資材マスタ）</remarks>
    Public Shared Function SetBeforData_Tori(ByRef Dr As DataRow, ByVal row As Object) As Boolean

        SetBeforData_Tori = False

        Try
            Dr("取引先名（漢字）") = row(1)
            Dr("取引先名（カナ）") = row(2)
            Dr("取引先区分") = row(3)
            Dr("税区分") = row(4)
            Dr("窓口部署名（カナ）") = row(5)
            Dr("窓口住所（カナ）１") = row(6)
            Dr("窓口住所（カナ）２") = row(7)
            Dr("窓口電話番号") = row(8)
            Dr("窓口ＦＡＸ番号") = row(9)
            Dr("窓口郵便番号") = row(10)
            Dr("窓口担当者") = row(11)
            Dr("除外ＳＹ") = row(12)
            Dr("登録年月日") = row(13)
            Dr("修正年月日") = row(14)

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

#Region "フォルダ内の最新ファイルを取得する"
    ''' <summary>
    ''' フォルダ内の最新ファイルを取得する
    ''' </summary>
    ''' <param name="files">ファイル</param>
    ''' <param name="Kojo_kode">工場ｺｰﾄﾞ</param>
    Public Shared Function GetLastFile(ByVal files() As String, ByVal Kojo_kode As String) As String

        Dim lstFile As New ArrayList

        '工場ごとに最新ファイルを取得する
        For Each file In files

            '該当工場
            If Kojo_kode <> "" Then
                If file.IndexOf(Kojo_kode) >= 0 Then
                    lstFile.Add(file)

                End If
            Else
                lstFile.Add(file)

            End If
        Next

        '1件以上の場合はソートして0番目
        If lstFile.Count > 0 Then
            lstFile.Sort()

            '最新は最後データ
            GetLastFile = lstFile(lstFile.Count - 1)

        Else
            '0件の場合は空白
            GetLastFile = ""

        End If

        Return GetLastFile

    End Function

#End Region

    '20170310修正(HIDOC) E      BT課題[No.19]

    '20170526修正(HIDOC) S      本番稼動後課題[No.102]
#Region "連携対象外用前日情報用データ設定（資材マスタ）"
    ''' <summary>
    ''' 連携対象外用前日情報用データ設定（資材マスタ）
    ''' </summary>>
    ''' <param name="stArrayData">設定用配列</param>
    ''' <param name="row">入力ファイル情報（配列）</param>
    ''' <returns></returns>
    ''' <remarks>入力ファイル情報から前日情報用データを配列にセットする（資材マスタ）</remarks>
    Public Shared Function SetBeData_Sizai(ByRef stArrayData As String(), ByVal row As Object) As Boolean

        SetBeData_Sizai = False

        Try

            '入力情報
            stArrayData = Nothing
            ReDim stArrayData(31)

            stArrayData(0) = ""
            stArrayData(1) = row(3).ToString.Trim       '資材略称
            stArrayData(2) = row(4).ToString.Trim       '在庫区分
            stArrayData(3) = row(5).ToString.Trim       '購買区分
            stArrayData(4) = row(6).ToString.Trim       '購買担当者
            stArrayData(5) = row(10).ToString.Trim      '標準納期
            stArrayData(6) = row(11).ToString.Trim      '最短納期
            stArrayData(7) = row(12).ToString.Trim      '検査要否
            stArrayData(8) = row(14).ToString.Trim      '標準発注ロット
            stArrayData(9) = row(19).ToString.Trim      '標準納入ロット
            stArrayData(10) = row(21).ToString.Trim     '発注点(生産点)
            stArrayData(11) = row(24).ToString.Trim     '購入単位略号
            stArrayData(12) = row(29).ToString.Trim     '当月払出予算＠
            stArrayData(13) = row(31).ToString.Trim     '翌期払出予算＠
            stArrayData(14) = row(35).ToString.Trim     '支給＠
            stArrayData(15) = row(38).ToString.Trim     '管理勘定
            stArrayData(16) = row(44).ToString.Trim     '備考(図＃)
            stArrayData(17) = row(49).ToString.Trim     'ベース＠
            stArrayData(18) = row(51).ToString.Trim     '登録年月日
            stArrayData(19) = row(52).ToString.Trim     '訂正年月日
            stArrayData(20) = row(56).ToString.Trim     '振区
            stArrayData(21) = row(67).ToString.Trim     '荷姿単位コード
            stArrayData(22) = row(72).ToString.Trim     '受渡場所コード
            stArrayData(23) = row(75).ToString.Trim     '一般共通品名
            stArrayData(24) = row(76).ToString.Trim     '統計単位略号
            stArrayData(25) = row(77).ToString.Trim     '購入仕様書No
            stArrayData(26) = row(78).ToString.Trim     '統計単位換算係数
            stArrayData(27) = row(96).ToString.Trim     'CS登録年月日
            stArrayData(28) = row(97).ToString.Trim     'CS修正年月日
            stArrayData(29) = row(103).ToString.Trim    '重要度区分
            stArrayData(30) = row(141).ToString.Trim    '当社の用途
            stArrayData(31) = row(54).ToString.Trim     '現場材料管理区分

            SetBeData_Sizai = True

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

    '20170526修正(HIDOC) E      本番稼動後課題[No.102]
    '20170630修正(HIDOC) S      本番稼動後課題[No.123]
#Region "ログ種別取得"
    ''' <summary>
    ''' ログ種別取得
    ''' </summary>
    ''' <param name="strErrMes">メッセージ</param>
    ''' <param name="FlgType">処理タイプ(1：メッセージID、2：メッセージ内容)</param>
    ''' <param name="RtnType">戻り値タイプ(1：エラーID(3(ERR)、5(WARNING))、2：文字列(【ERR】、【WAR】))</param>
    ''' <param name="ERRFLG">エラーフラグ(true：エラーあり、false：エラーなし)</param>
    ''' <param name="WARFLG">ワーニングフラグ(true：ワーニングあり、false：ワーニングなし)</param>
    ''' <returns></returns>
    ''' <remarks>指定されたメッセージのログ種別を判断する</remarks>
    Public Shared Function GetLogType(ByVal strErrMes As String, ByVal FlgType As Integer, ByVal RtnType As Integer, Optional ByRef ERRFLG As Boolean = False, Optional ByRef WARFLG As Boolean = False) As String
        'Public Shared Function GetLogType(ByVal dt As DataTable, ByVal strErrMes As String, ByVal FlgType As Integer) As String

        GetLogType = ""

        Try
            '警告メッセージ管理テーブルのレコード確認
            If clsSQLServer.getWarMes_Data(strErrMes, FlgType) = False Then
                'なし（エラー）
                If RtnType = 1 Then
                    GetLogType = ClsLogString.RunState.Err
                Else
                    GetLogType = "【ERR】"
                End If
                ERRFLG = True
            Else
                'あり（ワーニング）
                If RtnType = 1 Then
                    GetLogType = ClsLogString.RunState.Warning
                Else
                    GetLogType = "【WAR】"
                End If
                WARFLG = True
            End If

        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return ""
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        End Try

    End Function
#End Region
    '20170630修正(HIDOC) E      本番稼動後課題[No.123]
End Class

