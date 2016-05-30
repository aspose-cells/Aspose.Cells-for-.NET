Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Drawing
Namespace DrawingObjects.Controls
    Public Class AddingLabelControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet in the workbook.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Add a new label to the worksheet.
            Dim label As Global.Aspose.Cells.Drawing.Label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120)

            ' Set the caption of the label.
            label.Text = "This is a Label"

            ' Set the Placement Type, the way the
            ' Label is attached to the cells.
            label.Placement = PlacementType.FreeFloating

            ' Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Yellow

            ' Saves the file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace