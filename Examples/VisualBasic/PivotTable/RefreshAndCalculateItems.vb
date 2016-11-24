Imports System.IO
Imports Aspose.Cells.Pivot
Imports Aspose.Cells
Imports System.Drawing

Namespace PivotTableExamples
    Public Class RefreshAndCalculateItems
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load source excel file containing a pivot table having calculated items
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim sheet As Worksheet = wb.Worksheets(0)

            ' Change the value of cell D2
            sheet.Cells("D2").PutValue(20)

            ' Refresh and calculate all the pivot tables inside this sheet
            For Each pt As PivotTable In sheet.PivotTables
                pt.RefreshData()
                pt.CalculateData()
            Next

            ' Save the workbook in output pdf
            wb.Save(dataDir & Convert.ToString("RefreshAndCalculateItems_out.pdf"), SaveFormat.Pdf)
            ' ExEnd:1

        End Sub
    End Class
End Namespace
