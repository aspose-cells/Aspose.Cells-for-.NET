Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Tables

Namespace Tables
    Public Class SetCommentOfTableOrListObject
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open the template file.
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet.
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first list object or table.
            Dim lstObj As ListObject = worksheet.ListObjects(0)

            ' Set the comment of the list object
            lstObj.Comment = "This is Aspose.Cells comment."

            ' Save the workbook in xlsx format
            workbook.Save(dataDir & Convert.ToString("SetCommentOfTableOrListObject_out_.xlsx"), SaveFormat.Xlsx)
            ' ExEnd:1

        End Sub
    End Class
End Namespace

