Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class SaveFileInExcel972003format
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a Workbook object
            Dim workbook As New Workbook()

            'Your Code goes here for any workbook related operations

            'Save in Excel 97 – 2003 format
            workbook.Save(dataDir & "output.xls")

            'OR
            workbook.Save(dataDir & "output.xls", New XlsSaveOptions(SaveFormat.Excel97To2003))
            'ExEnd:1
        End Sub
    End Class
End Namespace
