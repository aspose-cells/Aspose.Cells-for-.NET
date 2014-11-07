'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace SetPictureBackGroundFillChartExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook.
			Dim workbook As New Workbook()

			'Get the first worksheet.
			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Set the name of worksheet
			sheet.Name = "Data"

			'Get the cells collection in the sheet.
			Dim cells As Cells = workbook.Worksheets(0).Cells

			'Put some values into a cells of the Data sheet.
			cells("A1").PutValue("Region")
			cells("A2").PutValue("France")
			cells("A3").PutValue("Germany")
			cells("A4").PutValue("England")
			cells("A5").PutValue("Sweden")
			cells("A6").PutValue("Italy")
			cells("A7").PutValue("Spain")
			cells("A8").PutValue("Portugal")
			cells("B1").PutValue("Sale")
			cells("B2").PutValue(70000)
			cells("B3").PutValue(55000)
			cells("B4").PutValue(30000)
			cells("B5").PutValue(40000)
			cells("B6").PutValue(35000)
			cells("B7").PutValue(32000)
			cells("B8").PutValue(10000)

			'Add a chart sheet.
			Dim sheetIndex As Integer = workbook.Worksheets.Add(SheetType.Chart)
			sheet = workbook.Worksheets(sheetIndex)

			'Set the name of worksheet
			sheet.Name = "Chart"

			'Create chart
			Dim chartIndex As Integer = 0
			chartIndex = sheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 1, 1, 25, 10)
			Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(chartIndex)

			'Set some properties of chart plot area.
			'to set a picture as fill format and make the border invisible.
			Dim fs As FileStream = File.OpenRead(dataDir & "aspose-logo.jpg")
			Dim data(fs.Length - 1) As Byte
			fs.Read(data, 0, data.Length)
			chart.PlotArea.Area.FillFormat.ImageData = data
			chart.PlotArea.Border.IsVisible = False

			'Set properties of chart title
			chart.Title.Text = "Sales By Region"
			chart.Title.Font.Color = Color.Blue
			chart.Title.Font.IsBold = True
			chart.Title.Font.Size = 12

			'Set properties of nseries
			chart.NSeries.Add("Data!B2:B8", True)
			chart.NSeries.CategoryData = "Data!A2:A8"
			chart.NSeries.IsColorVaried = True

			'Set the Legend.
			Dim legend As Aspose.Cells.Charts.Legend = chart.Legend
			legend.Position = Aspose.Cells.Charts.LegendPositionType.Top

			'Save the excel file
			workbook.Save(dataDir & "column_chart.xls")
		End Sub
	End Class
End Namespace