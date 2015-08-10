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

Namespace Aspose.Cells.Examples.Formatting.ApproachesToFormatData
    Public Class UsingExcelPredefinedStyles
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook.
            Dim workbook As New Workbook()

            'Create a style object based on a predefined Excel 2007 style.
            Dim style As Style = workbook.Styles.CreateBuiltinStyle(BuiltinStyleType.Accent1)

            'Input a value to A1 cell.
            workbook.Worksheets(0).Cells("A1").PutValue("Test")

            'Apply the style to the cell.
            workbook.Worksheets(0).Cells("A1").SetStyle(style)

            'Save the Excel 2007 file.
            workbook.Save(dataDir & "book1.xlsx")

        End Sub
    End Class
End Namespace