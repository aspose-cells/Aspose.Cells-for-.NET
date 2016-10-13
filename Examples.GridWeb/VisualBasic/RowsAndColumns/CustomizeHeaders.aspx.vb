Imports Aspose.Cells.GridWeb.Data

Namespace RowsAndColumns
    Public Class CustomizeHeaders
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Put user code to initialize the page here
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0

                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\RowsAndColumns\Headers.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")
        End Sub

        Protected Sub btnCreateCaption_Click(sender As Object, e As EventArgs)
            CreateRowCaptions()
            CreateColumnCaptions()

            ' Accessing the worksheet that is currently active
            Dim workSheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adjusts column width.
            Dim cells As GridCells = workSheet.Cells
            cells.SetColumnWidth(0, 20)
            cells.SetColumnWidth(1, 20)
            cells.SetColumnWidth(2, 20)
        End Sub

        Private Sub CreateColumnCaptions()
            ' ExStart:CustomizeColumnHeader
            ' Accessing the worksheet that is currently active
            Dim workSheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Creates custom column header caption.
            workSheet.SetColumnCaption(0, "Product")
            workSheet.SetColumnCaption(1, "Category")
            workSheet.SetColumnCaption(2, "Price")
            ' ExEnd:CustomizeColumnHeader
        End Sub

        Private Sub CreateRowCaptions()
            ' ExStart:CustomizeRowHeader
            ' Accessing the worksheet that is currently active
            Dim workSheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Create custom row header caption.
            workSheet.SetRowCaption(1, "Row1")
            workSheet.SetRowCaption(2, "Row2")
            ' ExEnd:CustomizeRowHeader
        End Sub
    End Class
End Namespace
