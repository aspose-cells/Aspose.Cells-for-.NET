Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetHeadersAndFooters
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim excel As New Workbook()

            ' Obtaining the reference of the PageSetup of the worksheet
            Dim pageSetup As PageSetup = excel.Worksheets(0).PageSetup

            ' Setting worksheet name at the left section of the header
            pageSetup.SetHeader(0, "&A")

            ' Setting current date and current time at the centeral section of the header
            ' and changing the font of the header
            pageSetup.SetHeader(1, "&""Times New Roman,Bold""&D-&T")

            ' Setting current file name at the right section of the header and changing the
            ' font of the header
            pageSetup.SetHeader(2, "&""Times New Roman,Bold""&12&F")

            ' Setting a string at the left section of the footer and changing the font
            ' of the footer
            pageSetup.SetFooter(0, "Hello World! &""Courier New""&14 123")

            ' Setting the current page number at the central section of the footer
            pageSetup.SetFooter(1, "&P")

            ' Setting page count at the right section of footer
            pageSetup.SetFooter(2, "&N")

            ' Save the Workbook.
            excel.Save(dataDir & Convert.ToString("SetHeadersAndFooters_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace
