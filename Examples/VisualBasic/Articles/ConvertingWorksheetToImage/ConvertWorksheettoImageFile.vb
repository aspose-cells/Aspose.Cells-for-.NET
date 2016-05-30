Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing

Namespace Articles.ConvertingWorksheetToImage
    Public Class ConvertWorksheettoImageFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook object
            ' Open a template excel file
            Dim book As New Workbook(dataDir & "Testbook.xlsx")
            ' Get the first worksheet.
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Define ImageOrPrintOptions
            Dim imgOptions As New ImageOrPrintOptions()
            ' Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            ' Render the sheet with respect to specified image/print options
            Dim sr As New SheetRender(sheet, imgOptions)
            ' Render the image for the sheet
            Dim bitmap As Bitmap = sr.ToImage(0)

            ' Save the image file
            bitmap.Save(dataDir & "output.jpg")
            ' ExEnd:1


        End Sub
    End Class
End Namespace