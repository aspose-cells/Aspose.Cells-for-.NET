Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class SetWorksheetTabColor
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook
            'Open an Excel file
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")

            'Get the first worksheet in the book
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Set the tab color
            worksheet.TabColor = Color.Red

            'Save the Excel file
            workbook.Save(dataDir & "worksheettabcolor.out.xls")

        End Sub
    End Class
End Namespace