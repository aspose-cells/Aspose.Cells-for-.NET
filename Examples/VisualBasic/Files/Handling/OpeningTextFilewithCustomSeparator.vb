Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningTextFilewithCustomSeparator
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "Book11.csv"

            ' Instantiate Text File' S LoadOptions
            Dim txtLoadOptions As New TxtLoadOptions()

            ' Specify the separator
            txtLoadOptions.Separator = Convert.ToChar(",")

            ' Specify the encoding type
            txtLoadOptions.Encoding = System.Text.Encoding.UTF8

            ' Create a Workbook object and opening the file from its path
            Dim wb As New Workbook(filePath, txtLoadOptions)

            ' Save file
            wb.Save(dataDir & "output.txt")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
