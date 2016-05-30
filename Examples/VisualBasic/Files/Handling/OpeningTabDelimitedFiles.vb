Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningTabDelimitedFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening Tab Delimited Files
            ' Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions5 As New LoadOptions(LoadFormat.TabDelimited)

            ' Create a Workbook object and opening the file from its path
            Dim wbTabDelimited As New Workbook(dataDir & "Book1TabDelimited.txt", loadOptions5)
            Console.WriteLine("Tab delimited file opened successfully!")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
