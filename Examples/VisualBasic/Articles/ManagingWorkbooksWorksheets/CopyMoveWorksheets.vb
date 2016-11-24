Namespace Articles.ManagingWorkbooksWorksheets
    Public Class CopyMoveWorksheets
        Public Shared Sub Run()
            ' ExStart:CopyWorksheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Open a file into the first book.
            Dim excelWorkbook1 As New Workbook(dataDir & Convert.ToString("FirstWorkbook.xlsx"))

            ' Copy the first sheet of the first book with in the workbook
            excelWorkbook1.Worksheets(2).Copy(excelWorkbook1.Worksheets("Copy"))

            ' Save the file.
            excelWorkbook1.Save(dataDir & Convert.ToString("FirstWorkbookCopied_out.xlsx"))
            ' ExEnd:CopyWorksheets

            ' ExStart:MoveWorksheets
            ' Open a file into the first book.
            Dim excelWorkbook2 As New Workbook(dataDir & Convert.ToString("FirstWorkbook.xlsx"))

            ' Move the sheet
            excelWorkbook2.Worksheets("Move").MoveTo(2)

            ' Save the file.
            excelWorkbook2.Save(dataDir & Convert.ToString("FirstWorkbookMoved_out.xlsx"))
            ' ExEnd:MoveWorksheets

            ' ExStart:CopyWorksheetsBetweenWorkbooks
            ' Open a file into the first book.
            Dim excelWorkbook3 As New Workbook(dataDir & Convert.ToString("FirstWorkbook.xlsx"))

            ' Open a file into the second book.
            Dim excelWorkbook4 As New Workbook(dataDir & Convert.ToString("SecondWorkbook.xlsx"))

            ' Add new worksheet into second Workbook
            excelWorkbook4.Worksheets.Add()

            ' Copy the first sheet of the first book into second book.
            excelWorkbook4.Worksheets(1).Copy(excelWorkbook3.Worksheets("Copy"))

            ' Save the file.
            excelWorkbook4.Save(dataDir & Convert.ToString("CopyWorksheetsBetweenWorkbooks_out.xlsx"))
            ' ExEnd:CopyWorksheetsBetweenWorkbooks

            ' ExStart:MoveWorksheetsBetweenWorkbooks
            'Open a file into the first book.
            Dim excelWorkbook5 As New Workbook(dataDir & Convert.ToString("FirstWorkbook.xlsx"))

            'Create another Workbook. Open a file into the Second book.
            Dim excelWorkbook6 As New Workbook(dataDir & Convert.ToString("SecondWorkbook.xlsx"))

            'Add New Worksheet
            excelWorkbook6.Worksheets.Add()

            'Copy the sheet from first book into second book.
            excelWorkbook6.Worksheets(2).Copy(excelWorkbook5.Worksheets(2))

            'Remove the copied worksheet from first workbook
            excelWorkbook5.Worksheets.RemoveAt(2)

            'Save the file.
            excelWorkbook5.Save(dataDir & Convert.ToString("FirstWorkbookWithMove_out.xlsx"))

            'Save the file.
            excelWorkbook6.Save(dataDir & Convert.ToString("SecondWorkbookWithMove_out.xlsx"))
            ' ExEnd:MoveWorksheetsBetweenWorkbooks
        End Sub
    End Class
End Namespace