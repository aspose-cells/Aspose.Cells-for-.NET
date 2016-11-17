Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class AddInsertWorksheet
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AddingWorksheet
			' Adding a worksheet to the Grid
			Dim i As Integer = gridDesktop1.Worksheets.Add()
			Dim sheet As Worksheet = gridDesktop1.Worksheets(i)
			' ExEnd:AddingWorksheet
		End Sub

		Private Sub button4_Click(sender As Object, e As EventArgs)
			' ExStart:AddingWorksheetWithName
			' Adding a worksheet to the Grid with a specific name
			Dim sheet1 As Worksheet = gridDesktop1.Worksheets.Add("AddWorksheetWithName")
			' ExEnd:AddingWorksheetWithName
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:InsertingWorksheet
			' Inserting a worksheet to Grid at first position of the worksheets collection
			gridDesktop1.Worksheets.Insert(0)
			' ExEnd:InsertingWorksheet
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:InsertingWorksheetWithName
			' Inserting a worksheet to Grid at first position with a specific sheet name
			Dim sheet1 As Worksheet = gridDesktop1.Worksheets.Insert(0, "InsertWorksheetWithName")
			' ExEnd:InsertingWorksheetWithName
		End Sub
	End Class
End Namespace
