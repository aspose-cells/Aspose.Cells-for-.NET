Namespace Articles
        ' ExStart:1
    Public Class GetWarningsForFontSubstitution
        Implements IWarningCallback
        Public Sub Warning(info As WarningInfo) Implements IWarningCallback.Warning
            If info.WarningType = WarningType.FontSubstitution Then
                Debug.WriteLine("WARNING INFO: " + info.Description)
            End If
        End Sub

        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            Dim options As New PdfSaveOptions()
            options.WarningCallback = New GetWarningsForFontSubstitution()
            dataDir = dataDir & Convert.ToString("output_out_.pdf")
            workbook.Save(dataDir, options)
        End Sub
    End Class
    ' ExEnd:1
End Namespace