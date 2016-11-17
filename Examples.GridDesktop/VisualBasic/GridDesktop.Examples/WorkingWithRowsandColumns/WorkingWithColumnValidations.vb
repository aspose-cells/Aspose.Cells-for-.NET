Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithRowsandColumns
	Public Partial Class WorkingWithColumnValidations
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddValidation
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Adding Is Required Validation to a column
			sheet.Columns(2).AddValidation(True, "")

			' Adding simple Regular Expression Validation to a column
			sheet.Columns(4).AddValidation(True, "\d+")

			' Adding complex Regular Expression Validation to a column
			sheet.Columns(6).AddValidation(True, "\d{4}-\d{2}-\d{2}")

			' Adding Custom Validation to a column
			sheet.Columns(8).AddValidation(New CustomValidation())
			' ExEnd:AddValidation
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AccessValidation
			' Accessing first worksheet of the Grid
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Accessing the Validation object applied on a specific column
			'Validation validation = sheet.Columns[2].Validation;

			' Editing the attributes of Validation
			'validation.IsRequired = true;
			'validation.RegEx = "";
			'validation.CustomValidation = null;
			' ExEnd:AccessValidation
		End Sub

		Private Sub button4_Click(sender As Object, e As EventArgs)
			' ExStart:RemoveValidation
			' Accessing first worksheet of the Grid
			'Worksheet sheet = gridDesktop1.Worksheets[0];

			' Removing the Validation applied on a specific column
			'sheet.Columns[2].RemoveValidation();
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
