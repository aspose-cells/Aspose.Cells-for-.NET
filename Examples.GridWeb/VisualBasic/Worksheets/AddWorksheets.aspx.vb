Imports Aspose.Cells.GridWeb.Data
Imports System.Drawing

Namespace Worksheets
    Public Class AddWorksheets
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit to the page init GridWeb data
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitData()

                ' Set sheets selectedIndex to 0
                GridWeb1.WorkSheets.ActiveSheetIndex = 0
            End If
        End Sub

        Private Sub InitData()
            GridWeb1.WorkSheets.Clear()
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets.Add("Students")
            Dim cells As GridCells = sheet.Cells
            cells(0, 0).PutValue("Name")
            Dim cellstyle As GridTableItemStyle = cells(0, 0).Style
            cellstyle.Font.Size = New FontUnit("10pt")
            cellstyle.Font.Bold = True
            cellstyle.ForeColor = Color.Black
            cellstyle.HorizontalAlign = HorizontalAlign.Center
            cellstyle.BorderWidth = 1
            cells(0, 0).Style = cellstyle

            cells(0, 1).PutValue("Gender")

            cells(0, 1).Style = cellstyle

            cells(0, 2).PutValue("Age")

            cells(0, 2).Style = cellstyle

            cells(0, 3).PutValue("Class")

            cells(0, 3).Style = cellstyle

            cells(1, 0).PutValue("Jack")
            cells(1, 1).PutValue("M")
            cells(1, 2).PutValue(19)
            cells(1, 3).PutValue("One")

            cells(2, 0).PutValue("Tome")
            cells(2, 1).PutValue("M")
            cells(2, 2).PutValue(20)
            cells(2, 3).PutValue("Four")

            cells(3, 0).PutValue("Jeney")
            cells(3, 1).PutValue("W")
            cells(3, 2).PutValue(18)
            cells(3, 3).PutValue("Two")

            cells(4, 0).PutValue("Marry")
            cells(4, 1).PutValue("W")
            cells(4, 2).PutValue(17)
            cells(4, 3).PutValue("There")

            cells(5, 0).PutValue("Amy")
            cells(5, 1).PutValue("W")
            cells(5, 2).PutValue(16)
            cells(5, 3).PutValue("Four")

            cells(6, 0).PutValue("Ben")
            cells(6, 1).PutValue("M")
            cells(6, 2).PutValue(17)
            cells(6, 3).PutValue("Four")

            cells.SetColumnWidth(0, 10)
            cells.SetColumnWidth(1, 10)
            cells.SetColumnWidth(2, 10)
            cells.SetColumnWidth(3, 10)
        End Sub

        Protected Sub btnAddWorksheets_Click(sender As Object, e As EventArgs)
            ' ExStart:AddWorksheetWithoutName
            ' Adding a worksheet to GridWeb without specifying name
            Dim sheetIndex As Integer = GridWeb1.WorkSheets.Add()
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(sheetIndex)
            Label1.Text = sheet.Name & " worksheet is added at index " & sheetIndex & ". <br/>"
            ' ExEnd:AddWorksheetWithoutName

            ' ExStart:AddWorksheetWithName
            'Adding a worksheet to GridWeb with a specified name
            If GridWeb1.WorkSheets("Teachers") Is Nothing Then
                Dim sheet1 As GridWorksheet = GridWeb1.WorkSheets.Add("Teachers")
                Label1.Text &= sheet1.Name & " worksheet is added at index " & sheet1.Index & ". <br/>"
            End If
            ' ExEnd:AddWorksheetWithName
        End Sub
    End Class
End Namespace
