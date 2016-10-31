Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class ProtectCells
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Label1.Text = ""
        End Sub

        Protected Sub chkAllCells_CheckedChanged(sender As Object, e As EventArgs)
            chkSelectedCells.Checked = False

            If chkAllCells.Checked Then
                ' ExStart:MakeAllCellsEditable
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Setting all cells of the worksheet to Editable
                sheet.SetAllCellsEditable()
                ' ExEnd:MakeAllCellsEditable

                Label1.Text = "All cells are editable now."
            Else
                ' ExStart:MakeAllCellsReadOnly
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Setting all cells of the worksheet to Readonly
                sheet.SetAllCellsReadonly()
                ' ExEnd:MakeAllCellsReadOnly

                Label1.Text = "All cells are readonly now."
            End If
        End Sub

        Protected Sub chkSelectedCells_CheckedChanged(sender As Object, e As EventArgs)
            chkAllCells.Checked = False

            If chkSelectedCells.Checked Then
                ' ExStart:MakeSelectedCellsEditable
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Setting all cells of the worksheet to Readonly first
                sheet.SetAllCellsReadonly()

                ' Finally, Setting selected cells of the worksheet to Editable
                sheet.SetEditableRange(3, 2, 4, 1)
                ' ExEnd:MakeSelectedCellsEditable

                Label1.Text = "4 rows and 1 column are editable starting from row 4 and column 3"
            Else
                ' ExStart:MakeSelectedCellsReadOnly
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Setting all cells of the worksheet to Editable first
                sheet.SetAllCellsEditable()

                ' Finally, Setting selected cells of the worksheet to Readonly
                sheet.SetReadonlyRange(3, 2, 4, 1)
                ' ExEnd:MakeSelectedCellsReadOnly

                Label1.Text = "4 rows and 1 column are readonly starting from row 4 and column 3"
            End If
        End Sub
    End Class
End Namespace
