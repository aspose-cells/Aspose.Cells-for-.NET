Namespace KnowledgeBase.Benchmarking
    Public Class Creating50XLSFiles
        ' ExStart:1
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                CreateAsposeCellsFiles(dataDir & Convert.ToString("AsposeSample"))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub CreateAsposeCellsFiles(filename As String)
            Dim start As DateTime = DateTime.Now
            For wkb As Integer = 0 To 49
                Dim workbook As New Workbook()
                workbook.Worksheets.RemoveAt(0)
                For i As Integer = 0 To 4
                    Dim ws As Worksheet = workbook.Worksheets(workbook.Worksheets.Add())
                    ws.Name = i.ToString()
                    For row As Integer = 0 To 149
                        For col As Integer = 0 To 49
                            ws.Cells(row, col).PutValue("row" + row.ToString() + " col" + col.ToString())
                        Next
                    Next
                Next
                workbook.Save((filename & wkb.ToString()) + "_out.xls")
            Next
            Dim [end] As DateTime = DateTime.Now
            Dim time As TimeSpan = [end] - start
            Console.WriteLine("50 File(s) Created! " & vbLf + "Time consumed (Seconds): " + time.TotalSeconds.ToString())
        End Sub
        ' ExEnd:1
    End Class
End Namespace