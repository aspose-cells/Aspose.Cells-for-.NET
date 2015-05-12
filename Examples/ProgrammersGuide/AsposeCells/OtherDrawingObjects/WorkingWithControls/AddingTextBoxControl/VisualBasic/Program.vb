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
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace AddingTextBoxControl
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
			Dim worksheet As Worksheet = workbook.Worksheets(0)

			'Add a new textbox to the collection.
			Dim textboxIndex As Integer = worksheet.TextBoxes.Add(2, 1, 160, 200)

			'Get the textbox object.
			Dim textbox0 As Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(textboxIndex)

			'Fill the text.
			textbox0.Text = "ASPOSE______The .NET & JAVA Component Publisher!"

			'Get the textbox text frame.
			Dim textframe0 As MsoTextFrame = textbox0.TextFrame

			'Set the textbox to adjust it according to its contents.
			textframe0.AutoSize = True

			'Set the placement.
			textbox0.Placement = PlacementType.FreeFloating

			'Set the font color.
			textbox0.Font.Color = Color.Blue

			'Set the font to bold.
			textbox0.Font.IsBold = True

			'Set the font size.
			textbox0.Font.Size = 14

			'Set font attribute to italic.
			textbox0.Font.IsItalic = True

			'Add a hyperlink to the textbox.
			textbox0.AddHyperlink("http://www.aspose.com/")

			'Get the filformat of the textbox.
			Dim fillformat As MsoFillFormat = textbox0.FillFormat

			'Set the fillcolor.
			fillformat.ForeColor = Color.Silver

			'Get the lineformat type of the textbox.
			Dim lineformat As MsoLineFormat = textbox0.LineFormat

			'Set the line style.
			lineformat.Style = MsoLineStyle.ThinThick

			'Set the line weight.
			lineformat.Weight = 6

			'Set the dash style to squaredot.
			lineformat.DashStyle = MsoLineDashStyle.SquareDot

			'Add another textbox.
			textboxIndex = worksheet.TextBoxes.Add(15, 4, 85, 120)

			'Get the second textbox.
			Dim textbox1 As Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(textboxIndex)

			'Input some text to it.
			textbox1.Text = "This is another simple text box"

			'Set the placement type as the textbox will move and
			'resize with cells.
			textbox1.Placement = PlacementType.MoveAndSize

			'Save the excel file.
			workbook.Save(dataDir & "book1.xls")

		End Sub
	End Class
End Namespace