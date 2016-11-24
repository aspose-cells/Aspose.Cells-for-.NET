
Namespace Articles
    Public Class UsingCommonSubmitButton
        Inherits System.Web.UI.Page

        ' ExStart:UsingCommonSubmitButton
        ' Implementing Page_Load event handler
        Protected Sub Page_Load(sender As Object, e As EventArgs)
            ' Checking if there is no postback
            If Not IsPostBack Then
                ' Adding javascript function to onclick attribute of Button control
                SubmitButton.Attributes("onclick") = GridWeb1.ClientID + ".updateData(); if (" + GridWeb1.ClientID + ".validateAll()) return true; else return false;"
            End If
        End Sub
        ' ExEnd:UsingCommonSubmitButton

    End Class
End Namespace
