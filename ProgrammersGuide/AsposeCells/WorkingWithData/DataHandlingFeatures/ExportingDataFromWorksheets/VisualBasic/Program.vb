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
Imports System.Data

Namespace ExportingDataFromWorksheets
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Creating a file stream containing the Excel file to be opened
			Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

			'Instantiating a Workbook object
			'Opening the Excel file through the file stream
			Dim workbook As New Workbook(fstream)

			'Accessing the first worksheet in the Excel file
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
			Dim dataTable As DataTable = worksheet.Cells.ExportDataTable(0, 0, 7, 2, True)

			System.Console.WriteLine("Number of Rows in Data Table: " & dataTable.Rows.Count)

			'Closing the file stream to free all resources
			fstream.Close()

		End Sub
	End Class
End Namespace