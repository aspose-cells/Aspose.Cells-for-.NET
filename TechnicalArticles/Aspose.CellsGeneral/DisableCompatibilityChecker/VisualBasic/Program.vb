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

Namespace DisableCompatibilityCheckerExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Open a template file
			Dim workbook As New Workbook(dataDir & "sample.xlsx")

			'Disable the compatibility checker
			workbook.Settings.CheckComptiliblity = False

			'Saving the Excel file
			workbook.Save(dataDir & "Output_BK_CompCheck.xlsx")


		End Sub
	End Class
End Namespace