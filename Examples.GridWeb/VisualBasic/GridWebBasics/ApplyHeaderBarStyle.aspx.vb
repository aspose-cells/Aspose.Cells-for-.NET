
Namespace GridWebBasics
    Public Class ApplyHeaderBarStyle
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

        Protected Sub btnApplyHeaderStyle_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyHeaderBarStyle
            ' Setting the background color of the header bars
            GridWeb1.HeaderBarStyle.BackColor = System.Drawing.Color.Brown

            ' Setting the foreground color of the header bars
            GridWeb1.HeaderBarStyle.ForeColor = System.Drawing.Color.Yellow

            ' Setting the font of the header bars to bold
            GridWeb1.HeaderBarStyle.Font.Bold = True

            ' Setting the font name to "Century Gothic"
            GridWeb1.HeaderBarStyle.Font.Name = "Century Gothic"

            ' Setting the border width to 2 points
            GridWeb1.HeaderBarStyle.BorderWidth = New Unit(2, UnitType.Point)
            ' ExEnd:ApplyHeaderBarStyle
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
