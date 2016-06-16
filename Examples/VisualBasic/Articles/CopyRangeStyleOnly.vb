Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing

Imports Aspose.Cells

Namespace Articles
    Public Class CopyRangeStyleOnly
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first Worksheet Cells.
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Fill some sample data into the cells.
            For i As Integer = 0 To 49
                For j As Integer = 0 To 9
                    cells(i, j).PutValue(i.ToString() & "," & j.ToString())
                Next j

            Next i

            ' Create a range (A1:D3).
            Dim range As Range = cells.CreateRange("A1", "D3")

            ' Create a style object.
            Dim style As Style
            style = workbook.CreateStyle()
            ' Specify the font attribute.
            style.Font.Name = "Calibri"
            ' Specify the shading color.
            style.ForegroundColor = Color.Yellow
            style.Pattern = BackgroundType.Solid
            ' Specify the border attributes.
            style.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.TopBorder).Color = Color.Blue
            style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.BottomBorder).Color = Color.Blue
            style.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.LeftBorder).Color = Color.Blue
            style.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.RightBorder).Color = Color.Blue
            ' Create the styleflag object.
            Dim flag1 As New StyleFlag()
            ' Implement font attribute
            flag1.FontName = True
            ' Implement the shading / fill color.
            flag1.CellShading = True
            ' Implment border attributes.
            flag1.Borders = True
            ' Set the Range style.
            range.ApplyStyle(style, flag1)

            ' Create a second range (C10:E13).
            Dim range2 As Range = cells.CreateRange("C10", "E13")

            ' Copy the range style only.
            range2.CopyStyle(range)

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace