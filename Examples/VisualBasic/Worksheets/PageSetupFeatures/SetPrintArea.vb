Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetPrintArea
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the PageSetup of the worksheet
            Dim pageSetup As PageSetup = workbook.Worksheets(0).PageSetup

            ' Specifying the cells range (from A1 cell to T35 cell) of the print area
            pageSetup.PrintArea = "A1:T35"

            ' Save the workbook.
            workbook.Save(dataDir & Convert.ToString("SetPrintArea_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace