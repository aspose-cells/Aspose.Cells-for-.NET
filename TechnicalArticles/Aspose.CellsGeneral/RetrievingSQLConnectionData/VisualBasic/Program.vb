'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.ExternalConnections
Imports System

Namespace RetrievingSQLConnectionDataExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create a workbook object from source file
			Dim workbook As New Workbook(dataDir & "connection.xlsx")

			'Access the external collections
			Dim connections As ExternalConnectionCollection = workbook.DataConnections

			Dim connectionCount As Integer = connections.Count

			Dim connection As ExternalConnection = Nothing

			For i As Integer = 0 To connectionCount - 1
				connection = connections(i)

				'Check if the Connection is DBConnection, then retrieve its various properties
				If TypeOf connection Is DBConnection Then

					Dim dbConn As DBConnection = CType(connection, DBConnection)

					'Retrieve DB Connection Command
					Console.WriteLine("Command: " & dbConn.Command)

					'Retrieve DB Connection Command Type
					Console.WriteLine("Command Type: " & dbConn.CommandType)

					'Retrieve DB Connection Description
					Console.WriteLine("Description: " & dbConn.ConnectionDescription)

					'Retrieve DB Connection ID
					Console.WriteLine("Id: " & dbConn.ConnectionId)

					'Retrieve DB Connection Info
					Console.WriteLine("Info: " & dbConn.ConnectionInfo)

					'Retrieve DB Connection Credentials
					Console.WriteLine("Credentials: " & dbConn.Credentials)

					'Retrieve DB Connection Name
					Console.WriteLine("Name: " & dbConn.Name)

					'Retrieve DB Connection ODC File
					Console.WriteLine("OdcFile: " & dbConn.OdcFile)

					'Retrieve DB Connection Source File
					Console.WriteLine("Source file: " & dbConn.SourceFile)

					'Retrieve DB Connection Type
					Console.WriteLine("Type: " & dbConn.Type)

					'Retrieve DB Connection Parameters Collection
					Dim paramCollection As ConnectionParameterCollection = dbConn.Parameters

					Dim paramCount As Integer = paramCollection.Count

					'Iterate the Parameter Collection
					For j As Integer = 0 To paramCount - 1
						Dim param As ConnectionParameter = paramCollection(j)

						'Retrieve Parameter Cell Reference
						Console.WriteLine("Cell reference: " & param.CellReference)

						'Retrieve Parameter Name
						Console.WriteLine("Parameter name: " & param.Name)

						'Retrieve Parameter Prompt
						Console.WriteLine("Prompt: " & param.Prompt)

						'Retrieve Parameter SQL Type
						Console.WriteLine("SQL Type: " & param.SqlType)

						'Retrieve Parameter Type
						Console.WriteLine("Param Type: " & param.Type)

						'Retrieve Parameter Value
						Console.WriteLine("Param Value: " & param.Value)

					Next j 'End for
				End If 'End if
			Next i 'End for

		End Sub
	End Class
End Namespace