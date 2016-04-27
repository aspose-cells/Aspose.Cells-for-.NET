Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles

    Public Class AvoidExponentialNotationWhileImportingFromHtml
        Public Shared Sub Main(ByVal args() As String)

            'ExStart:AvoidExponentialNotationWhileImportingFromHtml
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Sample Html containing large number with digits greater than 15
            Dim html As String = "<html><body><p>1234567890123456</p></body></html>"

            'Convert Html to byte array
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(html)

            'Set Html load options and keep precision true
            Dim loadOptions As HTMLLoadOptions = New Aspose.Cells.HTMLLoadOptions(LoadFormat.Html)
            loadOptions.KeepPrecision = True

            'Convert byte array into stream
            Dim stream As New System.IO.MemoryStream(byteArray)

            'Create workbook from stream with Html load options
            Dim workbook As New Workbook(stream, loadOptions)

            'Access first worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Auto fit the sheet columns
            sheet.AutoFitColumns()

            'Save the workbook
            workbook.Save(dataDir & "AvoidExponentialNotationWhileImportingFromHtml.xlsx", SaveFormat.Xlsx)
            'ExEnd:AvoidExponentialNotationWhileImportingFromHtml

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()

        End Sub
    End Class
End Namespace
