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
Imports System.Drawing

Namespace AddPictureToExcelComment
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiate a Workbook
			Dim workbook As New Workbook()

			'Get a reference of comments collection with the first sheet
			Dim comments As CommentCollection = workbook.Worksheets(0).Comments

			'Add a comment to cell A1
			Dim commentIndex As Integer = comments.Add(0, 0)
			Dim comment As Comment = comments(commentIndex)
			comment.Note = "First note."
			comment.Font.Name = "Times New Roman"

			'Load an image into stream
			Dim bmp As New Bitmap(dataDir & "image2.jpg")
			Dim ms As New MemoryStream()
			bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

			'Set image data to the shape associated with the comment
			comment.CommentShape.FillFormat.ImageData = ms.ToArray()

			'Save the workbook
			workbook.Save(dataDir & "commentwithpicture1.xlsx", Aspose.Cells.SaveFormat.Xlsx)


		End Sub
	End Class
End Namespace