Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class ShowFormulasInsteadOfValues
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "source.xlsx"

            'Load the source workbook
            Dim workbook As New Workbook(filePath)

            'Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Show formulas of the worksheet
            worksheet.ShowFormulas = True

            'Save the workbook
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace