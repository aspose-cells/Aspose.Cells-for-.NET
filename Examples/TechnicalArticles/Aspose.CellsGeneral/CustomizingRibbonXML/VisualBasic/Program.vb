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

Namespace CustomizingRibbonXML
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim wb As New Workbook(dataDir & "aspose-sample.xlsx")
			Dim fi As New FileInfo(dataDir & "CustomUI.xml")
			Dim sr As StreamReader = fi.OpenText()
			wb.RibbonXml = sr.ReadToEnd()
			sr.Close()


		End Sub
	End Class
End Namespace