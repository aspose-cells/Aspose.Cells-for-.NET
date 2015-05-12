'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Collections.Generic

Namespace ImportingFromCustomObject
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If

			'Instantiate a new Workbook
			Dim book As New Workbook()

			Dim sheet As Worksheet= book.Worksheets(0)

			'Define List
			Dim list As List(Of Person) = New List(Of Person)()

			list.Add(New Person("Mike", 25))
			list.Add(New Person("Steve", 30))
			list.Add(New Person("Billy", 35))



			Dim imp As New ImportTableOptions()
			imp.InsertRows = True

			'We pick a few columns not all to import to the worksheet
			'We pick a few columns not all to import to the worksheet
			sheet.Cells.ImportCustomObjects(CType(list, System.Collections.ICollection), New String() { "Name","Age" }, True, 0, 0, list.Count, True, "dd/mm/yyyy", False)

			'Auto-fit all the columns
			book.Worksheets(0).AutoFitColumns()

			'Save the Excel file
			book.Save(dataDir & "ImportedCustomObjects.xls")

		End Sub
	End Class

	Friend Class Person
		' Auto-implemented properties. 
		Private privateAge As Integer
		Public Property Age() As Integer
			Get
				Return privateAge
			End Get
			Set(ByVal value As Integer)
				privateAge = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property

		Public Sub New(ByVal name As String, ByVal age As Integer)
			Me.Age = age
			Me.Name = name
		End Sub
	End Class

End Namespace