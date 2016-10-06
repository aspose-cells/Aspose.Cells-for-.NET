
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Globalization
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Articles
    Public Class LoadWorkbookWithSpecificCultureInfoDateFormat
        Public Shared Sub Run()
            ' ExStart:LoadWorkbookWithSpecificCultureInfoDateFormat
            Using inputStream = New MemoryStream()
                Using writer = New StreamWriter(inputStream)
                    writer.WriteLine("<html><head><title>Test Culture</title></head><body><table><tr><td>10-01-2016</td></tr></table></body></html>")
                    writer.Flush()

                    Dim culture = New CultureInfo("en-GB")
                    culture.NumberFormat.NumberDecimalSeparator = ","
                    culture.DateTimeFormat.DateSeparator = "-"
                    culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy"
                    Dim options As New LoadOptions(LoadFormat.Html)
                    options.CultureInfo = culture

                    Using workbook = New Workbook(inputStream, options)
                        Dim cell = workbook.Worksheets(0).Cells("A1")
                        Assert.AreEqual(CellValueType.IsDateTime, cell.Type)
                        Assert.AreEqual(New DateTime(2016, 1, 10), cell.DateTimeValue)
                    End Using
                End Using
            End Using
            ' ExEnd:LoadWorkbookWithSpecificCultureInfoDateFormat
        End Sub
    End Class
End Namespace
