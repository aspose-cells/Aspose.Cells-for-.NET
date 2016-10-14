Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManagingWorkbooksWorksheets
    Public Class DetectFileFormatAndEncryption
        Public Shared Sub Run()
            ' ExStart:DetectFileFormatAndEncryption
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Detect file format
            Dim info As FileFormatInfo = FileFormatUtil.DetectFileFormat(dataDir & Convert.ToString("Book1.xlsx"))

            'Gets the detected load format
            Console.WriteLine("The spreadsheet format is: " + FileFormatUtil.LoadFormatToExtension(info.LoadFormat))

            'Check if the file is encrypted.
            Console.WriteLine("The file is encrypted: " + info.IsEncrypted)
            ' ExEnd:DetectFileFormatAndEncryption
        End Sub
    End Class
End Namespace