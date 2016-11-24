Namespace Articles.PageSetupAndPrintingOptions
    Public Class SettingPrintingOptions
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the template workbook
            Dim workbook As New Workbook(dataDir & Convert.ToString("PageSetup.xlsx"))

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            Dim pageSetup As PageSetup = worksheet.PageSetup

            ' Specifying the cells range (from A1 cell to E30 cell) of the print area
            pageSetup.PrintArea = "A1:E30"

            ' Defining column numbers A & E as title columns
            pageSetup.PrintTitleColumns = "$A:$E"

            ' Defining row numbers 1 as title rows
            pageSetup.PrintTitleRows = "$1:$2"

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

            ' Setting the printing order of the pages to over then down
            pageSetup.Order = PrintOrderType.OverThenDown

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("PageSetup_Print_out.xlsx"))
            ' ExEnd:1
        End Sub

    End Class
End Namespace