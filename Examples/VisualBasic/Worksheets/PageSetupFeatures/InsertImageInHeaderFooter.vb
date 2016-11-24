Imports System.IO
Imports Aspose.Cells

Namespace Worksheets.PageSetupFeatures
    Public Class InsertImageInHeaderFooter
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Creating a Workbook object
            Dim workbook As New Workbook()

            ' Creating a string variable to store the url of the logo/picture
            Dim logo_url As String = dataDir & Convert.ToString("aspose-logo.jpg")

            ' Declaring a FileStream object
            Dim inFile As FileStream

            ' Declaring a byte array
            Dim binaryData As Byte()

            ' Creating the instance of the FileStream object to open the logo/picture in the stream
            inFile = New System.IO.FileStream(logo_url, System.IO.FileMode.Open, System.IO.FileAccess.Read)

            ' Instantiating the byte array of FileStream object's size
            binaryData = New [Byte](inFile.Length - 1) {}

            ' Reads a block of bytes from the stream and writes data in a given buffer of byte array.
            Dim bytesRead As Long = inFile.Read(binaryData, 0, CInt(inFile.Length))

            ' Creating a PageSetup object to get the page settings of the first worksheet of the workbook
            Dim pageSetup As PageSetup = workbook.Worksheets(0).PageSetup

            ' Setting the logo/picture in the central section of the page header
            pageSetup.SetHeaderPicture(1, binaryData)

            ' Setting the script for the logo/picture
            pageSetup.SetHeader(1, "&G")

            ' Setting the Sheet's name in the right section of the page header with the script
            pageSetup.SetHeader(2, "&A")

            ' Saving the workbook
            workbook.Save(dataDir & Convert.ToString("InsertImageInHeaderFooter_out.xls"))

            'Closing the FileStream object
            inFile.Close()
            ' ExEnd:1
        End Sub
    End Class
End Namespace