
Namespace GridWebBasics
    Public Class ApplyEditModes
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0

                GridWeb1.ForceValidation = False
            End If
        End Sub

        Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
            If CheckBox1.Checked Then
                ' ExStart:ApplyEditMode
                ' Enabling the Edit Mode of GridWeb
                GridWeb1.EditMode = True
                ' ExEnd:ApplyEditMode
            Else
                ' ExStart:ApplyViewMode
                ' Enabling the View Mode of GridWeb
                GridWeb1.EditMode = False
                ' ExEnd:ApplyViewMode
            End If

            Panel2.Visible = GridWeb1.EditMode
            Panel3.Visible = GridWeb1.EditMode
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

        Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
            Dim row As Integer = Integer.Parse(Me.TextBox1.Text)
            GridWeb1.WorkSheets(0).SetRowReadonly(row, CheckBox2.Checked)

        End Sub

        Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
            Dim col As Integer = Integer.Parse(Me.TextBox2.Text)
            GridWeb1.WorkSheets(0).SetColumnReadonly(col, CheckBox3.Checked)
        End Sub
    End Class
End Namespace
