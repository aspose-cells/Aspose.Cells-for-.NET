Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddDropdownListValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddDropDownListValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddDropDownListValidation
            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Access "B1" cell and add some text
            Dim cell As GridCell = sheet.Cells(0, 1)
            cell.PutValue("Select Degree:")

            ' Accessing "C1" cell
            cell = sheet.Cells(0, 2)

            ' Creating DropDownList validation for the "C1" cell
            Dim validation = cell.CreateValidation(GridValidationType.DropDownList, True)

            ' Adding values to DropDownList validation
            Dim values = New System.Collections.Specialized.StringCollection()
            values.Add("Bachelor")
            values.Add("Master")
            values.Add("Doctor")
            validation.ValueList = values
            ' ExEnd:AddDropDownListValidation
        End Sub
    End Class
End Namespace
