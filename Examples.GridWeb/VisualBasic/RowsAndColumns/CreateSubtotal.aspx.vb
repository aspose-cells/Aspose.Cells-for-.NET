Imports System.Data.OleDb
Imports Aspose.Cells.GridWeb.Data
Imports System.Drawing

Namespace RowsAndColumns
    Public Class CreateSubtotal
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                'Load data against selected drop down value
                LoadData(ddlSort.SelectedItem.Value)
            End If
        End Sub

        Private Sub LoadData(sort As String)
            ' Loads data from access database.
            Dim ds As New DataSet()

            ' Create path to database file
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            ' Create database connection object
            Dim conn As New OleDbConnection()

            ' Create connection string to database
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\RowsAndColumns\Database\Northwind.mdb"

            ' Write select command
            Dim sql As String = "SELECT Products.ProductID, Categories.CategoryName, Suppliers.CompanyName, Products.ProductName, Products.QuantityPerUnit, Products.UnitPrice FROM Suppliers INNER JOIN (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID) ON Suppliers.SupplierID = Products.SupplierID"

            ' Create data adapter object
            Dim da As New OleDbDataAdapter(sql, conn)
            Try
                ' Connects to database and fetches data.
                da.Fill(ds, "Products")
                ' Sorting
                Dim productsView As New DataView(ds.Tables("Products"), "", sort, DataViewRowState.CurrentRows)

                ' Clear gridweb worksheet
                GridWeb1.WebWorksheets.Clear()

                ' Import data from dataview
                GridWeb1.WebWorksheets.ImportDataView(productsView, Nothing, Nothing)

                ' Sets column width.
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(0, New Unit(108.75, UnitType.Point))
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(1, New Unit(74.25, UnitType.Point))
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(2, New Unit(181.5, UnitType.Point))
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(3, New Unit(155.25, UnitType.Point))
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(4, New Unit(96, UnitType.Point))
                GridWeb1.WebWorksheets(0).Cells.SetColumnWidth(5, New Unit(47.25, UnitType.Point))
            Finally
                ' Close database connection
                conn.Close()
            End Try
        End Sub

        Protected Sub ddlSort_SelectedIndexChanged(sender As Object, e As System.EventArgs)
            ' Reload data, sort by the select value.
            LoadData(ddlSort.SelectedItem.Value)
        End Sub

        Protected Sub btnCreate_Click(sender As Object, e As System.EventArgs)
            ' Fill web worksheet object
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(0)

            ' Removes the created subtotal first.
            sheet.RemoveSubtotal()

            ' Creates the subtotal.
            Dim groupByIndex As Integer
            If ddlSort.SelectedItem.Value = "CategoryName" Then
                groupByIndex = 1
            Else
                groupByIndex = 2
            End If

            ' Creates GrandTotal and Subtotal style.
            Dim grandStyle As New Aspose.Cells.GridWeb.TableItemStyle()
            grandStyle.BackColor = Color.Gray
            grandStyle.ForeColor = Color.Black
            Dim subtotalStyle As New Aspose.Cells.GridWeb.TableItemStyle()
            subtotalStyle.BackColor = Color.SkyBlue
            subtotalStyle.ForeColor = Color.Black

            ' ExStart:CreateSubTotal
            sheet.CreateSubtotal(0, sheet.Cells.MaxRow, groupByIndex, CType(System.[Enum].Parse(GetType(SubtotalFunction), ddlFunction.SelectedItem.Value), SubtotalFunction), New Integer() {1, 2, 3, 4, 5}, ddlFunction.SelectedItem.Text, _
                grandStyle, subtotalStyle, NumberType.General, Nothing)
            ' ExEnd:CreateSubTotal
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As System.EventArgs)
            ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out.xls"

            Dim path As String = TryCast(Me.Master, Site).GetDataDir() + "\RowsAndColumns\"

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
