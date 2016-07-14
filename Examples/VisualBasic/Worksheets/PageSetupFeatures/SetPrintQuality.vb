Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetPrintQuality
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Setting the print quality of the worksheet to 180 dpi
            worksheet.PageSetup.PrintQuality = 180

            ' Save the Workbook.
            workbook.Save(dataDir & Convert.ToString("SetPrintQuality_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace