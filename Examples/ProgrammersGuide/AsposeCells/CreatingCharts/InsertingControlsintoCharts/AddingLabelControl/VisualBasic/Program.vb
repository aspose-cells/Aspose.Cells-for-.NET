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
Imports System.Drawing

Namespace AddingLabelControl
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook.
			'Open the existing file.
			Dim workbook As New Workbook(dataDir & "chart.xls")

			'Get the designer chart in the second sheet.
			Dim sheet As Worksheet = workbook.Worksheets(1)
			Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(0)

			'Add a new label to the chart.
			Dim label As Aspose.Cells.Drawing.Label = chart.Shapes.AddLabelInChart(100, 100, 350, 900)

			'Set the caption of the label.
			label.Text = "A Label In Chart"

			'Set the Placement Type, the way the
			'label is attached to the cells.
			label.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating

			'Set the fill color of the label.
			label.FillFormat.ForeColor = Color.Azure

			'Save the excel file.
			workbook.Save(dataDir & "chart_out.xls")


		End Sub
	End Class
End Namespace