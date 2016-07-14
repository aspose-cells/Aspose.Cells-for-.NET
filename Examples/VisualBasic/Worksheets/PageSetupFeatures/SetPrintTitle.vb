Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class SetPrintTitle
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Obtaining the reference of the PageSetup of the worksheet
            Dim pageSetup As Aspose.Cells.PageSetup = workbook.Worksheets(0).PageSetup

            ' Defining column numbers A & B as title columns
            pageSetup.PrintTitleColumns = "$A:$B"

            ' Defining row numbers 1 & 2 as title rows
            pageSetup.PrintTitleRows = "$1:$2"

            ' Save the workbook.
            workbook.Save(dataDir & Convert.ToString("SetPrintTitle_out.xls"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace