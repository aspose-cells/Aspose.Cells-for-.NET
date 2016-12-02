Imports System.IO

Namespace Articles
    Public Class AbsolutePathOfExternalDataSourceFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file containing the external link
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the first external link
            Dim externalLink As ExternalLink = wb.Worksheets.ExternalLinks(0)

            'Print the data source of external link, it will print existing remote path
            Console.WriteLine("External Link Data Source: " + externalLink.DataSource)

            ' Remove remote path and print new data source assign the new data source to external link and print again
            Dim newDataSource As String = Path.GetFileName(externalLink.DataSource)
            externalLink.DataSource = newDataSource
            Console.WriteLine("External Link Data Source After Removing Remote Path: " + externalLink.DataSource)

            ' Change the absolute path of the workbook, it will also change the external link path
            wb.AbsolutePath = "C:\Files\Extra\"

            ' Now print the data source again
            Console.WriteLine("External Link Data Source After Changing Workbook.AbsolutePath to Local Path: " + externalLink.DataSource)

            ' Change the absolute path of the workbook to some remote path, it will again affect the external link path
            wb.AbsolutePath = "http://www.aspose.com/WebFiles/ExcelFiles/"

            ' Now print the data source again
            Console.WriteLine("External Link Data Source After Changing Workbook.AbsolutePath to Remote Path: " + externalLink.DataSource)
            ' ExEnd:1
        End Sub
    End Class
End Namespace