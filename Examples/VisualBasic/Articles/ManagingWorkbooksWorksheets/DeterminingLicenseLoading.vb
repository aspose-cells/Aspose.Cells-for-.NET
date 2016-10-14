Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class DeterminingLicenseLoading
        Public Shared Sub Run()
            ' ExStart:DeterminingLicenseLoading
            ' The path to the License File
            Dim licPath As String = "Aspose.Cells.lic"

            ' Create workbook object before setting a license
            Dim workbook As New Workbook()

            ' Check if the license is loaded or not. It will return false
            Console.WriteLine(workbook.IsLicensed)

            Try
                Dim lic As New Aspose.Cells.License()
                lic.SetLicense(licPath)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            ' Check if the license is loaded or not. Now it will return true
            Console.WriteLine(workbook.IsLicensed)
            ' ExEnd:DeterminingLicenseLoading
        End Sub
    End Class
End Namespace