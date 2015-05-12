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
Imports System.Drawing
Imports System.Collections

Namespace UnionOfRanges
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate a workbook object.
			'Open an existing excel file.
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Get the named ranges.
			Dim ranges() As Range = workbook.Worksheets.GetNamedRanges()

			'Create a style object.
			Dim style As Style = workbook.Styles(workbook.Styles.Add())

			'Set the shading color with solid pattern type.
			style.ForegroundColor = Color.Yellow
			style.Pattern = BackgroundType.Solid

			'Create a styleflag object.
			Dim flag As New StyleFlag()

			'Apply the cellshading.
			flag.CellShading = True

			'Creates an arraylist.
			Dim al As New ArrayList()

			'Get the arraylist collection apply the union operation.
			al = ranges(0).Union(ranges(1))

			'Define a range object.
			Dim rng As Range
			Dim frow, fcol, erow, ecol As Integer

			For i As Integer = 0 To al.Count - 1
				'Get a range.
				rng = CType(al(i), Range)
				frow = rng.FirstRow
				fcol = rng.FirstColumn
				erow = rng.RowCount
				ecol = rng.ColumnCount

				'Apply the style to the range.
				rng.ApplyStyle(style, flag)

			Next i

			'Save the excel file.
			workbook.Save(dataDir & "rngUnion.xls")
		End Sub
	End Class
End Namespace