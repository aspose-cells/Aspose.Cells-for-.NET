Imports Aspose.Cells.GridWeb
Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class AddHyperlinks
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
            AddCellCommandHyperlinks()
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
            ' ExStart:AddImageHyperlinks
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
            ' ExEnd:AddImageHyperlinks
        End Sub

        Private Sub AddCellCommandHyperlinks()
            ' ExStart:AddCellCommandHyperlinks
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

            ' Adding hyperlink to the worksheet
            Dim link1 As Hyperlink = sheet.Hyperlinks.AddHyperlink("B8")

            ' Setting the action type of the link to CellCommand
            link1.ActionType = HyperlinkActionType.CellCommand

            ' Setting the cell command for the link
            link1.CellCommand = "Click"

            ' Setting tool tip of the hyperlink
            link1.ToolTip = "Click Here"

            ' Setting URL of the button image that will be displayed as hyperlink
            link1.ImageUrl = "../Images/button.jpg"

            ' Resize the row to display image nicely
            sheet.Cells.SetRowHeight(7, 30)
            ' ExEnd:AddCellCommandHyperlinks
        End Sub

        Protected Sub Button1_Click(sender As Object, e As EventArgs)
            InitData()
        End Sub

        Protected Sub GridWeb1_SaveCommand(sender As Object, e As EventArgs)
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

        ' ExStart:HandleCellCommandHyperlinkEvent
        ' Event Handler for CellCommand event
        Protected Sub GridWeb1_CellCommand(sender As Object, e As Aspose.Cells.GridWeb.CellEventArgs)
            ' Checking the CellCommand of the hyperlink
            If e.Argument.Equals("Click") Then
                ' Accessing the reference of the worksheet that is currently active
                Dim sheet As WebWorksheet = GridWeb1.WebWorksheets(GridWeb1.ActiveSheetIndex)

                ' Adding value to "C8" cell
                sheet.Cells("C8").PutValue("Cell Command Hyperlink Clicked")

                ' Resize the column to display message nicely
                sheet.Cells.SetColumnWidth(2, 250)
            End If
        End Sub
    End Class
End Namespace
