Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
    Public Class FormatRanges2
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

            'Clears the worksheets
            workbook.Worksheets.Clear()

            'Adding a new worksheet to the Workbook object
            workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Accessing the "A1" cell from the worksheet
            Dim cell As Cell = worksheet.Cells("A1")

            'Adding some value to the "A1" cell
            cell.PutValue("Hello World From Aspose")

            'Creating a range of cells starting from "A1" cell to 3rd column in a row
            Dim range As Range = worksheet.Cells.CreateRange(0, 0, 1, 3)

            'Adding a thick top border with blue line
            range.SetOutlineBorder(BorderType.TopBorder, CellBorderType.Thick, Color.Blue)

            'Adding a thick bottom border with blue line
            range.SetOutlineBorder(BorderType.BottomBorder, CellBorderType.Thick, Color.Blue)

            'Adding a thick left border with blue line
            range.SetOutlineBorder(BorderType.LeftBorder, CellBorderType.Thick, Color.Blue)

            'Adding a thick right border with blue line
            range.SetOutlineBorder(BorderType.RightBorder, CellBorderType.Thick, Color.Blue)

            'Saving the Excel file
            workbook.Save(dataDir & "book1.out.xls")
        End Sub
    End Class
End Namespace