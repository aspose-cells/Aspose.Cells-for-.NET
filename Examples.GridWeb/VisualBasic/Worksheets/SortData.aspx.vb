Imports Aspose.Cells.GridWeb.Data
Imports System.Drawing

Namespace Worksheets
    Public Class SortData
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit, initialize data for GridWeb
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitData()
            End If
        End Sub

        Private Sub InitData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\Worksheets\Sort.xls"

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)

            ' Creates sorting header style.
            Dim itemStyle As New GridTableItemStyle()
            itemStyle.BorderStyle = BorderStyle.Outset
            itemStyle.BorderWidth = 2
            itemStyle.BorderColor = Color.White
            itemStyle.BackColor = Color.Silver
            itemStyle.HorizontalAlign = HorizontalAlign.Center
            itemStyle.VerticalAlign = VerticalAlign.Middle

            ' Creates Hyperlinks Sheet1. Sorts from top to bottom orientation.
            Dim cellcmd As GridHyperlink
            Dim cells0 As GridCells = GridWeb1.WorkSheets(0).Cells
            cells0("A1").CopyStyle(itemStyle)
            Dim ghc As GridHyperlinkCollection = GridWeb1.WorkSheets(0).Hyperlinks
            Dim i As Integer = ghc.Add("A1", "")
            cellcmd = ghc(i)
            cellcmd.Command = "A1"
            cellcmd.ScreenTip = "Sorts Descending"
            cellcmd.TextToDisplay = "OrderId"

            cells0("B1").CopyStyle(itemStyle)
            cellcmd = ghc(ghc.Add("B1", ""))
            cellcmd.Command = "B1"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Sales Amout"

            cells0("C1").CopyStyle(itemStyle)
            cellcmd = ghc(ghc.Add("C1", ""))
            cellcmd.Command = "C1"
            cellcmd.ScreenTip = "Sorts Descending"
            cellcmd.TextToDisplay = "Percent of Saler's Total"

            cells0("D1").CopyStyle(itemStyle)
            cellcmd = ghc(ghc.Add("D1", ""))

            cellcmd.Command = "D1"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Percent of Country Total"

            ' Creates Hyperlinks Sheet2. Sorts from left to right orientation.
            Dim cells1 As GridCells = GridWeb1.WorkSheets(1).Cells
            Dim ghcb As GridHyperlinkCollection = GridWeb1.WorkSheets(1).Hyperlinks
            cells1("A1").CopyStyle(itemStyle)
            cellcmd = ghcb(ghcb.Add("A1", ""))

            cellcmd.Command = "1A1"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Product"

            cells1("A2").CopyStyle(itemStyle)
            cellcmd = ghcb(ghcb.Add("A2", ""))

            cellcmd.Command = "1A2"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Category"

            cells1("A3").CopyStyle(itemStyle)
            cellcmd = ghcb(ghcb.Add("A3", ""))

            cellcmd.Command = "1A3"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Package"

            cells1("A4").CopyStyle(itemStyle)
            cellcmd = ghcb(ghcb.Add("A4", ""))

            cellcmd.Command = "1A4"
            cellcmd.ScreenTip = "Sorts Ascending"
            cellcmd.TextToDisplay = "Quantity"
        End Sub

        Protected Sub Button1_Click(sender As Object, e As EventArgs)
            InitData()
        End Sub

        Protected Sub GridWeb1_CellCommand(sender As Object, e As Aspose.Cells.GridWeb.CellEventArgs)
            ' Handles sorting of columns and rows
            If e.Argument.ToString() = "A1" Then
                ' ExStart:SortTopToBottom
                ' Sorts Column 1 from top to bottom in descending order
                ' Cells.Sort(int startRow, int startColumn, int rows, int columns, int index, bool isAsending, bool isCaseSensitive, bool islefttoright);
                GridWeb1.WorkSheets(0).Cells.Sort(1, 0, 20, 4, 0, False, _
                    True, False)
                ' ExEnd:SortTopToBottom
            ElseIf e.Argument.ToString() = "B1" Then
                GridWeb1.WorkSheets(0).Cells.Sort(1, 0, 20, 4, 1, True, _
                    True, False)
            ElseIf e.Argument.ToString() = "C1" Then
                GridWeb1.WorkSheets(0).Cells.Sort(1, 0, 20, 4, 2, False, _
                    True, False)
            ElseIf e.Argument.ToString() = "D1" Then
                GridWeb1.WorkSheets(0).Cells.Sort(1, 0, 20, 4, 3, True, _
                    True, False)
            ElseIf e.Argument.ToString() = "1A1" Then
                ' ExStart:SortLeftToRight
                ' Sorts Row A1 from left to right in ascending order
                ' Cells.Sort(int startRow, int startColumn, int rows, int columns, int index, bool isAsending, bool isCaseSensitive, bool islefttoright);
                GridWeb1.WorkSheets(1).Cells.Sort(0, 1, 4, 7, 0, True, _
                    True, True)
                ' ExEnd:SortLeftToRight
            ElseIf e.Argument.ToString() = "1A2" Then
                GridWeb1.WorkSheets(1).Cells.Sort(0, 1, 4, 7, 1, True, _
                    True, True)
            ElseIf e.Argument.ToString() = "1A3" Then
                GridWeb1.WorkSheets(1).Cells.Sort(0, 1, 4, 7, 2, True, _
                    True, True)
            ElseIf e.Argument.ToString() = "1A4" Then
                GridWeb1.WorkSheets(1).Cells.Sort(0, 1, 4, 7, 3, True, _
                    True, True)
            End If
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
            ' Generates a temporary file name.
            Dim filename As String = Session.SessionID + "_out.xls"

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
