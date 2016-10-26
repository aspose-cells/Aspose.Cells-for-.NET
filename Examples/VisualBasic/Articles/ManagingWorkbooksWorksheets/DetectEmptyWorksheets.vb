Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class DetectEmptyWorksheets
        Public Shared Sub Run()
            ' ExStart:DetectEmptyWorksheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook and load an existing spreadsheet
            Dim book = New Workbook(dataDir & Convert.ToString("sample.xlsx"))
            ' Loop over all worksheets in the workbook
            For i As Integer = 0 To book.Worksheets.Count - 1
                Dim sheet As Worksheet = book.Worksheets(i)
                ' Check if worksheet has populated cells
                If sheet.Cells.MaxDataRow <> -1 Then
                    Console.WriteLine(sheet.Name + " is not empty because one or more cells are populated")
                    ' Check if worksheet has shapes
                ElseIf sheet.Shapes.Count > 0 Then
                    Console.WriteLine(sheet.Name + " is not empty because there are one or more shapes")
                Else
                    ' Check if worksheet has empty initialized cells
                    Dim range As Aspose.Cells.Range = sheet.Cells.MaxDisplayRange
                    Dim rangeIterator = range.GetEnumerator()
                    If rangeIterator.MoveNext() Then
                        Console.WriteLine(sheet.Name + " is not empty because one or more cells are initialized")
                    End If
                End If
            Next
            ' ExEnd:DetectEmptyWorksheets
        End Sub
    End Class
End Namespace