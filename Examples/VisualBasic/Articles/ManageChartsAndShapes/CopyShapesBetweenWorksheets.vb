Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManageChartsAndShapes
    Public Class CopyShapesBetweenWorksheets
        Public Shared Sub Run()
            ' ExStart:CopyPictureBetweenWorksheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the template file
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Get the Picture from the "Picture" worksheet.
            Dim picturesource As Aspose.Cells.Drawing.Picture = workbook.Worksheets("Picture").Pictures(0)

            ' Save Picture to Memory Stream
            Dim ms As New MemoryStream(picturesource.Data)

            ' Copy the picture to the Result Worksheet
            workbook.Worksheets("Result").Pictures.Add(picturesource.UpperLeftRow, picturesource.UpperLeftColumn, ms, picturesource.WidthScale, picturesource.HeightScale)

            ' Save the Worksheet
            workbook.Save(dataDir & Convert.ToString("PictureCopied_out_.xlsx"))
            ' ExEnd:CopyPictureBetweenWorksheets

            ' ExStart:CopyChartBetweenWorksheets
            ' Get the Chart from the "Chart" worksheet.
            Dim chartsource As Aspose.Cells.Charts.Chart = workbook.Worksheets("Chart").Charts(0)

            Dim cshape As Aspose.Cells.Drawing.ChartShape = chartsource.ChartObject

            ' Copy the Chart to the Result Worksheet
            workbook.Worksheets("Result").Shapes.AddCopy(cshape, 20, 0, 2, 0)

            ' Save the Worksheet
            workbook.Save(dataDir & Convert.ToString("ChartCopied_out_.xlsx"))
            ' ExEnd:CopyChartBetweenWorksheets

            ' ExStart:CopyControlsAndOtherDrawingObjects
            ' Open the template file
            workbook = New Workbook(dataDir & Convert.ToString("sample2.xlsx"))

            ' Get the Shapes from the "Control" worksheet.
            Dim shape As Aspose.Cells.Drawing.ShapeCollection = workbook.Worksheets("Control").Shapes

            ' Copy the Textbox to the Result Worksheet
            workbook.Worksheets("Result").Shapes.AddCopy(shape(0), 5, 0, 2, 0)

            ' Copy the Oval Shape to the Result Worksheet
            workbook.Worksheets("Result").Shapes.AddCopy(shape(1), 10, 0, 2, 0)

            ' Save the Worksheet
            workbook.Save(dataDir & Convert.ToString("ControlsCopied_out_.xlsx"))
            ' ExEnd:CopyControlsAndOtherDrawingObjects
        End Sub
    End Class
End Namespace