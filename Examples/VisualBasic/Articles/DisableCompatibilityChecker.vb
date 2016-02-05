Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class DisableCompatibilityChecker
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Open a template file
            Dim workbook As New Workbook(dataDir & "sample.xlsx")

            'Disable the compatibility checker
            workbook.Settings.CheckComptiliblity = False

            'Saving the Excel file
            workbook.Save(dataDir & "Output_BK_CompCheck.out.xlsx")


        End Sub
    End Class
End Namespace