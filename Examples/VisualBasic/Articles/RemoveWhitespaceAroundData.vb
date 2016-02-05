Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering

Namespace Aspose.Cells.Examples.Articles
    Public Class RemoveWhitespaceAroundData
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate a workbook
            'Open the template file
            Dim book As New Workbook(dataDir & "MyTestBook1.xlsx")

            'Get the first worksheet
            Dim sheet As Worksheet = book.Worksheets(0)

            'Specify your print area if you want
            'sheet.PageSetup.PrintArea = "A1:H8";

            'To remove the white border around the image.
            sheet.PageSetup.LeftMargin = 0
            sheet.PageSetup.RightMargin = 0
            sheet.PageSetup.BottomMargin = 0
            sheet.PageSetup.TopMargin = 0

            'Define ImageOrPrintOptions
            Dim imgOptions As New ImageOrPrintOptions()
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf
            'Set only one page would be rendered for the image
            imgOptions.OnePagePerSheet = True
            imgOptions.PrintingPage = PrintingPageType.IgnoreBlank

            'Create the SheetRender object based on the sheet with its
            'ImageOrPrintOptions attributes
            Dim sr As New SheetRender(sheet, imgOptions)
            'Convert the image
            sr.ToImage(0, dataDir & "img_MyTestBook1.out.emf")

        End Sub
    End Class
End Namespace