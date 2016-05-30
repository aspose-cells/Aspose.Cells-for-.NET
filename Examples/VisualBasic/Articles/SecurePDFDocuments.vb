Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class SecurePDFDocuments
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Open an Excel file
            Dim workbook As New Workbook(dataDir & "input.xlsx")

            ' Instantiate PDFSaveOptions to manage security attributes
            Dim saveOption As New PdfSaveOptions()

            saveOption.SecurityOptions = New Global.Aspose.Cells.Rendering.PdfSecurity.PdfSecurityOptions()
            ' Set the user password
            saveOption.SecurityOptions.UserPassword = "user"

            ' Set the owner password
            saveOption.SecurityOptions.OwnerPassword = "owner"

            ' Disable extracting content permission
            saveOption.SecurityOptions.ExtractContentPermission = False

            ' Disable print permission
            saveOption.SecurityOptions.PrintPermission = False

            ' Save the PDF document with encrypted settings
            workbook.Save(dataDir & "output.pdf", saveOption)
            ' ExEnd:1

        End Sub
    End Class
End Namespace