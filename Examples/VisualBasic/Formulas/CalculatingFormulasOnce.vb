Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Aspose.Cells.Examples.Formulas
    Public Class CalculatingFormulasOnce
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)



            'Load the template workbook
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Print the time before formula calculation
            Console.WriteLine(DateTime.Now)

            'Set the CreateCalcChain as false
            workbook.Settings.CreateCalcChain = False

            'Calculate the workbook formulas
            workbook.CalculateFormula()

            'Print the time after formula calculation
            Console.WriteLine(DateTime.Now)

        End Sub
    End Class
End Namespace