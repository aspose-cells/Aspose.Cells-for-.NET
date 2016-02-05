Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Vba

Namespace Aspose.Cells.Examples.Articles
    Public Class CheckVbaProjectSigned
        Shared Sub Main()
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)
            Console.WriteLine("VBA Project is Signed: " & workbook.VbaProject.IsSigned)
        End Sub
    End Class
End Namespace
