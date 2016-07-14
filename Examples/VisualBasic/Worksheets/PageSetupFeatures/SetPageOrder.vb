Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetPageOrder
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the PageSetup of the worksheet
            Dim pageSetup As PageSetup = workbook.Worksheets(0).PageSetup

            ' Setting the printing order of the pages to over then down
            pageSetup.Order = PrintOrderType.OverThenDown

            ' Save the workbook.
            workbook.Save(dataDir & Convert.ToString("SetPageOrder_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace
