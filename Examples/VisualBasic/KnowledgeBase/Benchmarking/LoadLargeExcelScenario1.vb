Namespace KnowledgeBase.Benchmarking
    Public Class LoadLargeExcelScenario1
        ' ExStart:1
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                CreateAsposeCellsFile(dataDir & Convert.ToString("Sample.xls"), dataDir & Convert.ToString("output_out.xls"))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub CreateAsposeCellsFile(filename_in As String, filename_out As String)
            Dim start As DateTime = DateTime.Now
            Dim designerFile As String = filename_in
            Dim workbook As New Workbook(designerFile)
            For i As Integer = 0 To 99
                Dim ws As Worksheet = workbook.Worksheets(i)
                ws.Cells(0, 0).PutValue("Data" + i.ToString())
            Next
            workbook.Save(filename_out)
            Dim [end] As DateTime = DateTime.Now
            Dim time As TimeSpan = [end] - start
            Console.WriteLine("File Updated! " & vbLf + "Time consumed (Seconds): " + time.TotalSeconds.ToString())
        End Sub
        ' ExEnd:1
    End Class
End Namespace