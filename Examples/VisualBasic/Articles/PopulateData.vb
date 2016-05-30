Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class PopulateData
        Public Shared Sub Run()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook()
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells
            cells("A1").PutValue("data1")
            cells("B1").PutValue("data2")
            cells("A2").PutValue("data3")
            cells("B2").PutValue("data4")
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1

        End Sub
    End Class
End Namespace