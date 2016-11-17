Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ValidationInWorksheets
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingValidation
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding values to specific cells of the worksheet
			sheet.Cells("a2").Value = "Required"
			sheet.Cells("a4").Value = "100"
			sheet.Cells("a6").Value = "2006-07-21"
			sheet.Cells("a8").Value = "101.2"

			' Adding Is Required Validation to a cell
			sheet.Validations.Add("a2", True, "")

			' Adding simple Regular Expression Validation to a cell
			sheet.Validations.Add("a4", True, "\d+")

			' Adding complex Regular Expression Validation to a cell
			sheet.Validations.Add("a6", True, "\d{4}-\d{2}-\d{2}")

			' Adding Custom Validation to a cell
			sheet.Validations.Add("a8", New CustomValidation())
			' ExEnd:AddingValidation
			MessageBox.Show("Validation has been added.")
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingValidation
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			If sheet.Validations.Count > 0 Then
				' Accessing the Validation object applied on "a8" cell
				Dim validation As Aspose.Cells.GridDesktop.Data.GridValidation = sheet.Validations(7, 0)

				' Editing the attributes of Validation
				validation.IsRequired = True
				validation.RegEx = ""
				validation.CustomValidation = Nothing
				MessageBox.Show("Validation has been edited after accessing it.")
			Else
				MessageBox.Show("No validations found to access.")
			End If
			' ExEnd:AccessingValidation
		End Sub

		Private Sub button4_Click(sender As Object, e As EventArgs)
			' ExStart:RemoveValidation
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)
			If sheet.Validations.Count > 0 Then
				' Removing the Validation object applied on "a6" cell
				sheet.Validations.RemoveAt(1)
				MessageBox.Show("Validation has been removed.")
			Else
				MessageBox.Show("No validations found to remove.")
			End If
			' ExEnd:RemoveValidation
		End Sub
	End Class

	' ExStart:ImplementingICustomInterface
	' Implementing ICustomValidation interface
	Public Class CustomValidation
		Implements Aspose.Cells.GridDesktop.ICustomValidation
		' Implementing Validate method already defined in the interface
		Public Function Validate(worksheet As Worksheet, row As Integer, col As Integer, value As Object) As Boolean Implements ICustomValidation.Validate
			' Checking the cell's address
			If row = 7 AndAlso col = 0 Then
				'Checking the data type of cell's value
				Dim d As Double = 0
				Try
					d = CDbl(value)
				Catch
					Return False
				End Try

				' Checking if the cell's value is greater than 100
				If d > 100 Then
					Return True
				End If
			End If
			Return False
		End Function
	End Class
	' ExEnd:ImplementingICustomInterface
End Namespace
