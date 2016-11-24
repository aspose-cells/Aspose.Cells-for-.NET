Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace Articles.ManageChartsAndShapes
    Public Class LockingWordartWatermark
        Public Shared Sub Run()
            ' ExStart:LockingWordartWatermark
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook
            Dim workbook As New Workbook()

            ' Get the first default sheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Add Watermark
            Dim wordart As Shape = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1, "CONFIDENTIAL", "Arial Black", 50, False, True, _
             18, 8, 1, 1, 130, 800)

            ' Lock Shape Aspects
            wordart.IsLocked = True
            wordart.SetLockedProperty(ShapeLockType.Selection, True)
            wordart.SetLockedProperty(ShapeLockType.ShapeType, True)
            wordart.SetLockedProperty(ShapeLockType.Move, True)
            wordart.SetLockedProperty(ShapeLockType.Resize, True)
            wordart.SetLockedProperty(ShapeLockType.Text, True)

            ' Get the fill format of the word art
            Dim wordArtFormat As FillFormat = wordart.Fill

            ' Set the color
            wordArtFormat.SetOneColorGradient(Color.Red, 0.2, GradientStyleType.Horizontal, 2)

            ' Set the transparency
            wordArtFormat.Transparency = 0.9

            ' Make the line invisible
            wordart.HasLine = False

            ' Save the file
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:LockingWordartWatermark
        End Sub
    End Class
End Namespace