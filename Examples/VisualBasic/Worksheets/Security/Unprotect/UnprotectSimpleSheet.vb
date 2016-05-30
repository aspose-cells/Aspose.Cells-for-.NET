Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Worksheets.Security.Unprotect
    Public Class UnprotectSimpleSheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Unprotecting the worksheet without a password
            worksheet.Unprotect()

            ' Saving the Workbook
            workbook.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)
            ' ExEnd:1


        End Sub
    End Class
End Namespace