Imports Aspose.Cells.GridWeb.Data

Namespace RowsAndColumns
    Public Class AddRowsColumns
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                LoadData()

                ' Set sheets active index to 0
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

        Protected Sub btnAddColumn_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' ExStart:AddColumn
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Get column index entered by user
                Dim columnIndex As Integer = Convert.ToInt16(txtColumnIndex.Text.Trim())

                ' Add column at specified index
                sheet.Cells.InsertColumn(columnIndex)
                ' ExEnd:AddColumn
            End If
        End Sub

        Protected Sub btnAddRow_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' ExStart:AddRow
                'Accessing the reference of the worksheet that is currently active
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Get row index entered by user
                Dim rowIndex As Integer = Convert.ToInt16(txtRowIndex.Text.Trim())

                ' Add row at specified index
                sheet.Cells.InsertRow(rowIndex)
                ' ExEnd:AddRow            
            End If
        End Sub

        Protected Sub btnReload_Click(sender As Object, e As EventArgs)
            LoadData()
        End Sub
    End Class
End Namespace
