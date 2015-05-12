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

Namespace ConvertTableToRange
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Open an existing file that contains a table/list object in it
			Dim wb As New Workbook(dataDir & "book1.xlsx")

			'Convert the first table/list object (from the first worksheet) to normal range
			wb.Worksheets(0).ListObjects(0).ConvertToRange()

			'Save the file
			wb.Save(dataDir & "output.xlsx")

		End Sub
	End Class
End Namespace