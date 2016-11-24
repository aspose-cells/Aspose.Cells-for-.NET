Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingRowsColumnsCells
    Public Class PopulateDataEfficiently
        Public Shared Sub Run()
            ' ExStart:PopulateDataFirstByRowThenColumns
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook
            Dim workbook As New Workbook()

            ' Populate Data into Cells
            Dim cells As Cells = workbook.Worksheets(0).Cells
            cells("A1").PutValue("data1")
            cells("B1").PutValue("data2")
            cells("A2").PutValue("data3")
            cells("B2").PutValue("data4")

            ' Save workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:PopulateDataFirstByRowThenColumns
        End Sub
    End Class
End Namespace