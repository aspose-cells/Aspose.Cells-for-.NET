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

Namespace AddWorkbookScopedNamedRange
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook object
			Dim workbook As New Workbook()

			'get first worksheet of the workbook
			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Get worksheet's cells collection
			Dim cells As Cells = sheet.Cells

			'Create a range of Cells from Cell A1 to C10
			Dim workbookScope As Range = cells.CreateRange("A1", "C10")

			'Assign the nsame to workbook scope named range
			workbookScope.Name = "workbookScope"

			'save the workbook
			workbook.Save(dataDir & "WorkbookScope.xlsx")


		End Sub
	End Class
End Namespace