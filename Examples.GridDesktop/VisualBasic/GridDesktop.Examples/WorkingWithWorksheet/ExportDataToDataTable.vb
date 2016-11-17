Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop

Namespace WorkingWithWorksheet
	Public Partial Class ExportDataToDataTable
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ExportDataToDataTable_Load(sender As Object, e As EventArgs)
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			' Specifying the path of Excel file using ImportExcelFile method of the control
			gridDesktop1.ImportExcelFile(dataDir & "book1.xlsx")
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:ExportToSpecificDataTable
			' Creating a new DataTable object
			Dim dataTable As New DataTable()

			' Adding specific columns to the DataTable object
			dataTable.Columns.Add("ProductName", System.Type.[GetType]("System.String"))
			dataTable.Columns.Add("CategoryName", System.Type.[GetType]("System.String"))
			dataTable.Columns.Add("QuantityPerUnit", System.Type.[GetType]("System.String"))
			dataTable.Columns.Add("UnitsInStock", System.Type.[GetType]("System.Int32"))

			' Exporting the data of the first worksheet of the Grid to the specific DataTable object
			dataTable = gridDesktop1.Worksheets(0).ExportDataTable(dataTable, 0, 0, 69, 4, True)
			' ExEnd:ExportToSpecificDataTable
			MessageBox.Show("DataTable Rows Count: " & dataTable.Rows.Count)
		End Sub

		Private Sub button1_Click(sender As Object, e As EventArgs)
			' ExStart:ExportToNewDataTable
			' Accessing the reference of the worksheet that is currently active
			Dim sheet As Worksheet = gridDesktop1.GetActiveWorksheet()

			'Getting the total number of rows and columns inside the worksheet
			Dim totalRows As Integer = sheet.RowsCount
			Dim totalCols As Integer = sheet.ColumnsCount

			' Exporting the data of the active worksheet to a new DataTable object
			Dim table As DataTable = sheet.ExportDataTable(0, 0, totalRows, totalCols, False, True)
			' ExEnd:ExportToNewDataTable
			MessageBox.Show("DataTable Rows Count: " & table.Rows.Count)
		End Sub
	End Class
End Namespace
