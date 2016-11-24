Imports Aspose.Cells.GridWeb
Imports Aspose.Cells.GridWeb.Data

Namespace Worksheets
    Public Class AddHyperlinks
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            'if first visit this page initialize GridWeb1 
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
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adds a text hyperlink that goes to Aspose site and opens in new window
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("B1", "http://www.aspose.com")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link1.Target = "_blank"

            ' Setting text and tool tip of the hyperlink
            link1.TextToDisplay = "Aspose"
            link1.ScreenTip = "Open Aspose Web Site in new window"

            ' Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("B2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb")
            Dim link2 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link2.Target = "_parent"

            ' Setting text and tool tip of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs"
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window"
            ' ExEnd:AddTextHyperlinks
        End Sub

        Private Sub AddImageHyPerlinks()
            ' ExStart:AddImageHyperlinks
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adding hyperlink to the worksheet
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("B5", "http://www.aspose.com")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link1.Target = "_blank"

            ' Setting Image URL and tool tip of hyperlink
            link1.ImageURL = "../Images/Aspose.Banner.gif"
            link1.ScreenTip = "Open Aspose Web Site in new window"

            ' Adding hyperlink to the worksheet
            linkIndex = sheet.Hyperlinks.Add("B6", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb")
            Dim link2 As GridHyperlink = sheet.Hyperlinks(linkIndex)
            link2.Target = "_blank"

            ' Setting URL, tool tip and alt text of hyperlink
            link2.ImageURL = "../Images/Aspose.Grid.gif"
            link2.ScreenTip = "Open Aspose.Grid Docs in new window"
            link2.AltText = "Open Aspose.Grid Docs in new window"

            ' Resize the row to display image nicely
            sheet.Cells.SetRowHeight(4, 40)
            sheet.Cells.SetRowHeight(5, 40)
            ' ExEnd:AddImageHyperlinks
        End Sub

        Private Sub AddCellCommandHyperlinks()
            ' ExStart:AddCellCommandHyperlinks
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adding hyperlink to the worksheet
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("B8", "")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)

            ' Setting the cell command, tool tip and image URL for the hyperlink
            link1.Command = "Click"
            link1.ScreenTip = "Click Here"
            link1.ImageURL = "../Images/button.jpg"

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
                Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

                ' Adding value to "C8" cell
                sheet.Cells("C8").PutValue("Cell Command Hyperlink Clicked")

                ' Resize the column to display message nicely
                sheet.Cells.SetColumnWidth(2, 250)
            End If
        End Sub
		' ExEnd:HandleCellCommandHyperlinkEvent
    End Class
End Namespace
