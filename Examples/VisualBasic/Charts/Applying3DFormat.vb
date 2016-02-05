Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing
Imports Aspose.Cells.Charts

Namespace Aspose.Cells.Examples.Charts
    Public Class Applying3DFormat
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook
            Dim book As New Workbook()

            'Add a Data Worksheet
            Dim dataSheet As Worksheet = book.Worksheets.Add("DataSheet")

            'Add Chart Worksheet
            Dim sheet As Worksheet = book.Worksheets.Add("MyChart")

            'Put some values into the cells in the data worksheet
            dataSheet.Cells("B1").PutValue(1)
            dataSheet.Cells("B2").PutValue(2)
            dataSheet.Cells("B3").PutValue(3)
            dataSheet.Cells("A1").PutValue("A")
            dataSheet.Cells("A2").PutValue("B")
            dataSheet.Cells("A3").PutValue("C")


            'Define the Chart Collection
            Dim charts As ChartCollection = sheet.Charts
            'Add a Column chart to the Chart Worksheet
            Dim chartSheetIdx As Integer = charts.Add(ChartType.Column, 5, 0, 25, 15)

            'Get the newly added Chart
            Dim chart As Global.Aspose.Cells.Charts.Chart = book.Worksheets(2).Charts(0)

            'Set the background/foreground color for PlotArea/ChartArea
            chart.PlotArea.Area.BackgroundColor = Color.White
            chart.ChartArea.Area.BackgroundColor = Color.White
            chart.PlotArea.Area.ForegroundColor = Color.White
            chart.ChartArea.Area.ForegroundColor = Color.White

            'Hide the Legend
            chart.ShowLegend = False

            'Add Data Series for the Chart
            chart.NSeries.Add("DataSheet!B1:B3", True)
            'Specify the Category Data
            chart.NSeries.CategoryData = "DataSheet!A1:A3"

            'Get the Data Series
            Dim ser As Global.Aspose.Cells.Charts.Series = chart.NSeries(0)

            'Apply the 3-D formatting
            Dim spPr As ShapePropertyCollection = ser.ShapeProperties
            Dim fmt3d As Format3D = spPr.Format3D

            'Specify Bevel with its height/width
            Dim bevel As Bevel = fmt3d.TopBevel
            bevel.Type = BevelPresetType.Circle
            bevel.Height = 2
            bevel.Width = 5

            'Specify Surface material type
            fmt3d.SurfaceMaterialType = PresetMaterialType.WarmMatte

            'Specify surface lighting type
            fmt3d.SurfaceLightingType = LightRigType.ThreePoint

            'Specify lighting angle
            fmt3d.LightingAngle = 20

            'Specify Series background/foreground and line color
            ser.Area.BackgroundColor = Color.Maroon
            ser.Area.ForegroundColor = Color.Maroon
            ser.Border.Color = Color.Maroon

            'Save the Excel file
            book.Save(dataDir & "3d_format.xlsx")

        End Sub
    End Class
End Namespace