Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.Handling.Find
    Public Class FindDataOrFormulas
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate the workbook object
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Get Cells collection
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            ' Instantiate FindOptions Object
            Dim findOptions As New FindOptions()

            ' Create a Cells Area
            Dim ca As New CellArea()
            ca.StartRow = 8
            ca.StartColumn = 2
            ca.EndRow = 17
            ca.EndColumn = 13

            ' Set cells area for find options
            findOptions.SetRange(ca)

            ' Set searching properties
            findOptions.SearchNext = True
            findOptions.SeachOrderByRows = True

            ' Set the lookintype, you may specify, values, formulas, comments etc.
            findOptions.LookInType = LookInType.Values

            ' Set the lookattype, you may specify Match entire content, endswith, starwith etc.
            findOptions.LookAtType = LookAtType.EntireContent

            ' Find the cell with value
            Dim cell As Cell = cells.Find(205, Nothing, findOptions)

            If cell IsNot Nothing Then
                Console.WriteLine("Name of the cell containing the value: " & cell.Name)
            Else
                Console.WriteLine("Record not found ")
            End If
            ' ExEnd:1
        End Sub
    End Class
End Namespace