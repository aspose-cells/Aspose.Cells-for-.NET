Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithGrid
	Public Partial Class GridDesktopEvents
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		' ExStart:ClickEvent
		Private Sub gridDesktop1_CellClick(sender As Object, e As Aspose.Cells.GridDesktop.CellEventArgs)
			MessageBox.Show("Cell is clicked")
		End Sub
		' ExEnd:ClickEvent
	End Class
End Namespace
