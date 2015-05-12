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

Namespace DynamicFormulas
	Public Class Program
		Public Shared Sub Main(ByVal args As String())
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Create directory if it is not already present.
			Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
			If (Not IsExists) Then
				System.IO.Directory.CreateDirectory(dataDir)
			End If


			'Instantiating a WorkbookDesigner object
			Dim designer As WorkbookDesigner = New WorkbookDesigner()

			'Open a designer spreadsheet containing smart markers
			designer.Workbook = New Workbook(designerFile)

			'Set the data source for the designer spreadsheet
			designer.SetDataSource(dataset)

			'Process the smart markers
			designer.Process()


		End Sub

		Public Shared Property designerFile() As Stream
			Get
			Set
			End Set
			End Get

		public static System.Data.SqlClient.SqlConnection dataset
			Get
			Set
			End Set
			End Get
		End Property