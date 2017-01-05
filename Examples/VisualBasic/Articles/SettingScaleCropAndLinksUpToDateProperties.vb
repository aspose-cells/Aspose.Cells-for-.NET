Namespace Articles
    Public Class SettingScaleCropAndLinksUpToDateProperties

        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Instantiating a Workbook object
            Dim workbook As New Workbook()

            ' Setting ScaleCrop and LinksUpToDate BuiltIn Document Properties
            workbook.BuiltInDocumentProperties.ScaleCrop = True
            workbook.BuiltInDocumentProperties.LinksUpToDate = True

            ' Saving the Excel file
            workbook.Save(dataDir & "output.xls", SaveFormat.Auto)
            ' ExEnd:1


        End Sub
    End Class
End Namespace