Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System
Imports Aspose.Cells.Drawing

Namespace Aspose.Cells.Examples.Articles
    Public Class InsertingWAVFile
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Define a string variable to store the image path.
            Dim ImageUrl As String = dataDir & "image2.jpg"

            'Get the picture into the streams.
            Dim fs As FileStream = File.OpenRead(ImageUrl)

            'Define a byte array.
            Dim imageData(fs.Length - 1) As Byte

            'Obtain the picture into the array of bytes from streams.
            fs.Read(imageData, 0, imageData.Length)

            'Close the stream.
            fs.Close()

            'Get an excel file path in a variable.
            Dim filepath As String = dataDir & "chord.wav"

            'Get the file into the streams.
            fs = File.OpenRead(filepath)

            'Define an array of bytes. 
            Dim objectData(fs.Length - 1) As Byte

            'Store the file from streams.
            fs.Read(objectData, 0, objectData.Length)

            'Close the stream.
            fs.Close()
            Dim intIndex As Integer = 0

            'Instantiate a new Workbook.
            Dim workbook As New Workbook()

            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Add Ole Object
            sheet.OleObjects.Add(14, 3, 200, 220, imageData)
            workbook.Worksheets(0).OleObjects(intIndex).FileFormatType = FileFormatType.Unknown
            workbook.Worksheets(0).OleObjects(intIndex).ObjectData = objectData
            workbook.Worksheets(0).OleObjects(intIndex).ObjectSourceFullName = filepath

            'Save the excel file
            workbook.Save(dataDir & "testWAV.out.xlsx")


        End Sub
    End Class
End Namespace