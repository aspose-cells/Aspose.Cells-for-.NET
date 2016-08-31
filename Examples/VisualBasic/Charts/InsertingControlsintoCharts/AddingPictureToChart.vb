Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Charts.InsertingControlsintoCharts
    Public Class AddingPictureToChart
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook.
            ' Open the existing file.
            Dim workbook As New Workbook(dataDir & "chart.xls")

            ' Get an image file to the stream.
            Dim stream As New FileStream(dataDir & "logo.jpg", FileMode.Open, FileAccess.Read)

            ' Get the designer chart in the second sheet.
            Dim sheet As Worksheet = workbook.Worksheets(0)
            Dim chart As Global.Aspose.Cells.Charts.Chart = sheet.Charts(0)

            ' Add a new picture to the chart.
            Dim pic0 As Global.Aspose.Cells.Drawing.Picture = chart.Shapes.AddPictureInChart(50, 50, stream, 40, 40)

            ' Get the lineformat type of the picture.
            Dim lineformat As Global.Aspose.Cells.Drawing.LineFormat = pic0.Line

            ' Set the dash style.
            lineformat.DashStyle = Global.Aspose.Cells.Drawing.MsoLineDashStyle.Solid

            ' Set the line weight.
            lineformat.Weight = 4

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace