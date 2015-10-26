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
    Public Class CombineMultipleWorksheetsSingleWorksheet
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim filePath As String = dataDir & "SampleInput.xlsx"

            Dim workbook As New Workbook(filePath)

            Dim destWorkbook As New Workbook()

            Dim destSheet As Worksheet = destWorkbook.Worksheets(0)

            Dim TotalRowCount As Integer = 0

            For i As Integer = 0 To workbook.Worksheets.Count - 1
                Dim sourceSheet As Worksheet = workbook.Worksheets(i)

                Dim sourceRange As Range = sourceSheet.Cells.MaxDisplayRange

                Dim destRange As Range = destSheet.Cells.CreateRange(sourceRange.FirstRow + TotalRowCount, sourceRange.FirstColumn, sourceRange.RowCount, sourceRange.ColumnCount)

                destRange.Copy(sourceRange)

                TotalRowCount = sourceRange.RowCount + TotalRowCount
            Next i

            destWorkbook.Save(dataDir & "Output.xlsx")


        End Sub
    End Class
End Namespace