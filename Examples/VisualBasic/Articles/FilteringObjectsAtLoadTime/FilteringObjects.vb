Namespace Articles.FilteringObjectsAtLoadTime
    Friend Class FilteringObjects
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Filter charts from the workbook
            Dim lOptions As New LoadOptions()
            lOptions.LoadFilter = New LoadFilter(LoadDataFilterOptions.All And (Not LoadDataFilterOptions.Chart))

            ' Load the workbook with above filter
            Dim workbook As New Workbook(dataDir & "sampleFilterCharts.xlsx", lOptions)

            ' Save worksheet to a single PDF page
            Dim pOptions As New PdfSaveOptions()
            pOptions.OnePagePerSheet = True

            ' Save the workbook in pdf format
            workbook.Save(dataDir & "sampleFilterCharts.pdf", pOptions)
            ' ExEnd:1

        End Sub
    End Class
End Namespace