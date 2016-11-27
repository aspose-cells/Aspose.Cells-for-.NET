Namespace Introduction
    Public Class FirstApplication
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                ' Create a License object
                Dim license As New License()

                ' Set the license of Aspose.Cells to avoid the evaluation limitations
                license.SetLicense(dataDir & Convert.ToString("Aspose.Cells.lic"))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            ' Instantiate a Workbook object that represents Excel file.
            Dim wb As New Workbook()

            ' When you create a new workbook, a default "Sheet1" is added to the workbook.
            Dim sheet As Worksheet = wb.Worksheets(0)

            ' Access the "A1" cell in the sheet.
            Dim cell As Cell = sheet.Cells("A1")

            ' Input the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!")

            ' Save the Excel file.
            wb.Save(dataDir & Convert.ToString("MyBook_out.xlsx"), SaveFormat.Excel97To2003)
            ' ExEnd:1
        End Sub
    End Class
End Namespace
