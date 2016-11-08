
Namespace GridWebBasics
    Public Class InitCustomCommandButton
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnInitCommandButton_Click(sender As Object, e As EventArgs)
            ' ExStart:InitCustomCommandButton
            ' Instantiating a CustomCommandButton object
            Dim button As New CustomCommandButton()

            ' Setting the command, text and image URL for button. Image should be relative to website root folder
            button.Command = "MyButton"
            button.Text = "MyButton"
            button.ImageUrl = "../Image/aspose.ico"

            ' Adding button to CustomCommandButtons collection of GridWeb
            GridWeb1.CustomCommandButtons.Add(button)
            ' ExEnd:InitCustomCommandButton
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
            Response.[End]()
        End Sub
    End Class
End Namespace
