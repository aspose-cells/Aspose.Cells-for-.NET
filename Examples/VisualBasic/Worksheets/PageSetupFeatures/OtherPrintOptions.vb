Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class OtherPrintOptions
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the PageSetup of the worksheet
            Dim pageSetup As PageSetup = workbook.Worksheets(0).PageSetup

            ' Allowing to print gridlines
            pageSetup.PrintGridlines = True

            ' Allowing to print row/column headings
            pageSetup.PrintHeadings = True

            ' Allowing to print worksheet in black & white mode
            pageSetup.BlackAndWhite = True

            ' Allowing to print comments as displayed on worksheet
            pageSetup.PrintComments = PrintCommentsType.PrintInPlace

            ' Allowing to print worksheet with draft quality
            pageSetup.PrintDraft = True

            ' Allowing to print cell errors as N/A
            pageSetup.PrintErrors = PrintErrorsType.PrintErrorsNA

            ' Save the workbook.
            workbook.Save(dataDir & Convert.ToString("OtherPrintOptions_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace