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
Imports System

Namespace UsingBuiltInNumberFormats
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

			'Obtaining the reference of first worksheet
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Adding the current system date to "A1" cell
			worksheet.Cells("A1").PutValue(DateTime.Now)

			'Getting the Style of the A1 Cell
			Dim style As Style = worksheet.Cells("A1").GetStyle()

			'Setting the display format to number 15 to show date as "d-mmm-yy"
			style.Number = 15

			'Applying the style to the A1 cell
			worksheet.Cells("A1").SetStyle(style)

			'Adding a numeric value to "A2" cell
			worksheet.Cells("A2").PutValue(20)

			'Getting the Style of the A2 Cell
			style = worksheet.Cells("A2").GetStyle()

			'Setting the display format to number 9 to show value as percentage
			style.Number = 9

			'Applying the style to the A2 cell
			worksheet.Cells("A2").SetStyle(style)

			'Adding a numeric value to "A3" cell
			worksheet.Cells("A3").PutValue(2546)

			'Getting the Style of the A3 Cell
			style = worksheet.Cells("A3").GetStyle()

			'Setting the display format to number 6 to show value as currency
			style.Number = 6

			'Applying the style to the A3 cell
			worksheet.Cells("A3").SetStyle(style)

			'Saving the Excel file
			workbook.Save(dataDir & "book1.xls", SaveFormat.Excel97To2003)

		End Sub
	End Class
End Namespace