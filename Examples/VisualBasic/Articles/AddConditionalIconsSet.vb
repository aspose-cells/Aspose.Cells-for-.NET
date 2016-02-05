Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class AddConditionalIconsSet
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook
            Dim workbook As New Workbook()
            'Get the first worksheet (default worksheet) in the workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            'Get the cells
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells
            'Set the columns widths (A, B and C)
            worksheet.Cells.SetColumnWidth(0, 24)
            worksheet.Cells.SetColumnWidth(1, 24)
            worksheet.Cells.SetColumnWidth(2, 24)

            'Input date into the cells
            cells("A1").PutValue("KPIs")
            cells("A2").PutValue("Total Turnover (Sales at List)")
            cells("A3").PutValue("Total Gross Margin %")
            cells("A4").PutValue("Total Net Margin %")
            cells("B1").PutValue("UA Contract Size Group 4")
            cells("B2").PutValue(19551794)
            cells("B3").PutValue(11.8070745566204)
            cells("B4").PutValue(11.858589818569)
            cells("C1").PutValue("UA Contract Size Group 3")
            cells("C2").PutValue(8150131.66666667)
            cells("C3").PutValue(10.3168384396244)
            cells("C4").PutValue(11.3326931937091)

            'Get the conditional icon's image data
            Dim imagedata() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.TrafficLights31, 0)
            'Create a stream based on the image data
            Dim stream As New MemoryStream(imagedata)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(1, 1, stream)

            'Get the conditional icon's image data
            Dim imagedata1() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.Arrows3, 2)
            'Create a stream based on the image data
            Dim stream1 As New MemoryStream(imagedata1)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(1, 2, stream1)

            'Get the conditional icon's image data
            Dim imagedata2() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.Symbols3, 0)
            'Create a stream based on the image data
            Dim stream2 As New MemoryStream(imagedata2)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(2, 1, stream2)

            'Get the conditional icon's image data
            Dim imagedata3() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.Stars3, 0)
            'Create a stream based on the image data
            Dim stream3 As New MemoryStream(imagedata3)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(2, 2, stream3)

            'Get the conditional icon's image data
            Dim imagedata4() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.Boxes5, 1)
            'Create a stream based on the image data
            Dim stream4 As New MemoryStream(imagedata4)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(3, 1, stream4)

            'Get the conditional icon's image data
            Dim imagedata5() As Byte = ConditionalFormattingIcon.GetIconImageData(IconSetType.Flags3, 1)
            'Create a stream based on the image data
            Dim stream5 As New MemoryStream(imagedata5)
            'Add the picture to the cell based on the stream
            worksheet.Pictures.Add(3, 2, stream5)

            'Save the Excel file
            workbook.Save(dataDir & "outfile_cond_icons1.out.xlsx")
        End Sub
    End Class
End Namespace