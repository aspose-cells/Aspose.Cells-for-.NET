Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing

Namespace Articles.ManagingVBAModules
    Public Class CheckVbaCodeIsSigned
        Public Shared Sub Run()
            ' ExStart:CheckVbaCodeIsSigned
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & Convert.ToString("sampleVBAProjectSigned.xlsm"))

            Console.WriteLine("Is VBA Code Project Signed: " + workbook.VbaProject.IsSigned)
            ' ExEnd:CheckVbaCodeIsSigned
        End Sub
    End Class
End Namespace