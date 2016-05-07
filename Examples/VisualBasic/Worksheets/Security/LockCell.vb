Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Security
    Public Class LockCell
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook(dataDir & "Book1.xlsx")

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            worksheet.Cells("A1").GetStyle().IsLocked = True
            ' Finally, Protect the sheet now.

            worksheet.Protect(ProtectionType.All)
            workbook.Save(dataDir & "output.xlsx")

            'ExEnd:1


        End Sub
    End Class
End Namespace
