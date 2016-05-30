Imports System.IO

Imports Aspose.Cells

Namespace Worksheets.Display
    Public Class RemovePanes
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a new workbook and Open a template file
            Dim book As New Workbook(dataDir & "Book1.xls")

            ' Set the active cell
            book.Worksheets(0).ActiveCell = "A20"

            ' Split the worksheet window
            book.Worksheets(0).RemoveSplit()

            ' Save the excel file
            book.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
