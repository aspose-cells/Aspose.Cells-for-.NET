Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.AddOn.Merging
    Public Class UnMergingtheMergedCells
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a Workbook.
            'Open the excel file.
            Dim wbk As Workbook = New Global.Aspose.Cells.Workbook(dataDir & "mergingcells.xls")

            'Create a Worksheet and get the first sheet.
            Dim worksheet As Worksheet = wbk.Worksheets(0)

            'Create a Cells object ot fetch all the cells.
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells

            'Unmerge the cells.
            cells.UnMerge(5, 2, 2, 3)

            'Save the file.
            wbk.Save(dataDir & "unmergingcells.xls")


        End Sub
    End Class
End Namespace