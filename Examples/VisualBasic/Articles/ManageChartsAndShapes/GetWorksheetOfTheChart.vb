Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts

Namespace Articles.ManageChartsAndShapes
    Public Class GetWorksheetOfTheChart
        Public Shared Sub Run()
            ' ExStart:GetWorksheetOfTheChart
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from sample Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet of the workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Print worksheet name
            Console.WriteLine("Sheet Name: " + worksheet.Name)

            ' Access the first chart inside this worksheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Access the chart's sheet and display its name again
            Console.WriteLine("Chart's Sheet Name: " + chart.Worksheet.Name)
            ' ExEnd:GetWorksheetOfTheChart
        End Sub
    End Class
End Namespace