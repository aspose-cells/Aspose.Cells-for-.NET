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

            ' Load the workbook with the spcified worksheet only.
            Dim loadOptions As New LoadOptions(LoadFormat.Xlsx)
            loadOptions.LoadFilter = New CustomLoad()

            ' Creat the workbook.
            workbook = New Workbook(dataDir & "TestData.xlsx", loadOptions)

            ' Perform your desired task.

            ' Save the workbook.
            workbook.Save(dataDir & "outputFile.out.xlsx")
            ' ExEnd:1

        End Sub
    End Class
    ' ExStart:2
    Class CustomLoad
        Inherits LoadFilter
        Public Overrides Sub StartSheet(ByVal sheet As Worksheet)
            If sheet.Name = "Sheet2" Then
                ' Load everything from worksheet "Sheet2"
                Me.m_LoadDataFilterOptions = LoadDataFilterOptions.All
            Else
                ' Load nothing
                Me.m_LoadDataFilterOptions = LoadDataFilterOptions.None
            End If
        End Sub
    End Class
    ' ExEnd:2

End Namespace