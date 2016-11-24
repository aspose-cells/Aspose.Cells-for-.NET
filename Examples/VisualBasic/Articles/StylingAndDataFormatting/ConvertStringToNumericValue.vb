
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class ConvertStringToNumericValue
        Public Shared Sub Run()
            ' ExStart:ConvertTextNumericDatatoNumber
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate workbook object with an Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("SampleBook.xlsx"))

            For i As Integer = 0 To workbook.Worksheets.Count - 1
                workbook.Worksheets(i).Cells.ConvertStringToNumericValue()
            Next

            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:ConvertTextNumericDatatoNumber
        End Sub
    End Class
End Namespace
