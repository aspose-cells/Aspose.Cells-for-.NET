Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.Processing.FilteringAndValidation
    Public Class AutofilterData
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Creating AutoFilter by giving the cells range of the heading row
            worksheet.AutoFilter.Range = "A1:B1"

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace