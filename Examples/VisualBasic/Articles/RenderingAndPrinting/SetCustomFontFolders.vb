Imports System.IO
Imports Aspose.Cells

Namespace Articles.RenderingAndPrinting
    Public Class SetCustomFontFolders
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Defining string variables to store paths to font folders & font file
            Dim fontFolder1 As String = dataDir & Convert.ToString("Arial")
            Dim fontFolder2 As String = dataDir & Convert.ToString("Calibri")
            Dim fontFile As String = dataDir & Convert.ToString("arial.ttf")

            ' Setting first font folder with SetFontFolder method
            ' Second parameter directs the API to search the subfolders for font files
            FontConfigs.SetFontFolder(fontFolder1, True)

            ' Setting both font folders with SetFontFolders method
            ' Second parameter prohibits the API to search the subfolders for font files
            FontConfigs.SetFontFolders(New String() {fontFolder1, fontFolder2}, False)

            ' Defining FolderFontSource
            Dim sourceFolder As New FolderFontSource(fontFolder1, False)

            ' Defining FileFontSource
            Dim sourceFile As New FileFontSource(fontFile)

            ' Defining MemoryFontSource
            Dim sourceMemory As New MemoryFontSource(System.IO.File.ReadAllBytes(fontFile))

            ' Setting font sources
            FontConfigs.SetFontSources(New FontSourceBase() {sourceFolder, sourceFile, sourceMemory})
            ' ExEnd:1          

        End Sub
        Public Shared Sub FontSubstitution()
            ' ExStart:FontSubstitution
            ' Substituting the Arial font with Times New Roman & Calibri
            FontConfigs.SetFontSubstitutes("Arial", New String() {"Times New Roman", "Calibri"})
            ' ExEnd:FontSubstitution
        End Sub
    End Class
End Namespace