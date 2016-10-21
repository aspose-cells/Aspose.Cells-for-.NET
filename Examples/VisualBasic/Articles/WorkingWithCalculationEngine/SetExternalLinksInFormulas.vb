Imports System.IO
Imports Aspose.Cells

Namespace Articles.WorkingWithCalculationEngine
    Public Class SetExternalLinksInFormulas
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook.
            Dim workbook As New Workbook()

            ' Get first Worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Get Cells collection
            Dim cells As Cells = sheet.Cells

            ' Set formula with external links
            cells("A1").Formula = (Convert.ToString((Convert.ToString("=SUM('[") & dataDir) + "book1.xlsx]Sheet1'!A2, '[") & dataDir) + "book1.xlsx]Sheet1'!A4)"

            ' Set formula with external links
            cells("A2").Formula = (Convert.ToString("='[") & dataDir) + "book1.xlsx]Sheet1'!A8"

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output.out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace