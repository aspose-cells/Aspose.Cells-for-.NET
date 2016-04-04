Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class SaveInSpreadsheetMLFormat
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a Workbook object
            Dim workbook As New Workbook()
            'Save in SpreadsheetML format
            workbook.Save(dataDir & "output.xml", SaveFormat.SpreadsheetML)
            'ExEnd:1
        End Sub
    End Class
End Namespace
