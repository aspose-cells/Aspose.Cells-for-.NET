Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Files.Utility
    Public Class Excel2PDFConversion
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate the Workbook object
            'Open an Excel file
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            'Save the document in PDF format
            workbook.Save(dataDir & "output.pdf", SaveFormat.Pdf)

            ' Display result, so that use know the processing has finished.
            System.Console.WriteLine("Conversion completed.")
            'ExEnd:1
        End Sub
    End Class
End Namespace