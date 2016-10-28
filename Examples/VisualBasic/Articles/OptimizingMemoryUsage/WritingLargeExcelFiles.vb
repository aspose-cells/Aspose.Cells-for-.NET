Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles.OptimizingMemoryUsage
    Public Class WritingLargeExcelFilesExample
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new Workbook
            Dim wb As New Workbook()
            ' Set the memory preferences

            ' Note: This setting cannot take effect for the existing worksheets that are created before using the below line of code
            wb.Settings.MemorySetting = MemorySetting.MemoryPreference

            ' Note: The memory settings also would not work for the default sheet i.e., "Sheet1" etc. automatically created by the Workbook

            ' To change the memory setting of existing sheets, please change memory setting for them manually:
            Dim cells As Cells = wb.Worksheets(0).Cells
            cells.MemorySetting = MemorySetting.MemoryPreference
            ' Input large dataset into the cells of the worksheet.
            ' Your code goes here.
            ' .........

            ' Get cells of the newly created Worksheet "Sheet2" whose memory setting is same with the one defined in WorkbookSettings:
            cells = wb.Worksheets.Add("Sheet2").Cells
            ' .........
            ' Input large dataset into the cells of the worksheet.
            ' Your code goes here.
            ' .........
            ' ExEnd:1
        End Sub
    End Class
End Namespace