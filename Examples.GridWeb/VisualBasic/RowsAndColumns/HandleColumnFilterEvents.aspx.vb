
Namespace RowsAndColumns
    Public Class HandleColumnFilterEvents
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

            Dim fileName As String = path + "\RowsAndColumns\Products.xlsx"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)
            GridWeb1.ActiveCell = GridWeb1.WorkSheets(0).Cells("A1")

            ' Access active worksheet
            Dim sheet = GridWeb1.WorkSheets(Me.GridWeb1.ActiveSheetIndex)

            ' Enable GridWeb's auto-filter.
            sheet.AddAutoFilter(0, 0, sheet.Cells.MaxDataColumn)
            sheet.RefreshFilter()

        End Sub

        ' ExStart:BeforeColumnFilter
        Protected Sub GridWeb1_BeforeColumnFilter(sender As Object, e As RowColumnEventArgs)
            ' Display the column index and filter applied
            Dim msg As String = "[Column Index]: " & (e.Num) & ", [Filter Value]: " & e.Argument
            Label1.Text = msg
        End Sub
        ' ExEnd:BeforeColumnFilter

        ' ExStart:AfterColumnFilter
        Protected Sub GridWeb1_AfterColumnFilter(sender As Object, e As RowColumnEventArgs)
            Dim hidden As String = ""
            Dim headrow As Integer = 0
            Dim maxrow As Integer = GridWeb1.WorkSheets(0).Cells.MaxRow
            Dim count As Integer = 0

            ' Iterate all worksheet rows to find out filtered rows
            Dim i As Integer = headrow + 1
            While i <= maxrow
                If GridWeb1.WorkSheets(0).Cells.Rows(i).Hidden Then
                    hidden += "-" + (i + 1)
                Else
                    count += 1
                End If
                i += 1
            End While

            ' Display hidden rows and visible rows count 
            Dim msg As String = "[Hidden Rows]: " & hidden & " [Visible Rows]: " & count
            Label1.Text = msg
        End Sub
        ' ExEnd:AfterColumnFilter

    End Class
End Namespace
