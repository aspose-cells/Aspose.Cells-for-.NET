Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class GetValidationAppliedOnCell
        Public Shared Sub Run()
            ' ExStart:GetValidationAppliedOnCell
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate the workbook from sample Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access its first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Cell C1 has the Decimal Validation applied on it. It can take only the values Between 10 and 20
            Dim cell As Cell = worksheet.Cells("C1")

            ' Access the valditation applied on this cell
            Dim validation As Validation = cell.GetValidation()

            ' Read various properties of the validation
            Console.WriteLine("Reading Properties of Validation")
            Console.WriteLine("--------------------------------")
            Console.WriteLine("Type: " + validation.Type)
            Console.WriteLine("Operator: " + validation.[Operator])
            Console.WriteLine("Formula1: " + validation.Formula1)
            Console.WriteLine("Formula2: " + validation.Formula2)
            Console.WriteLine("Ignore blank: " + validation.IgnoreBlank)
            ' ExEnd:GetValidationAppliedOnCell
        End Sub
    End Class
End Namespace