'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Imports Aspose.Cells

Namespace AccessSpecificNamedRange
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			'Opening the Excel file through the file stream
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Getting the specified named range
			Dim range As Range = workbook.Worksheets.GetRangeByName("TestRange")

			If range IsNot Nothing Then
				Console.WriteLine("Named Range : " & range.RefersTo)
			End If

		End Sub
	End Class
End Namespace