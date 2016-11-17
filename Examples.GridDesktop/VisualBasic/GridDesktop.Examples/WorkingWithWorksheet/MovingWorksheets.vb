Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithWorksheet
	Public Partial Class MovingWorksheets
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:1
			' Move the 2nd worksheet to 4th position.
			gridDesktop1.Worksheets.MoveTo(1, 3)
			' ExEnds:1
			gridDesktop1.Refresh()
		End Sub

		Private Sub MovingWorksheets_Load(sender As Object, e As EventArgs)
			gridDesktop1.Worksheets.Add()
			gridDesktop1.Worksheets.Add()
			gridDesktop1.Worksheets.Add()
			gridDesktop1.Worksheets.Add()
		End Sub
	End Class
End Namespace
