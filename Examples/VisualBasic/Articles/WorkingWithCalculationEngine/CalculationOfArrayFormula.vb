Imports System.IO
Imports System.Diagnostics
Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class CalculationOfArrayFormula
        Public Shared Sub Run()
            ' ExStart:CalculateArrayFormula
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("DataTable.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' When you will put 100 in B1, then all Data Table values formatted as Yellow will become 120
            worksheet.Cells("B1").PutValue(100)

            ' Calculate formula, now it also calculates Data Table array formula
            workbook.CalculateFormula()

            ' Save the workbook in pdf format
            workbook.Save(dataDir & Convert.ToString("output_out.pdf"))
            ' ExEnd:CalculateArrayFormula
        End Sub
    End Class
End Namespace