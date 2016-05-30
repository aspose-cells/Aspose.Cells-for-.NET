Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Namespace Data.Handling.Importing
    Public Class ImportingFromDataGrid
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a DataTable object and set it as DataSource of DataGrid.
            Dim dataTable As New DataTable("Products")
            dataTable.Columns.Add("Product ID", GetType(Int32))
            dataTable.Columns.Add("Product Name", GetType(String))
            dataTable.Columns.Add("Units In Stock", GetType(Int32))
            Dim dr As DataRow = dataTable.NewRow()
            dr(0) = 1
            dr(1) = "Aniseed Syrup"
            dr(2) = 15
            dataTable.Rows.Add(dr)
            dr = dataTable.NewRow()
            dr(0) = 2
            dr(1) = "Boston Crab Meat"
            dr(2) = 123
            dataTable.Rows.Add(dr)

            ' Now take care of DataGrid
            Dim dg As New DataGrid()
            dg.DataSource = dataTable
            dg.DataBind()

            ' We have a DataGrid object with some data in it.
            ' Lets import it into our spreadsheet

            ' Creat a new workbook
            Dim workbook As New Workbook()
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Importing the contents of the data grid to the worksheet
            worksheet.Cells.ImportDataGrid(dg, 0, 0, False)

            ' Save it as Excel file
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
