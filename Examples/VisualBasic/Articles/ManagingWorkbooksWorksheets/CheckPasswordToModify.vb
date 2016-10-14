Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class CheckPasswordToModify
        Public Shared Sub Run()
            ' ExStart:CheckPasswordToModifyUsingAsposeCells
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify password to open inside the load options
            Dim opts As New LoadOptions()
            opts.Password = "1234"

            ' Open the source Excel file with load options
            Dim workbook As New Workbook(dataDir & Convert.ToString("sampleBook.xlsx"), opts)

            ' Check if 567 is Password to modify
            Dim ret As Boolean = workbook.Settings.WriteProtection.ValidatePassword("567")
            Console.WriteLine("Is 567 correct Password to modify: " + ret)

            ' Check if 5679 is Password to modify
            ret = workbook.Settings.WriteProtection.ValidatePassword("5678")
            Console.WriteLine("Is 5678 correct Password to modify: " + ret)
            ' ExEnd:CheckPasswordToModifyUsingAsposeCells
        End Sub
    End Class
End Namespace