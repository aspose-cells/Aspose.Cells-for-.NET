Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Data.AddOn.NamedRanges
    Public Class RenameNamedRange
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open an existing Excel file that has a (global) named range "TestRange" in it
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Get the first worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Get the Cells of the sheet
            Dim cells As Global.Aspose.Cells.Cells = sheet.Cells

            ' Get the named range "MyRange"
            Dim name As Name = workbook.Worksheets.Names("TestRange")

            ' Rename it
            name.Text = "NewRange"

            ' Save the Excel file
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1
        End Sub
    End Class
End Namespace