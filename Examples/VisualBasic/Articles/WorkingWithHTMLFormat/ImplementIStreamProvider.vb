Imports System.IO
Imports Aspose.Cells

Namespace Articles.WorkingWithHTMLFormat
    ' ExStart:ExportStreamProviderClass
    Public Class ExportStreamProvider
        Implements IStreamProvider
        Private outputDir As String

        Public Sub New(dir As String)
            outputDir = dir
        End Sub

        Public Sub InitStream(options As StreamProviderOptions) Implements IStreamProvider.InitStream
            Dim path__1 As String = outputDir & Path.GetFileName(options.DefaultPath)
            options.CustomPath = path__1
            Directory.CreateDirectory(Path.GetDirectoryName(path__1))
            options.Stream = File.Create(path__1)
        End Sub

        Public Sub CloseStream(options As StreamProviderOptions) Implements IStreamProvider.CloseStream
            If options IsNot Nothing AndAlso options.Stream IsNot Nothing Then
                options.Stream.Close()
            End If
        End Sub
    End Class
    ' ExEnd:ExportStreamProviderClass

    Public Class ImplementIStreamProvider
        Public Shared Sub Run()
            ' ExStart:ImplementIStreamProvider
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim outputDir As String = dataDir & Convert.ToString("out\")

            ' Create workbook
            Dim wb As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            Dim options As New HtmlSaveOptions()
            options.StreamProvider = New ExportStreamProvider(outputDir)

            ' Save into .html using HtmlSaveOptions
            wb.Save(dataDir & Convert.ToString("output_out_.html"), options)
            ' ExEnd:ImplementIStreamProvider
        End Sub
    End Class
End Namespace