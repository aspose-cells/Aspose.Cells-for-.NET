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
Imports System

Namespace FindDataOrFormulas
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate the workbook object
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Get Cells collection
			Dim cells As Cells = workbook.Worksheets(0).Cells

			'Instantiate FindOptions Object
			Dim findOptions As New FindOptions()

			'Create a Cells Area
			Dim ca As New CellArea()
			ca.StartRow = 8
			ca.StartColumn = 2
			ca.EndRow = 17
			ca.EndColumn = 13

			'Set cells area for find options
			findOptions.SetRange(ca)

			'Set searching properties
			findOptions.SearchNext = True
			findOptions.SeachOrderByRows = True

			'Set the lookintype, you may specify, values, formulas, comments etc.
			findOptions.LookInType = LookInType.Values

			'Set the lookattype, you may specify Match entire content, endswith, starwith etc.
			findOptions.LookAtType = LookAtType.EntireContent

			'Find the cell with value
			Dim cell As Cell = cells.Find(205, Nothing, findOptions)

			If cell IsNot Nothing Then
				Console.WriteLine("Name of the cell containing the value: " & cell.Name)
			Else
				Console.WriteLine("Record not found ")
			End If

		End Sub
	End Class
End Namespace