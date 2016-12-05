Namespace KnowledgeBase.Benchmarking
    Public Class CreateAnExcelFileFiveSheets
        ' ExStart:1
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                CreateAsposeCellsFile(dataDir & Convert.ToString("ACellsSample_out.xls"))
            Catch ex As Exception
                Console.WriteLine("Error: " + ex.Message)
            End Try
        End Sub

        Private Shared Sub CreateAsposeCellsFile(filename As String)
            Dim start As DateTime = DateTime.Now
            Dim workbook As New Workbook()
            workbook.Worksheets.RemoveAt(0)
            For i As Integer = 0 To 4
                Dim ws As Worksheet = workbook.Worksheets(workbook.Worksheets.Add())
                ws.Name = i.ToString()
                For row As Integer = 0 To 149
                    For col As Integer = 0 To 55
                        ws.Cells(row, col).PutValue("row" + row.ToString() + " col" + col.ToString())
                    Next
                Next
            Next
            workbook.Save(filename)
            Dim [end] As DateTime = DateTime.Now
            Dim time As TimeSpan = [end] - start
            Console.WriteLine("File Created! " & vbLf + "Time consumed (Seconds): " + time.TotalSeconds.ToString())
        End Sub
        ' ExEnd:1
    End Class
End Namespace