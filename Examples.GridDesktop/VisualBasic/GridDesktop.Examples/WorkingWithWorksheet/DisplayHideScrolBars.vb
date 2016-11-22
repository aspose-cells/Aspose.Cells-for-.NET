Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithWorksheet
	Public Partial Class DisplayHideScrolBars
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:ShowScrollbars
			' Displaying the vertical scroll bar
			gridDesktop1.IsVerticalScrollBarVisible = True

			' Displaying the horizontal scroll bar
			gridDesktop1.IsHorizontalScrollBarVisible = True
            ' ExEnd:ShowScrollbars
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:HideScrollbars
			' Hiding the vertical scroll bar
			gridDesktop1.IsVerticalScrollBarVisible = False

			' Hiding the horizontal scroll bar
			gridDesktop1.IsHorizontalScrollBarVisible = False
			' ExEnd:HideScrollbars
		End Sub
	End Class
End Namespace
