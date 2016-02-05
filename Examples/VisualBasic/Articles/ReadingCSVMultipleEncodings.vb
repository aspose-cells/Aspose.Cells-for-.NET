Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class ReadingCSVMultipleEncodings
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "MultiEncoded.csv"

            'Set Multi Encoded Property to True
            Dim options As New TxtLoadOptions()
            options.IsMultiEncoded = True

            'Load the CSV file into Workbook
            Dim workbook As New Workbook(filePath, options)

            'Save it in XLSX format
            workbook.Save(filePath & ".out.xlsx", SaveFormat.Xlsx)
        End Sub
    End Class
End Namespace