Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.DigitalSignatures
Imports System.Security.Cryptography.X509Certificates

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class AssignAndValidateDigitalSignatures
        Public Shared Sub Run()
            ' ExStart:AssignAndValidateDigitalSignatures
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' dsc is signature collection contains one or more signature needed to sign
            Dim dsc As New DigitalSignatureCollection()

            ' Cert must contain private key, it can be contructed from cert file or windows certificate collection. aa is password of cert
            Dim cert As New X509Certificate2(dataDir & Convert.ToString("mykey2.pfx"), "aa")
            Dim ds As New DigitalSignature(cert, "test for sign", DateTime.Now)
            dsc.Add(ds)
            Dim wb As New Workbook()

            ' wb.SetDigitalSignature signs all signatures in dsc
            wb.SetDigitalSignature(dsc)
            wb.Save(dataDir & Convert.ToString("newfile_out.xlsx"))

            ' open the file
            wb = New Workbook(dataDir & Convert.ToString("newfile_out.xlsx"))
            System.Console.WriteLine(wb.IsDigitallySigned)

            ' Get digitalSignature collection from workbook
            dsc = wb.GetDigitalSignature()
            For Each dst As DigitalSignature In dsc
                System.Console.WriteLine(dst.Comments)
                'test for sign -OK
                System.Console.WriteLine(dst.SignTime)
                '11/25/2010 1:22:01 PM -OK
                'True -OK
                System.Console.WriteLine(dst.IsValid)
            Next
            ' ExEnd:AssignAndValidateDigitalSignatures
        End Sub
    End Class
End Namespace