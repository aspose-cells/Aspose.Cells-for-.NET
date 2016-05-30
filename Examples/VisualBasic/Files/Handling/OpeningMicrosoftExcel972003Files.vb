Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningMicrosoftExcel972003Files
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Get the Excel file into stream
            Dim stream As New FileStream(dataDir & "Book_Excel97_2003.xls", FileMode.Open)

            ' Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions1 As New LoadOptions(LoadFormat.Excel97To2003)

            ' Create a Workbook object and opening the file from the stream
            Dim wbExcel97 As New Workbook(stream, loadOptions1)
            Console.WriteLine("Microsoft Excel 97 - 2003 workbook opened successfully!")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
