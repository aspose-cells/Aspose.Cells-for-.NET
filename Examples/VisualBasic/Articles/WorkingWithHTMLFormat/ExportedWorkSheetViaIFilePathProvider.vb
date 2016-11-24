Imports System.IO
Imports Aspose.Cells

Namespace Articles.WorkingWithHTMLFormat
    ' ExStart:ExportedWorkSheetViaIFilePathProvider
    Public Class ExportedWorkSheetViaIFilePathProvider
        ' This is the directory path which contains the sample.xlsx file
        Shared dirPath As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
        Private Shared Sub Main(args As String())
            ' If you will not set the license, program will go in infinite loop
            ' because Aspose.Cells will always make the warning worksheet as active sheet in Evaluation mode.
            SetLicense()

            ' Check if license is set, otherwise do not proceed
            Dim wb As New Workbook()
            If wb.IsLicensed = False Then
                Console.WriteLine("You must set the license to execute this code successfully.")
                Console.ReadKey()
            Else
                ' Test IFilePathProvider interface
                TestFilePathProvider()
            End If
        End Sub

        Private Shared Sub SetLicense()
            Dim licPath As String = "Aspose.Cells.lic"

            Dim lic As New Aspose.Cells.License()
            lic.SetLicense(licPath)

            Console.WriteLine(CellsHelper.GetVersion())
            System.Diagnostics.Debug.WriteLine(CellsHelper.GetVersion())

            Environment.CurrentDirectory = dirPath
        End Sub

        Private Shared Sub TestFilePathProvider()
            ' Create subdirectory for second and third worksheets
            Directory.CreateDirectory(dirPath & Convert.ToString("OtherSheets"))

            ' Load sample workbook from your directory
            Dim wb As New Workbook(dirPath & Convert.ToString("Sample.xlsx"))

            ' Save worksheets to separate html files
            ' Because of IFilePathProvider, hyperlinks will not be broken.
            For i As Integer = 0 To wb.Worksheets.Count - 1
                ' Set the active worksheet to current value of variable i
                wb.Worksheets.ActiveSheetIndex = i

                ' Creat html save option
                Dim options As New HtmlSaveOptions()
                options.ExportActiveWorksheetOnly = True

                ' ExStart:hyperlinks
                ' If you will comment this line, then hyperlinks will be broken
                options.FilePathProvider = New FilePathProvider()
                ' ExEnd:hyperlinks

                ' Sheet actual index which starts from 1 not from 0
                Dim sheetIndex As Integer = i + 1

                Dim filePath As String = ""

                ' Save first sheet to same directory and second and third worksheets to subdirectory
                If i = 0 Then
                    filePath = dirPath & Convert.ToString("Sheet1.html")
                Else
                    filePath = (dirPath & Convert.ToString("OtherSheets\Sheet")) + sheetIndex + "_out.html"
                End If

                ' Save the worksheet to html file
                wb.Save(filePath, options)
            Next
        End Sub
    End Class
    ' Implementation of IFilePathProvider interface
    Public Class FilePathProvider
        Implements IFilePathProvider

        ' Constructor        
        Public Sub New()
        End Sub

        Function GetFullName(ByVal sheetName As String) As String Implements IFilePathProvider.GetFullName
            If "Sheet2".Equals(sheetName) Then
                Return "file:///" & "OtherSheets\Sheet2.html"
            ElseIf "Sheet3".Equals(sheetName) Then
                Return "file:///" & "OtherSheets\Sheet3.html"
            End If

            Return ""
        End Function
    End Class
    ' ExEnd:ExportedWorkSheetViaIFilePathProvider
End Namespace