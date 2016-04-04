Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Formatting.Excel2007Themes
    Public Class UtilizeThemeColors
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a Workbook.
            Dim workbook As New Workbook()

            'Get cells collection in the first (default) worksheet.
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            'Get the D3 cell.
            Dim c As Global.Aspose.Cells.Cell = cells("D3")

            'Get the style of the cell.
            Dim s As Style = c.GetStyle()

            'Set foreground color for the cell from the default theme Accent2 color.
            s.ForegroundThemeColor = New ThemeColor(ThemeColorType.Accent2, 0.5)

            'Set the pattern type.
            s.Pattern = BackgroundType.Solid

            'Get the font for the style.
            Dim f As Global.Aspose.Cells.Font = s.Font

            'Set the theme color.
            f.ThemeColor = New ThemeColor(ThemeColorType.Accent4, 0.1)

            'Apply style.
            c.SetStyle(s)

            'Put a value.
            c.PutValue("Testing1")

            'Save the excel file.
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace