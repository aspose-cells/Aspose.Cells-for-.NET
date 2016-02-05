Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class CombineMultipleWorkbooksSingleWorkbook
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            'Define the first source
            'Open the first excel file.
            Dim SourceBook1 As New Workbook(dataDir & "SampleChart.xlsx")

            'Define the second source book.
            'Open the second excel file.
            Dim SourceBook2 As New Workbook(dataDir & "SampleImage.xlsx")

            'Combining the two workbooks
            SourceBook1.Combine(SourceBook2)

            'Save the target book file.
            SourceBook1.Save(dataDir & "Combined.out.xlsx")

        End Sub
    End Class
End Namespace