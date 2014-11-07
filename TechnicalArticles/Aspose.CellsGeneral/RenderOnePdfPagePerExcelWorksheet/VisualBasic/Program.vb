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

Namespace RenderOnePdfPagePerExcelWorksheetExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Initialize a new Workbook
			'Open an Excel file
			Dim workbook As New Workbook(dataDir & "input.xlsx")

			'Implement one page per worksheet option
			Dim pdfSaveOptions As New PdfSaveOptions()
			pdfSaveOptions.OnePagePerSheet = True

			'Save the PDF file
			workbook.Save(dataDir & "OutputFile.pdf", pdfSaveOptions)

		End Sub
	End Class
End Namespace