Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Formulas
    Public Class DirectCalculationFormula
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Put 20 in cell A1
            Dim cellA1 As Cell = worksheet.Cells("A1")
            cellA1.PutValue(20)

            ' Put 30 in cell A2
            Dim cellA2 As Cell = worksheet.Cells("A2")
            cellA2.PutValue(30)

            ' Calculate the Sum of A1 and A2
            Dim results = worksheet.CalculateFormula("=Sum(A1:A2)")

            ' Print the output
            System.Console.WriteLine("Value of A1: " & cellA1.StringValue)
            System.Console.WriteLine("Value of A2: " & cellA2.StringValue)
            System.Console.WriteLine("Result of Sum(A1:A2): " & results.ToString())
            ' ExEnd:1
        End Sub
    End Class
End Namespace