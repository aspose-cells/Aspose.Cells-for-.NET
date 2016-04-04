Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class SaveXLSFile
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Load your source workbook
            Dim workbook As New Workbook()
            'Save in Excel2007 xlsx format
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1
        End Sub
    End Class
End Namespace
