Imports System
Imports System.IO


Imports Aspose.Cells
Imports System.Data

Namespace Data.Handling
    Public Class ExportColumnContainingStronglyTypedData
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "Book1.xlsx"

            ' Instantiating a Workbook object
            Dim workbook As New Workbook(filePath)

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            Dim dataTable As DataTable = worksheet.Cells.ExportDataTable(0, 0, 11, 2, True)

            For Each r As DataRow In dataTable.Rows
                For Each c As DataColumn In dataTable.Columns
                    Dim value As Double = r.Field(Of Double)(c)
                    Console.Write(value & "    ")
                Next c
                Console.WriteLine()
            Next r
            ' ExEnd:1

        End Sub
    End Class
End Namespace
