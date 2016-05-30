Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles

    Public Class FindIfCellValueStartsWithSingleQuote
        Public Shared Sub Run()

            ' ExStart:FindIfCellValueStartsWithSingleQuote
            
            ' Create workbook
            Dim wb As New Workbook()

            ' Create worksheet
            Dim sheet As Worksheet = wb.Worksheets(0)

            ' Access cell A1 and A2
            Dim a1 As Cell = sheet.Cells("A1")
            Dim a2 As Cell = sheet.Cells("A2")

            ' Add sample in A1 and sample with quote prefix in A2
            a1.PutValue("sample")
            a2.PutValue("' Sample")

            ' Print their string values, A1 and A2 both are same
            Console.WriteLine("String value of A1: " & a1.StringValue)
            Console.WriteLine("String value of A2: " & a2.StringValue)

            ' Access styles of A1 and A2
            Dim s1 As Style = a1.GetStyle()
            Dim s2 As Style = a2.GetStyle()

            Console.WriteLine()

            ' Check if A1 and A2 has a quote prefix
            Console.WriteLine("A1 has a quote prefix: " & s1.QuotePrefix)
            Console.WriteLine("A2 has a quote prefix: " & s2.QuotePrefix)

            ' ExEnd:FindIfCellValueStartsWithSingleQuote

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()

        End Sub
    End Class
End Namespace
