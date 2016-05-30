Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningMicrosoftExcel2007XlsxFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Opening Microsoft Excel 2007 Xlsx Files
            ' Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions2 As New LoadOptions(LoadFormat.Xlsx)

            ' Create a Workbook object and opening the file from its path
            Dim wbExcel2007 As New Workbook(dataDir & "Book_Excel2007.xlsx", loadOptions2)
            Console.WriteLine("Microsoft Excel 2007 workbook opened successfully!")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
