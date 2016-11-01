Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Aspose.Cells

Namespace Articles
    Public Class UsingBuiltinStyles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim output1Path As String = dataDir & Convert.ToString("Output.xlsx")
            Dim output2Path As String = dataDir & Convert.ToString("Output.out.ods")

            Dim workbook As New Workbook()
            Dim style As Style = workbook.CreateBuiltinStyle(BuiltinStyleType.Title)

            Dim cell As Cell = workbook.Worksheets(0).Cells("A1")
            cell.PutValue("Aspose")
            cell.SetStyle(style)

            Dim worksheet As Worksheet = workbook.Worksheets(0)
            worksheet.AutoFitColumn(0)
            worksheet.AutoFitRow(0)

            workbook.Save(output1Path)
            Console.WriteLine("File saved {0}", output1Path)
            workbook.Save(output2Path)
            Console.WriteLine("File saved {0}", output1Path)
            ' ExEnd:1
        End Sub
    End Class
End Namespace