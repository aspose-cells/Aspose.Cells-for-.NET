
Namespace GridWebBasics
    Public Class GetGridWebVersion
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnGetGridWebVersion_Click(sender As Object, e As EventArgs)
            ' ExStart:GetGridWebVersion
            ' Find version of GridWeb and display in label.
            Dim version As String = Aspose.Cells.GridWeb.GridWeb.GetVersion()
            Label1.Text = "GridWeb Version: " + version
            ' ExEnd:GetGridWebVersion
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
            ' ExStart:SaveExcelFile
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
            ' ExEnd:SaveExcelFile
        End Sub
    End Class
End Namespace