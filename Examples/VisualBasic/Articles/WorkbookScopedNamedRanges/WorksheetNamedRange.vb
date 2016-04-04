Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles.OptimizingMemoryUsage
    Public Class WorksheetNamedRange
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new Workbook object
            Dim workbook As New Workbook()

            'get first worksheet of the workbook
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Get worksheet's cells collection
            Dim cells As Global.Aspose.Cells.Cells = sheet.Cells
            'Create a range of Cells
            Dim localRange As Range = cells.CreateRange("A1", "C10")

            'Assign name to range with sheet raference
            localRange.Name = "Sheet1!local"

            'save the workbook
            workbook.Save(dataDir & "ouput.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace