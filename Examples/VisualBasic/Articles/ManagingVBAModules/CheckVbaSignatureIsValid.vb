Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing

Namespace Articles.ManagingVBAModules
    Public Class CheckVbaSignatureIsValid
        Public Shared Sub Run()
            ' ExStart:CheckVbaSignatureIsValid
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & Convert.ToString("sampleVBAProjectSigned.xlsm"))

            ' Signature is valid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned)

            ' Modify the VBA Code, save the workbook then reload
            ' VBA Code Signature will now be invalid
            Dim code As String = workbook.VbaProject.Modules(1).Codes
            code = code.Replace("Welcome to Aspose", "Welcome to Aspose.Cells")
            workbook.VbaProject.Modules(1).Codes = code

            ' Save
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsm"))

            ' Reload
            workbook = New Workbook(dataDir & Convert.ToString("output_out_.xlsm"))

            ' Now the signature is invalid
            Console.WriteLine("Is VBA Code Project Valid Signed: " + workbook.VbaProject.IsValidSigned)
            ' ExEnd:CheckVbaSignatureIsValid
        End Sub
    End Class
End Namespace