Imports System.IO
Imports Aspose.Cells
Imports System
Imports System.Drawing
Imports System.Collections.Generic

Namespace SmartMarkers
    Public Class UsingGenericList

        Public Class Husband
            Private m_Name As String

            Public Property Name() As String
                Get
                    Return m_Name
                End Get
                Set(ByVal value As String)
                    m_Name = value
                End Set
            End Property

            Private m_Age As Integer

            Public Property Age() As Integer
                Get
                    Return m_Age
                End Get
                Set(ByVal value As Integer)
                    m_Age = value
                End Set
            End Property

            Friend Sub New(ByVal name As String, ByVal age As Integer)
                Me.Name = name
                Me.Age = age
            End Sub

            ' Accepting a generic List as a Nested Object
            Private m_Wives As List(Of Wife)

            Public Property Wives() As List(Of Wife)
                Get
                    Return m_Wives
                End Get
                Set(ByVal value As List(Of Wife))
                    m_Wives = value
                End Set
            End Property

        End Class

        Public Class Wife
            Public Sub New(ByVal name As String, ByVal age As Integer)
                Me.m_name = name
                Me.m_age = age
            End Sub

            Private m_name As String

            Public Property Name() As String
                Get
                    Return m_name
                End Get
                Set(ByVal value As String)
                    m_name = value
                End Set
            End Property
            Private m_age As Integer

            Public Property Age() As Integer
                Get
                    Return m_age
                End Get
                Set(ByVal value As Integer)
                    m_age = value
                End Set
            End Property
        End Class

        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim workbook As New Workbook()

            ' Create a designer workbook

            ' Workbook workbook = new Workbook();
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            worksheet.Cells("A1").PutValue("Husband Name")
            worksheet.Cells("A2").PutValue("&=Husband.Name")

            worksheet.Cells("B1").PutValue("Husband Age")
            worksheet.Cells("B2").PutValue("&=Husband.Age")

            worksheet.Cells("C1").PutValue("Wife' S Name")
            worksheet.Cells("C2").PutValue("&=Husband.Wives.Name")

            worksheet.Cells("D1").PutValue("Wife' S Age")
            worksheet.Cells("D2").PutValue("&=Husband.Wives.Age")

            ' Apply Style to A1:D1
            Dim range As Range = worksheet.Cells.CreateRange("A1:D1")
            Dim style As Style = workbook.CreateStyle()
            style.Font.IsBold = True
            style.ForegroundColor = Color.Yellow
            style.Pattern = BackgroundType.Solid
            Dim flag As New StyleFlag()
            flag.All = True
            range.ApplyStyle(style, flag)

            ' Initialize WorkbookDesigner object
            Dim designer As New WorkbookDesigner()

            ' Load the template file
            designer.Workbook = workbook

            Dim list As New System.Collections.Generic.List(Of Husband)()

            ' Create an object for the Husband class
            Dim h1 As New Husband("Mark John", 30)

            ' Create the relevant Wife objects for the Husband object
            h1.Wives = New List(Of Wife)()
            h1.Wives.Add(New Wife("Chen Zhao", 34))
            h1.Wives.Add(New Wife("Jamima Winfrey", 28))
            h1.Wives.Add(New Wife("Reham Smith", 35))

            ' Create another object for the Husband class
            Dim h2 As New Husband("Masood Shankar", 40)

            ' Create the relevant Wife objects for the Husband object
            h2.Wives = New List(Of Wife)()
            h2.Wives.Add(New Wife("Karishma Jathool", 36))
            h2.Wives.Add(New Wife("Angela Rose", 33))
            h2.Wives.Add(New Wife("Hina Khanna", 45))

            ' Add the objects to the list
            list.Add(h1)
            list.Add(h2)

            ' Specify the DataSource
            designer.SetDataSource("Husband", list)

            ' Process the markers
            designer.Process()

            ' Autofit columns
            worksheet.AutoFitColumns()

            ' Save the Excel file.
            designer.Workbook.Save(dataDir & "output.xlsx")

            ' ExEnd:1
        End Sub
    End Class
End Namespace
