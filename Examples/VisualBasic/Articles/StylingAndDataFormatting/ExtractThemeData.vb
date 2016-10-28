Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class ExtractThemeData
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Extract theme name applied to this workbook
            Console.WriteLine(workbook.Theme)

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cell A1
            Dim cell As Cell = worksheet.Cells("A1")

            ' Get the style object
            Dim style As Style = cell.GetStyle()

            If style.ForegroundThemeColor IsNot Nothing Then
                ' Extract theme color applied to this cell if theme has foregroundtheme color defined
                Console.WriteLine(style.ForegroundThemeColor.ColorType)
            Else
                Console.WriteLine("Theme has not foreground color defined.")
            End If

            ' Extract theme color applied to the bottom border of the cell if theme has border color defined
            Dim bot As Border = style.Borders(BorderType.BottomBorder)
            If bot.ThemeColor IsNot Nothing Then
                Console.WriteLine(bot.ThemeColor.ColorType)
            Else
                Console.WriteLine("Theme has not Border color defined.")
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace