Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Collections

Namespace Articles
    ' ExStart:1
    Public Class AddingAnonymousCustomObject
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            ' Open a designer workbook
            Dim designer As New WorkbookDesigner()

            ' Get worksheet Cells collection
            Dim cells As Global.Aspose.Cells.Cells = designer.Workbook.Worksheets(0).Cells

            ' Set Cell Values
            cells("A1").PutValue("Name")
            cells("B1").PutValue("Age")

            ' Set markers
            cells("A2").PutValue("&=Person.Name")
            cells("B2").PutValue("&=Person.Age")

            ' Create Array list
            Dim list As New ArrayList()

            ' Add custom objects to the list
            list.Add(New Person("Simon", 30))
            list.Add(New Person("Johnson", 33))

            ' Add designer' S datasource
            designer.SetDataSource("Person", list)

            ' Process designer
            designer.Process(False)

            ' Save the resultant file
            designer.Workbook.Save(dataDir & "output.xls")
        End Sub
    End Class
End Namespace

Public Class Person
	Public Name As String
	Public Age As Integer
	Friend Sub New(ByVal name As String, ByVal age As Integer)
		Me.Name = name
		Me.Age = age
	End Sub
End Class
' ExEnd:1