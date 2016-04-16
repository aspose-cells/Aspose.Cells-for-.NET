Imports System
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles
    Friend Class AccessTextBoxName
        Public Shared Sub Main(ByVal args() As String)
            'ExStart:AccessTextBoxName
            ' Create an object of the Workbook class
            Dim workbook As New Workbook()

            ' Access first worksheet from the collection
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Add the TextBox to the worksheet
            Dim idx As Integer = sheet.TextBoxes.Add(10, 10, 10, 10)

            ' Access newly created TextBox using its index & name it
            Dim tb1 As TextBox = sheet.TextBoxes(idx)
            tb1.Name = "MyTextBox"

            ' Set text for the TextBox
            tb1.Text = "This is MyTextBox"

            ' Access the same TextBox via its name
            Dim tb2 As TextBox = sheet.TextBoxes("MyTextBox")

            'Display the text of the TextBox accessed via name
            Console.WriteLine(tb2.Text)

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            'ExEnd:AccessTextBoxName
        End Sub
    End Class
End Namespace
