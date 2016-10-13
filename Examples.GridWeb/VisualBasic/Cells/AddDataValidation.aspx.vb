Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddDataValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddDataValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddDataValidation
            ' Access first worksheet
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(0)

            ' Access cell B3
            Dim cell As GridCell = sheet.Cells("B3")

            ' Add validation inside the gridcell
            ' Any value which is not between 20 and 40 will cause error in a gridcell
            Dim val As GridValidation = cell.CreateValidation(GridValidationType.WholeNumber, True)
            val.Formula1 = "=20"
            val.Formula2 = "=40"
            val.[Operator] = GridOperatorType.Between
            val.ShowError = True
            val.ShowInput = True
            ' ExEnd:AddDataValidation

            Label1.Text = "Data Validation is added in cell B3. Any value which is not between 20 and 40 will cause error."
        End Sub
    End Class
End Namespace
