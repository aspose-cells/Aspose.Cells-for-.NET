Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class HidingDisplayOfZeroValues
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create a new Workbook object
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            'Get First worksheet of the workbook
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Hide the zero values in the sheet
            sheet.DisplayZeros = False

            'Save the workbook
            workbook.Save(dataDir & "outputfile.out.xlsx")


        End Sub
    End Class
End Namespace