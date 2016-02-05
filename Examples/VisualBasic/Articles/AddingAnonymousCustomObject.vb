Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Collections

Namespace Aspose.Cells.Examples.Articles
    Public Class AddingAnonymousCustomObject
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Open a designer workbook
            Dim designer As New WorkbookDesigner()

            'get worksheet Cells collection
            Dim cells As Global.Aspose.Cells.Cells = designer.Workbook.Worksheets(0).Cells

            'Set Cell Values
            cells("A1").PutValue("Name")
            cells("B1").PutValue("Age")

            'Set markers
            cells("A2").PutValue("&=Person.Name")
            cells("B2").PutValue("&=Person.Age")

            'Create Array list
            Dim list As New ArrayList()

            'add custom objects to the list
            list.Add(New Person("Simon", 30))
            list.Add(New Person("Johnson", 33))

            'add designer's datasource
            designer.SetDataSource("Person", list)

            'process designer
            designer.Process(False)

            'save the resultant file
            designer.Workbook.Save(dataDir & "result.out.xls")
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