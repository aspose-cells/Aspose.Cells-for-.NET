Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class ImplementingNonSequencedRanges
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Adding a Name for non sequenced range
            Dim index As Integer = workbook.Worksheets.Names.Add("NonSequencedRange")

            Dim name As Name = workbook.Worksheets.Names(index)

            ' Creating a non sequence range of cells
            name.RefersTo = "=Sheet1!$A$1:$B$3,Sheet1!$E$5:$D$6"

            ' Save the workbook
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace