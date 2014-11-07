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

Namespace SettingFormulaCalculationModeWorkbookExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Create a workbook
			Dim workbook As New Workbook()

			'Set the Formula Calculation Mode to Manual
			workbook.Settings.CalcMode = CalcModeType.Manual

			'Save the workbook
			workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)

		End Sub
	End Class
End Namespace