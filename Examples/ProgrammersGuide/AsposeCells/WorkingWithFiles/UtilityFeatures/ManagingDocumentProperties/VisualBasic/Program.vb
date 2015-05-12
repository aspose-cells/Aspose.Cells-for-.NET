'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells

Namespace ManagingDocumentProperties
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate a Workbook object
			'Open an Excel file
			Dim workbook As New Workbook(dataDir & "Book1.xls")

			'Retrieve a list of all custom document properties of the Excel file
			Dim customProperties As Aspose.Cells.Properties.DocumentPropertyCollection = workbook.Worksheets.CustomDocumentProperties

			'Accessing a custom document property by using the property index
			Dim customProperty1 As Aspose.Cells.Properties.DocumentProperty = customProperties(3)

			'Accessing a custom document property by using the property name
			Dim customProperty2 As Aspose.Cells.Properties.DocumentProperty = customProperties("Owner")

			System.Console.WriteLine(customProperty1.Name & " -> " & customProperty1.Value)
			System.Console.WriteLine(customProperty2.Name & " -> " & customProperty2.Value)

			'Retrieve a list of all custom document properties of the Excel file
			Dim customPropertiesCollection As Aspose.Cells.Properties.CustomDocumentPropertyCollection = workbook.Worksheets.CustomDocumentProperties

			'Adding a custom document property to the Excel file
			Dim publisher As Aspose.Cells.Properties.DocumentProperty = customPropertiesCollection.Add("Publisher", "Aspose")

			'Add link to content.
			customPropertiesCollection.AddLinkToContent("Owner", "MyRange")
			'Accessing the custom document property by using the property name
			Dim customProperty3 As Aspose.Cells.Properties.DocumentProperty = customPropertiesCollection("Owner")
			'Check whether the property is lined to content
			Dim islinkedtocontent As Boolean = customProperty3.IsLinkedToContent
			'Get the source for the property
			Dim source As String = customProperty3.Source

			'Save the file with added properties
			workbook.Save(dataDir & "Test_Workbook.xls")

			'Removing a custom document property
			customProperties.Remove("Publisher")

			'Save the file with added properties
			workbook.Save(dataDir & "Test_Workbook_RemovedProperty.xls")

		End Sub
	End Class
End Namespace