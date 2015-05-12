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

Namespace AddingRectangleControl
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
			Dim excelbook As New Workbook()

			'Add a rectangle control.
			Dim rectangle As Aspose.Cells.Drawing.RectangleShape = excelbook.Worksheets(0).Shapes.AddRectangle(3, 0, 2, 0, 70, 130)

			'Set the placement of the rectangle.
			rectangle.Placement = PlacementType.FreeFloating

			'Set the fill format.
			rectangle.FillFormat.ForeColor = Color.Azure

			'Set the line style.
			rectangle.LineFormat.Style = MsoLineStyle.ThickThin

			'Set the line weight.
			rectangle.LineFormat.Weight = 4

			'Set the color of the line.
			rectangle.LineFormat.ForeColor = Color.Blue

			'Set the dash style of the rectangle.
			rectangle.LineFormat.DashStyle = MsoLineDashStyle.Solid

			'Save the excel file.
			excelbook.Save(dataDir & "book1.xls")

		End Sub
	End Class
End Namespace