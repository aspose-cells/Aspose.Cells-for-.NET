Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
    Public Class UsingStyleObject
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Excel object
            Dim i As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the first worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(i)

            'Accessing the "A1" cell from the worksheet
            Dim cell As Cell = worksheet.Cells("A1")

            'Adding some value to the "A1" cell
            cell.PutValue("Hello Aspose!")

            'Adding a new Style to the styles collection of the Excel object
            Dim index As Integer = workbook.Styles.Add()

            'Accessing the newly added Style to the Excel object
            Dim style As Style = workbook.Styles(index)

            'Setting the vertical alignment of the text in the "A1" cell
            style.VerticalAlignment = TextAlignmentType.Center

            'Setting the horizontal alignment of the text in the "A1" cell
            style.HorizontalAlignment = TextAlignmentType.Center

            'Setting the font color of the text in the "A1" cell
            style.Font.Color = Color.Green

            'Shrinking the text to fit in the cell
            style.ShrinkToFit = True

            'Setting the bottom border color of the cell to red
            style.Borders(BorderType.BottomBorder).Color = Color.Red

            'Setting the bottom border type of the cell to medium
            style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Medium

            'Assigning the Style object to the "A1" cell
            cell.SetStyle(style)


            'Apply the same style to some other cells
            worksheet.Cells("B1").SetStyle(style)
            worksheet.Cells("C1").SetStyle(style)
            worksheet.Cells("D1").SetStyle(style)


            'Saving the Excel file
            workbook.Save(dataDir & "book1.out.xls")

        End Sub
    End Class
End Namespace