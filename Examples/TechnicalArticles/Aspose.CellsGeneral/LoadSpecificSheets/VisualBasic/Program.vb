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

Namespace LoadSpecificSheetsExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Define a new Workbook.
			Dim workbook As Workbook

			'Set the load data option with selected sheet(s).
			Dim dataOption As New LoadDataOption()
			dataOption.SheetNames = New String() { "Sheet2" }

			'Load the workbook with the spcified worksheet only.
			Dim loadOptions As New LoadOptions(LoadFormat.Xlsx)
			loadOptions.LoadDataOptions = dataOption
			loadOptions.LoadDataAndFormatting = True

			'Creat the workbook.
			workbook = New Workbook(dataDir & "TestData.xlsx", loadOptions)

			'Perform your desired task.

			'Save the workbook.
			workbook.Save(dataDir & "outputFile.xlsx")


		End Sub
	End Class
End Namespace