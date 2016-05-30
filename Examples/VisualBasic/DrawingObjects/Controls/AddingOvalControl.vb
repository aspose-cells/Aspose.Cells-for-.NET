Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingOvalControl
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

            ' Add an oval shape.
            Dim oval1 As Global.Aspose.Cells.Drawing.Oval = excelbook.Worksheets(0).Shapes.AddOval(2, 0, 2, 0, 130, 160)

            ' Set the placement of the oval.
            oval1.Placement = PlacementType.FreeFloating

            ' Set the fill format.
            oval1.FillFormat.ForeColor = Color.PaleGreen

            ' Set the line style.
            oval1.LineFormat.Style = MsoLineStyle.Single

            ' Set the line weight.
            oval1.LineFormat.Weight = 1

            ' Set the color of the oval line.
            oval1.LineFormat.ForeColor = Color.Green

            ' Set the dash style of the oval.
            oval1.LineFormat.DashStyle = MsoLineDashStyle.Solid

            ' Add another oval (circle) shape.
            Dim oval2 As Global.Aspose.Cells.Drawing.Oval = excelbook.Worksheets(0).Shapes.AddOval(9, 0, 2, 15, 130, 130)

            ' Set the placement of the oval.
            oval2.Placement = PlacementType.FreeFloating

            ' Set the line style.
            oval2.LineFormat.Style = MsoLineStyle.Single

            ' Set the line weight.
            oval2.LineFormat.Weight = 1

            ' Set the color of the oval line.
            oval2.LineFormat.ForeColor = Color.Blue

            ' Set the dash style of the oval.
            oval2.LineFormat.DashStyle = MsoLineDashStyle.Solid

            ' Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace