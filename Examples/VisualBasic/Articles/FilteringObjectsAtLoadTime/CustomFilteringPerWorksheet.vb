Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Articles.FilteringObjectsAtLoadTime
    ' ExStart:CustomLoadFilter
    Public Class CustomLoadFilter
        Inherits LoadFilter
        Public Overrides Sub StartSheet(ByVal sheet As Worksheet)
            If sheet.Name = "NoCharts" Then
                'Load everything and filter charts
                Me.LoadDataFilterOptions = LoadDataFilterOptions.All And Not LoadDataFilterOptions.Chart
            End If

            If sheet.Name = "NoShapes" Then
                'Load everything and filter shapes
                Me.LoadDataFilterOptions = LoadDataFilterOptions.All And Not LoadDataFilterOptions.Shape
            End If

            If sheet.Name = "NoConditionalFormatting)" Then
                'Load everything and filter conditional formatting
                Me.LoadDataFilterOptions = LoadDataFilterOptions.All And Not LoadDataFilterOptions.ConditionalFormatting
            End If
        End Sub
    End Class
    ' ExEnd:CustomLoadFilter

    Friend Class CustomFilteringPerWorksheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Filter worksheets using CustomLoadFilter class
            Dim loadOpts As New LoadOptions()
            loadOpts.LoadFilter = New CustomLoadFilter()

            ' Load the workbook with filter defined in CustomLoadFilter class
            Dim workbook As New Workbook(dataDir & "sampleCustomFilter.xlsx", loadOpts)

            ' Take the image of all worksheets one by one
            For i As Integer = 0 To workbook.Worksheets.Count - 1
                ' Access worksheet at index i
                Dim worksheet As Worksheet = workbook.Worksheets(i)

                ' Create an instance of ImageOrPrintOptions
                ' Render entire worksheet to image
                Dim imageOpts As New ImageOrPrintOptions()
                imageOpts.OnePagePerSheet = True
                imageOpts.ImageFormat = ImageFormat.Png

                ' Convert worksheet to image
                Dim render As New SheetRender(worksheet, imageOpts)
                render.ToImage(0, dataDir & worksheet.Name & ".png")
            Next i

            ' ExEnd:1


        End Sub
    End Class
End Namespace