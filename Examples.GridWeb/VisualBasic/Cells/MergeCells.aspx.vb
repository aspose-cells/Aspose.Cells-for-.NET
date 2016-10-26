Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class MergeCells
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub chkMergeCells_CheckedChanged(sender As Object, e As EventArgs)
            If chkMergeCells.Checked Then
                ' ExStart:MergeCells
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Merging cells starting from the cell with 3rd row and 3rd column. 
                ' 2 rows and 2 columns will be merged from the starting cell
                sheet.Cells.Merge(2, 2, 2, 2)
                ' ExEnd:MergeCells

                Label1.Text = "2 rows and 2 columns are merged starting from row 3 and column 3"
            Else
                ' ExStart:UnmergeCells
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Unmerging cells starting from the cell with 3rd row and 3rd column. 
                ' 2 rows and 2 columns will be unmerged from the starting cell
                sheet.Cells.UnMerge(2, 2, 2, 2)
                ' ExEnd:UnmergeCells

                Label1.Text = "2 rows and 2 columns are unmerged starting from row 3 and column 3"
            End If
        End Sub
    End Class
End Namespace
