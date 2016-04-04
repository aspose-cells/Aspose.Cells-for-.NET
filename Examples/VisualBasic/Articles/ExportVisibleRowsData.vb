Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace Aspose.Cells.Examples.Articles
    Public Class ExportVisibleRowsData
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "aspose-sample.xlsx"

            'Load the source workbook
            Dim workbook As New Workbook(filePath)

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Specify export table options
            Dim exportOptions As New ExportTableOptions()
            exportOptions.PlotVisibleRows = True
            exportOptions.ExportColumnName = True

            'Export the data from worksheet with export options
            Dim dataTable As DataTable = worksheet.Cells.ExportDataTable(0, 0, 10, 4, exportOptions)
            'ExEnd:1


        End Sub
    End Class
End Namespace