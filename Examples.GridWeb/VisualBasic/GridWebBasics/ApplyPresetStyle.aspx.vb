
Namespace GridWebBasics
    Public Class ApplyPresetStyle
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

        ' Handles the preset style dropdown list changing event
        Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs)

            ' Changes the preset style using built in style thats The Aspose.Cells.GridWeb provides.
            Select Case DropDownList1.SelectedValue
                Case "Standard"
                    'Applying Standard style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Standard
                    Exit Select
                Case "Colorful1"
                    ' ExStart:ApplyPresetStyle
                    ' Applying Colorful1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Colorful1
                    ' ExEnd:ApplyPresetStyle
                    Exit Select
                Case "Colorful2"
                    ' Applying Colorful2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Colorful2
                    Exit Select
                Case "Professional1"
                    ' Applying Professional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional1
                    Exit Select
                Case "Professional2"
                    ' Applying Professional2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Professional2
                    Exit Select
                Case "Traditional1"
                    ' Applying Traditional1 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Traditional1
                    Exit Select
                Case "Traditional2"
                    ' Applying Traditional2 style on the GridWeb control
                    GridWeb1.PresetStyle = PresetStyle.Traditional2
                    Exit Select
                Case Else
                    GridWeb1.PresetStyle = PresetStyle.Standard
                    Exit Select
            End Select
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
