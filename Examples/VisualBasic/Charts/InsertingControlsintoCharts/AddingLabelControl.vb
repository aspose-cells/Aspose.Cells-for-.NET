Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System.Drawing

Namespace Charts.InsertingControlsintoCharts
    Public Class AddingLabelControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook.
            ' Open the existing file.
            Dim workbook As New Workbook(dataDir & "chart.xls")

            ' Get the designer chart in the second sheet.
            Dim sheet As Worksheet = workbook.Worksheets(1)
            Dim chart As Global.Aspose.Cells.Charts.Chart = sheet.Charts(0)

            ' Add a new label to the chart.
            Dim label As Global.Aspose.Cells.Drawing.Label = chart.Shapes.AddLabelInChart(100, 100, 350, 900)

            ' Set the caption of the label.
            label.Text = "A Label In Chart"

            ' Set the Placement Type, the way the
            ' Label is attached to the cells.
            label.Placement = Global.Aspose.Cells.Drawing.PlacementType.FreeFloating

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace