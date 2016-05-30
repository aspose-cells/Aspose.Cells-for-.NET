Imports System.IO

Imports Aspose.Cells

Namespace Files.Handling
    Public Class SaveInODSFormat
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a Workbook object
            Dim workbook As New Workbook()

            ' Save in ODS format
            workbook.Save(dataDir & "output.ods", SaveFormat.ODS)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
