
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class WorksheetToImageDesiredSize
        Public Shared Sub Run()
            ' ExStart:WorksheetToImageDesiredSize
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Set image or print options we want one page per sheet. The image format is in png and desired dimensions are 400x400
            Dim opts As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            opts.OnePagePerSheet = True
            opts.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            opts.SetDesiredSize(400, 400)

            ' Render sheet into image
            Dim sr As New Aspose.Cells.Rendering.SheetRender(worksheet, opts)
            sr.ToImage(0, dataDir & Convert.ToString("ImageWithDesiredSize_out.png"))
            ' ExEnd:WorksheetToImageDesiredSize
        End Sub
    End Class
End Namespace
