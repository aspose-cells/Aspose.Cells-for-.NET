Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingButtonControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Create a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet in the workbook.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Add a new button to the worksheet.
            Dim button As Global.Aspose.Cells.Drawing.Button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80)

            ' Set the caption of the button.
            button.Text = "Aspose"

            ' Set the Placement Type, the way the
            ' Button is attached to the cells.
            button.Placement = PlacementType.FreeFloating

            ' Set the font name.
            button.Font.Name = "Tahoma"

            ' Set the caption string bold.
            button.Font.IsBold = True

            ' Set the color to blue.
            button.Font.Color = Color.Blue

            ' Set the hyperlink for the button.
            button.AddHyperlink("http://www.aspose.com/")

            ' Saves the file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace