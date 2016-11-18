Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithCells
	Public Partial Class UsingFormatPainter
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:UseOnce
			' Starting format painter to paint once
			gridDesktop1.StartFormatPainter(False)
			' ExEnd:UseOnce
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:UseAlways
			' Starting format painter to keep painting forever
			gridDesktop1.StartFormatPainter(True)
			' ExEnd:UseAlways
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:EndUse
			' Ending format painter to stop painting
			gridDesktop1.EndFormatPainter()
			' ExEnd:EndUse
		End Sub
	End Class
End Namespace
