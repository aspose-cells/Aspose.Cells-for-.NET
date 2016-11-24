Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class ConvertXLSBToXLSM
        Public Shared Sub Run()
            ' ExStart:ConvertXLSBRevisionToXLSM
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open workbook
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsb"))

            ' Save Workbook to XLSM format
            workbook.Save(dataDir & Convert.ToString("output_out.xlsm"), SaveFormat.Xlsm)
            ' ExEnd:ConvertXLSBRevisionToXLSM
        End Sub
    End Class
End Namespace