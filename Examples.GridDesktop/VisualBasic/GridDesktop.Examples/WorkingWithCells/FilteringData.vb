Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithCells
	Public Partial Class FilteringData
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:AutoFilter
			' Enable GridDesktop's auto-filter.
			gridDesktop1.Worksheets(0).RowFilter.EnableAutoFilter = True

			' Set the header row.
			gridDesktop1.Worksheets(0).RowFilter.HeaderRow = 0

			' Set the starting row.
			gridDesktop1.Worksheets(0).RowFilter.StartRow = 1

			' Set the ending row.
			gridDesktop1.Worksheets(0).RowFilter.EndRow = 101
			' ExEnd:AutoFilter
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:CustomFilter
			' Set the starting row.
			gridDesktop1.Worksheets(0).RowFilter.StartRow = 1

			' Set the ending row.
			gridDesktop1.Worksheets(0).RowFilter.EndRow = 101

			' Get the RowFilter object for the first worksheet.
			Dim rowFilter As RowFilterSettings = gridDesktop1.Worksheets(0).RowFilter

			' Filter Rows.
			rowFilter.FilterRows(0, "Customer 1")
			' ExEnd:CustomFilter
		End Sub

		Private Sub FilteringData_Load(sender As Object, e As EventArgs)
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Specifying the path of Excel file using ImportExcelFile method of the control
			gridDesktop1.ImportExcelFile(dataDir & "book1.xlsx")
		End Sub
	End Class
End Namespace
