Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
    Public Class UsingGetStyleSetStyle
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Obtaining the reference of the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Accessing the "A1" cell from the worksheet
            Dim cell As Cell = worksheet.Cells("A1")

            'Adding some value to the "A1" cell
            cell.PutValue("Hello Aspose!")

            'Defining a Style object
            Dim style As Global.Aspose.Cells.Style

            'Get the style from A1 cell
            style = cell.GetStyle()

            'Setting the vertical alignment
            style.VerticalAlignment = TextAlignmentType.Center

            'Setting the horizontal alignment
            style.HorizontalAlignment = TextAlignmentType.Center

            'Setting the font color of the text
            style.Font.Color = Color.Green

            'Setting to shrink according to the text contained in it
            style.ShrinkToFit = True

            'Setting the bottom border color to red
            style.Borders(BorderType.BottomBorder).Color = Color.Red

            'Setting the bottom border type to medium
            style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Medium

            'Applying the style to A1 cell
            cell.SetStyle(style)

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace