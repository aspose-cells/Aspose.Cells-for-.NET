Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data
Imports System

Namespace Aspose.Cells.Examples.Data.Handling.Importing
    Public Class ImportingFromDataTable
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object            
            Dim workbook As New Workbook()

            'Obtaining the reference of the worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Instantiating a "Products" DataTable object
            Dim dataTable As New DataTable("Products")

            'Adding columns to the DataTable object
            dataTable.Columns.Add("Product ID", GetType(Int32))
            dataTable.Columns.Add("Product Name", GetType(String))
            dataTable.Columns.Add("Units In Stock", GetType(Int32))

            'Creating an empty row in the DataTable object
            Dim dr As DataRow = dataTable.NewRow()

            'Adding data to the row
            dr(0) = 1
            dr(1) = "Aniseed Syrup"
            dr(2) = 15

            'Adding filled row to the DataTable object
            dataTable.Rows.Add(dr)

            'Creating another empty row in the DataTable object
            dr = dataTable.NewRow()

            'Adding data to the row
            dr(0) = 2
            dr(1) = "Boston Crab Meat"
            dr(2) = 123

            'Adding filled row to the DataTable object
            dataTable.Rows.Add(dr)

            'Importing the contents of DataTable to the worksheet starting from "A1" cell,
            'where true specifies that the column names of the DataTable would be added to
            'the worksheet as a header row
            worksheet.Cells.ImportDataTable(dataTable, True, "A1")


            'Saving the Excel file
            workbook.Save(dataDir & "DataImport.out.xls")

        End Sub
    End Class
End Namespace