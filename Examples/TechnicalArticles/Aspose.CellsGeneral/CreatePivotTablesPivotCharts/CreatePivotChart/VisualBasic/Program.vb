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

Namespace CreatePivotChart
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating an Workbook object
			'Opening the excel file
			Dim workbook As New Workbook(dataDir & "pivotTable_test.xlsx")
			'Adding a new sheet
			Dim sheet3 As Worksheet = workbook.Worksheets(workbook.Worksheets.Add(SheetType.Chart))
			'Naming the sheet
			sheet3.Name = "PivotChart"
			'Adding a column chart
			Dim index As Integer = sheet3.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 5, 28, 16)
			'Setting the pivot chart data source
			sheet3.Charts(index).PivotSource = "PivotTable!PivotTable1"
			sheet3.Charts(index).HidePivotFieldButtons = False
			'Saving the Excel file
			workbook.Save(dataDir & "pivotChart_test.xlsx")


		End Sub
	End Class
End Namespace