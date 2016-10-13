Imports Aspose.Cells.GridWeb.Data
Imports System.Data.OleDb
Imports System.Drawing

Namespace Worksheets
    Public Class ImportDataView
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            'if first visit this page clear GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                GridWeb1.WorkSheets.Clear()
                GridWeb1.WorkSheets.Add()

                'set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0
            End If
        End Sub

        ' Handles the "import" button click event and load data from a dataview object.
        Protected Sub Button1_Click(sender As Object, e As EventArgs)
            ' ExStart:ImportDataView
            ' Connect database
            Dim oleDbConnection1 As System.Data.OleDb.OleDbConnection = New OleDbConnection()
            Dim oleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter = New OleDbDataAdapter()
            Dim oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand = New OleDbCommand()
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()
            oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\Worksheets\Database\Northwind.mdb"
            oleDbSelectCommand1.Connection = oleDbConnection1
            oleDbDataAdapter1.SelectCommand = oleDbSelectCommand1

            Dim dataTable1 As New DataTable()
            dataTable1.Reset()

            ' Queries database.
            Try
                oleDbSelectCommand1.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories"
                oleDbDataAdapter1.Fill(dataTable1)
            Catch
            Finally
                oleDbConnection1.Close()
            End Try

            ' Imports data from dataview object.
            dataTable1.TableName = "Categories"
            GridWeb1.WorkSheets.Clear()
            GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, Nothing, Nothing)

            '  Imports data from dataview object with sheet name and position specified.
            GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, Nothing, Nothing, "SpecifiedName&Position", 2, 1)
            ' ExEnd:ImportDataView

            ' Resize cells
            Dim cells As GridCells = GridWeb1.WorkSheets(0).Cells
            ' Sets column width.
            cells.SetColumnWidth(0, 10)
            cells.SetColumnWidth(1, 10)
            cells.SetColumnWidth(2, 30)
            cells.SetRowHeight(2, 30)
            Dim cellsb As GridCells = GridWeb1.WorkSheets(1).Cells
            cellsb.SetColumnWidth(1, 10)
            cellsb.SetColumnWidth(2, 10)
            cellsb.SetColumnWidth(3, 30)
            cellsb.SetRowHeight(4, 30)

            ' Add style to cells
            Dim style As New GridTableItemStyle()
            style.HorizontalAlign = HorizontalAlign.Center
            style.BorderStyle = BorderStyle.Solid
            style.BorderColor = Color.Black
            style.BorderWidth = 1

            Dim i As Integer = 1
            While i <= cells.MaxRow
                Dim j As Integer = 0
                While j <= cells.MaxColumn
                    Dim cell As GridCell = cells(i, j)

                    cell.CopyStyle(style)
                    j += 1
                End While
                i += 1
            End While

            i = 3
            While i <= cellsb.MaxRow
                Dim j As Integer = 1
                While j <= cellsb.MaxColumn
                    Dim cell As GridCell = cellsb(i, j)

                    cell.CopyStyle(style)
                    j += 1
                End While
                i += 1
            End While
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As System.EventArgs)
             ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out_.xls"

            Dim path As String = TryCast(Me.Master, Site).GetDataDir() + "\Worksheets\"

            ' Saves to the file.
            Me.GridWeb1.SaveToExcelFile(path + filename)

            ' Sents the file to browser.
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment; filename=" + filename)
            Response.WriteFile(path + filename)
            Response.[End]()
        End Sub
    End Class
End Namespace
