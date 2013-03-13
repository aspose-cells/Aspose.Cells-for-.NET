'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells

Namespace DisplayHideTabs
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			'Opening the Excel file
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Hiding the tabs of the Excel file
			workbook.Settings.ShowTabs = False

			'Saving the modified Excel file
			workbook.Save(dataDir & "output.xls")
		End Sub
	End Class
End Namespace