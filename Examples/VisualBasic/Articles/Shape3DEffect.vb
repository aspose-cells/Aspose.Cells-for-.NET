Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class Shape3DEffect
        Public Shared Sub Run()
            ' ExStart:Shape3DEffect
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load excel file containing a shape
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access first shape
            Dim sh As Shape = ws.Shapes(0)

            ' Apply different three dimensional settings
            Dim n3df As ThreeDFormat = sh.ThreeDFormat
            n3df.ContourWidth = 17
            n3df.ExtrusionHeight = 32

            ' Save the output excel file in xlsx format
            wb.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:Shape3DEffect
        End Sub
    End Class
End Namespace