Imports System
Imports System.IO
Imports Aspose.Cells
Imports Aspose.Cells.Drawing

Namespace Articles

    ' ExStart:UsingImageMarkersWhileGroupingDataInSmartMarkers
    Public Class UsingImageMarkersWhileGroupingDataInSmartMarkers
        Private Class Person
            ' Create Name, City and Photo properties
            Private m_Name As String
            Private m_City As String
            Private m_Photo As Byte()

            Public Sub New(name As String, city As String, photo As Byte())
                m_Name = name
                m_City = city
                m_Photo = photo
            End Sub

            Public Property Name() As String
                Get
                    Return m_Name
                End Get
                Set(value As String)
                    m_Name = value
                End Set
            End Property

            Public Property City() As String
                Get
                    Return m_City
                End Get
                Set(value As String)
                    m_City = value
                End Set
            End Property

            Public Property Photo() As Byte()
                Get
                    Return m_Photo
                End Get
                Set(value As Byte())
                    m_Photo = value
                End Set
            End Property

        End Class

        Public Shared Sub Run()

            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Get the images
            Dim photo1 As Byte() = File.ReadAllBytes(dataDir + "moon.png")
            Dim photo2 As Byte() = File.ReadAllBytes(dataDir + "moon2.png")

            ' Create a new workbook and access its worksheet
            Dim workbook As New Workbook()
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            ' Set the standard row height to 35
            worksheet.Cells.StandardHeight = 35

            ' Set column widhts of D, E and F
            worksheet.Cells.SetColumnWidth(3, 20)
            worksheet.Cells.SetColumnWidth(4, 20)
            worksheet.Cells.SetColumnWidth(5, 40)

            ' Add the headings in columns D, E and F
            worksheet.Cells("D1").PutValue("Name")
            Dim st As Style = worksheet.Cells("D1").GetStyle()
            st.Font.IsBold = True
            worksheet.Cells("D1").SetStyle(st)

            worksheet.Cells("E1").PutValue("City")
            worksheet.Cells("E1").SetStyle(st)

            worksheet.Cells("F1").PutValue("Photo")
            worksheet.Cells("F1").SetStyle(st)

            ' Add smart marker tags in columns D, E, F
            worksheet.Cells("D2").PutValue("&=Person.Name(group:normal,skip:1)")
            worksheet.Cells("E2").PutValue("&=Person.City")
            worksheet.Cells("F2").PutValue("&=Person.Photo(Picture:FitToCell)")

            ' Create Persons objects with photos
            Dim persons As New List(Of Person)()
            persons.Add(New Person("George", "New York", photo1))
            persons.Add(New Person("George", "New York", photo2))
            persons.Add(New Person("George", "New York", photo1))
            persons.Add(New Person("George", "New York", photo2))
            persons.Add(New Person("Johnson", "London", photo2))
            persons.Add(New Person("Johnson", "London", photo1))
            persons.Add(New Person("Johnson", "London", photo2))
            persons.Add(New Person("Simon", "Paris", photo1))
            persons.Add(New Person("Simon", "Paris", photo2))
            persons.Add(New Person("Simon", "Paris", photo1))
            persons.Add(New Person("Henry", "Sydney", photo2))
            persons.Add(New Person("Henry", "Sydney", photo1))
            persons.Add(New Person("Henry", "Sydney", photo2))

            ' Create a workbook designer
            Dim designer As New WorkbookDesigner(workbook)

            ' Set the data source and process smart marker tags
            designer.SetDataSource("Person", persons)
            designer.Process()

            ' Save the workbook
            workbook.Save(dataDir & "UsingImageMarkersWhileGroupingDataInSmartMarkers.xlsx", SaveFormat.Xlsx)

            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()

        End Sub
    End Class
    ' ExEnd:UsingImageMarkersWhileGroupingDataInSmartMarkers
End Namespace
