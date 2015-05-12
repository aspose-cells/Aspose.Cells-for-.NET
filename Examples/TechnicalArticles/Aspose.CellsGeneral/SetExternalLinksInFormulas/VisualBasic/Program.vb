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

Namespace SetExternalLinksInFormulasExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")



			'Instantiate a new Workbook.
			Dim workbook As New Workbook()

			'Get first Worksheet
			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Get Cells collection
			Dim cells As Cells = sheet.Cells

			'Set formula with external links
			cells("A1").Formula = "=SUM('[" & dataDir & "book1.xlsx]Sheet1'!A2, '[" & dataDir & "book1.xlsx]Sheet1'!A4)"

			'Set formula with external links
			cells("A2").Formula = "='[" & dataDir & "book1.xlsx]Sheet1'!A8"

			'Save the workbook
			workbook.Save(dataDir & "output.xlsx")




		End Sub
	End Class
End Namespace