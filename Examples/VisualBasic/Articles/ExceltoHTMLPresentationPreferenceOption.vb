Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class ExceltoHTMLPresentationPreferenceOption
        Public Shared Sub Main()
            'ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate the Workbook
            'Instantiate the Workbook
            'Load an Excel file
            Dim workbook As New Workbook(dataDir & "HiddenCol.xlsx")

            'Create HtmlSaveOptions object
            Dim options As New HtmlSaveOptions()
            'Set the Presenation preference option
            options.PresentationPreference = True

            'Save the Excel file to HTML with specified option
            workbook.Save(dataDir & "outPresentationlayout1.out.html", options)
            'ExEnd:1

        End Sub
    End Class
End Namespace