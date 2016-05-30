Imports System.IO

Imports Aspose.Cells
Imports System.Data
Imports System

Namespace Data.Handling.Importing
    Public Class ImportHtmlFormattedData
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim output1Path As String = dataDir & "Output.out.xlsx"
            Dim output2Path As String = dataDir & "Output.out.ods"

            ' Prepare a DataTable with some HTML formatted values
            Dim dataTable As New DataTable("Products")
            dataTable.Columns.Add("Product ID", GetType(Int32))
            dataTable.Columns.Add("Product Name", GetType(String))
            dataTable.Columns.Add("Units In Stock", GetType(Int32))
            Dim dr As DataRow = dataTable.NewRow()
            dr(0) = 1
            dr(1) = "<i>Aniseed</i> Syrup"
            dr(2) = 15
            dataTable.Rows.Add(dr)
            dr = dataTable.NewRow()
            dr(0) = 2
            dr(1) = "<b>Boston Crab Meat</b>"
            dr(2) = 123
            dataTable.Rows.Add(dr)

            ' Create import options
            Dim importOptions As New ImportTableOptions()
            importOptions.IsFieldNameShown = True
            importOptions.IsHtmlString = True

            ' Create workbook
            Dim workbook As New Workbook()
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            worksheet.Cells.ImportData(dataTable, 0, 0, importOptions)
            worksheet.AutoFitRows()
            worksheet.AutoFitColumns()

            workbook.Save(output1Path)
            workbook.Save(output2Path)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
