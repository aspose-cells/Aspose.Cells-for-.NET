Imports System.IO

Namespace Introduction
    Public Class OpenExistingFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Try
                ' Create a License object
                Dim license As New License()

                ' Set the license of Aspose.Cells to avoid the evaluation limitations
                license.SetLicense("Aspose.Cells.lic")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            ' Creating a file stream containing the Excel file to be opened
            Dim fstream As New FileStream(dataDir & Convert.ToString("Sample.xlsx"), FileMode.Open)

            ' Instantiate a Workbook object that represents the existing Excel file
            Dim workbook As New Workbook(fstream)

            ' Get the reference of "A1" cell from the cells collection of a worksheet
            Dim cell As Cell = workbook.Worksheets(0).Cells("A1")

            ' Put the "Hello World!" text into the "A1" cell
            cell.PutValue("Hello World!")

            ' Save the Excel file
            workbook.Save(dataDir & Convert.ToString("HelloWorld_out.xlsx"))

            ' Closing the file stream to free all resources
            fstream.Close()
            ' ExEnd:1
        End Sub
    End Class
End Namespace