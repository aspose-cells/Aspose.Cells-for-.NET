Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.CopyShapesBetweenWorksheets
    Public Class CopyChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create a workbook object
            ' Open the template file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            ' Get the Chart from the "Chart" worksheet.
            Dim source As Global.Aspose.Cells.Charts.Chart = workbook.Worksheets("Sheet2").Charts(0)

            Dim cshape As Global.Aspose.Cells.Drawing.ChartShape = source.ChartObject

            ' Copy the Chart to the Result Worksheet
            workbook.Worksheets("Sheet3").Shapes.AddCopy(cshape, 20, 0, 2, 0)

            ' Save the Worksheet
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace