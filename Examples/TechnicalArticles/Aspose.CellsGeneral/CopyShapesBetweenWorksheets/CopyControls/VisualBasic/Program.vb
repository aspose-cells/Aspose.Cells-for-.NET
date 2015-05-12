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

Namespace CopyControls
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a workbook object
			'Open the template file
			Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

			'Get the Shapes from the "Control" worksheet.
			Dim shape As Aspose.Cells.Drawing.ShapeCollection = workbook.Worksheets("Sheet3").Shapes

			'Copy the Textbox to the Result Worksheet
			workbook.Worksheets("Sheet1").Shapes.AddCopy(shape(0), 5, 0, 2, 0)

			'Copy the Oval Shape to the Result Worksheet
			workbook.Worksheets("Sheet1").Shapes.AddCopy(shape(1), 10, 0, 2, 0)

			'Save the Worksheet
			workbook.Save(dataDir & "Controls.xlsx")

		End Sub
	End Class
End Namespace