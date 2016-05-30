Imports System.IO

Imports Aspose.Cells

Namespace Formulas
    Public Class ProcessDataUsingR1C1
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Setting an R1C1 formula on the "A11" cell, 
            ' Row and Column indeces are relative to destination index
            worksheet.Cells("A11").R1C1Formula = "=SUM(R[-10]C[0]:R[-7]C[0])"

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
