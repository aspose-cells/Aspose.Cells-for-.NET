'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells

Namespace ConvertingToMHTMLFiles
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Specify the file path
			Dim filePath As String = dataDir & "Book1.xlsx"

			'Specify the HTML Saving Options
			Dim sv As New HtmlSaveOptions(SaveFormat.MHtml)

			'Instantiate a workbook and open the template XLSX file
			Dim wb As New Workbook(filePath)

			'Save the MHT file
			wb.Save(filePath & ".out.mht", sv)
		End Sub
	End Class
End Namespace