Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles.ManageChartsAndShapes
    Public Class ChangeShapesAdjustmentValues
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create workbook object from source excel file
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Access first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access first three shapes of the worksheet
            Dim shape1 As Shape = worksheet.Shapes(0)
            Dim shape2 As Shape = worksheet.Shapes(1)
            Dim shape3 As Shape = worksheet.Shapes(2)

            ' Change the adjustment values of the shapes
            shape1.Geometry.ShapeAdjustValues(0).Value = 0.5
            shape2.Geometry.ShapeAdjustValues(0).Value = 0.8
            shape3.Geometry.ShapeAdjustValues(0).Value = 0.5

            ' Save the workbook
            workbook.Save(dataDir & Convert.ToString("output_out_.xlsx"))
            ' ExEnd:1
        End Sub
    End Class
End Namespace