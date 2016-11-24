Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Articles.RenderingAndPrinting
    Public Class SetDefaultFontWhileRenderingSpreadsheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object.
            Dim wb As New Workbook()

            ' Set default font of the workbook to none
            Dim s As Style = wb.DefaultStyle
            s.Font.Name = ""
            wb.DefaultStyle = s

            ' Access first worksheet.
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access cell A4 and add some text inside it.
            Dim cell As Cell = ws.Cells("A4")
            cell.PutValue("This text has some unknown or invalid font which does not exist.")

            ' Set the font of cell A4 which is unknown.
            Dim st As Style = cell.GetStyle()
            st.Font.Name = "UnknownNotExist"
            st.Font.Size = 20
            st.IsTextWrapped = True
            cell.SetStyle(st)

            ' Set first column width and fourth column height
            ws.Cells.SetColumnWidth(0, 80)
            ws.Cells.SetRowHeight(3, 60)

            ' Create image or print options.
            Dim opts As New ImageOrPrintOptions()
            opts.OnePagePerSheet = True
            opts.ImageFormat = ImageFormat.Png

            ' Render worksheet image with Courier New as default font.
            opts.DefaultFont = "Courier New"
            Dim sr As New SheetRender(ws, opts)
            sr.ToImage(0, "out_courier_new_out.png")

            ' Render worksheet image again with Times New Roman as default font.
            opts.DefaultFont = "Times New Roman"
            sr = New SheetRender(ws, opts)
            sr.ToImage(0, "times_new_roman_out.png")
            ' ExEnd:1           

        End Sub
    End Class
End Namespace

