Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Vba

Namespace Articles
    Public Class CheckVbaProjectSigned
        Public Shared Sub Run()
            ' ExStart:1
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample1.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)
            Console.WriteLine("VBA Project is Signed: " & workbook.VbaProject.IsSigned)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
