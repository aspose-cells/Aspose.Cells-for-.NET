Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Rendering

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class CalculateScalingFactor
        Public Shared Sub Run()
            ' ExStart:CalculatePageSetupScalingFactor
            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Put some data in these cells
            worksheet.Cells("A4").PutValue("Test")
            worksheet.Cells("S4").PutValue("Test")

            ' Set paper size
            worksheet.PageSetup.PaperSize = PaperSizeType.PaperA4

            ' Set fit to pages wide as 1
            worksheet.PageSetup.FitToPagesWide = 1

            ' Calculate page scale via sheet render
            Dim sr As New SheetRender(worksheet, New ImageOrPrintOptions())

            ' Convert page scale double value to percentage
            Dim strPageScale As String = sr.PageScale.ToString("0%")

            ' Write the page scale value
            Console.WriteLine(strPageScale)
            ' ExEnd:CalculatePageSetupScalingFactor
        End Sub
    End Class
End Namespace