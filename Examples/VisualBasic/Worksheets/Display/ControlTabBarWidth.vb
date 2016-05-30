Imports System.IO

Imports Aspose.Cells

Namespace Worksheets.Display
    Public Class ControlTabBarWidth
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiating a Workbook object
            ' Opening the Excel file
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Hiding the tabs of the Excel file
            workbook.Settings.ShowTabs = True

            ' Adjusting the sheet tab bar width
            workbook.Settings.SheetTabBarWidth = 800

            ' Saving the modified Excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace
