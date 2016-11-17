Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class AccessingWorksheets
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub AccessingWorksheets_Load(sender As Object, e As EventArgs)
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
			gridDesktop1.ImportExcelFile(dataDir & "book1.xlsx")
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingWithIndex
			' Accesing a worksheet using its index
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)
			' ExEnd:AccessingWithIndex
			MessageBox.Show("You accessed " & sheet.Name)
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingWithName
			' Accesing a worksheet using its name
			Dim sheet As Worksheet = gridDesktop1.Worksheets("Sheet2")
			' ExEnd:AccessingWithName
			MessageBox.Show("You accessed " & sheet.Name)
		End Sub

		Private Sub button3_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingWithActiveWorksheet
			' Accesing an active worksheet using its index
			Dim sheet As Worksheet = gridDesktop1.Worksheets(gridDesktop1.ActiveSheetIndex)
			' ExEnd:AccessingWithActiveWorksheet
			MessageBox.Show("You accessed " & sheet.Name)
		End Sub

		Private Sub button4_Click(sender As Object, e As EventArgs)
			' ExStart:AccessingWithGetActiveWorksheet
			' Accesing an active worksheet directly
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()
			' ExEnd:AccessingWithGetActiveWorksheet
			MessageBox.Show("You accessed " & sheet.Name)
		End Sub
	End Class
End Namespace
