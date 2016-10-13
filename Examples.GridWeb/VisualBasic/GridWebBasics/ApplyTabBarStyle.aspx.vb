
Namespace GridWebBasics
    Public Class ApplyTabBarStyle
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\GridWebBasics\Skins.xls"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
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

        Protected Sub btnApplyTabBarStyle_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyTabBarStyle
            ' Setting the background color of tabs to Yellow
            GridWeb1.TabStyle.BackColor = System.Drawing.Color.Yellow

            ' Setting the foreground color of tabs to Blue
            GridWeb1.TabStyle.ForeColor = System.Drawing.Color.Blue

            ' Setting the background color of active tab to Blue
            GridWeb1.ActiveTabStyle.BackColor = System.Drawing.Color.Blue

            ' Setting the foreground color of active tab to Yellow
            GridWeb1.ActiveTabStyle.ForeColor = System.Drawing.Color.Yellow
            ' ExEnd:ApplyTabBarStyle
        End Sub
    End Class
End Namespace
