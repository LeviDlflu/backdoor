Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.Data.OleDb

Public Class clsCSV

#Region "DataTableの内容をCSVファイルに保存する"
    ''' <summary>
    ''' DataTableの内容をCSVファイルに保存する
    ''' </summary>
    ''' <param name="dt">CSVに変換するDataTable</param>
    ''' <param name="csvPath">保存先のCSVファイルのパス(ファイル名含む）</param>
    ''' <param name="writeHeader">ヘッダを書き込む時はtrue。</param>
    ''' <param name="DoubleQuotesNeed">"で囲む時はtrue。</param>
    Public Shared Function ConvertDataTableToCsv(
            ByRef dt As DataTable, ByRef csvPath As String, ByVal writeHeader As Boolean, ByVal DoubleQuotesNeed As Boolean) As Boolean

        Try
            'CSVファイルに書き込むときに使うEncoding
            Dim enc As System.Text.Encoding =
                System.Text.Encoding.GetEncoding("Shift_JIS")

            '書き込むファイルを開く
            Dim sr As New System.IO.StreamWriter(csvPath, False, enc)

            Dim colCount As Integer = dt.Columns.Count
            Dim lastColIndex As Integer = colCount - 1
            Dim i As Integer

            'ヘッダを書き込む
            If writeHeader Then
                For i = 0 To colCount - 1
                    'ヘッダの取得
                    Dim field As String = dt.Columns(i).Caption

                    If DoubleQuotesNeed Then
                        '"で囲む
                        field = EncloseDoubleQuotesIfNeed(field)

                    End If

                    'フィールドを書き込む
                    sr.Write(field)
                    'カンマを書き込む
                    If lastColIndex > i Then
                        sr.Write(","c)
                    End If
                Next
                '改行する
                sr.Write(vbCrLf)
            End If

            'レコードを書き込む
            Dim row As DataRow
            For Each row In dt.Rows
                For i = 0 To colCount - 1
                    'フィールドの取得
                    Dim field As String = row(i).ToString()

                    If DoubleQuotesNeed Then
                        '"で囲む
                        field = EncloseDoubleQuotesIfNeed(field)
                    End If

                    'フィールドを書き込む
                    sr.Write(field)
                    'カンマを書き込む
                    If lastColIndex > i Then
                        sr.Write(","c)
                    End If
                Next
                '改行する
                sr.Write(vbCrLf)
            Next

            '閉じる
            sr.Close()

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

#Region "必要ならば、文字列をダブルクォートで囲む"
    ''' <summary>
    ''' 必要ならば、文字列をダブルクォートで囲む
    ''' </summary>
    Private Shared Function EncloseDoubleQuotesIfNeed(field As String) As String
        If NeedEncloseDoubleQuotes(field) Then
            Return EncloseDoubleQuotes(field)
        End If
        Return field
    End Function
#End Region

