Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class ReadingCSVMultipleEncodings
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "MultiEncoded.csv"

            ' Set Multi Encoded Property to True
            Dim options As New TxtLoadOptions()
            options.IsMultiEncoded = True

            ' Load the CSV file into Workbook
            Dim workbook As New Workbook(filePath, options)

            ' Save it in XLSX format
            workbook.Save(filePath & "output.xlsx", SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace