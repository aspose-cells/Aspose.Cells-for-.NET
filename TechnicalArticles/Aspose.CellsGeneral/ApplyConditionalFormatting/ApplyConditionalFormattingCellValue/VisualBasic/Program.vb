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

Namespace ApplyConditionalFormattingCellValue
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiating a Workbook object
			Dim workbook As New Workbook()

			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Adds an empty conditional formatting
			Dim index As Integer = sheet.ConditionalFormattings.Add()

			Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)

			'Sets the conditional format range.
			Dim ca As New CellArea()

			ca.StartRow = 0
			ca.EndRow = 0
			ca.StartColumn = 0
			ca.EndColumn = 0

			fcs.AddArea(ca)

			'Adds condition.
			Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")

			'Sets the background color.
			Dim fc As FormatCondition = fcs(conditionIndex)

			fc.Style.BackgroundColor = Color.Red

			'Saving the Excel file
			workbook.Save(dataDir & "output.xls", SaveFormat.Auto)


		End Sub
	End Class
End Namespace