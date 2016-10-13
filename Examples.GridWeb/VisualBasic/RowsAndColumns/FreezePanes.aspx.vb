Imports Aspose.Cells.GridWeb.Data

Namespace RowsAndColumns
    Public Class FreezePanes
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page clear GridWeb and load data
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then

                GridWeb1.WorkSheets.Add()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0

                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\RowsAndColumns\FreezePane.xls"

            '  Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")
        End Sub

        Protected Sub btnFreeze_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' ExStart:FreezePanes
                ' Get user inputs for row, column, number of rows and number of columns
                Dim row As Integer = Convert.ToInt16(txtRow.Text.Trim())
                Dim column As Integer = Convert.ToInt16(txtColumn.Text.Trim())
                Dim noOfRows As Integer = Convert.ToInt16(txtNoOfRows.Text.Trim())
                Dim noOfColumns As Integer = Convert.ToInt16(txtNoOfColumns.Text.Trim())

                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Freeze desired rows and columns
                sheet.FreezePanes(row, column, noOfRows, noOfColumns)
                ' ExEnd:FreezePanes
            End If
        End Sub

        Protected Sub btnUnfreeze_Click(sender As Object, e As EventArgs)
            ' ExStart:UnfreezePanes
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Unfreezing rows and columns
            sheet.UnFreezePanes()
            ' ExEnd:UnfreezePanes
        End Sub
    End Class
End Namespace
