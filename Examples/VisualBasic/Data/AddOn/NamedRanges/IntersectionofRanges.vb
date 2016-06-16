Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing

Namespace Data.AddOn.NamedRanges
    Public Class IntersectionofRanges
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a workbook object.
            ' Open an existing excel file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Get the named ranges.
            Dim ranges() As Range = workbook.Worksheets.GetNamedRanges()

            ' Check whether the first range intersect the second range.
            Dim isintersect As Boolean = ranges(0).IsIntersect(ranges(1))

            ' Create a style object.
            Dim style As Style = workbook.CreateStyle()

            ' Set the shading color with solid pattern type.
            style.ForegroundColor = Color.Yellow
            style.Pattern = BackgroundType.Solid

            ' Create a styleflag object.
            Dim flag As New StyleFlag()

            ' Apply the cellshading.
            flag.CellShading = True

            ' If first range intersects second range.
            If isintersect Then
                ' Create a range by getting the intersection.
                Dim intersection As Range = ranges(0).Intersect(ranges(1))

                ' Name the range.
                intersection.Name = "Intersection"

                ' Apply the style to the range.
                intersection.ApplyStyle(style, flag)

            End If

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace