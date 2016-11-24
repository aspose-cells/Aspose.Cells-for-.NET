Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManageChartsAndShapes
    Public Class RefreshValueOfLinkedShapes
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook from source file
            Dim workbook As New Workbook(dataDir & Convert.ToString("LinkedShape.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Change the value of cell A1
            Dim cell As Cell = worksheet.Cells("A1")
            cell.PutValue(100)

            ' Update the value of the Linked Picture which is linked to cell A1
            worksheet.Shapes.UpdateSelectedValue()

            ' Save the workbook in pdf format
            workbook.Save(dataDir & Convert.ToString("output_out.pdf"), SaveFormat.Pdf)
            ' ExEnd:1
        End Sub
    End Class
End Namespace