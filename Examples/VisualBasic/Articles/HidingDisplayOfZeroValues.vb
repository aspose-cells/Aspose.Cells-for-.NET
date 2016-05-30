Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class HidingDisplayOfZeroValues
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Create a new Workbook object
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            ' Get First worksheet of the workbook
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Hide the zero values in the sheet
            sheet.DisplayZeros = False

            ' Save the workbook
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace