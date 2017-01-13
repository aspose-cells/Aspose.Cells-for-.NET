Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningFilewithDataOnly
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Load only specific sheets with data and formulas
            ' Other objects, items etc. would be discarded

            ' Instantiate LoadOptions specified by the LoadFormat
            Dim loadOptions7 As New LoadOptions(LoadFormat.Xlsx)

            ' Load only cell data, formulas & formatting
            loadOptions7.LoadFilter = New LoadFilter(LoadDataFilterOptions.CellData)

            ' Create a Workbook object and opening the file from its path
            Dim wb As New Workbook(dataDir & "Book1.xlsx", loadOptions7)
            Console.WriteLine("File data imported successfully!")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
