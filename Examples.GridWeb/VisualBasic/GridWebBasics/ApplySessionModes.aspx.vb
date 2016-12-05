
Namespace GridWebBasics
    Public Class ApplySessionModes
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0

                GridWeb1.ForceValidation = False

                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\GridWebBasics\SampleData.xls"

            '  Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
        End Sub

        Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
            If CheckBox1.Checked Then
                ' ExStart:ApplySesionMode
                ' Enabling the Session Mode of GridWeb
                GridWeb1.SessionMode = SessionMode.Session
                ' ExEnd:ApplySesionMode
            Else
                ' ExStart:ApplySesionlessMode
                ' Enabling the Sessionless Mode of GridWeb
                GridWeb1.SessionMode = SessionMode.ViewState
                ' ExEnd:ApplySesionlessMode
            End If
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
            Response.[End]()
        End Sub
    End Class
End Namespace
