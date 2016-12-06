Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection

Namespace KnowledgeBase.ComparingVSTOWithAspose
    Public Class VSTOCode
        Public Shared Sub Run()
            Try
                ' ExStart:1
                ' The path to the documents directory.
                Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

                Dim start As DateTime = DateTime.Now
                Dim excelApp As Excel.Application = New Application()
                Dim myPath As String = dataDir & Convert.ToString("TempBook.xls")
                excelApp.Workbooks.Open(myPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, _
                 Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, _
                 Missing.Value, Missing.Value, Missing.Value)

                For i As Integer = 1 To 1000
                    For j As Integer = 1 To 20
                        excelApp.Cells(i, j) = "Row " + i.ToString() + " " + "Col " + j.ToString()
                    Next
                Next

                excelApp.Save(dataDir & Convert.ToString("TempBook1_out.xls"))
                excelApp.Quit()
                Dim [end] As DateTime = DateTime.Now
                Dim time As TimeSpan = [end] - start
                ' ExEnd:1
                Console.WriteLine("File Created! " + "Time consumed (Seconds): " + time.TotalSeconds.ToString())
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub
    End Class
End Namespace