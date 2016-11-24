Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing
Imports System.Security.Cryptography.X509Certificates
Imports Aspose.Cells.DigitalSignatures

Namespace Articles.ManagingVBAModules
    Public Class DigitallySignVbaProjectWithCertificate
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("Book1.xlsm"))

            ' Please use System.Security.Cryptography.X509Certificates namespace for X509Certificate2 class
            Dim cert As New X509Certificate2(dataDir & Convert.ToString("SampleCert.pfx"), "1234")

            ' Create a Digital Signature
            Dim ds As New DigitalSignature(cert, "Signing Digital Signature using Aspose.Cells", DateTime.Now)

            ' Sign VBA Code Project with Digital Signature
            wb.VbaProject.Sign(ds)

            ' Save the workbook
            wb.Save(dataDir & Convert.ToString("DigitallySigned_out.xlsm"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace