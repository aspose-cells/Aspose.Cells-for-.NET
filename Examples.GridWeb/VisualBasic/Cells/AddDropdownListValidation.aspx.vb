Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddDropdownListValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddDropDownListValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddDropDownListValidation
            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell
            Dim cell As WebCell = sheet.Cells(0, 1)

            ' Putting value to "B1" cell
            cell.PutValue("Select Degree:")

            ' Accessing "C1" cell
            cell = sheet.Cells(0, 2)

            ' Creating DropDownList validation for the "C1" cell
            cell.CreateValidation(ValidationType.DropDownList, True)

            ' Adding values to DropDownList validation
            cell.Validation.ValueList.Add("Bachelor")
            cell.Validation.ValueList.Add("Master")
            cell.Validation.ValueList.Add("Doctor")
            ' ExEnd:AddDropDownListValidation
        End Sub
    End Class
End Namespace
