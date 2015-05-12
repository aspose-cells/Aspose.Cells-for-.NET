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

Namespace CopyingRows
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate a new workbook
			'Open an existing excel file
			Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

			'Get the first worksheet cells
			Dim cells As Cells = workbook.Worksheets(0).Cells
			'Apply formulas to the cells
			For i As Integer = 0 To 4
				cells(0, i).Formula = "=Input!" & cells(0, i).Name
			Next i
			'Copy the first row to next 10 rows
			cells.CopyRows(cells, 0, 1, 10)
			'Save the excel file
			workbook.Save(dataDir & "outaspose-sample.xlsx")

		End Sub
	End Class
End Namespace