Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class DisableCompatibilityChecker
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Open a template file
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            ' Disable the compatibility checker
            workbook.Settings.CheckCompatibility = False

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace