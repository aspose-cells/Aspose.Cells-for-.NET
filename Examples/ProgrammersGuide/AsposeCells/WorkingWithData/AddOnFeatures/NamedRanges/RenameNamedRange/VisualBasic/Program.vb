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

Namespace RenameNamedRange
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Open an existing Excel file that has a (global) named range "TestRange" in it
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Get the first worksheet
			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Get the Cells of the sheet
			Dim cells As Cells = sheet.Cells

			'Get the named range "MyRange"
			Dim name As Name = workbook.Worksheets.Names("TestRange")

			'Rename it
			name.Text = "NewRange"

			'Save the Excel file
			workbook.Save(dataDir & "RenamingRange.xlsx")
		End Sub
	End Class
End Namespace