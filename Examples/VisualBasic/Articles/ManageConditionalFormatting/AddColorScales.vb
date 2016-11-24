Imports System.IO
Imports Aspose.Cells
Imports System.Drawing

Namespace Articles.ManageConditionalFormatting
    Public Class AddColorScales
        Public Shared Sub Run()
            ' ExStart:AddColorScales
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook
            Dim workbook As New Workbook()

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add some data in cells
            worksheet.Cells("A1").PutValue("2-Color Scale")
            worksheet.Cells("D1").PutValue("3-Color Scale")

            For i As Integer = 2 To 15
                worksheet.Cells(Convert.ToString("A") & i).PutValue(i)
                worksheet.Cells(Convert.ToString("D") & i).PutValue(i)
            Next

            ' Adding 2-Color Scale Conditional Formatting
            Dim ca As CellArea = CellArea.CreateCellArea("A2", "A15")

            Dim idx As Integer = worksheet.ConditionalFormattings.Add()
            Dim fcc As FormatConditionCollection = worksheet.ConditionalFormattings(idx)
            fcc.AddCondition(FormatConditionType.ColorScale)
            fcc.AddArea(ca)

            Dim fc As FormatCondition = worksheet.ConditionalFormattings(idx)(0)
            fc.ColorScale.Is3ColorScale = False
            fc.ColorScale.MaxColor = Color.LightBlue
            fc.ColorScale.MinColor = Color.LightGreen

            ' Adding 3-Color Scale Conditional Formatting
            ca = CellArea.CreateCellArea("D2", "D15")

            idx = worksheet.ConditionalFormattings.Add()
            fcc = worksheet.ConditionalFormattings(idx)
            fcc.AddCondition(FormatConditionType.ColorScale)
            fcc.AddArea(ca)

            fc = worksheet.ConditionalFormattings(idx)(0)
            fc.ColorScale.Is3ColorScale = True
            fc.ColorScale.MaxColor = Color.LightBlue
            fc.ColorScale.MidColor = Color.Yellow
            fc.ColorScale.MinColor = Color.LightGreen

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:AddColorScales
        End Sub
    End Class
End Namespace