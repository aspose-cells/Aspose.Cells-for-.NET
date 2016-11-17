Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class AddingCellControls
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AddingButton
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			' Adding button to the Controls collection of the Worksheet
			Dim button As Aspose.Cells.GridDesktop.Button = sheet.Controls.AddButton(cl.Row, cl.Column, 80, 20, "Button")
			' ExEnd:AddingButton

			' ExStart:SetBackground
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Set the image.
			Dim image__1 As Image = Image.FromFile(dataDir & "AsposeLogo.jpg")
			button.Image = image__1
			' ExEnd:SetBackground
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AddingCheckbox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			' Adding checkbox to the Controls collection of the Worksheet
			sheet.Controls.AddCheckBox(cl.Row, cl.Column, True)
			' ExEnd:AddingCheckbox
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AddingCombobox
			' Accessing the worksheet of the Grid that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			' Accessing the location of the cell that is currently in focus
			Dim cl As CellLocation = sheet.GetFocusedCellLocation()

			'Creating an array of items or values that will be added to combobox
			Dim items As String() = New String(2) {}
			items(0) = "Aspose"
			items(1) = "Aspose.Grid"
			items(2) = "Aspose.Grid.Desktop"

			' Adding combobox to the Controls collection of the Worksheet
			sheet.Controls.AddComboBox(cl.Row, cl.Column, items)
			' ExEnd:AddingCombobox
		End Sub

		' ExStart:HandlingButton
		' Implenting CellButtonClick event handler
		Private Sub gridDesktop1_CellButtonClick(sender As Object, e As CellControlEventArgs)
			' Displaying the message when button is clicked
			MessageBox.Show("Button is clicked.")
		End Sub
		' ExEnd:HandlingButton

		' ExStart:HandlingCheckbox
		' Implenting CellCheckedChanged event handler
		Private Sub gridDesktop1_CellCheckedChanged(sender As Object, e As CellControlEventArgs)
			' Getting the reference of the CheckBox control whose event is triggered
			Dim check As Aspose.Cells.GridDesktop.CheckBox = DirectCast(gridDesktop1.GetActiveWorksheet().Controls(e.Row, e.Column), Aspose.Cells.GridDesktop.CheckBox)

			' Displaying the message when the Checked state of CheckBox is changed
			MessageBox.Show("Current state of CheckBox is " & check.Checked)
		End Sub
		' ExEnd:HandlingCheckbox

		' ExStart:HandlingCombobox
		' Implenting CellSelectedIndexChanged event handler
		Private Sub gridDesktop1_CellSelectedIndexChanged(sender As Object, e As CellComboBoxEventArgs)
			' Getting the reference of the ComboBox control whose event is triggered
			Dim combo As Aspose.Cells.GridDesktop.ComboBox = DirectCast(gridDesktop1.GetActiveWorksheet().Controls(e.Row, e.Column), Aspose.Cells.GridDesktop.ComboBox)

			' Displaying the message when the Selected Index of ComboBox is changed
			MessageBox.Show(combo.Items(combo.SelectedIndex).ToString())
		End Sub
		' ExEnd:HandlingCombobox
	End Class
End Namespace
