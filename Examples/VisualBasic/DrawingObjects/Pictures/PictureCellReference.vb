Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.DrawingObjects.Pictures
    Public Class PictureCellReference
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook
            Dim workbook As New Workbook()
            'Get the first worksheet's cells collection
            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            'Add string values to the cells
            cells("A1").PutValue("A1")
            cells("C10").PutValue("C10")

            'Add a blank picture to the D1 cell
            Dim pic As Picture = workbook.Worksheets(0).Shapes.AddPicture(0, 3, 10, 6, Nothing)

            'Specify the formula that refers to the source range of cells
            'pic.Formula = "A1:C10";

            'Update the shapes selected value in the worksheet
            workbook.Worksheets(0).Shapes.UpdateSelectedValue()

            'Save the Excel file.
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1

        End Sub
    End Class
End Namespace