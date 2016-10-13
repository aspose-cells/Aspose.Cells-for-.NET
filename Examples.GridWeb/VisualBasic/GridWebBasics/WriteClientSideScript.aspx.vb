Imports Aspose.Cells.GridWeb.Data

Namespace GridWebBasics
    Public Class WriteClientSideScript
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page init GridWeb
            If Not Page.IsPostBack Then
                ' Initialize GridWeb 
                InitGridWeb()
            End If
        End Sub

        Private Sub InitGridWeb()
            ' ExStart:WriteClientSideScript
            ' Assigning the name of JavaScript function to OnSubmitClientFunction property of GridWeb
            GridWeb1.OnSubmitClientFunction = "ConfirmFunction"

            ' Assigning the name of JavaScript function to OnValidationErrorClientFunction property of GridWeb
            GridWeb1.OnValidationErrorClientFunction = "ValidationErrorFunction"

            ' Accessing the cells collection of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell
            Dim cell As WebCell = sheet.Cells(0, 1)

            ' Putting value to "B1" cell
            cell.PutValue("Date (yyyy-mm-dd):")

            ' Accessing "C1" cell
            cell = sheet.Cells(0, 2)

            ' Creating a custom expression validation for the "C1" cell
            cell.CreateValidation(ValidationType.CustomExpression, True)

            ' Setting regular expression for the validation to accept dates in yyyy-mm-dd format
            cell.Validation.RegEx = "\d{4}-\d{2}-\d{2}"
            ' ExEnd:WriteClientSideScript
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
            ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out_.xls"

            Dim path As String = TryCast(Me.Master, Site).GetDataDir() + "\GridWebBasics\"

            ' Saves to the file.
            Me.GridWeb1.SaveToExcelFile(path + filename)

            ' Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment; filename=" + filename)
            Response.WriteFile(path + filename)
            Response.End()
        End Sub
    End Class
End Namespace
