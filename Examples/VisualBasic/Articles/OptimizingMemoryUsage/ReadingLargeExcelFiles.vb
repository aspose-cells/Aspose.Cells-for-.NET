Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.OptimizingMemoryUsage
    Public Class ReadingLargeExcelFiles
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Specify the LoadOptions
            Dim opt As New LoadOptions()
            'Set the memory preferences
            opt.MemorySetting = MemorySetting.MemoryPreference

            'Instantiate the Workbook
            'Load the Big Excel file having large Data set in it
            Dim wb As New Workbook(dataDir & "Book1.out.xlsx", opt)

        End Sub
    End Class
End Namespace