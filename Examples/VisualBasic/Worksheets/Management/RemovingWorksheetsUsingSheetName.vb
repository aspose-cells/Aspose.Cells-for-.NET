Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Worksheets.Management
    Public Class RemovingWorksheetsUsingSheetName
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & "book1.xls", FileMode.Open)

            ' Instantiating a Workbook object
            ' Opening the Excel file through the file stream
            Dim workbook As New Workbook(fstream)

            ' Removing a worksheet using its sheet name
            workbook.Worksheets.RemoveAt("Sheet1")

            ' Save workbook
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace