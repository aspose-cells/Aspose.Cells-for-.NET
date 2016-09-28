Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles
    Public Class InsertPictureCellReference
        Public Shared Sub Run()
            Try
                ' ExStart:1
                ' The path to the documents directory.
                Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
                ' Instantiate a new Workbook
                Dim workbook As Workbook = New Workbook()
                ' Get the first worksheet' S cells collection
                Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

                ' Add string values to the cells
                cells("A1").PutValue("A1")
                cells("C10").PutValue("C10")

                ' Get the conditional icon's image data
                Dim imagedata As Byte() = ConditionalFormattingIcon.GetIconImageData(IconSetType.TrafficLights31, 0)
                ' Create a stream based on the image data
                Dim stream As New MemoryStream(imagedata)

                ' Add a blank picture to the D1 cell
                Dim pic As Picture = CType(workbook.Worksheets(0).Shapes.AddPicture(0, 3, 10, 6, stream), Picture)
                ' Specify the formula that refers to the source range of cells
                pic.Formula = "A1:C10"
                ' Update the shapes selected value in the worksheet
                workbook.Worksheets(0).Shapes.UpdateSelectedValue()

                ' Save the Excel file.
                workbook.Save(dataDir & "output.out.xlsx")
                ' ExEnd:1
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Console.ReadLine()
            End Try

        End Sub
    End Class
End Namespace