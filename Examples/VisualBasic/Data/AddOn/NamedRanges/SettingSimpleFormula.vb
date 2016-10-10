Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Cells
Imports System

Namespace Data.AddOn.NamedRanges
    Public Class SettingSimpleFormula
        Public Shared Sub Run()
            ' ExStart:SettingSimpleFormulaForNamedRanges
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create an instance of Workbook
            Dim book As New Workbook()

            ' Get the WorksheetCollection
            Dim worksheets As WorksheetCollection = book.Worksheets

            ' Add a new Named Range with name "NewNamedRange"
            Dim index As Integer = worksheets.Names.Add("NewNamedRange")

            ' Access the newly created Named Range
            Dim name As Name = worksheets.Names(index)

            ' Set RefersTo property of the Named Range to a formula. Formula references another cell in the same worksheet
            name.RefersTo = "=Sheet1!$A$3"

            ' Set the formula in the cell A1 to the newly created Named Range
            worksheets(0).Cells("A1").Formula = "NewNamedRange"

            ' Insert the value in cell A3 which is being referenced in the Named Range
            worksheets(0).Cells("A3").PutValue("This is the value of A3")

            ' Calculate formulas
            book.CalculateFormula()

            ' Save the result in XLSX format
            book.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:SettingSimpleFormulaForNamedRanges
        End Sub
    End Class
End Namespace