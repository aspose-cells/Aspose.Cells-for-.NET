Imports System.IO

Imports Aspose.Cells
Imports System

Namespace SmartMarkers
    Public Class UsingHTMLProperty
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook()
            Dim designer As New WorkbookDesigner()
            designer.Workbook = workbook
            workbook.Worksheets(0).Cells("A1").PutValue("&=$VariableArray(HTML)")
            designer.SetDataSource("VariableArray", New String() {"Hello <b>World</b>", "Arabic", "Hindi", "Urdu", "French"})
            designer.Process()
            workbook.Save(dataDir & "output.xls")

            ' ExEnd:1
        End Sub
    End Class
End Namespace
