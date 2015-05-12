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

Namespace ErrorCheckingOptionsExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a workbook and opening a template spreadsheet
			Dim workbook As New Workbook(dataDir & "Book1.xlsx")

			'Get the first worksheet
			Dim sheet As Worksheet = workbook.Worksheets(0)
			'Instantiate the error checking options
			Dim opts As ErrorCheckOptionCollection = sheet.ErrorCheckOptions

			Dim index As Integer = opts.Add()
			Dim opt As ErrorCheckOption = opts(index)
			'Disable the numbers stored as text option
			opt.SetErrorCheck(ErrorCheckType.TextNumber, False)
			'Set the range
			opt.AddRange(CellArea.CreateCellArea(0, 0, 1000, 50))

			'Save the Excel file
			workbook.Save(dataDir & "out_test.xlsx")

		End Sub
	End Class
End Namespace