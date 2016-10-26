Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class AccessWorksheets
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb1 and load data 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()
                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\GridWebBasics\SampleData.xls"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
        End Sub

        Protected Sub btnViewWorksheets_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessWorksheetUsingIndex
            ' Accessing a worksheet using its index
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(0)
            Label1.Text = "Sheet at index 0 is : " & sheet.Name & "<br/>"
            ' ExEnd:AccessWorksheetUsingIndex

            ' ExStart:AccessWorksheetUsingName
            ' Accessing a worksheet using its name
            Dim sheet1 As GridWorksheet = GridWeb1.WorkSheets("Catalog")
            Label1.Text += "Index of sheet  Catalog is : " & sheet1.Index & "<br/>"
            ' ExEnd:AccessWorksheetUsingName
        End Sub
    End Class
End Namespace
