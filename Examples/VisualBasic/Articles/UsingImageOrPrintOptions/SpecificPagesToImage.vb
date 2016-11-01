Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Rendering

Namespace Articles.UsingImageOrPrintOptions
    Public Class SpecificPagesToImage
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open a template excel file
            Dim book As New Workbook(dataDir & Convert.ToString("Testbook1.xlsx"))

            ' Get the first worksheet.
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Get the second worksheet.
            ' Worksheet sheet = book.Worksheets[1];

            ' Define ImageOrPrintOptions
            Dim imgOptions As New ImageOrPrintOptions()

            ' Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg

            ' If you want entire sheet as a singe image
            imgOptions.OnePagePerSheet = True

            ' Render the sheet with respect to specified image/print options
            Dim sr As New SheetRender(sheet, imgOptions)

            ' Render the image for the sheet
            Dim bitmap As System.Drawing.Bitmap = sr.ToImage(0)

            ' Save the image file
            bitmap.Save(dataDir & Convert.ToString("SheetImage_out_.jpg"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace