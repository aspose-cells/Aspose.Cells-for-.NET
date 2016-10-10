Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System

Namespace Data.AddOn.NamedRanges
    Public Class CalculatingSumUsingNamedRange
        Public Shared Sub Run()
            ' ExStart:CalculatingSumUsingNamedRangeOnDifferentSheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook
            Dim book As New Workbook()

            ' Get the WorksheetCollection
            Dim worksheets As WorksheetCollection = book.Worksheets

            ' Insert some data in cell A1 of Sheet1
            worksheets("Sheet1").Cells("A1").PutValue(10)

            ' Add a new Worksheet and insert a value to cell A1
            worksheets(worksheets.Add()).Cells("A1").PutValue(10)

            ' Add a new Named Range with name "range"
            Dim index As Integer = worksheets.Names.Add("range")

            ' Access the newly created Named Range from the collection
            Dim range As Name = worksheets.Names(index)

            ' Set RefersTo property of the Named Range to a SUM function
            range.RefersTo = "=SUM(Sheet1!$A$1,Sheet2!$A$1)"

            ' Insert the Named Range as formula to 3rd worksheet
            worksheets(worksheets.Add()).Cells("A1").Formula = "range"

            ' Calculate formulas
            book.CalculateFormula()

            ' Save the result in XLSX format
            book.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:CalculatingSumUsingNamedRangeOnDifferentSheets
        End Sub
    End Class
End Namespace