Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.DrawingObjects.Comments
    Public Class AddingComment
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Workbook object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            'Adding a comment to "F5" cell
            Dim commentIndex As Integer = worksheet.Comments.Add("F5")

            'Accessing the newly added comment
            Dim comment As Comment = worksheet.Comments(commentIndex)

            'Setting the comment note
            comment.Note = "Hello Aspose!"

            'Saving the Excel file
            workbook.Save(dataDir & "book1.out.xls")

        End Sub
    End Class
End Namespace