Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Files.Handling
    Public Class OpeningFilewithDataOnly
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Load only specific sheets with data and formulas
            ' Other objects, items etc. would be discarded

            ' Instantiate LoadOptions specified by the LoadFormat
            Dim loadOptions7 As New LoadOptions(LoadFormat.Xlsx)

            ' Set the LoadDataOption
            Dim dataOption As New LoadDataOption()
            ' Specify the sheet(s) in the template file to be loaded
            dataOption.SheetNames = New String() {"Sheet2"}
            dataOption.ImportFormula = True
            ' Only data should be loaded.
            loadOptions7.LoadDataOnly = True
            ' Specify the LoadDataOption
            loadOptions7.LoadDataOptions = dataOption

            ' Create a Workbook object and opening the file from its path
            Dim wb As New Workbook(dataDir & "Book1.xlsx", loadOptions7)
            Console.WriteLine("File data imported successfully!")
            ' ExEnd:1

        End Sub
    End Class
End Namespace
