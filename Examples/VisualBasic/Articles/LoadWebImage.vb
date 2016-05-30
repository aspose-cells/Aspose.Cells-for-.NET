Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Articles
    Public Class LoadWebImage
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            ' Define memory stream object
            Dim objImage As System.IO.MemoryStream

            ' Define web client object
            Dim objwebClient As System.Net.WebClient

            ' Define a string which will hold the web image url
            Dim sURL As String = "http://www.aspose.com/Images/aspose-logo.jpg"

            Try
                ' Instantiate the web client object
                objwebClient = New System.Net.WebClient()

                ' Now, extract data into memory stream downloading the image data into the array of bytes
                objImage = New System.IO.MemoryStream(objwebClient.DownloadData(sURL))

                ' Create a new workbook
                Dim wb As New Global.Aspose.Cells.Workbook()

                ' Get the first worksheet in the book
                Dim sheet As Global.Aspose.Cells.Worksheet = wb.Worksheets(0)

                ' Get the first worksheet pictures collection
                Dim pictures As Global.Aspose.Cells.Drawing.PictureCollection = sheet.Pictures

                ' Insert the picture from the stream to B2 cell
                pictures.Add(1, 1, objImage)

                ' Save the excel file
                wb.Save(dataDir & "output.xlsx")
            Catch ex As Exception
                ' Write the error message on the console
                Console.WriteLine(ex.Message)
            End Try
            ' ExEnd:1


        End Sub
    End Class
End Namespace