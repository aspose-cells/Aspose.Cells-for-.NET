Imports System.IO
Imports Aspose.Cells

Namespace DrawingObjects.OLE
    Public Class RefreshOLEObjects
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from your sample excel file
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim sheet As Worksheet = wb.Worksheets(0)

            ' Set auto load property of first ole object to true
            sheet.OleObjects(0).AutoLoad = True

            ' Save the worbook in xlsx format
            wb.Save(dataDir & Convert.ToString("RefreshOLEObjects_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1

        End Sub
    End Class
End Namespace
