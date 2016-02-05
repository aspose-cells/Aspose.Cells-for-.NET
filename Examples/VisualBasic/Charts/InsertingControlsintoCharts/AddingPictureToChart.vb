Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Charts.InsertingControlsintoCharts
    Public Class AddingPictureToChart
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new Workbook.
            'Open the existing file.
            Dim workbook As New Workbook(dataDir & "chart.xls")

            'Get an image file to the stream.
            Dim stream As New FileStream(dataDir & "logo.jpg", FileMode.Open, FileAccess.Read)

            'Get the designer chart in the second sheet.
            Dim sheet As Worksheet = workbook.Worksheets(1)
            Dim chart As Global.Aspose.Cells.Charts.Chart = sheet.Charts(0)

            'Add a new picture to the chart.
            Dim pic0 As Global.Aspose.Cells.Drawing.Picture = chart.Shapes.AddPictureInChart(50, 50, stream, 40, 40)

            'Get the lineformat type of the picture.
            Dim lineformat As Global.Aspose.Cells.Drawing.MsoLineFormat = pic0.LineFormat

            'Set the line color.
            lineformat.ForeColor = Color.Red

            'Set the dash style.
            lineformat.DashStyle = Global.Aspose.Cells.Drawing.MsoLineDashStyle.Solid

            'set the line weight.
            lineformat.Weight = 4

            'Set the line style.
            lineformat.Style = Global.Aspose.Cells.Drawing.MsoLineStyle.ThickThin

            'Save the excel file.
            workbook.Save(dataDir & "chart.out.xls")

        End Sub
    End Class
End Namespace