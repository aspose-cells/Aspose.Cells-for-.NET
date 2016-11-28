
Namespace GridWebBasics
    Public Class ImportExportFile
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()
            End If
        End Sub

        Private Sub LoadData()
            ' License li = new  License();
            ' li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            ' ExStart:LoadExcelFile
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\GridWebBasics\SampleData.xls"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            ' ExEnd:LoadExcelFile
        End Sub

        ' Handles the load file button click event and load an excel file from disk
        Protected Sub btnLoadExcelFile_Click(sender As Object, e As EventArgs)
            LoadData()
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
            ' ExStart:SaveExcelFile
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
            ' ExEnd:SaveExcelFile
        End Sub
    End Class
End Namespace
