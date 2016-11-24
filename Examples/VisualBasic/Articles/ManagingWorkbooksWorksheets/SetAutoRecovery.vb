Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class SetAutoRecovery
        Public Shared Sub Run()
            ' ExStart:SetAutoRecovery
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Read AutoRecover property
            Console.WriteLine("AutoRecover: " + workbook.Settings.AutoRecover)

            ' Set AutoRecover property to false
            workbook.Settings.AutoRecover = False

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))

            ' Read the saved workbook again
            workbook = New Workbook(dataDir & Convert.ToString("output_out.xlsx"))

            ' Read AutoRecover property
            Console.WriteLine("AutoRecover: " + workbook.Settings.AutoRecover)
            ' ExEnd:SetAutoRecovery
        End Sub
    End Class
End Namespace