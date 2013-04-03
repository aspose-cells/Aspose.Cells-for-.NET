'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering

Namespace ConvertingWorksheetToSVG
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim filePath As String = dataDir & "Template.xlsx"

			'Create a workbook object from the template file
			Dim book As New Workbook(filePath)

			'Convert each worksheet into svg format in a single page.
			Dim imgOptions As New ImageOrPrintOptions()
			imgOptions.SaveFormat = SaveFormat.SVG
			imgOptions.OnePagePerSheet = True

			'Convert each worksheet into svg format
			For Each sheet As Worksheet In book.Worksheets
				Dim sr As New SheetRender(sheet, imgOptions)

				For i As Integer = 0 To sr.PageCount - 1
					'Output the worksheet into Svg image format
					sr.ToImage(i, filePath & sheet.Name & i & ".out.svg")
				Next i
			Next sheet
		End Sub
	End Class
End Namespace