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
Imports System.Diagnostics

Namespace GetWarningsForFontSubstitutionExample
	Public Class IWarningCallback
		Inherits IWarningCallback


			Public Sub Warning(ByVal info As WarningInfo)
		If info.WarningType = WarningType.FontSubstitution Then
			Debug.WriteLine("WARNING INFO: " & info.Description)
		End If
			End Sub
	End Class



		Private Sub Run()
				Dim workbook As Workbook = New Workbook("F:\AllExamples\Aspose.Cells\net\TechnicalArticles\Aspose.CellsGeneral\GetWarningsForFontSubstitution\Data\source.xlsx")

				Dim options As PdfSaveOptions = New PdfSaveOptions()
				options.WarningCallback = New WarningCallback()

				workbook.Save("F:\AllExamples\Aspose.Cells\net\TechnicalArticles\Aspose.CellsGeneral\GetWarningsForFontSubstitution\Data\output.pdf", options)
		End Sub













