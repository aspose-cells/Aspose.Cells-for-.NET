Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.Handling.Find
    Public Class FindCellsStringNumber
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate the workbook object
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Get Cells collection
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            Dim opts As New FindOptions()
            opts.LookInType = LookInType.Values
            opts.LookAtType = LookAtType.EntireContent

            ' Find the cell with the input integer or double
            Dim cell1 As Cell = cells.Find(205, Nothing, opts)

            If cell1 IsNot Nothing Then
                Console.WriteLine("Name of the cell containing the value: " & cell1.Name)
            Else
                Console.WriteLine("Record not found ")
            End If

            ' Find the cell with the input string
            Dim cell2 As Global.Aspose.Cells.Cell = cells.Find("Items A", Nothing, opts)

            If cell2 IsNot Nothing Then
                Console.WriteLine("Name of the cell containing the value: " & cell2.Name)
            Else
                Console.WriteLine("Record not found ")
            End If

            ' Find the cell containing with the input string
            opts.LookAtType = LookAtType.Contains
            Dim cell3 As Cell = cells.Find("Data", Nothing, opts)

            If cell3 IsNot Nothing Then
                Console.WriteLine("Name of the cell containing the value: " & cell3.Name)
            Else
                Console.WriteLine("Record not found ")
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace