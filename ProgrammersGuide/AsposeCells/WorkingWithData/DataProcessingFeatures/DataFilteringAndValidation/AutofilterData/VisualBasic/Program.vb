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

Namespace AutofilterData
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			'Opening the Excel file through the file stream
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Accessing the first worksheet in the Excel file
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Creating AutoFilter by giving the cells range of the heading row
			worksheet.AutoFilter.Range = "A1:B1"

			'Saving the modified Excel file
			workbook.Save(dataDir & "output.xls")

		End Sub
	End Class
End Namespace