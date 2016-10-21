Imports Aspose.Cells
Imports Aspose.Cells.Vba
Imports System.IO

Namespace Articles.ManagingVBAModules
    Public Class ModifyingVBAOrMacroCode
        Public Shared Sub Run()
            ' ExStart:ModifyingVBAOrMacroCode
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsm"))

            ' Change the VBA Module Code
            For Each [module] As VbaModule In workbook.VbaProject.Modules
                Dim code As String = [module].Codes

                ' Replace the original message with the modified message
                If code.Contains("This is test message.") Then
                    code = code.Replace("This is test message.", "This is Aspose.Cells message.")
                    [module].Codes = code
                End If
            Next

            ' Save the output Excel file
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsm"))
            ' ExEnd:ModifyingVBAOrMacroCode
        End Sub
    End Class
End Namespace