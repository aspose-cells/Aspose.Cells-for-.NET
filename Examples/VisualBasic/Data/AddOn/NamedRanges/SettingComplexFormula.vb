Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System

Namespace Data.AddOn.NamedRanges
    Public Class SettingComplexFormula
        Public Shared Sub Run()
            ' ExStart:SettingComplexFormulaNamedRange
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook
            Dim book As New Workbook()

            ' Get the WorksheetCollection
            Dim worksheets As WorksheetCollection = book.Worksheets

            ' Add a new Named Range with name "data"
            Dim index As Integer = worksheets.Names.Add("data")

            ' Access the newly created Named Range from the collection
            Dim data As Name = worksheets.Names(index)

            ' Set RefersTo property of the Named Range to a cell range in same worksheet
            data.RefersTo = "=Sheet1!$A$1:$A$10"

            ' Add another Named Range with name "range"
            index = worksheets.Names.Add("range")

            ' Access the newly created Named Range from the collection
            Dim range As Name = worksheets.Names(index)

            ' Set RefersTo property to a formula using the Named Range data
            range.RefersTo = "=INDEX(data,Sheet1!$A$1,1):INDEX(data,Sheet1!$A$1,9)"

            ' Save the workbook
            book.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:SettingComplexFormulaNamedRange
        End Sub
    End Class
End Namespace