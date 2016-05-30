Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells

Namespace Files.Handling
    Public Class SavingFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a Workbook object
            Dim workbook As New Workbook()

            ' Your Code goes here for any workbook related operations

            ' Save in Excel 97 ? 2003 format
            workbook.Save(dataDir & "output.xls")

            ' OR
            workbook.Save(dataDir & "output.xls", New XlsSaveOptions(SaveFormat.Excel97To2003))

            ' Save in Excel2007 xlsx format
            workbook.Save(dataDir & "output.xlsx", SaveFormat.Xlsx)

            ' Save in Excel2007 xlsb format
            workbook.Save(dataDir & "output.xlsb", SaveFormat.Xlsb)

            ' Save in ODS format
            workbook.Save(dataDir & "output.ods", SaveFormat.ODS)

            ' Save in Pdf format
            workbook.Save(dataDir & "output.pdf", SaveFormat.Pdf)

            ' Save in Html format
            workbook.Save(dataDir & "output.html", SaveFormat.Html)

            ' Save in SpreadsheetML format
            workbook.Save(dataDir & "output.xml", SaveFormat.SpreadsheetML)
            ' ExEnd:1
        End Sub
    End Class
End Namespace