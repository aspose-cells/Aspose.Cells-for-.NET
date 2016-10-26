Imports Aspose.Cells.GridWeb.Data
Imports System.Drawing

Namespace Cells
    Public Class FormatCells
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnApplyFontStyles_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyFontStyles
            ' Accessing the reference of the worksheet that is currently active and resize first row and column
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)
            sheet.Cells.Clear()
            sheet.Cells.SetColumnWidth(0, 50)
            sheet.Cells.SetRowHeight(0, 40)

            ' Accessing a specific cell of the worksheet
            Dim cell As GridCell = sheet.Cells("A1")

            ' Inserting a value in cell A1
            cell.PutValue("Aspose.Cells.GridWeb")

            Dim style = cell.Style

            ' Setting the font size to 12 points
            style.Font.Size = New FontUnit("12pt")

            ' Setting font style to Bold
            style.Font.Bold = True

            ' Setting foreground color of font to Blue
            style.ForeColor = Color.Blue

            ' Setting background color of font to Aqua
            style.BackColor = Color.Aqua

            ' Setting the horizontal alignment of font to Center
            style.HorizontalAlign = HorizontalAlign.Center

            ' Set the cell style
            cell.CopyStyle(style)
            sheet.AutoFitColumn(0)
            ' ExEnd:ApplyFontStyles           
        End Sub

        Protected Sub btnApplyBorderStyles_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyBorderStyles
            ' Accessing the reference of the worksheet that is currently active and resize first row and column
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)
            sheet.Cells.Clear()
            sheet.Cells.SetColumnWidth(0, 50)
            sheet.Cells.SetRowHeight(0, 40)

            ' Accessing a specific cell of the worksheet
            Dim cell As GridCell = sheet.Cells("A1")

            Dim style = cell.Style

            ' Setting the border style to Solid
            style.BorderStyle = BorderStyle.Solid

            ' Setting the border width to 2 pixels
            style.BorderWidth = New Unit(2, UnitType.Pixel)

            ' Setting the border color to Blue
            style.BorderColor = Color.Blue

            ' Set the cell style
            cell.CopyStyle(style)
            ' ExEnd:ApplyBorderStyles
        End Sub

        Protected Sub btnApplyRangeBorderStyles_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyRangeBorderStyles
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            sheet.Cells.Clear()

            ' Creating an instance of WebBorderStyle
            Dim bstyle As New WebBorderStyle()

            ' Setting the border style to Double
            bstyle.BorderStyle = BorderStyle.[Double]

            ' Setting the border width to 3 pixels
            bstyle.BorderWidth = New Unit(3, UnitType.Pixel)

            ' Setting the border color to Blue
            bstyle.BorderColor = Color.Blue

            ' Applying the instance of WebBorderStyle on a specified range of cells
            sheet.Cells.SetBorders(1, 1, 5, 4, SetBorderPosition.Cross, bstyle)
            ' ExEnd:ApplyRangeBorderStyles
        End Sub

        Protected Sub btnApplyNumberFormats_Click(sender As Object, e As EventArgs)
            ' ExStart:ApplyNumberFormats
            ' Accessing the reference of the worksheet that is currently active
            Dim sheet As GridWorksheet = GridWeb1.WorkSheets(GridWeb1.ActiveSheetIndex)

            sheet.Cells.Clear()

            sheet.Cells.SetColumnWidth(0, 50)
            sheet.Cells.SetRowHeight(0, 40)

            ' Putting values to cells
            sheet.Cells("A1").PutValue("Currency1 Number Format")
            sheet.Cells("A2").PutValue("Custom Number Format")
            sheet.Cells("B1").PutValue(7800)
            sheet.Cells("B2").PutValue(2500)

            ' Setting the number format of "B1" cell to Currency1
            sheet.Cells("B1").SetNumberType(Convert.ToInt32(NumberType.Currency1))

            ' Setting the custom number format of "B2" cell
            sheet.Cells("B2").SetCustom("#,##0.0000")
            ' ExEnd:ApplyNumberFormats
        End Sub
    End Class
End Namespace
