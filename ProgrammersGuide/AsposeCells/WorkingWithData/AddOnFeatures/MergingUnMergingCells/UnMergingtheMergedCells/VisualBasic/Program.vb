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

Namespace UnMergingtheMergedCells
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a Workbook.
			'Open the excel file.
			Dim wbk As Workbook = New Aspose.Cells.Workbook(dataDir & "mergingcells.xls")

			'Create a Worksheet and get the first sheet.
			Dim worksheet As Worksheet = wbk.Worksheets(0)

			'Create a Cells object ot fetch all the cells.
			Dim cells As Cells = worksheet.Cells

			'Unmerge the cells.
			cells.UnMerge(5, 2, 2, 3)

			'Save the file.
			wbk.Save(dataDir & "unmergingcells.xls")


		End Sub
	End Class
End Namespace