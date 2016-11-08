Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddCustomValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddCustomValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddCustomValidation
            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Access "B1" cell and add some text
            Dim cell As GridCell = sheet.Cells(0, 1)
            cell.PutValue("Date (yyyy-mm-dd):")

            ' Accessing "C1" cell and add to it custom expression validation to accept dates in yyyy-mm-dd format
            cell = sheet.Cells(0, 2)
            Dim validation = cell.CreateValidation(ValidationType.CustomExpression, True)
            validation.RegEx = "\d{4}-\d{2}-\d{2}"
            ' ExEnd:AddCustomValidation

            sheet.Cells.SetColumnWidth(1, 30)

            ' Assigning the name of JavaScript function to OnValidationErrorClientFunction property of GridWeb
            GridWeb1.OnValidationErrorClientFunction = "ValidationErrorFunction"
        End Sub
    End Class
End Namespace
