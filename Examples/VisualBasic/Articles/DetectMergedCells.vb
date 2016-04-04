Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Collections

Namespace Aspose.Cells.Examples.Articles
    Public Class DetectMergedCells
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook
            'Open an existing excel file
            Dim wkBook As New Workbook(dataDir & "SampleInput.xlsx")
            'Get a worksheet in the workbook
            Dim wkSheet As Worksheet = wkBook.Worksheets("Sheet2")
            'Clear its contents
            wkSheet.Cells.Clear()

            'Create an arraylist object
            Dim al As New ArrayList()
            'Get the merged cells list to put it into the arraylist object
            al = wkSheet.Cells.MergedCells
            'Define cellarea
            Dim ca As CellArea
            'Define some variables
            Dim frow, fcol, erow, ecol, trows, tcols As Integer
            'Loop through the arraylist and get each cellarea
            'to unmerge it
            For i As Integer = 0 To al.Count - 1
                ca = New CellArea()
                ca = CType(al(i), CellArea)
                frow = ca.StartRow
                fcol = ca.StartColumn
                erow = ca.EndRow
                ecol = ca.EndColumn

                trows = erow - frow + 1
                tcols = ecol - fcol + 1
                wkSheet.Cells.UnMerge(frow, fcol, trows, tcols)

            Next i

            'Save the excel file
            wkBook.Save(dataDir & "output.xlsx")
            'ExEnd:1


        End Sub
    End Class
End Namespace