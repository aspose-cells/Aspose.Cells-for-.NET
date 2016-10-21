Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing
Imports System.IO

Namespace Articles.ManagingVBAModules
    Public Class ExportVBACertificateToFile
        Public Shared Sub Run()
            ' ExStart:ExportVBACertificateToFile
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file into workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("sampleVBAProjectSigned.xlsm"))

            ' Retrieve bytes data of Digital Certificate of VBA Project
            Dim certBytes As Byte() = workbook.VbaProject.CertRawData

            ' Save Certificate Data into FileStream
            File.WriteAllBytes(dataDir & Convert.ToString("Cert_out_"), certBytes)
            ' ExEnd:ExportVBACertificateToFile
        End Sub
    End Class
End Namespace