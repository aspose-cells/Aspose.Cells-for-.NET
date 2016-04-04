Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningFilesThroughPath
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening through Path
            'Creating a Workbook object and opening an Excel file using its file path
            Dim workbook1 As New Workbook(dataDir & "Book1.xls")
            Console.WriteLine("Workbook opened using path successfully!")
            'ExEnd:1

        End Sub
    End Class
End Namespace
