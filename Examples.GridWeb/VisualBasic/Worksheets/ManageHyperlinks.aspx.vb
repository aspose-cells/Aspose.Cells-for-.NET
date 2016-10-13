Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class ManageHyperlinks
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            'if first visit this page init GridWeb1 
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
            ' ExStart:AddTextHyperlinks
            'Accessing the reference of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Adds a text hyperlink that gos to Aspose site and opens in new window
            Dim link1 As Hyperlink = sheet.Hyperlinks.AddHyperlink("B1")
            link1.Target = "_blank"

            ' Setting text of the hyperlink
            link1.Text = "Aspose"

            ' Setting URL of the hyperlink
            link1.Url = "http://www.aspose.com"

            ' Setting tool tip of the hyperlink
            link1.ToolTip = "Open Aspose Web Site in new window"

            ' Adding hyperlink to the worksheet to open in parent window
            Dim link2 As Hyperlink = sheet.Hyperlinks.AddHyperlink("B2")
            link2.Target = "_parent"

            ' Setting text of the hyperlink
            link2.Text = "Aspose.Grid Docs"

            ' Setting URL of the hyperlink
            link2.Url = "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb"

            ' Setting tool tip of the hyperlink
            link2.ToolTip = "Open Aspose.Grid Docs in parent window"
            ' ExEnd:AddTextHyperlinks
        End Sub

        Private Sub AddImageHyPerlinks()
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Adding hyperlink to the worksheet
            Dim link1 As Hyperlink = sheet.Hyperlinks.AddHyperlink("B5")
            link1.Target = "_blank"

            ' Setting URL of the image that will be displayed as hyperlink
            link1.ImageUrl = "../Images/Aspose.Banner.gif"

            ' Setting URL of the hyperlink
            link1.Url = "http://www.aspose.com"

            ' Setting tool tip of the hyperlink
            link1.ToolTip = "Open Aspose Web Site in new window"

            ' Resize the row to display image nicely
            sheet.Cells.SetRowHeight(4, 40)

            ' Adding hyperlink to the worksheet
            Dim link2 As Hyperlink = sheet.Hyperlinks.AddHyperlink("B6")
            link2.Target = "_blank"

            ' Setting URL of the image that will be displayed as hyperlink
            link2.ImageUrl = "../Images/Aspose.Grid.gif"

            ' Setting URL of the hyperlink
            link2.Url = "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb"

            ' Setting tool tip of the hyperlink
            link2.ToolTip = "Open Aspose.Grid Docs in new window"

            ' Setting text of the hyperlink. It will be displayed if image is not displayed due to some reason
            link2.Text = "Open Aspose.Grid Docs Page in new window"
        End Sub

        Protected Sub btnUpdateHyperlinks_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessHyperlinks
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Accessing a specific cell that contains hyperlink
            Dim cell As WebCell = sheet.Cells("B1")

            ' Accessing the hyperlink from the specific cell
            Dim link As Hyperlink = sheet.Hyperlinks.GetHyperlink(cell)

            If link IsNot Nothing Then
                ' Modifying the text of hyperlink
                link.Text = "Aspose.Blogs"

                ' Modifying the URL of hyperlink
                link.Url = "http://www.aspose.com/Community/Blogs"
            End If
            ' ExEnd:AccessHyperlinks
        End Sub

        Protected Sub btnRemoveHyperlinks_Click(sender As Object, e As EventArgs)
            ' ExStart:RemoveHyperlink
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Accessing a specific cell that contains hyperlink
            Dim cell As GridCell = sheet.Cells("B1")

            ' Removing hyperlink from the specific cell
            GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex).Hyperlinks.RemoveHyperlink(cell)
            ' ExEnd:RemoveHyperlink
        End Sub

    End Class
End Namespace
