Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Aspose.Cells.Examples.Articles
    Public Class ExportRangeofCellsExample
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "aspose-sample.xlsx"

            'Create workbook from source file.
            Dim workbook As New Workbook(filePath)

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Set the print area with your desired range
            worksheet.PageSetup.PrintArea = "E12:H16"

            'Set all margins as 0
            worksheet.PageSetup.LeftMargin = 0
            worksheet.PageSetup.RightMargin = 0
            worksheet.PageSetup.TopMargin = 0
            worksheet.PageSetup.BottomMargin = 0

            'Set OnePagePerSheet option as true
            Dim options As New ImageOrPrintOptions()
            options.OnePagePerSheet = True
            options.ImageFormat = ImageFormat.Jpeg

            'Take the image of your worksheet
            Dim sr As New SheetRender(worksheet, options)
            sr.ToImage(0, dataDir & "output.jpg")
            'ExEnd:1


        End Sub
    End Class
End Namespace