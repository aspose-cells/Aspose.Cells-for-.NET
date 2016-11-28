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
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell and add some text
            Dim cell As GridCell = sheet.Cells(0, 1)
            cell.PutValue("Date (yyyy-mm-dd):")

            ' Accessing "C1" cell and add to it custom expression validation to accept dates in yyyy-mm-dd format
            cell = sheet.Cells(0, 2)
            Dim validation = cell.CreateValidation(ValidationType.CustomExpression, True)
            validation.RegEx = "\d{4}-\d{2}-\d{2}"
            ' ExEnd:WriteClientSideScript
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
            ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out.xls"

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
