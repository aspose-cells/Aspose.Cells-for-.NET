Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningSpreadsheetMLFiles
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Opening SpreadsheetML Files
            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions3 As New LoadOptions(LoadFormat.SpreadsheetML)

            'Create a Workbook object and opening the file from its path
            Dim wbSpreadSheetML As New Workbook(dataDir & "output.xml", loadOptions3)
            Console.WriteLine("SpreadSheetML file opened successfully!")
            'ExEnd:1
        End Sub
    End Class
End Namespace
