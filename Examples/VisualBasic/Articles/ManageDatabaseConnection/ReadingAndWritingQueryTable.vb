Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.ExternalConnections

Namespace Articles.ManageDatabaseConnection
    Public Class ReadingAndWritingQueryTable
        Public Shared Sub Run()
            ' ExStart:ReadingAndWritingQueryTable
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("Sample.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first Query Table
            Dim qt As QueryTable = worksheet.QueryTables(0)

            ' Print Query Table Data
            Console.WriteLine("Adjust Column Width: " + qt.AdjustColumnWidth)
            Console.WriteLine("Preserve Formatting: " + qt.PreserveFormatting)

            ' Now set Preserve Formatting to true
            qt.PreserveFormatting = True

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("Output_out.xlsx"))
            ' ExEnd:ReadingAndWritingQueryTable
        End Sub
    End Class
End Namespace