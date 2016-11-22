Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports Aspose.Cells

Namespace Articles
    Public Class ConvertXLSFileToPDF
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                ' Get the template excel file path.
                Dim designerFile As String = dataDir & "SampleInput.xlsx"

                ' Specify the pdf file path.
                Dim pdfFile As String = dataDir & "Output.out.pdf"

                ' Open the template excel file which you have to
                Dim wb As New Global.Aspose.Cells.Workbook(designerFile)

                ' Save the pdf file.
                wb.Save(pdfFile, SaveFormat.Pdf)
            Catch e As Exception
                Console.WriteLine(e.Message)
                Console.ReadLine()
                ' ExEnd:1
            End Try
        End Sub
    End Class
End Namespace
