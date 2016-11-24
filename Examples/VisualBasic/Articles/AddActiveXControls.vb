Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports Aspose.Cells.Drawing.ActiveXControls
Imports Aspose.Cells.Vba
Namespace Articles
    Public Class AddActiveXControls
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim wb As New Workbook()

            ' Access first worksheet
            Dim sheet As Worksheet = wb.Worksheets(0)

            ' Add Toggle Button ActiveX Control inside the Shape Collection
            Dim s As Shape = sheet.Shapes.AddActiveXControl(ControlType.ToggleButton, 4, 0, 4, 0, 100, _
                30)

            ' Access the ActiveX control object and set its linked cell property
            Dim c As ActiveXControl = s.ActiveXControl
            c.LinkedCell = "A1"

            ' Save the worbook in xlsx format
            wb.Save(dataDir & Convert.ToString("AddActiveXControls_out.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
