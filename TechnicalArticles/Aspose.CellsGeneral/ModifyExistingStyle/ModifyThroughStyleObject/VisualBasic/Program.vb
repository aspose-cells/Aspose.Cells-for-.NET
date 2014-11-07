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

Namespace ModifyThroughStyleObjectExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Create a workbook.
			Dim workbook As New Workbook()

			'Create a new style object.
			Dim style As Style = workbook.Styles(workbook.Styles.Add())

			'Set the number format.
			style.Number = 14

			'Set the font color to red color.
			style.Font.Color = System.Drawing.Color.Red

			'Name the style.
			style.Name = "Date1"

			'Get the first worksheet cells.
			Dim cells As Cells = workbook.Worksheets(0).Cells

			'Specify the style (described above) to A1 cell.
			cells("A1").SetStyle(style)

			'Create a range (B1:D1).
			Dim range As Range = cells.CreateRange("B1", "D1")

			'Initialize styleflag object.
			Dim flag As New StyleFlag()

			'Set all formatting attributes on.
			flag.All = True

			'Apply the style (described above)to the range.
			range.ApplyStyle(style, flag)

			'Modify the style (described above) and change the font color from red to black.
			style.Font.Color = System.Drawing.Color.Black

			'Done! Since the named style (described above) has been set to a cell and range, 
			'the change would be Reflected(new modification is implemented) to cell(A1) and //range (B1:D1).
			style.Update()

			'Save the excel file. 
			workbook.Save(dataDir & "book_styles.xls")


		End Sub
	End Class
End Namespace