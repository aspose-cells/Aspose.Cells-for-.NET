
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class SaveExcelIntoPdfWithOptimizedSize
        Public Shared Sub Run()
            ' ExStart:SaveExcelIntoPdfWithOptimizedSize
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load excel file into workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            ' Save into Pdf with Minimum size
            Dim opts As New PdfSaveOptions()
            opts.OptimizationType = Aspose.Cells.Rendering.PdfOptimizationType.MinimumSize

            workbook.Save(dataDir & Convert.ToString("OptimizedOutput_out_.pdf"), opts)
            ' ExEnd:SaveExcelIntoPdfWithOptimizedSize
        End Sub
    End Class
End Namespace
