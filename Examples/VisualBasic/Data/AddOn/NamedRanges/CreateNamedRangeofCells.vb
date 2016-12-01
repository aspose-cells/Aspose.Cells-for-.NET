Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.AddOn.NamedRanges
    Public Class CreateNamedRangeofCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Creating a named range
            Dim range As Range = worksheet.Cells.CreateRange("B4", "G14")

            ' Setting the name of the named range
            range.Name = "TestRange"

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace