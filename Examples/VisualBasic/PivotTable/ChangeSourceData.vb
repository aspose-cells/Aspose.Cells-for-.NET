Imports System.IO
Imports Aspose.Cells
Imports System.Drawing

Namespace PivotTableExamples
    Public Class ChangeSourceData
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim InputPath As String = dataDir & "Book1.xlsx"

            ' Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(InputPath, FileMode.Open)

            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Populating new data to the worksheet cells
            worksheet.Cells("A9").PutValue("Golf")
            worksheet.Cells("B9").PutValue("Qtr4")
            worksheet.Cells("C9").PutValue(7000)

            ' Changing named range "DataSource"
            Dim range As Range = worksheet.Cells.CreateRange(0, 0, 9, 3)
            range.Name = "DataSource"

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")

            ' Closing the file stream to free all resources
            fstream.Close()
            ' ExEnd:1

        End Sub
    End Class
End Namespace
