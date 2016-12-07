Imports Aspose.Cells.GridWeb.Data

Namespace Cells
    Public Class AccessCellHyperlink
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack AndAlso Not GridWeb1.IsPostBack Then
                InitGridWeb()
            Else
                Label1.Text = ""
            End If
        End Sub

        Private Sub InitGridWeb()
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            ' Adds a text hyperlink that gos to Aspose site and opens in new window
            Dim linkIndex As Integer = sheet.Hyperlinks.Add("A1", "http://www.aspose.com")
            Dim link1 As GridHyperlink = sheet.Hyperlinks(linkIndex)

            link1.Target = "_blank"

            ' Setting text of the hyperlink
            link1.TextToDisplay = "Aspose"

            ' Setting tool tip of the hyperlink
            link1.ScreenTip = "Open Aspose Web Site in new window"

            ' Adding hyperlink to the worksheet to open in parent window
            linkIndex = sheet.Hyperlinks.Add("A2", "http://www.aspose.com/docs/display/cellsnet/Aspose.Cells.GridWeb")
            Dim link2 As GridHyperlink = sheet.Hyperlinks(linkIndex)

            link2.Target = "_parent"

            ' Setting text of the hyperlink
            link2.TextToDisplay = "Aspose.Grid Docs"

            ' Setting tool tip of the hyperlink
            link2.ScreenTip = "Open Aspose.Grid Docs in parent window"
        End Sub

        Protected Sub btnAccessCellHyperlink_Click(sender As Object, e As EventArgs)
            ' ExStart:AccessHyperlink
            ' Access first worksheet of gridweb and cell A1
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(0)
            Dim cellA1 As GridCell = sheet.Cells("A1")

            ' Access hyperlink of cell A1 if it contains any
            Dim cellHyperlink As GridHyperlink = sheet.Hyperlinks.GetHyperlink(cellA1)

            If cellHyperlink Is Nothing Then
                Label1.Text = "Cell A1 does not have any hyperlink"
            Else
                ' Access hyperlink properties e.g. address
                Dim hyperlinkAddress As String = cellHyperlink.Address
                Label1.Text = "Address of hyperlink in cell A1 :" & hyperlinkAddress
            End If
            ' ExEnd:AccessHyperlink
        End Sub

    End Class
End Namespace