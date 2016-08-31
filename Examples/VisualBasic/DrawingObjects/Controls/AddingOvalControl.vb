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

            ' Set the line weight.
            oval1.Line.Weight = 1

            ' Set the dash style of the oval.
            oval1.Line.DashStyle = MsoLineDashStyle.Solid

            ' Add another oval (circle) shape.
            Dim oval2 As Global.Aspose.Cells.Drawing.Oval = excelbook.Worksheets(0).Shapes.AddOval(9, 0, 2, 15, 130, 130)

            ' Set the placement of the oval.
            oval2.Placement = PlacementType.FreeFloating

            ' Set the line weight.
            oval2.Line.Weight = 1

            ' Set the dash style of the oval.
            oval2.Line.DashStyle = MsoLineDashStyle.Solid

            ' Save the excel file.
            excelbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace