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

Namespace AdvancedProtectionSettingsUsingAspose.Cells
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Creating a file stream containing the Excel file to be opened
			Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

			'Instantiating a Workbook object
			'Opening the Excel file through the file stream
			Dim excel As New Workbook(fstream)

			'Accessing the first worksheet in the Excel file
			Dim worksheet As Worksheet = excel.Worksheets(0)

			'Restricting users to delete columns of the worksheet
			worksheet.Protection.AllowDeletingColumn = False

			'Restricting users to delete row of the worksheet
			worksheet.Protection.AllowDeletingRow = False

			'Restricting users to edit contents of the worksheet
			worksheet.Protection.AllowEditingContent = False

			'Restricting users to edit objects of the worksheet
			worksheet.Protection.AllowEditingObject = False

			'Restricting users to edit scenarios of the worksheet
			worksheet.Protection.AllowEditingScenario = False

			'Restricting users to filter
			worksheet.Protection.AllowFiltering = False

			'Allowing users to format cells of the worksheet
			worksheet.Protection.AllowFormattingCell = True

			'Allowing users to format rows of the worksheet
			worksheet.Protection.AllowFormattingRow = True

			'Allowing users to insert columns in the worksheet
			worksheet.Protection.AllowFormattingColumn = True

			'Allowing users to insert hyperlinks in the worksheet
			worksheet.Protection.AllowInsertingHyperlink = True

			'Allowing users to insert rows in the worksheet
			worksheet.Protection.AllowInsertingRow = True

			'Allowing users to select locked cells of the worksheet
			worksheet.Protection.AllowSelectingLockedCell = True

			'Allowing users to select unlocked cells of the worksheet
			worksheet.Protection.AllowSelectingUnlockedCell = True

			'Allowing users to sort
			worksheet.Protection.AllowSorting = True

			'Allowing users to use pivot tables in the worksheet
			worksheet.Protection.AllowUsingPivotTable = True

			'Saving the modified Excel file
			excel.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)

			'Closing the file stream to free all resources
			fstream.Close()


		End Sub
	End Class
End Namespace