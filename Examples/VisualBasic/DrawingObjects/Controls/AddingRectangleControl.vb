Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace Aspose.Cells.Examples.DrawingObjects.Controls
    Public Class AddingRectangleControl
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook.
            Dim excelbook As New Workbook()

            'Add a rectangle control.
            Dim rectangle As Global.Aspose.Cells.Drawing.RectangleShape = excelbook.Worksheets(0).Shapes.AddRectangle(3, 0, 2, 0, 70, 130)

            'Set the placement of the rectangle.
            rectangle.Placement = PlacementType.FreeFloating

            'Set the fill format.
            rectangle.FillFormat.ForeColor = Color.Azure

            'Set the line style.
            rectangle.LineFormat.Style = MsoLineStyle.ThickThin

            'Set the line weight.
            rectangle.LineFormat.Weight = 4

            'Set the color of the line.
            rectangle.LineFormat.ForeColor = Color.Blue

            'Set the dash style of the rectangle.
            rectangle.LineFormat.DashStyle = MsoLineDashStyle.Solid

            'Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace