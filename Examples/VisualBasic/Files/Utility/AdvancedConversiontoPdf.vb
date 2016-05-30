Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering

Namespace Files.Utility
    Public Class AdvancedConversiontoPdf
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate new workbook
            Dim workbook As New Workbook()

            ' Insert a value into the A1 cell in the first worksheet
            workbook.Worksheets(0).Cells(0, 0).PutValue("Testing PDF/A")

            ' Define PdfSaveOptions
            Dim pdfSaveOptions As New PdfSaveOptions()

            ' Set the compliance type
            pdfSaveOptions.Compliance = PdfCompliance.PdfA1b

            ' Save the file
            workbook.Save(dataDir & "output.pdf", pdfSaveOptions)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
