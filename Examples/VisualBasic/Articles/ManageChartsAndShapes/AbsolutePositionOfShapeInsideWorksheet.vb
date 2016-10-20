Imports System.IO
Imports Aspose.Cells

Namespace Articles.ManageChartsAndShapes
    Public Class AbsolutePositionOfShapeInsideWorksheet
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Load the sample Excel file inside the workbook object
            Dim workbook As New Workbook(dataDir & Convert.ToString("sample.xlsx"))

            ' Access the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Access the first shape inside the worksheet
            Dim shape As Drawing.Shape = worksheet.Shapes(0)

            ' Displays the absolute position of the shape
            Console.WriteLine("Absolute Position of this Shape is ({0} , {1})", shape.LeftToCorner, shape.TopToCorner)
            ' ExEnd:1
        End Sub
    End Class
End Namespace