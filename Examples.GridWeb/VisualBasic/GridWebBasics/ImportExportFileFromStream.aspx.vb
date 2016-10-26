Imports System.IO

Namespace GridWebBasics
    Public Class ImportExportFileFromStream
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

            ' ExStart:LoadExcelFileFromStream
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\GridWebBasics\SampleData.xls"

            ' Opening an Excel file as a stream
            Dim fs As FileStream = File.OpenRead(fileName)

            ' Loading the Excel file contents into the control from a stream
            GridWeb1.ImportExcelFile(fs)

            ' Closing stream
            fs.Close()
            ' ExEnd:LoadExcelFileFromStream
        End Sub

        ' Handles the load file button click event and load an excel file from disk
        Protected Sub btnLoadExcelFile_Click(sender As Object, e As EventArgs)
            LoadData()
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

        Protected Sub btnSaveUsingStream_Click(sender As Object, e As EventArgs)
            ' ExStart:SaveExcelFileUsingStream
            ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out.xls"

            Dim path As String = TryCast(Me.Master, Site).GetDataDir() + "\GridWebBasics\"

            Dim fs As FileStream = File.Create(path + filename)

            ' Saving Grid content of the control to a stream
            GridWeb1.SaveToExcelFile(fs)

            ' Closing stream
            fs.Close()

            ' Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment; filename=" + filename)
            Response.WriteFile(path + filename)
            Response.[End]()
            ' ExEnd:SaveExcelFileUsingStream
        End Sub

    End Class
End Namespace
