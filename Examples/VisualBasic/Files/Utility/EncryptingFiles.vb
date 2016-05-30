Imports System.IO

Imports Aspose.Cells

Namespace Files.Utility
    Public Class EncryptingFiles
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Instantiate a Workbook object.
            ' Open an excel file.
            Dim workbook As New Workbook(dataDir & "Book1.xls")

            ' Specify XOR encryption type.
            workbook.SetEncryptionOptions(EncryptionType.XOR, 40)

            ' Specify Strong Encryption type (RC4,Microsoft Strong Cryptographic Provider).
            workbook.SetEncryptionOptions(EncryptionType.StrongCryptographicProvider, 128)

            ' Password protect the file.
            workbook.Settings.Password = "1234"

            ' Save the excel file.
            workbook.Save(dataDir & "output.xls")
            ' ExEnd:1
        End Sub
    End Class
End Namespace