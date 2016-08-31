Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingRectangleControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiate a new Workbook.
            Dim excelbook As New Workbook()

            ' Add a rectangle control.
            Dim rectangle As Global.Aspose.Cells.Drawing.RectangleShape = excelbook.Worksheets(0).Shapes.AddRectangle(3, 0, 2, 0, 70, 130)

            ' Set the placement of the rectangle.
            rectangle.Placement = PlacementType.FreeFloating

            ' Set the line weight.
            rectangle.Line.Weight = 4

            ' Set the dash style of the rectangle.
            rectangle.Line.DashStyle = MsoLineDashStyle.Solid

            ' Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace