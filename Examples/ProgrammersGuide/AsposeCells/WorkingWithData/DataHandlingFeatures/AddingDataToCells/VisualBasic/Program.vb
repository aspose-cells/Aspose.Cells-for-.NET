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

Namespace AddingDataToCells
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

			'Obtaining the reference of the first worksheet
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Adding a string value to the cell
			worksheet.Cells("A1").PutValue("Hello World")

			'Adding a double value to the cell
			worksheet.Cells("A2").PutValue(20.5)

			'Adding an integer  value to the cell
			worksheet.Cells("A3").PutValue(15)

			'Adding a boolean value to the cell
			worksheet.Cells("A4").PutValue(True)

			'Adding a date/time value to the cell
			worksheet.Cells("A5").PutValue(DateTime.Now)

			'Setting the display format of the date
			Dim style As Style = worksheet.Cells("A5").GetStyle()
			style.Number = 15
			worksheet.Cells("A5").SetStyle(style)

			'Saving the Excel file
			workbook.Save(dataDir & "output.xls")

		End Sub
	End Class
End Namespace