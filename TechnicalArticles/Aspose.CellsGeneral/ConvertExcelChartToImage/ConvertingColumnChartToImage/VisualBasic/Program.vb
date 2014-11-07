'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace ConvertingColumnChartToImage
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")


			'Create a new workbook.
			'Open the existing excel file which contains the column chart.
			Dim workbook As New Workbook(dataDir & "ColumnChart.xlsx")

			'Get the designer chart (first chart) in the first worksheet.
			'of the workbook.
			Dim chart As Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

			'Convert the chart to an image file.
			chart.ToImage(dataDir & "ColumnChart.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)


		End Sub
	End Class
End Namespace