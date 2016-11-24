Imports System.IO
Imports Aspose.Cells

Namespace Articles.RenderingAndPrinting
    Public Class SetDefaultFontWhileRendering
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object and access first worksheet.
            Dim wb As New Workbook()
            Dim ws As Worksheet = wb.Worksheets(0)

            ' Access cell B4 and add some text inside it.
            Dim cell As Cell = ws.Cells("B4")
            cell.PutValue("This text has some unknown or invalid font which does not exist.")

            ' Set the font of cell B4 which is unknown.
            Dim st As Style = cell.GetStyle()
            st.Font.Name = "UnknownNotExist"
            st.Font.Size = 20
            cell.SetStyle(st)

            ' Now save the workbook in html format and set the default font to Courier New.
            Dim opts As New HtmlSaveOptions()
            opts.DefaultFontName = "Courier New"
            wb.Save(dataDir & "out_courier_new_out.htm", opts)

            ' Now save the workbook in html format once again but set the default font to Arial.
            opts.DefaultFontName = "Arial"
            wb.Save(dataDir & "out_arial_out.htm", opts)

            ' Now save the workbook in html format once again but set the default font to Times New Roman.
            opts.DefaultFontName = "Times New Roman"
            wb.Save(dataDir & "times_new_roman_out.htm", opts)
            ' ExEnd:1          

        End Sub
    End Class
End Namespace
