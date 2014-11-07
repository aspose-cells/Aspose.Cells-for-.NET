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

Namespace ImplementingNonSequencedRangesExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			Dim workbook As New Workbook()

			'Adding a Name for non sequenced range
			Dim index As Integer = workbook.Worksheets.Names.Add("NonSequencedRange")

			Dim name As Name = workbook.Worksheets.Names(index)

			'Creating a non sequence range of cells
			name.RefersTo = "=Sheet1!$A$1:$B$3,Sheet1!$E$5:$D$6"

			'Save the workbook
			workbook.Save(dataDir & "Output.xlsx")

		End Sub
	End Class
End Namespace