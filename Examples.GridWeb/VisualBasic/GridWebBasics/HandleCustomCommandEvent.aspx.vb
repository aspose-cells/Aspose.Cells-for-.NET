Imports Aspose.Cells.GridWeb.Data

Namespace GridWebBasics
    Public Class HandleCustomCommandEvent
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InstantiateCustomCommandButton()
            End If
        End Sub

        Private Sub InstantiateCustomCommandButton()
            ' Instantiating a CustomCommandButton object
            Dim button As New CustomCommandButton()

            ' Setting the command for button
            button.Command = "MyButton"

            ' Setting text of the button
            button.Text = "MyButton"

            ' Setting image URL of the button, should be relative to website root folder
            button.ImageUrl = "../Image/aspose.ico"

            ' Adding button to CustomCommandButtons collection of GridWeb
            GridWeb1.CustomCommandButtons.Add(button)
        End Sub

        ' ExStart:HandleCustomCommandEvent
        ' Creating Event Handler for CustomCommand event
        Protected Sub GridWeb1_CustomCommand(ByVal sender As Object, ByVal command As String)
            ' Identifying a specific button by checking its command
            If command.Equals("MyButton") Then
                ' Accessing the cells collection of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Putting value to "A1" cell
                sheet.Cells("A1").PutValue("My Custom Command Button is Clicked.")

                ' Set first column width to make the text visible
                sheet.Cells.SetColumnWidth(0, 30)
            End If
        End Sub
        ' ExEnd:HandleCustomCommandEvent

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
            Response.[End]()
        End Sub
    End Class
End Namespace
