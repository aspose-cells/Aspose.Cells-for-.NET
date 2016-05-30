Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class Implement1904DateSystem
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Initialize a new Workbook
            ' Open an excel file
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            ' Implement 1904 date system
            workbook.Settings.Date1904 = True

            ' Save the excel file
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1



        End Sub
    End Class
End Namespace