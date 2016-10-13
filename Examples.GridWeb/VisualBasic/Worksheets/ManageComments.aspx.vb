Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class ManageComments
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddComments_Click(sender As Object, e As EventArgs)
            ' ExStart:AddComments
            ' Accessing the reference of the worksheet that is currently active and add a dummy value to cell A1
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)
            sheet.Cells("A1").PutValue("This cell has a comment added, hover to view.")

            ' Resize first column
            sheet.Cells.SetColumnWidth(0, 140)

            ' Adding comment to "A1" cell of the worksheet
            Dim comment As GridComment = sheet.Comments(sheet.Comments.Add("A1"))

            ' Setting the comment note
            comment.Note = "These are my comments for the cell"
            ' ExEnd:AddComments
        End Sub

        Protected Sub btnUpdateComments_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessComments
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing a specific cell that contains comment
            Dim cell As GridCell = sheet.Cells("A1")

            ' Accessing the comment from the specific cell
            Dim comment As GridComment = sheet.Comments(cell.Name)

            If comment IsNot Nothing Then
                ' Modifying the comment note
                comment.Note = "I have modified the comment note."
            End If
            ' ExEnd:AccessComments
        End Sub

        Protected Sub btnRemoveComments_Click(sender As Object, e As EventArgs)
            ' ExStart:RemoveComments
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing a specific cell that contains comment
            Dim cell As GridCell = sheet.Cells("A1")

            ' Removing comment from the specific cell
            sheet.Comments.RemoveAt(cell.Name)
            ' ExEnd:RemoveComments
        End Sub
    End Class
End Namespace
