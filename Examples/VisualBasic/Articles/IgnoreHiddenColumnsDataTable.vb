'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports System.IO
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class IgnoreHiddenColumnsDataTable
        Shared Sub Main()
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim inputPath As String = dataDir & "Sample.xlsx"

            Dim workbook As Workbook = New Workbook(inputPath)

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            Dim opts As ExportTableOptions = New ExportTableOptions()
            opts.PlotVisibleColumns = True

            Dim totalRows As Integer = worksheet.Cells.MaxRow + 1
            Dim totalColumns As Integer = worksheet.Cells.MaxColumn + 1

            Dim dt As DataTable = worksheet.Cells.ExportDataTable(0, 0, totalRows, totalColumns, opts)

        End Sub
    End Class
End Namespace
