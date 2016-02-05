Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class GenerateThumbnailOfWorksheet
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate and open an Excel file
            Dim book As Workbook = New Workbook(dataDir & "book1.xlsx")

            'Define ImageOrPrintOptions
            Dim imgOptions As ImageOrPrintOptions = New ImageOrPrintOptions()
            'Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            'Set the vertical and horizontal resolution
            imgOptions.VerticalResolution = 200
            imgOptions.HorizontalResolution = 200
            'One page per sheet is enabled
            imgOptions.OnePagePerSheet = True

            'Get the first worksheet
            Dim sheet As Worksheet = book.Worksheets(0)
            'Render the sheet with respect to specified image/print options
            Dim sr As SheetRender = New SheetRender(sheet, imgOptions)
            'Render the image for the sheet
            Dim bmp As Bitmap = sr.ToImage(0)
            'Create a bitmap
            Dim thumb As Bitmap = New Bitmap(100, 100)
            'Get the graphics for the bitmap
            Dim gr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(thumb)

            'Draw the image
            gr.DrawImage(bmp, 0, 0, 100, 100)

            'Save the thumbnail
            thumb.Save(dataDir & "mythumbnail.out.bmp")


        End Sub
    End Class
End Namespace