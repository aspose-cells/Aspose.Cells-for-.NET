Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data
Imports System

Namespace Data.Handling.Importing
    Public Class ImportingFromDataColumn
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a "Products" DataTable object
            Dim dataTable As New DataTable("Products")

            ' Adding columns to the DataTable object
            dataTable.Columns.Add("Product ID", GetType(Int32))
            dataTable.Columns.Add("Product Name", GetType(String))
            dataTable.Columns.Add("Units In Stock", GetType(Int32))

            ' Creating an empty row in the DataTable object
            Dim dr As DataRow = dataTable.NewRow()

            ' Adding data to the row
            dr(0) = 1
            dr(1) = "Aniseed Syrup"
            dr(2) = 15

            ' Adding filled row to the DataTable object
            dataTable.Rows.Add(dr)

            ' Creating another empty row in the DataTable object
            dr = dataTable.NewRow()

            ' Adding data to the row
            dr(0) = 2
            dr(1) = "Boston Crab Meat"
            dr(2) = 123

            ' Adding filled row to the DataTable object
            dataTable.Rows.Add(dr)

            ' Instantiate a new Workbook
            Dim book As New Workbook()

            Dim sheet As Worksheet = book.Worksheets(0)

            ' Create import options
            Dim importOptions As New ImportTableOptions()
            importOptions.IsFieldNameShown = True
            importOptions.IsHtmlString = True

            ' Importing the values of 2nd column of the data table
            sheet.Cells.ImportData(dataTable, 1, 1, importOptions)

            ' Save workbook
            book.Save(dataDir & "output.xls")
            ' ExEnd:1


        End Sub
    End Class
End Namespace