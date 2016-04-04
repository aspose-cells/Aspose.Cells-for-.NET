Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class OpeningMicrosoftExcel972003Files
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Get the Excel file into stream
            Dim stream As New FileStream(dataDir & "output.xls", FileMode.Open)

            'Instantiate LoadOptions specified by the LoadFormat.
            Dim loadOptions1 As New LoadOptions(LoadFormat.Excel97To2003)

            'Create a Workbook object and opening the file from the stream
            Dim wbExcel97 As New Workbook(stream, loadOptions1)
            Console.WriteLine("Microsoft Excel 97 - 2003 workbook opened successfully!")
            'ExEnd:1
        End Sub
    End Class
End Namespace
