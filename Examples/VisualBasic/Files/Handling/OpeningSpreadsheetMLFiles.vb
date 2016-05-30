Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningSpreadsheetMLFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Opening SpreadsheetML Files
            ' Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions3 As New LoadOptions(LoadFormat.SpreadsheetML)

            ' Create a Workbook object and opening the file from its path
            Dim wbSpreadSheetML As New Workbook(dataDir & "Book3.xml", loadOptions3)
            Console.WriteLine("SpreadSheetML file opened successfully!")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
