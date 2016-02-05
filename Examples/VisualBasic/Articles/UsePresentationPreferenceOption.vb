Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class UsePresentationPreferenceOption
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate the Workbook
            'Load an Excel file
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            'Create HtmlSaveOptions object
            Dim options As New HtmlSaveOptions()
            'Set the Presenation preference option
            options.PresentationPreference = True

            'Save the Excel file to HTML with specified option
            workbook.Save(dataDir & "outPresentationlayout1.out.html", options)


        End Sub
    End Class
End Namespace