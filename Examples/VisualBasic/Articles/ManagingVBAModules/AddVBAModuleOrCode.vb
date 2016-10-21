Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports Aspose.Cells.Drawing

Namespace Articles.ManagingVBAModules
    Public Class AddVBAModuleOrCode
        Public Shared Sub Run()
            ' ExStart:AddVBAModuleOrCode
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create new workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add VBA Module
            Dim idx As Integer = workbook.VbaProject.Modules.Add(worksheet)

            ' Access the VBA Module, set its name and codes
            Dim [module] As Aspose.Cells.Vba.VbaModule = workbook.VbaProject.Modules(idx)
            [module].Name = "TestModule"

            [module].Codes = "Sub ShowMessage()" + vbCr & vbLf + "    MsgBox ""Welcome to Aspose!""" + vbCr & vbLf + "End Sub"

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsm"), SaveFormat.Xlsm)
            ' ExEnd:AddVBAModuleOrCode
        End Sub
    End Class
End Namespace