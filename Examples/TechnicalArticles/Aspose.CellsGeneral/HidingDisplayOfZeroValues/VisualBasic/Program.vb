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

Namespace HidingDisplayOfZeroValuesExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Create a new Workbook object
			Dim workbook As New Workbook(dataDir & "book1.xlsx")

			'Get First worksheet of the workbook
			Dim sheet As Worksheet = workbook.Worksheets(0)

			'Hide the zero values in the sheet
			sheet.DisplayZeros = False

			'Save the workbook
			workbook.Save(dataDir & "outputfile.xlsx")


		End Sub
	End Class
End Namespace