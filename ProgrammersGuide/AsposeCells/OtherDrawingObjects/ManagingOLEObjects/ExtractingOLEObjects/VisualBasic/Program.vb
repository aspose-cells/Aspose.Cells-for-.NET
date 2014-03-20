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

Namespace ExtractingOLEObjects
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = System.IO.Path.GetFullPath("../../../Data/")

			'Instantiating a Workbook object
			'Open the template file.
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Get the OleObject Collection in the first worksheet.
			Dim oles As Aspose.Cells.Drawing.OleObjectCollection = workbook.Worksheets(0).OleObjects

			'Loop through all the oleobjects and extract each object.
			'in the worksheet.
			For i As Integer = 0 To oles.Count - 1
				Dim ole As Aspose.Cells.Drawing.OleObject = oles(i)

				'Specify the output filename.
				Dim fileName As String = dataDir & "ole_" & i & "."

				'Specify each file format based on the oleobject format type.
				Select Case ole.FileType
					Case Aspose.Cells.Drawing.OleFileType.Doc
						fileName &= "doc"
					Case Aspose.Cells.Drawing.OleFileType.Xls
						fileName &= "Xls"
					Case Aspose.Cells.Drawing.OleFileType.Ppt
						fileName &= "Ppt"
					Case Aspose.Cells.Drawing.OleFileType.Pdf
						fileName &= "Pdf"
					Case Aspose.Cells.Drawing.OleFileType.Unknown
						fileName &= "Jpg"
					Case Else
						'........
				End Select

				'Save the oleobject as a new excel file if the object type is xls.
				If ole.FileType = Aspose.Cells.Drawing.OleFileType.Xls Then
					Dim ms As New MemoryStream()
					ms.Write(ole.ObjectData, 0, ole.ObjectData.Length)
					Dim oleBook As New Workbook(ms)
					oleBook.Settings.IsHidden = False
					oleBook.Save(dataDir & "Excel_File" & i & ".xls")

				'Create the files based on the oleobject format types.
				Else
					Dim fs As FileStream = File.Create(fileName)
					fs.Write(ole.ObjectData, 0, ole.ObjectData.Length)
					fs.Close()
				End If

			Next i

		End Sub
	End Class
End Namespace