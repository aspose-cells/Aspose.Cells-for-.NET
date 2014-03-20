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

Namespace AddingTextBoxControl
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook.
			'Open the existing file.
			Dim workbook As New Workbook(dataDir & "chart.xls")

			'Get the designer chart in the second sheet.
			Dim sheet As Worksheet = workbook.Worksheets(1)
			Dim chart As Aspose.Cells.Charts.Chart = sheet.Charts(0)

			'Add a new textbox to the chart.
			Dim textbox0 As Aspose.Cells.Drawing.TextBox = chart.Shapes.AddTextBoxInChart(100, 1100, 350, 2550)

			'Fill the text.
			textbox0.Text = "Sales By Region"

			'Get the textbox text frame.
			Dim textframe0 As Aspose.Cells.Drawing.MsoTextFrame = textbox0.TextFrame

			'Set the textbox to adjust it according to its contents.
			textframe0.AutoSize = True

			'Set the font color.
			textbox0.Font.Color = Color.Maroon

			'Set the font to bold.
			textbox0.Font.IsBold = True

			'Set the font size.
			textbox0.Font.Size = 14

			'Set font attribute to italic.
			textbox0.Font.IsItalic = True

			'Get the filformat of the textbox.
			Dim fillformat As Aspose.Cells.Drawing.MsoFillFormat = textbox0.FillFormat

			'Set the fillcolor.
			fillformat.ForeColor = Color.Silver

			'Get the lineformat type of the textbox.
			Dim lineformat As Aspose.Cells.Drawing.MsoLineFormat = textbox0.LineFormat

			'Set the line style.
			lineformat.Style = Aspose.Cells.Drawing.MsoLineStyle.ThinThick

			'Set the line weight.
			lineformat.Weight = 2

			'Set the dash style to solid.
			lineformat.DashStyle = Aspose.Cells.Drawing.MsoLineDashStyle.Solid

			'Save the excel file.
			workbook.Save(dataDir & "chart_out.xls")

		End Sub
	End Class
End Namespace