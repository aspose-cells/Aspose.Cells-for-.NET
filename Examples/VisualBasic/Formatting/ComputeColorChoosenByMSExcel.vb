Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports System

Namespace Formatting
    Public Class ComputeColorChoosenByMSExcel
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a workbook object
            ' Open the template file
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")
            ' Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            ' Get the A1 cell
            Dim a1 As Cell = worksheet.Cells("A1")

            ' Get the conditional formatting resultant object
            Dim cfr1 As ConditionalFormattingResult = a1.GetConditionalFormattingResult()
            ' Get the ColorScale resultant color object
            Dim c As Color = cfr1.ColorScaleResult
            ' Read the color
            Console.WriteLine(c.ToArgb().ToString())
            Console.WriteLine(c.Name)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
