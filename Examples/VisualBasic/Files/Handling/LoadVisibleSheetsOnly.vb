Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class LoadVisibleSheetsOnly
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim sampleFile As String = "output.xlsx"
            Dim samplePath As String = dataDir & sampleFile

            ' Create a sample workbook
            ' and put some data in first cell of all 3 sheets
            Dim createWorkbook As New Workbook()
            createWorkbook.Worksheets("Sheet1").Cells("A1").Value = "Aspose"
            createWorkbook.Worksheets.Add("Sheet2").Cells("A1").Value = "Aspose"
            createWorkbook.Worksheets.Add("Sheet3").Cells("A1").Value = "Aspose"
            createWorkbook.Worksheets("Sheet3").IsVisible = False
            createWorkbook.Save(samplePath)

            ' Load the sample workbook

            Dim loadOptions As New LoadOptions()
            loadOptions.LoadFilter = New CustomLoad()

            Dim loadWorkbook As New Workbook(samplePath, loadOptions)
            Console.WriteLine("Sheet1: A1: {0}", loadWorkbook.Worksheets("Sheet1").Cells("A1").Value)
            Console.WriteLine("Sheet1: A2: {0}", loadWorkbook.Worksheets("Sheet2").Cells("A1").Value)
            Console.WriteLine("Sheet1: A3: {0}", loadWorkbook.Worksheets("Sheet3").Cells("A1").Value)
            ' ExEnd:1
        End Sub
    End Class
    ' ExStart:2
    Friend Class CustomLoad
        Inherits LoadFilter
        Public Overrides Sub StartSheet(ByVal sheet As Worksheet)
            If sheet.IsVisible Then
                ' Load everything from visible worksheet
                Me.LoadDataFilterOptions = LoadDataFilterOptions.All
            Else
                ' Load nothing
                Me.LoadDataFilterOptions = LoadDataFilterOptions.None
            End If
        End Sub
    End Class
    ' ExEnd:2
End Namespace
