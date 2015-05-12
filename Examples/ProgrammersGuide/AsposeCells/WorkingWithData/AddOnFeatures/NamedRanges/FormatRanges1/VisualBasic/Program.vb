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

Namespace FormatRanges1
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiate a new Workbook.
			Dim workbook As New Workbook()

			'Get the first worksheet in the book.
			Dim WS As Worksheet = workbook.Worksheets(0)

			'Create a range of cells.
			Dim range As Aspose.Cells.Range = WS.Cells.CreateRange(1, 1, 1, 18)

			'Name the range.
			range.Name = "MyRange"

			'Declare a style object.
			Dim stl As Style

			'Create/add the style object.
			stl = workbook.Styles(workbook.Styles.Add() Or workbook.Styles.Add())

			'Specify some Font settings.
			stl.Font.Name = "Arial"
			stl.Font.IsBold = True

			'Set the font text color
			stl.Font.Color = Color.Red

			'To Set the fill color of the range, you may use ForegroundColor with
			'solid Pattern setting.
			stl.ForegroundColor = Color.Yellow
			stl.Pattern = BackgroundType.Solid

			'Create a StyleFlag object.
			Dim flg As New StyleFlag()
			'Make the corresponding attributes ON.
			flg.Font = True
			flg.CellShading = True

			'Apply the style to the range.
			range.ApplyStyle(stl, flg)

			'Save the excel file.
			workbook.Save(dataDir & "rangestyles.xls")
		End Sub
	End Class
End Namespace