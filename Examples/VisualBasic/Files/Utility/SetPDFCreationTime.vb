Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Aspose.Cells.Examples.Files.Utility
    Friend Class SetPDFCreationTime
        Shared Sub Main()

            'ExStart:1
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Book1.xlsx"
            'Load excel file containing charts
            Dim workbook As New Workbook(inputPath)

            'Create an instance of PdfSaveOptions and pass SaveFormat to the constructor
            Dim options As New PdfSaveOptions(SaveFormat.Pdf)
            options.CreatedTime = Date.Now

            'Save the workbook to PDF format while passing the object of PdfSaveOptions
            workbook.Save(dataDir & "output.pdf", options)
            'ExEnd:1

        End Sub
    End Class
End Namespace
