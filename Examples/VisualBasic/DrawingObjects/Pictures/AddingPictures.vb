Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.DrawingObjects.Pictures
    Public Class AddingPictures
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating a Workbook object
            Dim workbook As New Workbook()

            'Adding a new worksheet to the Workbook object
            Dim sheetIndex As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)

            'Adding a picture at the location of a cell whose row and column indices
            'are 5 in the worksheet. It is "F6" cell
            worksheet.Pictures.Add(5, 5, dataDir & "logo.jpg")

            'Saving the Excel file
            workbook.Save(dataDir & "output.xls")
            'ExEnd:1
        End Sub
    End Class
End Namespace