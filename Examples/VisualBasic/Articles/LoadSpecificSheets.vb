Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Articles
    Public Class LoadSpecificSheets
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Define a new Workbook.
            Dim workbook As Workbook

            ' Set the load data option with selected sheet(s).
            Dim dataOption As New LoadDataOption()
            dataOption.SheetNames = New String() {"Sheet2"}

            ' Load the workbook with the spcified worksheet only.
            Dim loadOptions As New LoadOptions(LoadFormat.Xlsx)
            loadOptions.LoadDataOptions = dataOption
            loadOptions.LoadDataAndFormatting = True

            ' Creat the workbook.
            workbook = New Workbook(dataDir & "TestData.xlsx", loadOptions)

            ' Perform your desired task.

            ' Save the workbook.
            workbook.Save(dataDir & "output.xlsx")
            ' EnEnd:1

        End Sub
    End Class
End Namespace