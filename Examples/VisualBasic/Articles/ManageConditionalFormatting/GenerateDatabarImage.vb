Imports System.IO
Imports Aspose.Cells
Imports System.Drawing
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Articles.ManageConditionalFormatting
    Public Class GenerateDatabarImage
        Public Shared Sub Run()
            ' ExStart:GenerateDatabarImage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the cell which contains conditional formatting databar
            Dim cell As Cell = worksheet.Cells("C1")

            ' Create and get the conditional formatting of the worksheet
            Dim idx As Integer = worksheet.ConditionalFormattings.Add()
            Dim fcc As FormatConditionCollection = worksheet.ConditionalFormattings(idx)
            fcc.AddCondition(FormatConditionType.DataBar)

            ' Access the conditional formatting databar
            Dim dbar As DataBar = fcc(0).DataBar

            ' Create image or print options
            Dim opts As New ImageOrPrintOptions()
            opts.ImageFormat = ImageFormat.Png

            ' Get the image bytes of the databar
            Dim imgBytes As Byte() = dbar.ToImage(cell, opts)

            ' Write image bytes on the disk
            File.WriteAllBytes(dataDir & Convert.ToString("databar_out_.png"), imgBytes)
            ' ExEnd:GenerateDatabarImage
        End Sub
    End Class
End Namespace