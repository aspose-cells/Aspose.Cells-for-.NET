Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class OdsFileSaveOptions
        Public Shared Sub Run()
            ' ExStart:SaveODSFileinODF11and12Specifications
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Put some value in cell A1
            Dim cell As Cell = worksheet.Cells("A1")
            cell.PutValue("Welcome to Aspose!")

            ' Save ODS in ODF 1.2 version which is default
            Dim options As New OdsSaveOptions()
            workbook.Save(dataDir & Convert.ToString("ODF1.2_out_.ods"), options)

            ' Save ODS in ODF 1.1 version
            options.IsStrictSchema11 = True
            workbook.Save(dataDir & Convert.ToString("ODF1.1_out_.ods"), options)
            ' ExEnd:SaveODSFileinODF11and12Specifications
        End Sub
    End Class
End Namespace