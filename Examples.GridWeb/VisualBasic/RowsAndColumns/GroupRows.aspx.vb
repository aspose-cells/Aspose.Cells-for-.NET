Imports Aspose.Cells.GridWeb.Data
Imports System.Data.OleDb

Namespace RowsAndColumns
    Public Class GroupRows
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnLoad_Click(sender As Object, e As EventArgs)
            GridWeb1.WorkSheets.Clear()

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

            Try
                oleDbSelectCommand1.CommandText = "SELECT * FROM Products"
                oleDbDataAdapter1.Fill(dataTable1)

                ' Import data from database to grid web
                GridWeb1.WorkSheets.ImportDataView(dataTable1.DefaultView, Nothing, Nothing)
            Finally
                ' Close connection
                oleDbConnection1.Close()
            End Try
        End Sub

        Protected Sub GridWeb1_CustomCommand(sender As Object, command As String)
            ' Groups Rows or Ungroup Rows.
            If GridWeb1.ActiveSheetIndex = 0 Then
                Select Case command
                    Case "GROUP"
                        If GridWeb1.SelectCells IsNot Nothing AndAlso GridWeb1.SelectCells.Count > 0 Then
                            ' Get Cell Selected CellArea
                            Dim SelectedCells As WebCellArea = CType(GridWeb1.SelectCells(0), WebCellArea)

                            ' Group rows from starting cell to ending cell
                            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).GroupRows(SelectedCells.StartRow, SelectedCells.EndRow)
                        End If
                        Exit Select

                    Case "UNGROUP"
                        If GridWeb1.SelectCells IsNot Nothing AndAlso GridWeb1.SelectCells.Count > 0 Then
                            ' Get Cell Selected CellArea
                            Dim SelectedCells As WebCellArea = CType(GridWeb1.SelectCells(0), WebCellArea)

                            ' Group rows from starting cell to ending cell
                            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).UngroupRows(SelectedCells.StartRow, SelectedCells.EndRow)


                        End If
                        Exit Select
                End Select
            End If
        End Sub
    End Class
End Namespace
