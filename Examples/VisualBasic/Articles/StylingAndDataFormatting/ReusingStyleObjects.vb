
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Articles.StylingAndDataFormatting
    Public Class ReusingStyleObjects
        Public Shared Sub Run()
            ' ExStart:ReusingStyleObjects
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object
            Dim workbook As New Workbook()

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access cells
            Dim cell1 As Cell = worksheet.Cells("A1")
            Dim cell2 As Cell = worksheet.Cells("B1")

            ' Set the styles of both cells to Times New Roman
            Dim styleObject As Style = workbook.CreateStyle()
            styleObject.Font.Color = System.Drawing.Color.Red
            styleObject.Font.Name = "Times New Roman"
            cell1.SetStyle(styleObject)
            cell2.SetStyle(styleObject)

            ' Put the values inside the cell
            cell1.PutValue("Hello World!")
            cell2.PutValue("Hello World!!")

            ' Save to Pdf without setting PdfSaveOptions.IsFontSubstitutionCharGranularity
            workbook.Save(dataDir & Convert.ToString("SampleOutput_out_.xlsx"))
            ' ExEnd:ReusingStyleObjects
        End Sub
    End Class
End Namespace
