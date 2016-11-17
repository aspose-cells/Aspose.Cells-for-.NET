Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ManagingComments
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingComments
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding comment to "b2" cell
			sheet.Comments.Add("b2", "Please write your name.")

			' Adding another comment to "b4" cell using its row & column number
			sheet.Comments.Add(3, 1, "Please write your email.")
			' ExEnd:AddingComments
			MessageBox.Show("Comment has been added")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingComments
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Accessing a comment added to "c3" cell (specified using its row & column number)
			Dim comment1 As Aspose.Cells.GridDesktop.Data.GridComment = sheet.Comments(3, 1)

			If comment1 IsNot Nothing Then
				' Modifying the text of comment
				comment1.Text = "The 1st comment."
				MessageBox.Show("Comment has been modified")
			Else
				MessageBox.Show("Please add comment before accessing it.")
			End If
			' ExEnd:AccessingComments
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:RemovingComments
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			If sheet.Comments(3, 1) IsNot Nothing Then
				' Removing comment from "c3" cell
				sheet.Comments.Remove(3, 1)
				MessageBox.Show("Comment has been removed")
			Else
				MessageBox.Show("Please add comment before removing it.")
			End If
			' ExEnd:RemovingComments
		End Sub
	End Class
End Namespace
