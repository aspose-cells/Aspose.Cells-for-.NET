Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ManagingPictures
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingPictures
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding picture to "b2" cell from file
			sheet.Pictures.Add("b2", dataDir & "AsposeGrid.jpg")

			' Creating a stream contain picture
			Dim fs As New FileStream(dataDir & "AsposeLogo.jpg", FileMode.Open)

			Try
				' Adding picture to "b3" cell from stream
				sheet.Pictures.Add(2, 1, fs)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			Finally
				' Closing stream
				fs.Close()
			End Try
			' ExEnd:AddingPictures
			MessageBox.Show("Pictures have been added.")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AccessAndModifyPicture
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Accessing a picture added to "c3" cell (specified using its row & column number)
			Dim picture1 As Aspose.Cells.GridDesktop.Data.GridPicture = sheet.Pictures(1)

			' Modifying the image
			picture1.Image = Image.FromFile(dataDir & "Aspose.Grid.jpg")
			' ExEnd:AccessAndModifyPicture
			MessageBox.Show("Picture has been modified.")
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:RemovePicture
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Removing picture from "c3" cell
			sheet.Pictures.Remove(2, 2)
			' ExEnd:RemovePicture
			MessageBox.Show("Picture has been removed.")
		End Sub
	End Class
End Namespace
