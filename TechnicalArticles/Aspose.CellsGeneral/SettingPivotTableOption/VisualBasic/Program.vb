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
Imports Aspose.Cells.Pivot

Namespace SettingPivotTableOptionExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim wb As New Workbook(dataDir & "input.xlsx")

			Dim pt As PivotTable = wb.Worksheets(0).PivotTables(0)

			'Indicating if or not display the empty cell value
			pt.DisplayNullString = True

			'Indicating the null string
			pt.NullString = "null"

			pt.CalculateData()

			pt.RefreshDataOnOpeningFile = False

			wb.Save(dataDir & "output.xlsx")

		End Sub
	End Class
End Namespace