Imports System
Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles

    Public Class DeleteRedundantSpacesWhileImportingFromHtml
        Public Shared Sub Run()

            ' ExStart:DeleteRedundantSpacesWhileImportingFromHtml
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Sample Html containing redundant spaces after <br> tag
            Dim html As String = "<html> <body> <table> <tr> <td> <br>    This is sample data <br>    This is sample data<br>    This is sample data</td> </tr> </table> </body> </html>"

            ' Convert Html to byte array
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(html)

            ' Set Html load options and keep precision true
            Dim loadOptions As HTMLLoadOptions = New Aspose.Cells.HTMLLoadOptions(LoadFormat.Html)
            loadOptions.DeleteRedundantSpaces = True

            ' Convert byte array into stream
            Dim stream As New MemoryStream(byteArray)

            ' Create workbook from stream with Html load options
            Dim workbook As New Workbook(stream, loadOptions)

            ' Access first worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Auto fit the sheet columns
            sheet.AutoFitColumns()

            workbook.Save(dataDir & "DeleteRedundantSpaces.xlsx", SaveFormat.Xlsx)
            ' ExEnd:DeleteRedundantSpacesWhileImportingFromHtml

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()

        End Sub
    End Class
End Namespace