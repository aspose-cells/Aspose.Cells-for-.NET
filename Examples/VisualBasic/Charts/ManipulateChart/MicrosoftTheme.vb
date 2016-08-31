Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Charts.ManipulateChart
    Public Class MicrosoftTheme
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate the workbook to open the file that contains a chart
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")

            ' Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Get the first chart in the sheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Specify the FilFormat' S type to Solid Fill of the first series
            chart.NSeries(0).Area.FillFormat.FillType = Aspose.Cells.Drawing.FillType.Solid

            ' Get the CellsColor of SolidFill
            Dim cc As CellsColor = chart.NSeries(0).Area.FillFormat.SolidFill.CellsColor

            ' Create a theme in Accent style
            cc.ThemeColor = New ThemeColor(ThemeColorType.Accent6, 0.6)

            ' Apply the them to the series
            chart.NSeries(0).Area.FillFormat.SolidFill.CellsColor = cc

            ' Save the Excel file
            workbook.Save(dataDir & "output.xlsx")

            ' ExEnd:1

        End Sub
    End Class
End Namespace
