Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class ModifyCells
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
            ' Clear GridWeb 
            GridWeb1.WorkSheets.Clear()

            ' Add a new sheet by name and put some info text in cells
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets.Add("Modify-Cells")
            Dim cells As GridCells = sheet.Cells
            cells("A1").PutValue("String Value:")
            cells("A3").PutValue("Int Value:")
            cells("A5").PutValue("Double Value:")

            cells.SetColumnWidth(0, 30)
            cells.SetColumnWidth(1, 20)
        End Sub

        Protected Sub btnModifyCellValue_Click(sender As Object, e As EventArgs)
            AddStringValue()
            AddIntValue()
            AddDoubleValue()
        End Sub

        Private Sub AddStringValue()
            ' ExStart:AddCellStringValue
            ' Accessing the worksheet of the Grid that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B1" cell of the worksheet
            Dim cell As GridCell = sheet.Cells("B1")

            ' Accessing the string value of "B1" cell
            Label1.Text = cell.StringValue

            ' Modifying the string value of "B1" cell
            cell.PutValue("Hello Aspose.Grid")
            ' ExEnd:AddCellStringValue
        End Sub

        Private Sub AddIntValue()
            ' ExStart:AddCellIntValue
            ' Accessing the worksheet of the Grid that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B3" cell of the worksheet
            Dim cell As GridCell = sheet.Cells("B3")

            ' Putting a value in "B3" cell
            cell.PutValue(30)
            ' ExEnd:AddCellIntValue
        End Sub

        Private Sub AddDoubleValue()
            ' ExStart:AddCellDoubleValue
            ' Accessing the worksheet of the Grid that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing "B5" cell of the worksheet
            Dim cell As GridCell = sheet.Cells("B5")

            ' Putting a numeric value as string in "B5" cell that will be converted to a suitable data type automatically
            cell.PutValue("19.4", True)
            ' ExEnd:AddCellDoubleValue
        End Sub

    End Class
End Namespace
