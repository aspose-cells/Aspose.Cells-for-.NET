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

Namespace Aspose.Cells.Examples.RowsColumns.Copying
    Public Class CopyingColumns
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


            'Create another Workbook.
            Dim excelWorkbook1 As New Workbook(dataDir & "book1.xls")

            'Get the first worksheet in the book.
            Dim ws1 As Worksheet = excelWorkbook1.Worksheets(0)

            'Copy the first column from the first worksheet of the first workbook into
            'the first worksheet of the second workbook.
            ws1.Cells.CopyColumn(ws1.Cells, ws1.Cells.Columns(0).Index, ws1.Cells.Columns(2).Index)

            'Autofit the column.
            ws1.AutoFitColumn(2)

            'Save the excel file.
            excelWorkbook1.Save(dataDir & "output.xls")

        End Sub
    End Class
End Namespace