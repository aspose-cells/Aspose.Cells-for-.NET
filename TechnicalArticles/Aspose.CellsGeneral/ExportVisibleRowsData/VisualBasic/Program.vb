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
Imports System.Data

Namespace ExportVisibleRowsDataExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			Dim filePath As String = dataDir & "aspose-sample.xlsx"

			'Load the source workbook
			Dim workbook As New Workbook(filePath)

			'Access the first worksheet
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Specify export table options
			Dim exportOptions As New ExportTableOptions()
			exportOptions.PlotVisibleRows = True
			exportOptions.ExportColumnName = True

			'Export the data from worksheet with export options
			Dim dataTable As DataTable = worksheet.Cells.ExportDataTable(0, 0, 10, 4, exportOptions)


		End Sub
	End Class
End Namespace