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

Namespace CreateManipulateRemoveScenarios
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Instantiate the Workbook
			'Load an Excel file
			Dim workbook As Workbook = New Workbook(dataDir & "aspose-sample.xlsx")
			'Access first worksheet
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Remove the existing first scenario from the sheet
			worksheet.Scenarios.RemoveAt(0)


			'Create a scenario
			Dim i As Integer = worksheet.Scenarios.Add("MyScenario")
			'Get the scenario
			Dim scenario As Scenario = worksheet.Scenarios(i)
			'Add comment to it
			scenario.Comment = "Test sceanrio is created."
			'Get the input cells for the scenario
			Dim sic As ScenarioInputCellCollection = scenario.InputCells
			'Add the scenario on B4 (as changing cell) with default value
			sic.Add(3, 1, "1100000")


			'Save the Excel file.
			workbook.Save(dataDir & "outBk_scenarios1.xlsx")

		End Sub
	End Class
End Namespace