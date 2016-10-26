Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class CheckIfPasswordProtected
        Public Shared Sub Run()
            ' ExStart:CheckIfPasswordProtected
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook and load a spreadsheet
            Dim book = New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the protected Worksheet
            Dim sheet = book.Worksheets(0)

            ' Check if Worksheet is password protected
            If sheet.Protection.IsProtectedWithPassword Then
                Console.WriteLine("Worksheet is password protected")
            Else
                Console.WriteLine("Worksheet is not password protected")
            End If
            ' ExEnd:CheckIfPasswordProtected
        End Sub
    End Class
End Namespace