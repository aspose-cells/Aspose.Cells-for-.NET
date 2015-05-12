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
Imports System
Imports System.Threading

Namespace ReadingCellValuesInMultipleThreadsSimultaneouslyExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")
		End Sub

			Public Shared testWorkbook As Workbook

Public Shared Sub ThreadLoop()
	Dim random As New Random()
	Do While Thread.CurrentThread.IsAlive
		Dim row As Integer = random.Next(0, 10000)
		Dim col As Integer = random.Next(0, 100)
		Dim s = testWorkbook.Worksheets(0).Cells(row, col).StringValue
		If s IsNot AscW("R" )+ row + AscW("C" )+ col Then
		   ' MessageBox.Show("This message box will show up when cells read values are incorrect.");
		End If
	Loop
End Sub

Public Shared Sub TestMultiThreadingRead()
	testWorkbook = New Workbook()
	testWorkbook.Worksheets.Clear()
	testWorkbook.Worksheets.Add("Sheet1")

	For row = 0 To 9999
		For col = 0 To 99
			testWorkbook.Worksheets(0).Cells(row, col).Value = "R" & row & "C" & col
		Next col
	Next row

	'Commenting this line will show a pop-up message
	testWorkbook.Worksheets(0).Cells.MultiThreadReading = True

	Dim myThread1 As Thread
	myThread1 = New Thread(New ThreadStart(AddressOf ThreadLoop))
	myThread1.Start()

	Dim myThread2 As Thread
	myThread2 = New Thread(New ThreadStart(AddressOf ThreadLoop))
	myThread2.Start()

	System.Threading.Thread.Sleep(5*1000)
	myThread1.Abort()
	myThread2.Abort()
End Sub


	End Class
End Namespace
