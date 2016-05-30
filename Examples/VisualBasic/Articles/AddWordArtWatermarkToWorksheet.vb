Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class AddWordArtWatermarkToWorksheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiate a new Workbook
            Dim workbook As New Workbook()

            ' Get the first default sheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Add Watermark
            Dim wordart As Global.Aspose.Cells.Drawing.Shape = sheet.Shapes.AddTextEffect(MsoPresetTextEffect.TextEffect1, "CONFIDENTIAL", "Arial Black", 50, False, True, 18, 8, 1, 1, 130, 800)

            ' Get the fill format of the word art
            Dim wordArtFormat As MsoFillFormat = wordart.FillFormat

            ' Set the color
            wordArtFormat.ForeColor = System.Drawing.Color.Red

            ' Set the transparency
            wordArtFormat.Transparency = 0.9

            ' Make the line invisible
            Dim lineFormat As MsoLineFormat = wordart.LineFormat
            lineFormat.IsVisible = False

            ' Save the file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1


        End Sub
    End Class
End Namespace