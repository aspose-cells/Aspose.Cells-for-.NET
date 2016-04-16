Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Diagnostics

Namespace Aspose.Cells.Examples.Data.Handling.AccessingCells
    Public Class AccessingMaximumDisplayRangeofWorksheet
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Path to source file
            Dim filePath As String = dataDir & "Book1.xlsx"
            'Instantiating a Workbook object
            Dim workbook As New Workbook(filePath)

            'Instantiate a workbook from source file
            Dim wb As New Workbook(filePath)

            'Access the first workbook
            Dim worksheet As Worksheet = wb.Worksheets(0)

            'Access the Maximum Display Range
            Dim range As Range = worksheet.Cells.MaxDisplayRange

            'Print the Maximum Display Range RefersTo property
            Console.WriteLine("Maximum Display Range: " & range.RefersTo)
            'ExEnd:1
        End Sub
    End Class
End Namespace
