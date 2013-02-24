'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells

Namespace Excel2PDFConversion
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate the Workbook object
			'Open an Excel file
			Dim workbook As New Workbook(dataDir & "Book1.xls")

			'Save the document in PDF format
			workbook.Save(dataDir & "outBook1.pdf", SaveFormat.Pdf)

			' Display result, so that use know the processing has finished.
			System.Console.WriteLine("Conversion completed.")
		End Sub
	End Class
End Namespace