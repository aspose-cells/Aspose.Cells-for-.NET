
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class RenderWorksheetToGraphicContext
        Public Shared Sub Run()
            ' ExStart:RenderWorksheetToGraphicContext
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Create empty Bitmap
            Dim bmp As New System.Drawing.Bitmap(1100, 600)

            ' Create Graphics Context
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp)
            g.Clear(System.Drawing.Color.Blue)

            ' Set one page per sheet to true in image or print options
            Dim opts As New Aspose.Cells.Rendering.ImageOrPrintOptions()
            opts.OnePagePerSheet = True

            ' Render worksheet to graphics context
            Dim sr As New Aspose.Cells.Rendering.SheetRender(worksheet, opts)
            sr.ToImage(0, g, 0, 0)

            ' Save the graphics context image in Png format
            bmp.Save(dataDir & Convert.ToString("OutputImage_out.png"), System.Drawing.Imaging.ImageFormat.Png)
            ' ExEnd:RenderWorksheetToGraphicContext
        End Sub
    End Class
End Namespace
