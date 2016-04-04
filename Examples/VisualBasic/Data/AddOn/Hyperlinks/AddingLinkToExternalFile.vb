Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.AddOn.Hyperlinks
    Public Class AddingLinkToExternalFile
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Excel object
            Dim i As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(i)

            'Adding an internal hyperlink to the "B9" cell of the other worksheet "Sheet2" in
            'the same Excel file
            worksheet.Hyperlinks.Add("A5", 1, 1, dataDir & "book1.xls")

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1
        End Sub
    End Class
End Namespace