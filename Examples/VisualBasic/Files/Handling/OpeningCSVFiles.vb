Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningCSVFiles
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions4 As New LoadOptions(LoadFormat.CSV)

            'Create a Workbook object and opening the file from its path
            Dim wbCSV As New Workbook(dataDir & "output.csv", loadOptions4)
            Console.WriteLine("CSV file opened successfully!")
            'ExEnd:1
        End Sub
    End Class
End Namespace
