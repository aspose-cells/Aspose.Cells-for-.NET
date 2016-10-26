Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AccessCells
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit, load GridWeb data
            If Not Page.IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()
            Else
                Label1.Text = ""
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\Cells\Products.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")
        End Sub

        Protected Sub btnAccessCellValue_Click(sender As Object, e As EventArgs)
            AccessCellByName()
            AccessCellByRowColumnIndex()
        End Sub

        Private Sub AccessCellByName()
            ' ExStart:AccessCellByName
            ' Accessing the worksheet of the Grid that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell of the worksheet
            Dim cell As GridCell = sheet.Cells("A1")

            ' Display cell name and value
            Label1.Text &= "Cell Value of " & cell.Name & " is " & cell.StringValue & "<br/>"
            ' ExEnd:AccessCellByName
        End Sub

        Private Sub AccessCellByRowColumnIndex()
            ' ExStart:AccessCellByRowColumnIndex
            ' Accessing the worksheet of the Grid that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell of the worksheet using its row and column indices
            Dim cell As GridCell = sheet.Cells(0, 1)

            ' Display cell name and value
            Label1.Text &= "Cell Value of " & cell.Name & " is " & cell.StringValue & "<br/>"
            ' ExEnd:AccessCellByRowColumnIndex        
        End Sub
    End Class
End Namespace
