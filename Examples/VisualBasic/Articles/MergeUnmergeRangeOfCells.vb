Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class MergeUnmergeRangeOfCellsExample
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create a workbook
            Dim workbook As New Workbook()

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Create a range
            Dim range As Range = worksheet.Cells.CreateRange("A1:D4")

            'Merge range into a single cell
            range.Merge()

            'Save the workbook
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1


        End Sub
    End Class
End Namespace