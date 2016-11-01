Namespace Articles.ManagingWorkbooksWorksheets
    Public Class GetApplicationVersion
        Public Shared Sub Run()
            ' ExStart:1
            ' Create a workbook reference
            Dim workbook As Workbook = Nothing

            ' Print the version number of Excel 2003 XLS file
            workbook = New Workbook("Excel2003.xls")
            Console.WriteLine("Excel 2003 XLS Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2007 XLS file
            workbook = New Workbook("Excel2007.xls")
            Console.WriteLine("Excel 2007 XLS Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2010 XLS file
            workbook = New Workbook("Excel2010.xls")
            Console.WriteLine("Excel 2010 XLS Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2013 XLS file
            workbook = New Workbook("Excel2013.xls")
            Console.WriteLine("Excel 2013 XLS Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2007 XLSX file
            workbook = New Workbook("Excel2007.xlsx")
            Console.WriteLine("Excel 2007 XLSX Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2010 XLSX file
            workbook = New Workbook("Excel2010.xlsx")
            Console.WriteLine("Excel 2010 XLSX Version: " + workbook.BuiltInDocumentProperties.Version)

            ' Print the version number of Excel 2013 XLSX file
            workbook = New Workbook("Excel2013.xlsx")
            Console.WriteLine("Excel 2013 XLSX Version: " + workbook.BuiltInDocumentProperties.Version)
            ' ExEnd:1
        End Sub
    End Class
End Namespace