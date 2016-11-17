Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class RenameWorksheet
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			Try
				' ExStart:1
				' Accesing an active worksheet directly
				Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

				' Renaming a worksheet
					' ExEnd:1
				sheet.Name = "Renamed Sheet"
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
