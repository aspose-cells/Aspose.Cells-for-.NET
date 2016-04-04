Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Tables
    Public Class ConvertTableToRange
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Open an existing file that contains a table/list object in it
            Dim wb As New Workbook(dataDir & "book1.xlsx")

            'Convert the first table/list object (from the first worksheet) to normal range
            wb.Worksheets(0).ListObjects(0).ConvertToRange()

            'Save the file
            wb.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace