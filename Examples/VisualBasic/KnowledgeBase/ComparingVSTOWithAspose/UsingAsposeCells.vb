Namespace KnowledgeBase.ComparingVSTOWithAspose
    Public Class UsingAsposeCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim start As DateTime = DateTime.Now
            Dim myPath As String = dataDir & Convert.ToString("TempBook.xls")
            Dim workbook As New Workbook(myPath)
            Dim ws As Worksheet = workbook.Worksheets(0)

            For i As Integer = 0 To 999
                For j As Integer = 0 To 19
                    ws.Cells(i, j).PutValue("Row " + (i + 1).ToString() + " " + "Col " + (j + 1).ToString())
                Next
            Next

            workbook.Save(dataDir & Convert.ToString("TempBook1_out.xls"))
            Dim [end] As DateTime = DateTime.Now
            Dim time As TimeSpan = [end] - start
            Console.WriteLine("File Created! " + "Time consumed (Seconds): " + time.TotalSeconds.ToString())
            ' ExEnd:1
        End Sub
    End Class
End Namespace