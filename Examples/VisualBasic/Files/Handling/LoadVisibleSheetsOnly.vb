Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class LoadVisibleSheetsOnly
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
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
            Dim loadDataOption As New LoadDataOption()
            loadDataOption.OnlyVisibleWorksheet = True
            Dim loadOptions As New LoadOptions()
            loadOptions.LoadDataAndFormatting = True
            loadOptions.LoadDataOptions = loadDataOption

            Dim loadWorkbook As New Workbook(samplePath, loadOptions)
            Console.WriteLine("Sheet1: A1: {0}", loadWorkbook.Worksheets("Sheet1").Cells("A1").Value)
            Console.WriteLine("Sheet1: A2: {0}", loadWorkbook.Worksheets("Sheet2").Cells("A1").Value)
            Console.WriteLine("Sheet1: A3: {0}", loadWorkbook.Worksheets("Sheet3").Cells("A1").Value)
            'ExEnd:1
        End Sub
    End Class
End Namespace
