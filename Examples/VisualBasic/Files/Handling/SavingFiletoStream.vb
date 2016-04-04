Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class SavingFiletoStream
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "Book1.xlsx"

            'Load your source workbook
            Dim workbook As New Workbook(filePath)
            Dim stream As New FileStream(dataDir & "output.xlsx", FileMode.CreateNew)
            workbook.Save(stream, New XlsSaveOptions(SaveFormat.Xlsx))
            stream.Close()

            'ExEnd:1


        End Sub
    End Class
End Namespace
