Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Articles.UsingImageOrPrintOptions
    Public Class UseWorkbookRenderForImageConversion
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim wb As New Aspose.Cells.Workbook(dataDir & Convert.ToString("Testbook1.xlsx"), New Aspose.Cells.LoadOptions(Aspose.Cells.LoadFormat.Xlsx))

            For Each ws As Worksheet In wb.Worksheets
                Dim sr As New SheetRender(ws, New ImageOrPrintOptions() With { _
                 .OnePagePerSheet = True, _
                 .ImageFormat = ImageFormat.Jpeg _
                })
                sr.ToImage(0, (dataDir & Convert.ToString("Img_")) + ws.Index + "_out.jpg")
            Next
            ' ExEnd:1
        End Sub
    End Class
End Namespace