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

Namespace SaveEachWorksheetToDifferentPDFExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")


			'Get the Excel file path
			Dim filePath As String = dataDir & "input.xlsx"

			'Instantiage a new workbook and open the Excel
			'File from its location
			Dim workbook As New Workbook(filePath)

			'Get the count of the worksheets in the workbook
			Dim sheetCount As Integer = workbook.Worksheets.Count

			'Make all sheets invisible except first worksheet
			For i As Integer = 1 To workbook.Worksheets.Count - 1
			workbook.Worksheets(i).IsVisible = False
			Next i

			'Take Pdfs of each sheet
			For j As Integer = 0 To workbook.Worksheets.Count - 1
			 Dim ws As Worksheet = workbook.Worksheets(j)
			workbook.Save(dataDir & "worksheet-" & ws.Name & ".pdf")

				If j < workbook.Worksheets.Count - 1 Then
				 workbook.Worksheets(j + 1).IsVisible = True
				 workbook.Worksheets(j).IsVisible = False
				End If
			Next j




		End Sub
	End Class
End Namespace