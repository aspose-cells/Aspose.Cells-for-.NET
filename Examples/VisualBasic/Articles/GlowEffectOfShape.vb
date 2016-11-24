Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class GlowEffectOfShape
        Public Shared Sub Run()
            ' ExStart:GlowEffectOfShape
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first shape
            Dim sh As Shape = ws.Shapes(0)

            ' Set the glow effect of the shape, Set its Size and Transparency properties
            Dim ge As GlowEffect = sh.Glow
            ge.Size = 30
            ge.Transparency = 0.4

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:GlowEffectOfShape
        End Sub
    End Class
End Namespace