Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.DrawingObjects.Controls
    Public Class ManipulatingTextBoxControls
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook.
            'Open the existing excel file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Get the first worksheet in the book.
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Get the first textbox object.
            Dim textbox0 As Global.Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(0)

            'Obtain the text in the first textbox.
            Dim text0 As String = textbox0.Text

            'Get the second textbox object.
            Dim textbox1 As Global.Aspose.Cells.Drawing.TextBox = worksheet.TextBoxes(1)

            'Obtain the text in the second textbox.
            Dim text1 As String = textbox1.Text

            'Change the text of the second textbox.
            textbox1.Text = "This is an alternative text"

            'Save the excel file.
            workbook.Save(dataDir & "output.out.xls")

        End Sub
    End Class
End Namespace