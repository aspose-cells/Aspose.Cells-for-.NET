Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace Aspose.Cells.Examples.SmartMarkers

    Public Class AddCustomLabels
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate the workbook from a template file that contains Smart Markers
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")
            Dim designer As New Workbook(dataDir & "SmartMarker_Designer.xlsx")

            'Export data from the first worksheet to fill a data table
            Dim dt As DataTable = workbook.Worksheets(0).Cells.ExportDataTable(0, 0, 11, 5, True)

            'Instantiate a new WorkbookDesigner
            Dim d As New WorkbookDesigner()

            'Specify the workbook to the designer book
            d.Workbook = workbook

            'Set the table name
            dt.TableName = "Report"

            'Set the data source
            d.SetDataSource(dt)

            'Process the smart markers
            d.Process()

            'Save the Excel file
            workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)
            'ExEnd:1

        End Sub
    End Class
End Namespace
