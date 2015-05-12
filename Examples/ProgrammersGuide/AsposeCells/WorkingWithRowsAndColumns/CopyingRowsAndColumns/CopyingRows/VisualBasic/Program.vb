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

Namespace CopyingRows
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook.
			'Open the existing excel file.
			Dim excelWorkbook1 As New Workbook(dataDir & "book1.xls")

			'Get the first worksheet in the workbook.
			Dim wsTemplate As Worksheet = excelWorkbook1.Worksheets(0)

			'Copy the second row with data, formattings, images and drawing objects
			'to the 16th row in the worksheet.
			wsTemplate.Cells.CopyRow(wsTemplate.Cells, 1, 15)

			'Save the excel file.
			excelWorkbook1.Save(dataDir & "output.xls")

		End Sub
	End Class
End Namespace