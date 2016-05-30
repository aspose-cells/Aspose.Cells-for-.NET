Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Formatting.ConfiguringAlignmentSettings
    Public Class MergingCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Accessing the "A1" cell from the worksheet
            Dim cell As Global.Aspose.Cells.Cell = worksheet.Cells("A1")

            ' Adding some value to the "A1" cell
            cell.PutValue("Visit Aspose!")

            ' Merging the first three columns in the first row to create a single cell
            worksheet.Cells.Merge(0, 0, 1, 3)


            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)
            ' ExEnd:1
        End Sub
    End Class
End Namespace