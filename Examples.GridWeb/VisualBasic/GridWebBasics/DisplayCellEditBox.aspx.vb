
Namespace GridWebBasics
    Public Class DisplayCellEditBox
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
            If CheckBox1.Checked Then
                ' ExStart:DisplayCellEditBox
                ' Making the Edit Box (toolbar) visible for the GridWeb control
                GridWeb1.ShowCellEditBox = True
                ' ExEnd:DisplayCellEditBox
            Else
                ' Hide the Edit Box (toolbar) for the GridWeb control
                GridWeb1.ShowCellEditBox = False
            End If
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
