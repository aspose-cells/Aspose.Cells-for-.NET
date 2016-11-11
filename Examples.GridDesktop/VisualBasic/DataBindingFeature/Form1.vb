Imports Aspose.Cells.GridDesktop
' ExStart:AddingNamespaceToTheTop
' Adding namespace to the top of code
Imports System.Data.OleDb
' ExEnd:AddingNamespaceToTheTop

Public Class Form1
    ' ExStart:DeclareGlobalVariable
    ' Declaring global variable
    Dim adapter As OleDbDataAdapter
    Dim cb As OleDbCommandBuilder
    Dim ds As DataSet
    ' ExEnd:DeclareGlobalVariable

    ' ExStart:FillDataSet
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creating Select query to fetch data from database
        Dim query As String = "SELECT * FROM Products ORDER BY ProductID"

        ' Creating connection string to connect with database
        Dim conStr As String = "Provider=microsoft.jet.oledb.4.0;Data Source=" + Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) + "dbDatabase.mdb"

        ' Creating OleDbDataAdapter object that will be responsible to open/close connections with database, fetch data and fill DataSet with data
        adapter = New OleDbDataAdapter(query, conStr)

        ' Setting MissingSchemaAction to AddWithKey for getting necesssary primary key information of the tables
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Creating OleDbCommandBuilder object to create insert/delete SQL commmands
        ' automatically that are used by OleDbDatAdapter object for updating
        ' changes to the database        

        cb = New OleDbCommandBuilder(adapter)

        ' Creating DataSet object
        ds = New DataSet()

        ' Filling DataSet with data fetched by OleDbDataAdapter object
        adapter.Fill(ds, "Products")
    End Sub
    ' ExEnd:FillDataSet

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' ExStart:BindWorksheet
        ' Accessing the worksheet of the Grid that is currently active
        Dim sheet As Worksheet = GridDesktop1.GetActiveWorksheet()

        ' Binding the Worksheet to Products table by calling its DataBind method
        sheet.DataBind(ds.Tables("Products"), "")
        ' ExEnd:BindWorksheet

        ' ExStart:SettingColumnHeader
        ' Iterating through all columns of the Products table in DataSet
        For i As Integer = 0 To ds.Tables("Products").Columns.Count - 1
            ' Setting the column header of each column to the column caption of Products table
            sheet.Columns(i).Header = ds.Tables("Products").Columns(i).Caption
        Next
        ' ExEnd:SettingColumnHeader

        ' ExStart:CustomizingStyle
        ' Customizing the widths of columns of the worksheet
        sheet.Columns(0).Width = 70
        sheet.Columns(1).Width = 120
        sheet.Columns(2).Width = 80
        ' ExEnd:CustomizingStyle

        ' ExStart:ApplyCustomStyle
        ' Iterating through each column of the worksheet
        For i As Integer = 0 To sheet.ColumnsCount - 1
            ' Getting the style object of each column
            Dim style As Style = sheet.Columns(i).GetStyle()

            ' Setting the color of each column to Yellow
            style.Color = Color.Yellow

            ' Setting the Horizontal Alignment of each column to Centered
            style.HAlignment = HorizontalAlignmentType.Centred

            ' Setting the style of column to the updated one

            sheet.Columns(i).SetStyle(style)
        Next
        ' ExEnd:ApplyCustomStyle
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ' ExStart:AddingRows
        ' Adding new row to the worksheet
        GridDesktop1.GetActiveWorksheet().AddRow()
        ' ExEnd:AddingRows
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ' ExStart:DeletingRows
        ' Getting the index of the focused row
        Dim focusedRowIndex As Integer = GridDesktop1.GetActiveWorksheet().GetFocusedCell().Row

        ' Removing the focused row fro the worksheet
        GridDesktop1.GetActiveWorksheet().RemoveRow(focusedRowIndex)
        ' ExEnd:DeletingRows
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        ' ExStart:SavingChangesToDatabase
        ' Accessing the worksheet of the Grid that is currently active
        Dim sheet As Worksheet = GridDesktop1.GetActiveWorksheet()

        ' Updating the database according to worksheet data source
        adapter.Update(DirectCast(sheet.DataSource, DataTable))
        ' ExEnd:SavingChangesToDatabase
    End Sub
End Class