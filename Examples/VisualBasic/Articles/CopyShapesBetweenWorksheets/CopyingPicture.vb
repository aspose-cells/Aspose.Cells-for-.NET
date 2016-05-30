Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing

Imports Aspose.Cells

Namespace Articles.CopyShapesBetweenWorksheets
    Public Class CopyingPicture
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create a workbook object
            ' Open the template file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            ' Get the Picture from the "Picture" worksheet.
            Dim source As Global.Aspose.Cells.Drawing.Picture = workbook.Worksheets("Sheet1").Pictures(0)

            ' Save Picture to Memory Stream
            Dim ms As New MemoryStream(source.Data)

            ' Copy the picture to the Result Worksheet
            workbook.Worksheets("Sheet2").Pictures.Add(source.UpperLeftRow, source.UpperLeftColumn, ms, source.WidthScale, source.HeightScale)

            ' Save the Worksheet
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:1


        End Sub
    End Class
End Namespace