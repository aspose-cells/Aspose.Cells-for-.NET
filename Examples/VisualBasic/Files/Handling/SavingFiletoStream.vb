Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class SavingFiletoStream
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "Book1.xlsx"

            ' Load your source workbook
            Dim workbook As New Workbook(filePath)
            Dim stream As New FileStream(dataDir & "output_out.xlsx", FileMode.CreateNew)
            workbook.Save(stream, New XlsSaveOptions(SaveFormat.Xlsx))
            stream.Close()

            ' ExEnd:1


        End Sub
    End Class
End Namespace
