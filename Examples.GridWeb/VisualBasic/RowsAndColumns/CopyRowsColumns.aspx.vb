
Namespace RowsAndColumns
    Public Class CopyRowsColumns
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0

                Label1.Text = ""
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\RowsAndColumns\CopyData.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")
        End Sub

        Protected Sub btnCopyRow_Click(sender As Object, e As EventArgs)
            ' Set sheets selectedIndex to 0
            GridWeb1.WorkSheets.ActiveSheetIndex = 0

            ' ExStart:CopyRow
            ' Get the instance of active GridWorksheet
            Dim activeSheet = GridWeb1.ActiveSheet

            ' Copy first row to next row
            activeSheet.Cells.CopyRow(activeSheet.Cells, 0, 1)

            Label1.Text = "Row 1 copied to row 2 in worksheet " + activeSheet.Name
            ' ExEnd:CopyRow
        End Sub

        Protected Sub btnCopyMultipleRows_Click(sender As Object, e As EventArgs)
            ' Set sheets selectedIndex to 1
            GridWeb1.WorkSheets.ActiveSheetIndex = 1

            ' ExStart:CopyMultipleRows
            ' Get the instance of active GridWorksheet
            Dim activeSheet = GridWeb1.ActiveSheet

            ' Copy first 3 rows to 7th row
            activeSheet.Cells.CopyRows(activeSheet.Cells, 0, 6, 3)

            Label1.Text = "Rows 1 to 3 copied to rows 7 to 9 in worksheet " + activeSheet.Name
            ' ExEnd:CopyMultipleRows
        End Sub

        Protected Sub btnCopyColumn_Click(sender As Object, e As EventArgs)
            ' Set sheets selectedIndex to 2
            GridWeb1.WorkSheets.ActiveSheetIndex = 2

            ' ExStart:CopyColumn
            ' Get the instance of active GridWorksheet
            Dim activeSheet = GridWeb1.ActiveSheet

            ' Copy first column to next column
            activeSheet.Cells.CopyColumn(activeSheet.Cells, 0, 1)

            Label1.Text = "Column 1 copied to column 2 in worksheet " + activeSheet.Name
            ' ExEnd:CopyColumn
        End Sub

        Protected Sub btnCopyMultipleColumns_Click(sender As Object, e As EventArgs)
            ' Set sheets selectedIndex to 3
            GridWeb1.WorkSheets.ActiveSheetIndex = 3

            ' ExStart:CopyMultipleColumns
            ' Get the instance of active GridWorksheet
            Dim activeSheet = GridWeb1.ActiveSheet

            'Copy first 3 column to 7th column
            activeSheet.Cells.CopyColumns(activeSheet.Cells, 0, 6, 3)

            Label1.Text = "Columns 1 to 3 copied to columns 7 to 9 in worksheet " + activeSheet.Name
            ' ExEnd:CopyMultipleColumns
        End Sub

    End Class
End Namespace
