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

Namespace Aspose.Cells.Examples.Articles
    Public Class AutoFitRowsMergedCells
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook
            Dim wb As New Workbook()

            'Get the first (default) worksheet
            Dim _worksheet As Worksheet = wb.Worksheets(0)

            'Create a range A1:B1
            Dim range As Range = _worksheet.Cells.CreateRange(0, 0, 1, 2)

            'Merge the cells
            range.Merge()

            'Insert value to the merged cell A1
            _worksheet.Cells(0, 0).Value = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog....end"

            'Create a style object
            Dim style As Global.Aspose.Cells.Style = _worksheet.Cells(0, 0).GetStyle()

            'Set wrapping text on
            style.IsTextWrapped = True

            'Apply the style to the cell
            _worksheet.Cells(0, 0).SetStyle(style)

            'Create an object for AutoFitterOptions
            Dim options As New AutoFitterOptions()

            'Set auto-fit for merged cells
            options.AutoFitMergedCells = True

            'Autofit rows in the sheet(including the merged cells)
            _worksheet.AutoFitRows(options)

            'Save the Excel file
            wb.Save(dataDir & "AutoFitMergedCells.xlsx")


        End Sub
    End Class
End Namespace