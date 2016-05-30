Imports System.IO

Imports Aspose.Cells
Imports System.Data

Namespace SmartMarkers
    Public Class UsingVariableArray
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook designer.
            Dim report As New WorkbookDesigner()

            ' Get the first worksheet of the workbook.
            Dim w As Worksheet = report.Workbook.Worksheets(0)

            ' Set the Variable Array marker to a cell.
            ' You may also place this Smart Marker into a template file manually in Ms Excel and then open this file via Workbook.
            w.Cells("A1").PutValue("&=$VariableArray")

            ' Set the DataSource for the marker(s).
            report.SetDataSource("VariableArray", New String() {"English", "Arabic", "Hindi", "Urdu", "French"})

            ' Process the markers.
            report.Process(False)

            ' Save the Excel file.
            report.Workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
