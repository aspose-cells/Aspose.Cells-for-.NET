Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing

Imports Aspose.Cells

Namespace Articles.ModifyExistingStyle
    Public Class ModifyThroughSampleExcelFile
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook.
            ' Open a template file. 
            ' In the book1.xls file, we have applied Ms Excel' S 
            ' Named style i.e., "Percent" to the range "A1:C8". 
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            ' We get the Percent style and create a style object.
            Dim style As Style = workbook.Styles("Percent")

            ' Change the number format to "0.00%".
            style.Number = 11

            ' Set the font color.
            style.Font.Color = System.Drawing.Color.Red

            ' Update the style. so, the style of range "A1:C8" will be changed too.
            style.Update()

            ' Save the excel file.	
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1

        End Sub
    End Class
End Namespace