Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class ManageHyperlinks
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' If first visit this page init GridWeb1 
            If Not IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitData()
            End If

        End Sub

        Private Sub InitData()
            ' Gets the web application's path.
            Dim path As String = TryCast(Me.Master, Site).GetDataDir()

            Dim fileName As String = path + "\Worksheets\Hyperlink.xls"

            ' Clears datasheets first.
            GridWeb1.WorkSheets.Clear()

            ' Imports from an excel file.
            GridWeb1.ImportExcelFile(fileName)

            AddTextHyperlinks()
            AddImageHyPerlinks()
        End Sub

        Private Sub AddTextHyperlinks()
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adds a text hyperlink that gos to Aspose site and opens in new window
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("B1", "http://www.aspose.com")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)

            link1.Target = "_blank"

            ' Setting text of the hyperlink
            link1.TextToDisplay = "Aspose"

            ' Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window"

            ' Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("B2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb")
            Dim link2 As GridHyperlink = sheet.Hyperlinks(linkIndex)

            link2.Target = "_parent"

            ' Setting text of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs"

            ' Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window"
        End Sub

        Private Sub AddImageHyPerlinks()
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adding hyperlink to the worksheet
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("B5", "http://www.aspose.com")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link1.Target = "_blank"

            ' Setting URL of the image that will be displayed as hyperlink
            link1.ImageURL = "../Images/Aspose.Banner.gif"

            ' Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window"

            ' Resize the row to display image nicely
            sheet.Cells.SetRowHeight(4, 40)

            ' Adding hyperlink to the worksheet
            linkIndex = sheet.Hyperlinks.Add("B6", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb")
            Dim link2 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link2.Target = "_blank"

            ' Setting URL of the image that will be displayed as hyperlink
            link2.ImageURL = "../Images/Aspose.Grid.gif"

            ' Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in new window"
        End Sub

        Protected Sub btnUpdateHyperlinks_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessHyperlinks
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing a specific cell that contains hyperlink
            Dim cell As GridCell = sheet.Cells("B1")

            ' Accessing the hyperlink from the specific cell
            Dim link As GridHyperlink = sheet.Hyperlinks.GetHyperlink(cell)

            If link IsNot Nothing Then
                ' Modifying the text and URL of hyperlink
                link.TextToDisplay = "Aspose.Blogs"
                link.Address = "http://www.aspose.com/Community/Blogs"
            End If
            ' ExEnd:AccessHyperlinks
        End Sub

        Protected Sub btnRemoveHyperlinks_Click(sender As Object, e As EventArgs)
            ' ExStart:RemoveHyperlink
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Removing hyperlink from the specific cell
            sheet.Hyperlinks.Remove(New Data.GridCellArea() With {.StartRow = 0, .EndRow = 0, .StartColumn = 1, .EndColumn = 1})
            ' ExEnd:RemoveHyperlink
        End Sub
    End Class
End Namespace
