Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WorkingWithWorksheet
	Public Partial Class RemoveWorksheet
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub RemoveWorksheet_Load(sender As Object, e As EventArgs)
			gridDesktop1.Worksheets.Add("Sheet2")
			gridDesktop1.Worksheets.Add("Sheet3")
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			If gridDesktop1.Worksheets.Count > 0 Then
				' ExStart:RemoveUsingIndex
				' Removing a worksheet using its index
                gridDesktop1.Worksheets.Remove(0)
                ' ExEnd:RemoveUsingIndex
            Else
                MessageBox.Show("You have only 1 sheet left")
			End If
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			If gridDesktop1.Worksheets.Count > 0 Then
				Try
					' ExStart:RemoveUsingName
                    ' Removing a worksheet using its index
                    gridDesktop1.Worksheets.RemoveAt("Sheet3")
                    ' ExEnd:RemoveUsingName
				Catch ex As Exception
					MessageBox.Show(ex.Message)
				End Try
			Else
				MessageBox.Show("You have only 1 sheet left")
			End If
		End Sub
	End Class
End Namespace
