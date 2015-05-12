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

Namespace UnprotectSimpleSheet
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Accessing the first worksheet in the Excel file
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Unprotecting the worksheet without a password
			worksheet.Unprotect()

			'Saving the Workbook
			workbook.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)


		End Sub
	End Class
End Namespace