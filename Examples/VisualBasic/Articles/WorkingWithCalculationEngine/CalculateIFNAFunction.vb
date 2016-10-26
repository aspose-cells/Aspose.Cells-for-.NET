Imports System.IO
Imports System.Diagnostics
Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class CalculateIFNAFunction
        Public Shared Sub Run()
            ' ExStart:CalculateIFNAFunction
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create new workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add data for VLOOKUP
            worksheet.Cells("A1").PutValue("Apple")
            worksheet.Cells("A2").PutValue("Orange")
            worksheet.Cells("A3").PutValue("Banana")

            ' Access cell A5 and A6
            Dim cellA5 As Cell = worksheet.Cells("A5")
            Dim cellA6 As Cell = worksheet.Cells("A6")

            ' Assign IFNA formula to A5 and A6
            cellA5.Formula = "=IFNA(VLOOKUP(""Pear"",$A$1:$A$3,1,0),""Not found"")"
            cellA6.Formula = "=IFNA(VLOOKUP(""Orange"",$A$1:$A$3,1,0),""Not found"")"

            ' Caclulate the formula of workbook
            workbook.CalculateFormula()

            ' Print the values of A5 and A6
            Console.WriteLine(cellA5.StringValue)
            Console.WriteLine(cellA6.StringValue)
            ' ExEnd:CalculateIFNAFunction
        End Sub
    End Class
End Namespace