Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningTabDelimitedFiles
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening Tab Delimited Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions5 As New LoadOptions(LoadFormat.TabDelimited)

            'Create a Workbook object and opening the file from its path
            Dim wbTabDelimited As New Workbook(dataDir & "output.txt", loadOptions5)
            Console.WriteLine("Tab delimited file opened successfully!")
            'ExEnd:1
        End Sub
    End Class
End Namespace
