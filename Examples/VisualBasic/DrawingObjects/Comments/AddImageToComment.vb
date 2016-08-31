Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace DrawingObjects.Comments
    Public Class AddImageToComment
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiate a Workbook
            Dim workbook As New Workbook()

            ' Get a reference of comments collection with the first sheet
            Dim comments As CommentCollection = workbook.Worksheets(0).Comments

            ' Add a comment to cell A1
            Dim commentIndex As Integer = comments.Add(0, 0)
            Dim comment As Comment = comments(commentIndex)
            comment.Note = "First note."
            comment.Font.Name = "Times New Roman"

            ' Load an image into stream
            Dim bmp As New Bitmap(dataDir & "logo.jpg")
            Dim ms As New MemoryStream()
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

            ' Set image data to the shape associated with the comment
            comment.CommentShape.Fill.ImageData = ms.ToArray()

            ' Save the workbook
            workbook.Save(dataDir & "output.xlsx", Global.Aspose.Cells.SaveFormat.Xlsx)
            ' ExEnd:1

        End Sub
    End Class
End Namespace