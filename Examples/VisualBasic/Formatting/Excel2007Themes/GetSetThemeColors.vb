Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports System

Namespace Formatting.Excel2007Themes
    Public Class GetSetThemeColors
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate Workbook object.
            ' Open an exiting excel file.
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            ' Get the Background1 theme color.
            Dim c As Color = workbook.GetThemeColor(ThemeColorType.Background1)

            ' Print the color.
            Console.WriteLine("theme color Background1: " & c.ToString())

            ' Get the Accent2 theme color.
            c = workbook.GetThemeColor(ThemeColorType.Accent2)

            ' Print the color.
            Console.WriteLine("theme color Accent2: " & c.ToString())

            ' Change the Background1 theme color.
            workbook.SetThemeColor(ThemeColorType.Background1, Color.Red)

            ' Get the updated Background1 theme color.
            c = workbook.GetThemeColor(ThemeColorType.Background1)

            ' Print the updated color for confirmation.
            Console.WriteLine("theme color Background1 changed to: " & c.ToString())

            ' Change the Accent2 theme color.
            workbook.SetThemeColor(ThemeColorType.Accent2, Color.Blue)

            ' Get the updated Accent2 theme color.
            c = workbook.GetThemeColor(ThemeColorType.Accent2)

            ' Print the updated color for confirmation.
            Console.WriteLine("theme color Accent2 changed to: " & c.ToString())

            ' Save the updated file.
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace