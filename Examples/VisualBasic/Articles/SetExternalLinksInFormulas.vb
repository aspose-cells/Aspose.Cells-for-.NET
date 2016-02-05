Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class SetExternalLinksInFormulas
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)



            'Instantiate a new Workbook.
            Dim workbook As New Workbook()

            'Get first Worksheet
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Get Cells collection
            Dim cells As Global.Aspose.Cells.Cells = sheet.Cells

            'Set formula with external links
            cells("A1").Formula = "=SUM('[" & dataDir & "book1.xlsx]Sheet1'!A2, '[" & dataDir & "book1.xlsx]Sheet1'!A4)"

            'Set formula with external links
            cells("A2").Formula = "='[" & dataDir & "book1.xlsx]Sheet1'!A8"

            'Save the workbook
            workbook.Save(dataDir & "output.out.xlsx")




        End Sub
    End Class
End Namespace