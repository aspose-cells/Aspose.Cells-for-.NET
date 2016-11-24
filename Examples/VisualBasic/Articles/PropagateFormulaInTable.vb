Imports Aspose.Cells
Imports Aspose.Cells.Tables

Namespace Articles
    Public Class PropagateFormulaInTable
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim book As New Workbook()

            ' Access first worksheet
            Dim sheet As Worksheet = book.Worksheets(0)

            ' Add column headings in cell A1 and B1
            sheet.Cells(0, 0).PutValue("Column A")
            sheet.Cells(0, 1).PutValue("Column B")

            ' Add list object, set its name and style
            Dim listObject As ListObject = sheet.ListObjects(sheet.ListObjects.Add(0, 0, 1, sheet.Cells.MaxColumn, True))
            listObject.TableStyleType = TableStyleType.TableStyleMedium2
            listObject.DisplayName = "Table"

            ' Set the formula of second column so that it propagates to new rows automatically while entering data
            listObject.ListColumns(1).Formula = "=[Column A] + 1"

            ' Save the workbook in xlsx format
            book.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace