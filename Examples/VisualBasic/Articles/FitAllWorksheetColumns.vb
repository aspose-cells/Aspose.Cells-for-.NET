Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class FitAllWorksheetColumns
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create and initialize an instance of Workbook
            Dim book As New Workbook(dataDir & "TestBook.xlsx")
            'Create and initialize an instance of PdfSaveOptions
            Dim saveOptions As New PdfSaveOptions(SaveFormat.Pdf)
            'Set AllColumnsInOnePagePerSheet to true
            saveOptions.AllColumnsInOnePagePerSheet = True
            'Save Workbook to PDF fromart by passing the object of PdfSaveOptions
            book.Save(dataDir & "output.pdf", saveOptions)
            'ExEnd:1


        End Sub
    End Class
End Namespace