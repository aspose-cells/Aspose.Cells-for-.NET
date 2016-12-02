Namespace KnowledgeBase.FAQs
    Public Class FixOutOfMemoryException
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify the LoadOptions
            Dim options As New LoadOptions()

            ' Set the memory preferences
            options.MemorySetting = MemorySetting.MemoryPreference

            ' Load the Big Excel file having large Data set in it
            Dim book As New Workbook(dataDir & Convert.ToString("sample.xlsx"), options)
            Console.WriteLine("File has been loaded successfully")
            ' ExEnd:1
        End Sub
    End Class
End Namespace

