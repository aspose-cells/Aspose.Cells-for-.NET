Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningFilesThroughStream
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Opening through Stream
            'Create a Stream object
            Dim fstream As New FileStream(dataDir & "Book2.xls", FileMode.Open)

            'Creating a Workbook object, open the file from a Stream object
            'that contains the content of file and it should support seeking
            Dim workbook2 As New Workbook(fstream)
            Console.WriteLine("Workbook opened using stream successfully!")
            fstream.Close()
            'ExEnd:1
        End Sub
    End Class
End Namespace
