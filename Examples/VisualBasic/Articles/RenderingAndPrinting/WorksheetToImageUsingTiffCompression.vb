
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Cells.Rendering

Namespace Articles.RenderingAndPrinting
    Public Class WorksheetToImageUsingTiffCompression
        Public Shared Sub Run()
            ' ExStart:WorksheetToImageUsingTiffCompression
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook object with template
            Dim book As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            ' Get the first worksheet
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Apply different Image and Print options
            Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()

            ' Set Horizontal Resolution
            options.HorizontalResolution = 300

            ' Set Vertical Resolution
            options.VerticalResolution = 300

            ' Set TiffCompression
            options.TiffCompression = Aspose.Cells.Rendering.TiffCompression.CompressionLZW

            ' Set Autofit options
            options.IsCellAutoFit = False

            ' Set Image Format
            options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff

            ' Set printing page type
            options.PrintingPage = PrintingPageType.[Default]

            ' Render the sheet with respect to specified image/print options
            Dim sr As New SheetRender(sheet, options)

            ' Render/save the image for the sheet
            sr.ToImage(0, dataDir & Convert.ToString("SheetImage_out.tiff"))
            ' ExEnd:WorksheetToImageUsingTiffCompression
        End Sub
    End Class
End Namespace
