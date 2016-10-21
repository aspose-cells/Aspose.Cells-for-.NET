Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing

Namespace Articles.ManagingVBAModules
    Public Class CheckVbaProjectSigned
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & Convert.ToString("Sample1.xlsx"))
            Console.WriteLine("VBA Project is Signed: " + workbook.VbaProject.IsSigned)
            ' ExEnd:1
        End Sub
    End Class
End Namespace