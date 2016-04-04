Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class InsertLinkedPicture
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate a new Workbook.
            Dim workbook As New Workbook()
            'Insert a linked picture (from Web Address) to B2 Cell.
            Dim pic As Global.Aspose.Cells.Drawing.Picture = workbook.Worksheets(0).Shapes.AddLinkedPicture(1, 1, 100, 100, "http://www.aspose.com/Images/aspose-logo.jpg")
            'Set the height and width of the inserted image.
            pic.HeightInch = 1.04
            pic.WidthInch = 2.6
            'Save the Excel file.
            workbook.Save(dataDir & "output.xlsx")
            'ExEnd:1


        End Sub
    End Class
End Namespace