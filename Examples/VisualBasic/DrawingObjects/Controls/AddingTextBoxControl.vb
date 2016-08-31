Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace DrawingObjects.Controls
    Public Class AddingTextBoxControl
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiate a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet in the book.
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Add a new textbox to the collection.
            Dim textboxIndex As Integer = worksheet.TextBoxes.Add(2, 1, 160, 200)

            ' Get the textbox object.
            Dim textbox0 As Global.Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(textboxIndex)

            ' Fill the text.
            textbox0.Text = "ASPOSE______The .NET & JAVA Component Publisher!"

            ' Get the textbox text frame.
            ' Dim textframe0 As MsoTextFrame = textbox0.TextFrame

            ' Set the textbox to adjust it according to its contents.
            ' textframe0.AutoSize = True

            ' Set the placement.
            textbox0.Placement = PlacementType.FreeFloating

            ' Set the font color.
            textbox0.Font.Color = Color.Blue

            ' Set the font to bold.
            textbox0.Font.IsBold = True

            ' Set the font size.
            textbox0.Font.Size = 14

            ' Set font attribute to italic.
            textbox0.Font.IsItalic = True

            ' Add a hyperlink to the textbox.
            textbox0.AddHyperlink("http://www.aspose.com/")

            ' Get the filformat of the textbox.
            Dim fillformat As FillFormat = textbox0.Fill

            ' Get the lineformat type of the textbox.
            Dim lineformat As LineFormat = textbox0.Line

            ' Set the line weight.
            lineformat.Weight = 6

            ' Set the dash style to squaredot.
            lineformat.DashStyle = MsoLineDashStyle.SquareDot

            ' Add another textbox.
            textboxIndex = worksheet.TextBoxes.Add(15, 4, 85, 120)

            ' Get the second textbox.
            Dim textbox1 As Global.Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(textboxIndex)

            ' Input some text to it.
            textbox1.Text = "This is another simple text box"

            ' Set the placement type as the textbox will move and
            ' Resize with cells.
            textbox1.Placement = PlacementType.MoveAndSize

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace