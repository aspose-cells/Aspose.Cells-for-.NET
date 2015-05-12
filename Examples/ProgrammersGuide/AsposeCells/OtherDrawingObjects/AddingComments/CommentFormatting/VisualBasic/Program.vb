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

Namespace CommentFormatting
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiating a Workbook object
			Dim workbook As New Workbook()

			'Adding a new worksheet to the Workbook object
			Dim sheetIndex As Integer = workbook.Worksheets.Add()

			'Obtaining the reference of the newly added worksheet by passing its sheet index
			Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

			'Adding a comment to "F5" cell
			Dim commentIndex As Integer = worksheet.Comments.Add("F5")

			'Accessing the newly added comment
			Dim comment As Comment = worksheet.Comments(commentIndex)

			'Setting the comment note
			comment.Note = "Hello Aspose!"

			'Setting the font size of a comment to 14
			comment.Font.Size = 14

			'Setting the font of a comment to bold
			comment.Font.IsBold = True

			'Setting the height of the font to 10
			comment.HeightCM = 10

			'Setting the width of the font to 2
			comment.WidthCM = 2

			'Saving the Excel file
			workbook.Save(dataDir & "book1.xls")

		End Sub
	End Class
End Namespace