Imports System.IO
Imports System
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.CellsHelperClass
    Public Class MergeFiles
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create an Array (length=2)
            Dim files(1) As String
            'Specify files with their paths to be merged
            files(0) = dataDir & "Book1.xls"
            files(1) = dataDir & "Book2.xls"

            'Create a cachedFile for the process
            Dim cacheFile As String = dataDir & "test.txt"

            'Output File to be created
            Dim dest As String = dataDir & "output.xlsx"

            'Merge the files in the output file. Supports only .xls files
            CellsHelper.MergeFiles(files, cacheFile, dest)


            'Now if you need to rename your sheets, you may load the output file
            Dim workbook As New Workbook(dataDir & "output.xlsx")

            Dim i As Integer = 1

            'Browse all the sheets to rename them accordingly
            For Each sheet As Worksheet In workbook.Worksheets
                sheet.Name = "Sheet1" & i.ToString()
                i += 1

            Next sheet

            'Re-save the file
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1


        End Sub
    End Class
End Namespace
