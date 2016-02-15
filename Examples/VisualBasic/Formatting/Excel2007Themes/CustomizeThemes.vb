Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting.Excel2007Themes
    Public Class CustomizeThemes
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Define Color array (of 12 colors) for Theme.
            Dim carr(11) As Color
            carr(0) = Color.AntiqueWhite ' Background1
            carr(1) = Color.Brown ' Text1
            carr(2) = Color.AliceBlue ' Background2
            carr(3) = Color.Yellow ' Text2
            carr(4) = Color.YellowGreen ' Accent1
            carr(5) = Color.Red ' Accent2
            carr(6) = Color.Pink ' Accent3
            carr(7) = Color.Purple ' Accent4
            carr(8) = Color.PaleGreen ' Accent5
            carr(9) = Color.Orange ' Accent6
            carr(10) = Color.Green ' Hyperlink
            carr(11) = Color.Gray ' Followed Hyperlink

            'Instantiate a Workbook.
            'Open the template file.
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            'Set the custom theme with specified colors.
            workbook.CustomTheme("CustomeTheme1", carr)

            'Save as the excel file.
            workbook.Save(dataDir & "output.xlsx")


        End Sub
    End Class
End Namespace