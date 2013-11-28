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

Namespace AddingBordersToCells
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

			'Obtaining the reference of the first (default) worksheet by passing its sheet index
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Accessing the "A1" cell from the worksheet
			Dim cell As Aspose.Cells.Cell = worksheet.Cells("A1")

			'Adding some value to the "A1" cell
			cell.PutValue("Visit Aspose!")

			'Create a style object
			Dim style As Style = cell.GetStyle()

			'Setting the line style of the top border
			style.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thick

			'Setting the color of the top border
			style.Borders(BorderType.TopBorder).Color = Color.Black

			'Setting the line style of the bottom border
			style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thick

			'Setting the color of the bottom border
			style.Borders(BorderType.BottomBorder).Color = Color.Black

			'Setting the line style of the left border
			style.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thick

			'Setting the color of the left border
			style.Borders(BorderType.LeftBorder).Color = Color.Black

			'Setting the line style of the right border
			style.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thick

			'Setting the color of the right border
			style.Borders(BorderType.RightBorder).Color = Color.Black

			'Apply the border styles to the cell
			cell.SetStyle(style)

			'Saving the Excel file
			workbook.Save(dataDir & "book1.xls")

		End Sub
	End Class
End Namespace