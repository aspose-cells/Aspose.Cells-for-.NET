Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Management
    Public Class AddingWorksheetsToNewExcelFile
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Workbook object
            Dim i As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(i)

            'Setting the name of the newly added worksheet
            worksheet.Name = "My Worksheet"

            'Saving the Excel file
            workbook.Save(dataDir & "output.out.xls")
        End Sub
    End Class
End Namespace