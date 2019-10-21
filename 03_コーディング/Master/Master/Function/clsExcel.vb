Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Data

Public Class clsExcel
    Public Shared Sub ExportExcel(ByVal dt As DataTable, ByVal fileName As String)

        Dim xlApp As Object = Nothing
        Dim xlBooks As Object = Nothing
        Dim xlBook As Object = Nothing
        Dim xlSheet As Object = Nothing
        Dim xlCells As Object = Nothing
        Dim xlRange As Object = Nothing
        Dim xlCellStart As Object = Nothing
        Dim xlCellEnd As Object = Nothing
        '保存ディレクトリとファイル名を設定

        Try
            xlApp = CreateObject("Excel.Application")
            xlBooks = xlApp.Workbooks
            xlBook = xlBooks.Add
            xlSheet = xlBook.WorkSheets(1)

            'アラートメッセージ非表示設定
            xlApp.DisplayAlerts = False

            '現在日時を取得
            Dim timestanpText As String = Format(Now, "yyyyMMdd")

            Dim saveFileName As String
            saveFileName = xlApp.GetSaveAsFilename(InitialFilename:=fileName & "_" & timestanpText,
                                                    FileFilter:="Excel File (*.xlsx),*.xlsx")

            xlCells = xlSheet.Cells
            Dim dc As DataColumn
            Dim columnData(dt.Rows.Count, 1) As Object

            Dim row As Integer = 1
            Dim col As Integer = 1

            For col = 1 To dt.Columns.Count
                row = 1
                dc = dt.Columns(col - 1)
                'ヘッダー行の出力
                xlCells(row, col).value = dc.ColumnName
                row = row + 1

                ' 列データを配列に格納
                For i As Integer = 0 To dt.Rows.Count - 1
                    columnData(i, 0) = String.Format(dt.Rows(i)(col - 1))
                Next

                xlCellStart = xlCells(row, col)
                xlCellEnd = xlCells(row + dt.Rows.Count - 1, col)

                xlRange = xlSheet.Range(xlCellStart, xlCellEnd)

                ' Excel書式設定
                Select Case Type.GetTypeCode(dc.DataType)
                    Case TypeCode.String
                        xlRange.NumberFormatLocal = "@"
                    Case TypeCode.DateTime
                        xlRange.NumberFormatLocal = "yyyy/mm/dd"
                        'Case TypeCode.Decimal
                        '    xlRange.NumberFormatLocal = "#,###"
                End Select

                xlRange.value = columnData

            Next

            xlCells.EntireColumn.AutoFit()

            xlRange = xlSheet.UsedRange
            xlRange.Borders.LineStyle = True

            '保存先ディレクトリの設定が有効の場合はブックを保存
            If saveFileName <> "False" Then
                xlBook.SaveAs(Filename:=saveFileName)
                xlBook.close()
            End If

            xlApp.Visible = False

        Catch
            xlApp.DisplayAlerts = False
            xlApp.Quit()
            Throw
        Finally
            If xlCellStart IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCellStart)
            If xlCellEnd IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCellEnd)
            If xlRange IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange)
            If xlCells IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCells)
            If xlSheet IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet)

            xlApp.Quit()
            If xlBook IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook)
            If xlBook IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks)
            If xlApp IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)

            GC.Collect()

        End Try
    End Sub

End Class
