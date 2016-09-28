Imports System.IO
Imports System.Diagnostics
Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class DecreaseCalculationTime
        Public Shared Sub Run()
            ' ExStart:1
            ' Test calculation time after setting recursive true
            TestCalcTimeRecursive(True)

            ' Test calculation time after setting recursive false
            TestCalcTimeRecursive(False)
            ' ExEnd:1           

        End Sub
        ' ExStart:TestCalcTimeRecursive
        Private Shared Sub TestCalcTimeRecursive(rec As Boolean)
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Load your sample workbook
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Set the calculation option, set recursive true or false as per parameter
            Dim opts As New CalculationOptions()
            opts.Recursive = rec

            ' Start stop watch            
            Dim sw As New Stopwatch()
            sw.Start()

            ' Calculate cell A1 one million times
            For i As Integer = 0 To 999999
                ws.Cells("A1").Calculate(opts)
            Next

            ' Stop the watch
            sw.[Stop]()

            ' Calculate elapsed time in seconds
            Dim second As Long = 1000
            Dim estimatedTime As Long = sw.ElapsedMilliseconds / second

            ' Print the elapsed time in seconds
            Console.WriteLine("Recursive " + rec.ToString() + ": " + estimatedTime.ToString() + " seconds")

        End Sub
        ' ExEnd:TestCalcTimeRecursive
    End Class
End Namespace