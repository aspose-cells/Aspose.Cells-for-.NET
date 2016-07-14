Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetMargins
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook object
            Dim workbook As New Workbook()

            ' Get the worksheets in the workbook
            Dim worksheets As WorksheetCollection = workbook.Worksheets

            ' Get the first (default) worksheet
            Dim worksheet As Worksheet = worksheets(0)

            ' Get the pagesetup object
            Dim pageSetup As PageSetup = worksheet.PageSetup

            ' Set bottom,left,right and top page margins
            pageSetup.BottomMargin = 2
            pageSetup.LeftMargin = 1
            pageSetup.RightMargin = 1
            pageSetup.TopMargin = 3

            ' Save the Workbook.
            workbook.Save(dataDir & Convert.ToString("SetMargins_out.xls"))
            ' ExEnd:1
        End Sub
        Public Shared Sub CenterOnPage()
            ' ExStart:CenterOnPage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook object
            Dim workbook As New Workbook()

            ' Get the worksheets in the workbook
            Dim worksheets As WorksheetCollection = workbook.Worksheets

            ' Get the first (default) worksheet
            Dim worksheet As Worksheet = worksheets(0)

            ' Get the pagesetup object
            Dim pageSetup As PageSetup = worksheet.PageSetup

            ' Specify Center on page Horizontally and Vertically
            pageSetup.CenterHorizontally = True
            pageSetup.CenterVertically = True

            ' Save the Workbook.
            workbook.Save(dataDir & Convert.ToString("CenterOnPage_out.xls"))
            ' ExEnd:CenterOnPage
        End Sub
        Public Shared Sub HeaderAndFooterMargins()
            ' ExStart:HeaderAndFooterMargins
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook object
            Dim workbook As New Workbook()

            ' Get the worksheets in the workbook
            Dim worksheets As WorksheetCollection = workbook.Worksheets

            ' Get the first (default) worksheet
            Dim worksheet As Worksheet = worksheets(0)

            ' Get the pagesetup object
            Dim pageSetup As PageSetup = worksheet.PageSetup

            ' Specify Header / Footer margins
            pageSetup.HeaderMargin = 2
            pageSetup.FooterMargin = 2

            ' Save the Workbook.
            workbook.Save(dataDir & Convert.ToString("CenterOnPage_out.xls"))
            ' ExEnd:HeaderAndFooterMargins
        End Sub
    End Class
End Namespace
