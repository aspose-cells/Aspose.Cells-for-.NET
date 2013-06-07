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

Namespace ProtectingSpecificRowInWorksheet
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create a new workbook.
			Dim wb As New Workbook()

			' Create a worksheet object and obtain the first sheet.
			Dim sheet As Worksheet = wb.Worksheets(0)

			' Define the style object.
			Dim style As Style

			' Define the styleflag object.
			Dim flag As StyleFlag

			' Loop through all the columns in the worksheet and unlock them.
			For i As Integer = 0 To 255
				style = sheet.Cells.Columns(CByte(i)).Style
				style.IsLocked = False
				flag = New StyleFlag()
				flag.Locked = True
				sheet.Cells.Columns(CByte(i)).ApplyStyle(style, flag)

			Next i

			' Get the first row style.
			style = sheet.Cells.Rows(0).Style

			' Lock it.
			style.IsLocked = True

			' Instantiate the flag.
			flag = New StyleFlag()

			' Set the lock setting.
			flag.Locked = True

			' Apply the style to the first row.
			sheet.Cells.ApplyRowStyle(0, style, flag)

			' Protect the sheet.
			sheet.Protect(ProtectionType.All)

			' Save the excel file.
			wb.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)


		End Sub
	End Class
End Namespace