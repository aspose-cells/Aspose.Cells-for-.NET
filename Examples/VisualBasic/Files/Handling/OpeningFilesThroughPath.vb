Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningFilesThroughPath
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening through Path
            ' Creating a Workbook object and opening an Excel file using its file path
            Dim workbook1 As New Workbook(dataDir & "Book1.xlsx")
            Console.WriteLine("Workbook opened using path successfully!")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
