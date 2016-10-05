
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class DisplayBulletsInCellUsingHtml
        Public Shared Sub Run()
            ' ExStart:DisplayBulletsInCellUsingHtml
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cell A1
            Dim cell As Cell = worksheet.Cells("A1")

            ' Set the HTML string
            cell.HtmlString = "<font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'>Text 1 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 2 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 3 </font><font style='font-family:Wingdings;font-size:8.0pt;color:#009DD9;mso-font-charset:2;'>l</font><font style='font-family:Arial;font-size:10pt;color:#666666;vertical-align:top;text-align:left;'> Text 4 </font>"

            ' Auto fit the Columns
            worksheet.AutoFitColumns()

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("BulletsInCells_out_.xlsx"))
            ' ExEnd:DisplayBulletsInCellUsingHtml
        End Sub
    End Class
End Namespace
