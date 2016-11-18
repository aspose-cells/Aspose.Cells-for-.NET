Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class AddCellProtection
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:1
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Make sure sheet has been protected
			sheet.[Protected] = True

			' Choose a cell range
			Dim range As CellRange = sheet.CreateRange("A1", "B1")

			' Set protected range area on Worksheet
			sheet.SetProtected(range, True)
			' ExEnd:1
			MessageBox.Show("Cells has been protected now.")
		End Sub
	End Class
End Namespace
