Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Data.Processing
    Public Class TracingPrecedents
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & "Book1.xlsx")
            Dim cells As Cells = workbook.Worksheets(0).Cells
            Dim cell As Cell = cells("B4")

            Dim ret As ReferredAreaCollection = cell.GetPrecedents()
            Dim area As ReferredArea = ret(0)
            Console.WriteLine(area.SheetName)
            Console.WriteLine(CellsHelper.CellIndexToName(area.StartRow, area.StartColumn))
            Console.WriteLine(CellsHelper.CellIndexToName(area.EndRow, area.EndColumn))
            'ExEnd:1
            Console.ReadKey()
        End Sub
    End Class
End Namespace