#Region "文字列をダブルクォートで囲む"
    ''' <summary>
    ''' 文字列をダブルクォートで囲む
    ''' </summary>
    Private Shared Function EncloseDoubleQuotes(field As String) As String
        If field.IndexOf(""""c) > -1 Then
            '"を""とする
            field = field.Replace("""", """""")
        End If
        Return """" & field & """"
    End Function
#End Region

#Region "文字列をダブルクォートで囲む必要があるか調べる"
    ''' <summary>
    ''' 文字列をダブルクォートで囲む必要があるか調べる
    ''' </summary>
    Private Shared Function NeedEncloseDoubleQuotes(field As String) As Boolean
        Return field.IndexOf(""""c) > -1 OrElse
            field.IndexOf(","c) > -1 OrElse
            field.IndexOf(ControlChars.Cr) > -1 OrElse
            field.IndexOf(ControlChars.Lf) > -1 OrElse
            field.StartsWith(" ") OrElse
            field.StartsWith(vbTab) OrElse
            field.EndsWith(" ") OrElse
            field.EndsWith(vbTab)
    End Function
#End Region

#Region "CSVファイルをDataTableへ格納"

    'dt:データを入れるDataTable
    'hasHeader:CSVの一行目がカラム名かどうか
    'fileName:ファイル名
    'separator:カラムを分けている文字(,など)
    'quote:カラムを囲んでいる文字("など)
    Public Shared Function CSVtoDataTable(ByRef dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String, Optional separator As String = ",", Optional quote As Boolean = False) As Boolean

        'CSVを便利に読み込んでくれるTextFieldParserを使います。
        Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))

        Try
            Dim dTbl As New DataTable

            'これは可変長のフィールドでフィールドの区切りのマーカーが使われている場合です。
            'フィールドが固定長の場合は
            'parser.TextFieldType = FieldType.FixedWidth;
            parser.TextFieldType = FieldType.Delimited
            '区切り文字を設定します。
            parser.SetDelimiters(separator)
            'クォーテーションがあるかどうか。
            '但しダブルクォーテーションにしか対応していません。シングルクォーテーションは認識しません。
            parser.HasFieldsEnclosedInQuotes = quote

            '空白除去しない
            parser.TrimWhiteSpace = False

            Dim data() As String

            'ここのif文では、DataTableに必要なカラムを追加するために最初に1行だけ読み込んでいます。
            'データがあるか確認します。
            If Not parser.EndOfData Then
                'CSVファイルから1行読み取ります。
                data = parser.ReadFields()
                'カラムの数を取得します。
                Dim cols As Integer = data.Length
                If hasHeader Then
                    For i As Integer = 0 To cols - 1 Step 1
                        dTbl.Columns.Add(New DataColumn(data(i)))
                    Next i
                Else
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラム名にダミーを設定します。
                        dTbl.Columns.Add(New DataColumn("F" & i + 1))
                    Next i
                    'DataTableに追加するための新規行を取得します。
                    Dim row As DataRow = dTbl.NewRow()
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラムの数だけデータをうつします。
                        row(i) = data(i)
                    Next i
                    'DataTableに追加します。
                    dTbl.Rows.Add(row)
                End If
            Else
                '(懸案3450対応)ヘッダーが存在しない場合はエラーとする
                '(埼)化はヘッダー無形式だが、先頭行がファイルエンドの場合も一律エラーとする
                clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E046"), ClsLogString.RunState.Err)
            End If
            'ここのループがCSVを読み込むメインの処理です。
            '内容は先ほどとほとんど一緒です。
            While Not parser.EndOfData
                data = parser.ReadFields()
                Dim row As DataRow = dTbl.NewRow()
                For i As Integer = 0 To dTbl.Columns.Count - 1 Step 1
                    If i < data.Count Then
                        row(i) = data(i)
                    End If
                Next i
                dTbl.Rows.Add(row)

            End While
            dt = dTbl
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            parser.Close()
        End Try

    End Function

#End Region

#Region "CSV以外の区切り文字があるファイルをDataTableへ格納(出力ファイル対応用)"

    'dt:データを入れるDataTable
    'hasHeader:CSVの一行目がカラム名かどうか
    'fileName:ファイル名
    'separator:カラムを分けている文字(,など)
    'quote:カラムを囲んでいる文字("など)
    Public Shared Function CSVtoDataTable2(ByRef dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String, Optional separator As String = ",", Optional quote As Boolean = False) As Boolean

        'CSVを便利に読み込んでくれるTextFieldParserを使います。
        Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))

        Try
            Dim dTbl As New DataTable

            'これは可変長のフィールドでフィールドの区切りのマーカーが使われている場合です。
            'フィールドが固定長の場合は
            'parser.TextFieldType = FieldType.FixedWidth;
            parser.TextFieldType = FieldType.Delimited
            '区切り文字を設定します。
            parser.SetDelimiters(separator)
            'クォーテーションがあるかどうか。
            '但しダブルクォーテーションにしか対応していません。シングルクォーテーションは認識しません。
            parser.HasFieldsEnclosedInQuotes = quote

            Dim data() As String

            'ここのif文では、DataTableに必要なカラムを追加するために最初に1行だけ読み込んでいます。
            'データがあるか確認します。
            If Not parser.EndOfData Then
                'CSVファイルから1行読み取ります。
                data = parser.ReadFields()

                If (clsEtc.MidB(data(0).ToString, 1, 10) = "0000000000") Then
                    '次行読み込み
                    data = parser.ReadFields()
                End If

                If (clsEtc.MidB(data(0).ToString, 1, 10) = "9999999999") Then
                    '次行がフッタデータの場合、正常0件データとして扱う
                    Return True
                    Exit Function
                End If

                'カラムの数を取得します。
                Dim cols As Integer = data.Length
                If hasHeader Then
                    For i As Integer = 0 To cols - 1 Step 1
                        dTbl.Columns.Add(New DataColumn(data(i)))
                    Next i
                Else



                    For i As Integer = 0 To cols - 1 Step 1
                        'カラム名にダミーを設定します。
                        dTbl.Columns.Add(New DataColumn("F" & i + 1))
                    Next i
                    'DataTableに追加するための新規行を取得します。
                    Dim row As DataRow = dTbl.NewRow()
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラムの数だけデータをうつします。
                        row(i) = data(i)
                    Next i
                    'DataTableに追加します。
                    dTbl.Rows.Add(row)
                End If
            End If
            'ここのループがCSVを読み込むメインの処理です。
            '内容は先ほどとほとんど一緒です。
            While Not parser.EndOfData

                data = parser.ReadFields()

                If clsEtc.MidB(data(0).ToString, 1, 10) = "9999999999" Then

                    Exit While

                End If


                Dim row As DataRow = dTbl.NewRow()
                For i As Integer = 0 To dTbl.Columns.Count - 1 Step 1
                    If i < data.Count Then

                        row(i) = data(i)

                    End If
                Next i
                dTbl.Rows.Add(row)

            End While
            dt = dTbl
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            parser.Close()
        End Try

    End Function

#End Region

#Region "CSV以外の区切り文字があるファイルをDataTableへ格納(出力ファイル対応用)"
    '20170418(HIDOC)追加　─埼玉_出庫データ出力連携用（空白除去しない）─

    'dt:データを入れるDataTable
    'hasHeader:CSVの一行目がカラム名かどうか
    'fileName:ファイル名
    'separator:カラムを分けている文字(,など)
    'quote:カラムを囲んでいる文字("など)
    Public Shared Function CSVtoDataTable3(ByRef dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String, Optional separator As String = ",", Optional quote As Boolean = False) As Boolean

        'CSVを便利に読み込んでくれるTextFieldParserを使います。
        Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))

        Try
            Dim dTbl As New DataTable

            'これは可変長のフィールドでフィールドの区切りのマーカーが使われている場合です。
            'フィールドが固定長の場合は
            'parser.TextFieldType = FieldType.FixedWidth;
            parser.TextFieldType = FieldType.Delimited
            '区切り文字を設定します。
            parser.SetDelimiters(separator)
            'クォーテーションがあるかどうか。
            '但しダブルクォーテーションにしか対応していません。シングルクォーテーションは認識しません。
            parser.HasFieldsEnclosedInQuotes = quote

            '★空白除去しない★
            parser.TrimWhiteSpace = False

            Dim data() As String

            'ここのif文では、DataTableに必要なカラムを追加するために最初に1行だけ読み込んでいます。
            'データがあるか確認します。
            If Not parser.EndOfData Then
                'CSVファイルから1行読み取ります。
                data = parser.ReadFields()

                If (clsEtc.MidB(data(0).ToString, 1, 10) = "0000000000") Then
                    '次行読み込み
                    data = parser.ReadFields()
                End If

                If (clsEtc.MidB(data(0).ToString, 1, 10) = "9999999999") Then
                    '次行がフッタデータの場合、正常0件データとして扱う
                    Return True
                    Exit Function
                End If

                'カラムの数を取得します。
                Dim cols As Integer = data.Length
                If hasHeader Then
                    For i As Integer = 0 To cols - 1 Step 1
                        dTbl.Columns.Add(New DataColumn(data(i)))
                    Next i
                Else



                    For i As Integer = 0 To cols - 1 Step 1
                        'カラム名にダミーを設定します。
                        dTbl.Columns.Add(New DataColumn("F" & i + 1))
                    Next i
                    'DataTableに追加するための新規行を取得します。
                    Dim row As DataRow = dTbl.NewRow()
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラムの数だけデータをうつします。
                        row(i) = data(i)
                    Next i
                    'DataTableに追加します。
                    dTbl.Rows.Add(row)
                End If
            End If
            'ここのループがCSVを読み込むメインの処理です。
            '内容は先ほどとほとんど一緒です。
            While Not parser.EndOfData

                data = parser.ReadFields()

                If clsEtc.MidB(data(0).ToString, 1, 10) = "9999999999" Then

                    Exit While

                End If


                Dim row As DataRow = dTbl.NewRow()
                For i As Integer = 0 To dTbl.Columns.Count - 1 Step 1
                    If i < data.Count Then

                        row(i) = data(i)

                    End If
                Next i
                dTbl.Rows.Add(row)

            End While
            dt = dTbl
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            '20171026修正(システムズ) S  例外処理不具合対応
            'Return False
            Throw
            '20171026修正(システムズ) E  例外処理不具合対応
        Finally
            parser.Close()
        End Try

    End Function

#End Region

#Region "固定長ファイルをDataTableへ格納"
    ''' <summary>
    ''' 固定長ファイル読み込み
    ''' </summary>
    ''' <param name="dt">データを入れるDataTable</param>
    ''' <param name="fileName">ファイル名</param>
    ''' <param name="FieldSize">各項目のサイズ　　　例）{10, 5, 6, 20}</param>
    ''' <param name="hasHeader">CSVの一行目がカラム名かどうか</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FixedLengthDataFileToDataTable(ByRef dt As DataTable, ByVal fileName As String, ByVal FieldSize As Integer(), Optional hasHeader As Boolean = False) As Boolean
        Dim dTbl As New DataTable

        Try

            'CSVを便利に読み込んでくれるTextFieldParserを使います。
            Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))
            'これは可変長のフィールドでフィールドの区切りのマーカーが使われている場合です。
            'フィールドが固定長の場合は
            parser.TextFieldType = FieldType.FixedWidth
            parser.FieldWidths = FieldSize

            Dim data() As String

            'ここのif文では、DataTableに必要なカラムを追加するために最初に1行だけ読み込んでいます。
            'データがあるか確認します。
            If Not parser.EndOfData Then
                'CSVファイルから1行読み取ります。
                data = parser.ReadFields()
                'カラムの数を取得します。
                Dim cols As Integer = data.Length
                If hasHeader Then
                    For i As Integer = 0 To cols - 1 Step 1
                        dTbl.Columns.Add(New DataColumn(data(i)))
                    Next i
                Else
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラム名にダミーを設定します。
                        dTbl.Columns.Add(New DataColumn("F" & i + 1))
                    Next i
                    'DataTableに追加するための新規行を取得します。
                    Dim row As DataRow = dTbl.NewRow()
                    For i As Integer = 0 To cols - 1 Step 1
                        'カラムの数だけデータをうつします。
                        row(i) = data(i)
                    Next i
                    'DataTableに追加します。
                    dTbl.Rows.Add(row)
                End If
            End If
            ''ここのループがCSVを読み込むメインの処理です。
            ''内容は先ほどとほとんど一緒です。
            While Not parser.EndOfData
                data = parser.ReadFields()
                Dim row As DataRow = dTbl.NewRow()
                For i As Integer = 0 To dTbl.Columns.Count - 1 Step 1
                    row(i) = data(i)
                Next i
                dTbl.Rows.Add(row)

            End While
            dt = dTbl
            Return True
        Catch ex As Exception
            clsLogTrace.GetInstance.TraceWrite(clsGlobal.MSG("E999"), ClsLogString.RunState.Err)
            clsLogTrace.GetExInstance().ExceptionWrite(ex)

            Return False

        End Try

    End Function

#End Region

#Region "DataTableの内容を固定長ファイルに保存する(ヘッダ、フッタ用)"
    ''' <summary>
    ''' DataTableの内容を固定長ファイルに保存する
    ''' </summary>
    ''' <param name="dt">CSVに変換するDataTable</param>
    ''' <param name="filePath">保存先のCSVファイルのパス(ファイル名含む）</param>
    ''' <param name="writeHeader">ヘッダを書き込む時はtrue。</param>
    ''' <param name="DoubleQuotesNeed">"で囲む時はtrue。</param>
    Public Shared Function ConvertDataTableToFixedLengthDataFile(
            ByRef dt As DataTable, ByRef filePath As String, ByVal writeHeader As String, ByVal writefooter As String, ByVal DoubleQuotesNeed As Boolean) As Boolean

        Try
            'CSVファイルに書き込むときに使うEncoding
            Dim enc As System.Text.Encoding =
                System.Text.Encoding.GetEncoding("Shift_JIS")

            '書き込むファイルを開く
            Dim sr As New System.IO.StreamWriter(filePath, False, enc)

            Dim colCount As Integer = dt.Columns.Count
            Dim lastColIndex As Integer = colCount - 1
            Dim i As Integer


            'ヘッダデータを書き込む
            sr.Write(writeHeader)

            '20161226(HIDOC)修正 S    AT課題[No.56]
            'sr.Write(vbCrLf)
            sr.Write(vbLf)
            '20161226(HIDOC)修正 E

            'レコードを書き込む
            Dim row As DataRow
            For Each row In dt.Rows
                If row(0).ToString = "0" Then
                    For i = 1 To colCount - 1
                        'フィールドの取得
                        Dim field As String = row(i).ToString()

                        If DoubleQuotesNeed Then
                            '"で囲む
                            field = EncloseDoubleQuotesIfNeed(field)
                        End If

                        'フィールドを書き込む
                        sr.Write(field)
                        ' ''カンマを書き込む
                        ''If lastColIndex > i Then
                        ''    sr.Write(","c)
                        ''End If
                    Next
                    '改行する

                    '20161226(HIDOC)修正 S    AT課題[No.56]
                    'sr.Write(vbCrLf)
                    sr.Write(vbLf)
                    '20161226(HIDOC)修正 E
                End If

            Next

            'フッターデータを書き込む
            sr.Write(writefooter)

            '20161226(HIDOC)修正 S    AT課題[No.56]
            'sr.Write(vbCrLf)
            sr.Write(vbLf)
            '20161226(HIDOC)修正 E

            '閉じる
            sr.Close()

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

End Class

