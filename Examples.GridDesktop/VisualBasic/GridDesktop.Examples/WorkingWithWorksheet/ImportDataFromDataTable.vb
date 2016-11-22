Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells.GridDesktop
Imports System.Data.OleDb

Namespace WorkingWithWorksheet
	Public Partial Class ImportDataFromDataTable
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button2_Click(sender As Object, e As EventArgs)
			' ExStart:1
			' The path to the documents directory.
			Dim dataDir As String = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

			Dim adapter As OleDbDataAdapter
			Dim dt As New DataTable()

			' Creating connection string to connect with database
			Dim conStr As String = "Provider=microsoft.jet.oledb.4.0;Data Source=" & dataDir & "dbDatabase.mdb"

			' Creating Select query to fetch data from database
			Dim query As String = "SELECT * FROM Products ORDER BY ProductID"
			adapter = New OleDbDataAdapter(query, conStr)

			' Filling DataTable using an already created OleDbDataAdapter object
			adapter.Fill(dt)

			' Accessing the reference of a worksheet
			Dim sheet As Worksheet = gridDesktop1.Worksheets(0)

			' Importing data from DataTable to the worksheet. 0,0 specifies to start importing data from the cell with first row (0 index) and first column (0 index)
			sheet.ImportDataTable(dt, False, 0, 0)

			' Iterating through the number of columns contained in the DataTable
			For i As Integer = 0 To dt.Columns.Count - 1
				' Setting the column headers of the worksheet according to column names of the DataTable
				sheet.Columns(i).Header = dt.Columns(i).Caption
			Next

			' Setting the widths of the columns of the worksheet
			sheet.Columns(0).Width = 240
			sheet.Columns(1).Width = 160
			sheet.Columns(2).Width = 160
			sheet.Columns(3).Width = 100

			' Displaying the contents of the worksheet by making it active
			gridDesktop1.ActiveSheetIndex = 0
			' ExEnd:1
		End Sub
	End Class
End Namespace
