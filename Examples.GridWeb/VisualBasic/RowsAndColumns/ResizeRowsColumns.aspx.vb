Imports Aspose.Cells.GridWeb.Data

Namespace RowsAndColumns
    Public Class ResizeRowsColumns
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0
            End If
        End Sub

        Private Sub LoadData()
            ' License li = new  License();
            ' li.SetLicense(@"D:\grid_project\ZZZZZZ_release_version\Aspose.Total.20141214.lic");

            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\RowsAndColumns\SampleData.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")
        End Sub

        Protected Sub btnSetColumnWidth_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' ExStart:SetColumnWidth
                ' Get column index entered by user
                Dim columnIndex As Integer = Convert.ToInt16(txtColumnIndex.Text.Trim())

                ' Get column width entered by user
                Dim columnWidth As Integer = Convert.ToInt16(txtColumnWidth.Text.Trim())

                ' Accessing the cells collection of the worksheet that is currently active
                Dim cells As GridCells = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex).Cells

                ' Resize column at specified index to specified width
                cells.SetColumnWidth(columnIndex, columnWidth)
                ' ExEnd:SetColumnWidth
            End If
        End Sub

        Protected Sub btnSetRowHeight_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' ExStart:SetRowHeight
                ' Get row index entered by user
                Dim rowIndex As Integer = Convert.ToInt16(txtRowIndex.Text.Trim())

                ' Get row height entered by user
                Dim rowHeight As Integer = Convert.ToInt16(txtRowHeight.Text.Trim())

                ' Accessing the cells collection of the worksheet that is currently active
                Dim cells As GridCells = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex).Cells

                ' Resize row at specified index to specified height
                cells.SetRowHeight(rowIndex, rowHeight)
                ' ExEnd:SetRowHeight
            End If
        End Sub

        Protected Sub btnReload_Click(sender As Object, e As EventArgs)
            LoadData()
        End Sub
    End Class
End Namespace
