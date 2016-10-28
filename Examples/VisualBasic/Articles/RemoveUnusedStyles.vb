Namespace Articles
    Public Class RemoveUnusedStyles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load template excel file containing unused styles
            Dim workbook As New Workbook(dataDir & Convert.ToString("Template-With-Unused-Custom-Style.xlsx"))

            ' Remove all unused styles inside the template this will also remove AsposeStyle which is an unused style inside the template
            workbook.RemoveUnusedStyles()

            ' Save the file
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace