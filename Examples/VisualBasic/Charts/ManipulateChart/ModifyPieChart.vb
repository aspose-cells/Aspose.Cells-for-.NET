Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Aspose.Cells.Examples.Charts.ManipulateChart
    Public Class ModifyPieChart
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Open the existing file.
            Dim workbook As New Workbook(dataDir & "piechart.xls")

            'Get the designer chart in the second sheet.
            Dim sheet As Worksheet = workbook.Worksheets(1)
            Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(0)

            'Get the data labels in the data series of the third data point.
            Dim datalabels As Aspose.Cells.Charts.DataLabels = chart.NSeries(0).Points(2).DataLabels

            'Change the text of the label.
            datalabels.Text = "Unided Kingdom, 400K "

            'Save the excel file.
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace
