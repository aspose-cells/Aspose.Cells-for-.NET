Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class ShadowEffectOfShape
        Public Shared Sub Run()
            ' ExStart:ShadowEffectOfShape
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first shape
            Dim sh As Shape = ws.Shapes(0)

            ' Set the shadow effect of the shape, Set its Angle, Blur, Distance and Transparency properties
            Dim se As ShadowEffect = sh.ShadowEffect
            se.Angle = 150
            se.Blur = 4
            se.Distance = 45
            se.Transparency = 0.3

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:ShadowEffectOfShape
        End Sub
    End Class
End Namespace