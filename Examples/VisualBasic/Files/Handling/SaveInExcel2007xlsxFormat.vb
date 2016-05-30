Imports System.IO

Imports Aspose.Cells

Namespace Files.Handling
    Public Class SaveInExcel2007xlsxFormat
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a Workbook object
            Dim workbook As New Workbook()

            ' Save in Excel2007 xlsx format
            workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
