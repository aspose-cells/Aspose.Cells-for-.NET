Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Charts
    Public Class HowToCreateChart
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Excel object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            'Adding a sample value to "A1" cell
            worksheet.Cells("A1").PutValue(50)

            'Adding a sample value to "A2" cell
            worksheet.Cells("A2").PutValue(100)

            'Adding a sample value to "A3" cell
            worksheet.Cells("A3").PutValue(150)

            'Adding a sample value to "B1" cell
            worksheet.Cells("B1").PutValue(4)

            'Adding a sample value to "B2" cell
            worksheet.Cells("B2").PutValue(20)

            'Adding a sample value to "B3" cell
            worksheet.Cells("B3").PutValue(50)

            'Adding a chart to the worksheet
            Dim chartIndex As Integer = worksheet.Charts.Add(Global.Aspose.Cells.Charts.ChartType.Pyramid, 5, 0, 15, 5)

            'Accessing the instance of the newly added chart
            Dim chart As Global.Aspose.Cells.Charts.Chart = worksheet.Charts(chartIndex)

            'Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
            chart.NSeries.Add("A1:B3", True)

            'Saving the Excel file
            workbook.Save(dataDir & "book1.out.xls")

        End Sub
    End Class
End Namespace