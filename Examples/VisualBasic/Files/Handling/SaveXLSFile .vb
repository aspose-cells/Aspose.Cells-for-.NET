Imports System.IO
Imports System.Web
Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class SaveXLSFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim Respose As HttpResponse = Nothing
            ' Load your source workbook
            Dim workbook As New Workbook()
            If Respose IsNot Nothing Then
                ' Save in Excel2007 xlsx format
                workbook.Save(Respose, dataDir + "output.xls", ContentDisposition.Inline, New XlsSaveOptions())
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace
