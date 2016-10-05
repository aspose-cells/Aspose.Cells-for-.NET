
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class CustomDecimalAndGroupSeparator
        Public Shared Sub Run()
            ' ExStart:CustomDecimalAndGroupSeparator
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook()

            ' Specify custom separators
            workbook.Settings.NumberDecimalSeparator = "."c
            workbook.Settings.NumberGroupSeparator = " "c

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Set cell value
            Dim cell As Cell = worksheet.Cells("A1")
            cell.PutValue(123456.789)

            ' Set custom cell style
            Dim style As Style = cell.GetStyle()
            style.[Custom] = "#,##0.000;[Red]#,##0.000"
            cell.SetStyle(style)

            worksheet.AutoFitColumns()

            ' Save workbook as pdf
            workbook.Save(dataDir & Convert.ToString("CustomSeparator_out_.pdf"))
            ' ExEnd:CustomDecimalAndGroupSeparator
        End Sub
    End Class
End Namespace
