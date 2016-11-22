Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ManagingHyperlinks
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddHyperlink
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Accessing cell of the worksheet
			Dim cell As GridCell = sheet.Cells("b2")
			Dim cell2 As GridCell = sheet.Cells("c3")

			' Modifying the width of the column of the cell
			sheet.Columns(cell.Column).Width = 160
			sheet.Columns(cell2.Column).Width = 160

			' Adding a value to the cell
			cell.Value = "Aspose Home"
			cell2.Value = "Aspose Home"

			' Adding a hyperlink to the worksheet containing cell name and the hyperlink URL with which the cell will be linked
			sheet.Hyperlinks.Add("b2", "www.aspose.com")
			sheet.Hyperlinks.Add("c3", "www.aspose.com")
			' ExEnd:AddHyperlink
			MessageBox.Show("Hyperlinks have been added.")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessHyperlink
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Accessing a hyperlink added to "c3,b2" cells (specified using its row & column number)
			Dim hyperlink1 As Aspose.Cells.GridDesktop.Data.GridHyperlink = sheet.Hyperlinks(2, 2)
			Dim hyperlink2 As Aspose.Cells.GridDesktop.Data.GridHyperlink = sheet.Hyperlinks(1, 1)

			If hyperlink1 IsNot Nothing AndAlso hyperlink2 IsNot Nothing Then
				' Modifying the Url of the hyperlink
				hyperlink1.Url = "www.aspose.com"
				hyperlink2.Url = "www.aspose.com"
				MessageBox.Show("Hyperlinks are accessed and URL's are: " & vbLf & hyperlink1.Url & vbLf & hyperlink2.Url)
			Else
				MessageBox.Show("No hyperlinks are found in sheet. Add hyperlinks first.")
			End If
            ' ExEnd:AccessHyperlink
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:RemoveHyperlink
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			If sheet.Hyperlinks.Count > 0 Then
				' Removing hyperlink from "c3" cell
				sheet.Hyperlinks.Remove(2, 2)
				MessageBox.Show("Hyperlink in C3 cell has been removed.")
			Else
				MessageBox.Show("No hyperlinks are found in sheet to remove. Add hyperlinks first.")
			End If
			' ExEnd:RemoveHyperlink
		End Sub
	End Class
End Namespace
