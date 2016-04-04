Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Worksheets.Security.Protecting
    Public Class ProtectingWorksheet
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            'Instantiating a Workbook object
            'Opening the Excel file through the file stream
            Dim excel As New Workbook(fstream)

            'Accessing the first worksheet in the Excel file
            Dim worksheet As Worksheet = excel.Worksheets(0)

            'Protecting the worksheet with a password
            worksheet.Protect(ProtectionType.All, "aspose", Nothing)

            'Saving the modified Excel file in default format
            excel.Save(dataDir & "output.xls", SaveFormat.Excel97To2003)

            'Closing the file stream to free all resources
            fstream.Close()
            'ExEnd:1
        End Sub
    End Class
End Namespace