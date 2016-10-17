Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class SearchDataUsingOriginalValues
        Public Shared Sub Run()
            ' ExStart:SearchDataUsingOriginalValues
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add 10 in cell A1 and A2
            worksheet.Cells("A1").PutValue(10)
            worksheet.Cells("A2").PutValue(10)

            ' Add Sum formula in cell D4 but customize it as ---
            Dim cell As Cell = worksheet.Cells("D4")

            Dim style As Style = cell.GetStyle()
            style.[Custom] = "---"
            cell.SetStyle(style)

            ' The result of formula will be 20 but 20 will not be visible because the cell is formated as ---
            cell.Formula = "=Sum(A1:A2)"

            ' Calculate the workbook
            workbook.CalculateFormula()

            ' Create find options, we will search 20 using original values otherwise 20 will never be found because it is formatted as ---
            Dim options As New FindOptions()
            options.LookInType = LookInType.OriginalValues
            options.LookAtType = LookAtType.EntireContent

            Dim foundCell As Cell = Nothing
            Dim obj As Object = 20

            ' Find 20 which is Sum(A1:A2) and formatted as ---
            foundCell = worksheet.Cells.Find(obj, foundCell, options)

            ' Print the found cell
            Console.WriteLine(foundCell)

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:SearchDataUsingOriginalValues
        End Sub
    End Class
End Namespace