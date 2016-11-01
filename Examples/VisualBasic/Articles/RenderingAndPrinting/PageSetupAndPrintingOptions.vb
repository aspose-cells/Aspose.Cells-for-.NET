Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.RenderingAndPrinting
    Public Class PageSetupAndPrintingOptions
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the template workbook
            Dim workbook As New Workbook(dataDir & Convert.ToString("CustomerReport.xlsx"))

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Setting the orientation to Portrait
            worksheet.PageSetup.Orientation = PageOrientationType.Portrait

            ' Setting the scaling factor to 100
            ' worksheet.PageSetup.Zoom = 100;

            ' OR Alternately you can use Fit to Page Options as under

            ' Setting the number of pages to which the length of the worksheet will be spanned
            worksheet.PageSetup.FitToPagesTall = 1

            ' Setting the number of pages to which the width of the worksheet will be spanned
            worksheet.PageSetup.FitToPagesWide = 1

            ' Setting the paper size to A4
            worksheet.PageSetup.PaperSize = PaperSizeType.PaperA4

            ' Setting the print quality of the worksheet to 1200 dpi
            worksheet.PageSetup.PrintQuality = 1200

            'Setting the first page number of the worksheet pages
            worksheet.PageSetup.FirstPageNumber = 2

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("PageSetup_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace
