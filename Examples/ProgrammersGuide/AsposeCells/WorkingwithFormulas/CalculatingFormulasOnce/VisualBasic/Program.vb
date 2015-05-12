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
Imports System

Namespace CalculatingFormulasOnce
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")



			'Load the template workbook
			Dim workbook As New Workbook(dataDir & "book1.xls")

			'Print the time before formula calculation
			Console.WriteLine(DateTime.Now)

			'Set the CreateCalcChain as false
			workbook.Settings.CreateCalcChain = False

			'Calculate the workbook formulas
			workbook.CalculateFormula()

			'Print the time after formula calculation
			Console.WriteLine(DateTime.Now)

		End Sub
	End Class
End Namespace