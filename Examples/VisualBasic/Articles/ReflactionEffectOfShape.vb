Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class ReflactionEffectOfShape
        Public Shared Sub Run()
            ' ExStart:ReflactionEffectOfShape
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load your source excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first shape
            Dim sh As Shape = ws.Shapes(0)

            ' Set the reflection effect of the shape, set its Blur, Size, Transparency and Distance properties
            Dim re As ReflectionEffect = sh.Reflection
            re.Blur = 30
            re.Size = 90
            re.Transparency = 0
            re.Distance = 80

            ' Save the workbook in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:ReflactionEffectOfShape
        End Sub
    End Class
End Namespace