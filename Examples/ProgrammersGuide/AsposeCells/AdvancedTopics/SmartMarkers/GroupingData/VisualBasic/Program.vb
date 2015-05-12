'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace GroupingData
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a connection object, specify the provider info and set the data source.
			Dim con As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\test\Northwind.mdb")

			'Open the connection object.
			con.Open()

			'Create a command object and specify the SQL query.
			Dim cmd As New OleDbCommand("Select * from [Order Details]", con)

			'Create a data adapter object.
			Dim da As New OleDbDataAdapter()

			'Specify the command.
			da.SelectCommand = cmd

			'Create a dataset object.
			Dim ds As New DataSet()

			'Fill the dataset with the table records.
			da.Fill(ds, "Order Details")

			'Create a datatable with respect to dataset table.
			Dim dt As DataTable = ds.Tables("Order Details")

			'Create WorkbookDesigner object.
			Dim wd As New WorkbookDesigner()

			'Open the template file (which contains smart markers).
			wd.Workbook = New Workbook(dataDir & "TestSmartMarkers.xlsx")

			'Set the datatable as the data source.
			wd.SetDataSource(dt)

			'Process the smart markers to fill the data into the worksheets.
			wd.Process(True)

			'Save the excel file.
			wd.Workbook.Save(dataDir & "outSmartMarker_Designer.xlsx")


		End Sub
	End Class
End Namespace