Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Charts
Imports System.Drawing

Namespace Articles.ManageChartsAndShapes
    Public Class RichTextCustomDataLabel
        Public Shared Sub Run()
            ' ExStart:RichTextCustomDataLabelOfChartPoint
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook from source Excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first chart inside the sheet
            Dim chart As Chart = worksheet.Charts(0)

            ' Access the data label of first series first point
            Dim dlbls As DataLabels = chart.NSeries(0).Points(0).DataLabels

            ' Set data label text
            dlbls.Text = "Rich Text Label"

            ' Set the font setting of the first 10 characters
            Dim fntSetting As FontSetting = dlbls.Characters(0, 10)
            fntSetting.Font.Color = Color.Red
            fntSetting.Font.IsBold = True

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out.xlsx"))
            ' ExEnd:RichTextCustomDataLabelOfChartPoint
        End Sub
    End Class
End Namespace