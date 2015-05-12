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

Namespace ConvertWorksheetToImageByPage
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim book As New Workbook(dataDir & "TestData.xlsx")
			Dim sheet As Worksheet = book.Worksheets(0)
			Dim options As New Aspose.Cells.Rendering.ImageOrPrintOptions()
			options.HorizontalResolution = 200
			options.VerticalResolution = 200
			options.ImageFormat = System.Drawing.Imaging.ImageFormat.Tiff

			'Sheet2Image By Page conversion
			Dim sr As New SheetRender(sheet, options)
			For j As Integer = 0 To sr.PageCount - 1

				sr.ToImage(j, dataDir & "test" & sheet.Name & " Page" & (j + 1) & ".tif")
			Next j



		End Sub
	End Class
End Namespace