Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace DrawingObjects.OLE
    Public Class InsertingOLEObjects
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiate a new Workbook.
            Dim workbook As New Workbook()

            ' Get the first worksheet.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            ' Define a string variable to store the image path.
            Dim ImageUrl As String = dataDir & "logo.jpg"

            ' Get the picture into the streams.
            Dim fs As FileStream = File.OpenRead(ImageUrl)

            ' Define a byte array.
            Dim imageData(fs.Length - 1) As Byte

            ' Obtain the picture into the array of bytes from streams.
            fs.Read(imageData, 0, imageData.Length)

            ' Close the stream.
            fs.Close()

            ' Get an excel file path in a variable.
            Dim path As String = dataDir & "book1.xls"

            ' Get the file into the streams.
            fs = File.OpenRead(path)

            ' Define an array of bytes.
            Dim objectData(fs.Length - 1) As Byte

            ' Store the file from streams.
            fs.Read(objectData, 0, objectData.Length)

            ' Close the stream.
            fs.Close()

            ' Add an Ole object into the worksheet with the image
            ' Shown in MS Excel.
            sheet.OleObjects.Add(14, 3, 200, 220, imageData)

            ' Set embedded ole object data.
            sheet.OleObjects(0).ObjectData = objectData

            ' Save the excel file
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1

        End Sub
    End Class
End Namespace