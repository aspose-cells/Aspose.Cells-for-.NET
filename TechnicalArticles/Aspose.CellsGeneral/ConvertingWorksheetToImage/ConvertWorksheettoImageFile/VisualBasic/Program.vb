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
Imports Aspose.Cells.Rendering
Imports System.Drawing

Namespace ConvertWorksheettoImageFile
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a new Workbook object
			'Open a template excel file
			Dim book As New Workbook(dataDir & "Testbook.xlsx")
			'Get the first worksheet.
			Dim sheet As Worksheet = book.Worksheets(0)

			'Define ImageOrPrintOptions
			Dim imgOptions As New ImageOrPrintOptions()
			'Specify the image format
			imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
			'Render the sheet with respect to specified image/print options
			Dim sr As New SheetRender(sheet, imgOptions)
			'Render the image for the sheet
			Dim bitmap As Bitmap = sr.ToImage(0)

			'Save the image file
			bitmap.Save(dataDir & "SheetImage.jpg")


		End Sub
	End Class
End Namespace