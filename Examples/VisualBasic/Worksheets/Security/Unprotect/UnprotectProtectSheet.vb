Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Security.Unprotect
    Public Class UnprotectingProtectedWorksheet
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Unprotecting the worksheet with a password
            worksheet.Unprotect("aspose")

            'Save Workbook
            workbook.Save(dataDir & "output.out.xls")

        End Sub
    End Class
End Namespace