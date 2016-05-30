Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class ResamplingAddedImages
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Initialize a new Workbook
            ' Open an Excel file
            Dim workbook As New Workbook(dataDir & "input.xlsx")

            ' Instantiate the PdfSaveOptions
            Dim pdfSaveOptions As New PdfSaveOptions()
            ' Set Image Resample properties
            pdfSaveOptions.SetImageResample(300, 70)

            ' Save the PDF file
            workbook.Save(dataDir & "output.pdf", pdfSaveOptions)
            ' ExEnd:1

        End Sub
    End Class
End Namespace