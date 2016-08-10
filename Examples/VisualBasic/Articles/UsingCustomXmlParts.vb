Imports System
Imports Aspose.Cells

Namespace Articles
    Friend Class UsingCustomXmlParts
        Public Shared Sub Run()
            ' ExStart:UsingCustomXmlParts
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' The sample XML that will be injected to Workbook
            Dim booksXML As String = "<catalog> <book> <title>Complete C#</title> <price>44</price> </book> <book> <title>Complete Java</title> <price>76</price> </book> <book> <title>Complete SharePoint</title> <price>55</price> </book> <book> <title>Complete PHP</title> <price>63</price> </book> <book> <title>Complete VB.NET</title> <price>72</price> </book> </catalog>"

            ' Create an instance of Workbook class
            Dim workbook As New Workbook()

            ' Add Custom XML Part to ContentTypePropertyCollection
            workbook.ContentTypeProperties.Add("BookStore", booksXML)

            ' Save the resultant spreadsheet
            workbook.Save(dataDir & "output.xlsx")
            ' ExEnd:UsingCustomXmlParts
        End Sub
    End Class
End Namespace
