Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class VerifyPasswordUsedToProtectWorksheets
        Public Shared Sub Run()
            ' ExStart:VerifyPasswordUsedToProtectWorksheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook and load a spreadsheet
            Dim book = New Workbook(dataDir & Convert.ToString("Sample.xlsx"))

            ' Access the protected Worksheet
            Dim sheet = book.Worksheets(0)

            ' Check if Worksheet is password protected
            If sheet.Protection.IsProtectedWithPassword Then
                ' Verify the password used to protect the Worksheet
                If sheet.Protection.VerifyPassword("1234") Then
                    Console.WriteLine("Specified password has matched")
                Else
                    Console.WriteLine("Specified password has not matched")
                End If
            End If
            ' ExEnd:VerifyPasswordUsedToProtectWorksheets
        End Sub
    End Class
End Namespace