Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AddListValidation
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnAddListValidation_Click(sender As Object, e As EventArgs)
            ' ExStart:AddListValidation
            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell
            Dim cell As GridCell = sheet.Cells(0, 1)

            ' Putting value to "B1" cell
            cell.PutValue("Select Course:")

            ' Accessing "C1" cell
            cell = sheet.Cells(0, 2)

            ' Creating List validation for the "C1" cell
            Dim validation = cell.CreateValidation(GridValidationType.List, True)

            ' Adding values to List validation
            Dim values = New System.Collections.Specialized.StringCollection()
            values.Add("Fortran")
            values.Add("Pascal")
            values.Add("C++")
            values.Add("Visual Basic")
            values.Add("Java")
            values.Add("C#")
            validation.ValueList = values
            ' ExEnd:AddListValidation 
        End Sub
    End Class
End Namespace
