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
Imports System.Collections
Imports System.Text
Imports System.Threading
Imports Aspose.Cells.Rendering
Imports System.Security.Cryptography

Imports System.Drawing
Imports System.Diagnostics
Imports Aspose.Cells.DigitalSignatures
Imports System.Security.Cryptography.X509Certificates

Namespace AssignValidateDigitalSignatures
	Public Class Program
		Public Shared Sub Main(ByVal args As String())
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim test As Program = New MyTest()
			test.testSign()
			test.testvalidateSign()
			Console.ReadLine()


		End Sub
	End Class
End Namespace