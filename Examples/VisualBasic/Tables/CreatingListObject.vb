Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Tables
    Public Class CreatingListObject
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a Workbook object.
            'Open a template excel file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Get the List objects collection in the first worksheet.
            Dim listObjects As Global.Aspose.Cells.Tables.ListObjectCollection = workbook.Worksheets(0).ListObjects

            'Add a List based on the data source range with headers on.
            listObjects.Add(1, 1, 7, 5, True)

            'Show the total row for the List.
            listObjects(0).ShowTotals = True

            'Calculate the total of the last (5th ) list column.

            listObjects(0).ListColumns(4).TotalsCalculation = Global.Aspose.Cells.Tables.TotalsCalculation.Sum

            'Save the excel file.
            workbook.Save(dataDir & "ouput.out.xls")

        End Sub
    End Class
End Namespace