Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class SaveXLSXFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source workbook
            Dim workbook As New Workbook()

            ' Save in Excel2007 xlsx format
            workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)
            ' ExEnd:1


        End Sub
    End Class
End Namespace
