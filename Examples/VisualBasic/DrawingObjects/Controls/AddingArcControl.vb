Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingArcControl
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

            ' Add an arc shape.
            Dim arc1 As Global.Aspose.Cells.Drawing.ArcShape = excelbook.Worksheets(0).Shapes.AddArc(2, 0, 2, 0, 130, 130)

            ' Set the placement of the arc.
            arc1.Placement = PlacementType.FreeFloating

            ' Set the fill format.
            arc1.FillFormat.ForeColor = Color.Blue

            ' Set the line style.
            arc1.LineFormat.Style = MsoLineStyle.Single

            ' Set the line weight.
            arc1.LineFormat.Weight = 1

            ' Set the color of the arc line.
            arc1.LineFormat.ForeColor = Color.Blue

            ' Set the dash style of the arc.
            arc1.LineFormat.DashStyle = MsoLineDashStyle.Solid

            ' Add another arc shape.
            Dim arc2 As Global.Aspose.Cells.Drawing.ArcShape = excelbook.Worksheets(0).Shapes.AddArc(9, 0, 2, 0, 130, 130)

            ' Set the placement of the arc.
            arc2.Placement = PlacementType.FreeFloating

            ' Set the line style.
            arc2.LineFormat.Style = MsoLineStyle.Single

            ' Set the line weight.
            arc2.LineFormat.Weight = 1

            ' Set the color of the arc line.
            arc2.LineFormat.ForeColor = Color.Blue

            ' Set the dash style of the arc.
            arc2.LineFormat.DashStyle = MsoLineDashStyle.Solid

            ' Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace