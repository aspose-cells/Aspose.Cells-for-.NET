
Namespace GridWebBasics
    Public Class ApplyCustomPresetStyle
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

            ' Imports from a excel file.
            GridWeb1.ImportExcelFile(fileName)
        End Sub

        Protected Sub btnSaveCustomStyle_Click(sender As Object, e As EventArgs)
            ' ExStart:SaveCustomStyle
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

            ' Setting the background color of tabs to Yellow
            GridWeb1.TabStyle.BackColor = System.Drawing.Color.Yellow

            ' Setting the foreground color of tabs to Blue
            GridWeb1.TabStyle.ForeColor = System.Drawing.Color.Blue

            ' Setting the background color of active tab to Blue
            GridWeb1.ActiveTabStyle.BackColor = System.Drawing.Color.Blue

            ' Setting the foreground color of active tab to Yellow
            GridWeb1.ActiveTabStyle.ForeColor = System.Drawing.Color.Yellow

            ' Saving style information to an XML file
            GridWeb1.SaveCustomStyleFile(TryCast(Me.Master, Site).GetDataDir() + "\GridWebBasics\CustomPresetStyle_out_.xml")
            ' ExEnd:SaveCustomStyle

            lblMessage.Text = "Custom style xml file saved successfully at Data/GridWebBasics/CustomPresetStyle_out_.xml"
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

        Protected Sub btnApplyCustomStyle_Click(sender As Object, e As EventArgs)
            ' ExStart:LoadCustomStyle
            ' Setting the PresetStyle of the control to Custom
            GridWeb1.PresetStyle = PresetStyle.[Custom]

            ' Setting the path of style file to load style information from this file to the control
            GridWeb1.CustomStyleFileName = TryCast(Me.Master, Site).GetDataDir() + "\GridWebBasics\CustomStyle1.xml"
            ' ExEnd:LoadCustomStyle
        End Sub

    End Class
End Namespace
