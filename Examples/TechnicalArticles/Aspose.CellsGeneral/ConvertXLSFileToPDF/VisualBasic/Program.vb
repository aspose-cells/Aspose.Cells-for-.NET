'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports Aspose.Cells

Namespace ConvertXLSFileToPDF
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")


			Try

				'Get the template excel file path.
				Dim designerFile As String = dataDir & "SampleInput.xlsx"
				'Specify the pdf file path.
				Dim pdfFile As String = dataDir & "Output.pdf"
				'Create a new Workbook.
				'Open the template excel file which you have to
				Dim wb As New Aspose.Cells.Workbook(designerFile)
				'Save the pdf file.
				wb.Save(pdfFile, SaveFormat.Pdf)

			Catch e As Exception
				Console.WriteLine(e.Message)
				Console.ReadLine()

			End Try
		End Sub

	End Class
End Namespace
