Namespace KnowledgeBase.FAQs
    Public Class FileFormatInformation
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load File
            Dim finfo As FileFormatInfo = FileFormatUtil.DetectFileFormat(dataDir & Convert.ToString("sample.xls"))
            Console.WriteLine(finfo.FileFormatType = FileFormatType.Excel95)
            ' ExEnd:1
        End Sub
    End Class
End Namespace

