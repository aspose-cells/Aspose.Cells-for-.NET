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
Imports System.Drawing
Imports System

Namespace GetSetThemeColors
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate Workbook object.
			'Open an exiting excel file.
			Dim workbook As New Workbook(dataDir & "book1.xlsx")

			'Get the Background1 theme color.
			Dim c As Color = workbook.GetThemeColor(ThemeColorType.Background1)

			'Print the color.
            Console.WriteLine("theme color Background1: " & c.ToString())

			'Get the Accent2 theme color.
			c = workbook.GetThemeColor(ThemeColorType.Accent2)

			'Print the color.
            Console.WriteLine("theme color Accent2: " & c.ToString())

			'Change the Background1 theme color.
			workbook.SetThemeColor(ThemeColorType.Background1, Color.Red)

			'Get the updated Background1 theme color.
			c = workbook.GetThemeColor(ThemeColorType.Background1)

			'Print the updated color for confirmation.
            Console.WriteLine("theme color Background1 changed to: " & c.ToString())

			'Change the Accent2 theme color.
			workbook.SetThemeColor(ThemeColorType.Accent2, Color.Blue)

			'Get the updated Accent2 theme color.
			c = workbook.GetThemeColor(ThemeColorType.Accent2)

			'Print the updated color for confirmation.
            Console.WriteLine("theme color Accent2 changed to: " & c.ToString())

			'Save the updated file.
			workbook.Save(dataDir & "output.xlsx")

		End Sub
	End Class
End Namespace