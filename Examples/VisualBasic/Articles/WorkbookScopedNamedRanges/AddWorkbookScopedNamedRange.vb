Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.WorkbookScopedNamedRanges
    Public Class AddWorkbookScopedNamedRange
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a new Workbook object
            Dim workbook As New Workbook()

            ' Get first worksheet of the workbook
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Get worksheet' S cells collection
            Dim cells As Global.Aspose.Cells.Cells = sheet.Cells

            ' Create a range of Cells from Cell A1 to C10
            Dim workbookScope As Range = cells.CreateRange("A1", "C10")

            ' Assign the nsame to workbook scope named range
            workbookScope.Name = "workbookScope"

            ' Save the workbook
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace