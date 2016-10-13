Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddListValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddListValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddListValidation
            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell
            Dim cell As WebCell = sheet.Cells(0, 1)

            ' Putting value to "B1" cell
            cell.PutValue("Select Course:")

            ' Accessing "C1" cell
            cell = sheet.Cells(0, 2)

            ' Creating List validation for the "C1" cell
            cell.CreateValidation(ValidationType.List, True)

            ' Adding values to List validation
            cell.Validation.ValueList.Add("Fortran")
            cell.Validation.ValueList.Add("Pascal")
            cell.Validation.ValueList.Add("C++")
            cell.Validation.ValueList.Add("Visual Basic")
            cell.Validation.ValueList.Add("Java")
            cell.Validation.ValueList.Add("C#")
            ' ExEnd:AddListValidation 
        End Sub
    End Class
End Namespace
