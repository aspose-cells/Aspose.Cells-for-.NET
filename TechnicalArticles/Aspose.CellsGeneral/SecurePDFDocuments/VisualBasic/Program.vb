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

Namespace SecurePDFDocumentsExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
			'Open an Excel file
			Dim workbook As New Workbook(dataDir & "input.xlsx")

			'Instantiate PDFSaveOptions to manage security attributes
			Dim saveOption As New PdfSaveOptions()

			saveOption.SecurityOptions = New Aspose.Cells.Rendering.PdfSecurity.PdfSecurityOptions()
			'Set the user password
			saveOption.SecurityOptions.UserPassword = "user"

			'Set the owner password
			saveOption.SecurityOptions.OwnerPassword = "owner"

			'Disable extracting content permission
			saveOption.SecurityOptions.ExtractContentPermission = False

			'Disable print permission
			saveOption.SecurityOptions.PrintPermission = False

			'Save the PDF document with encrypted settings
			workbook.Save(dataDir & "securepdf_test.pdf", saveOption)

		End Sub
	End Class
End Namespace