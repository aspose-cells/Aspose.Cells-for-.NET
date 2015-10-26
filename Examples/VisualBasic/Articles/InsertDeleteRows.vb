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

Namespace Aspose.Cells.Examples.Articles
    Public Class InsertDeleteRows
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate a Workbook object.
            'Load a template file.
            Dim workbook As New Workbook(dataDir & "book1.xlsx")

            'Get the first worksheet in the book.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Insert 10 rows at row index 2 (insertion starts at 3rd row)
            sheet.Cells.InsertRows(2, 10)

            'Delete 5 rows now. (8th row - 12th row)
            sheet.Cells.DeleteRows(7, 5)

            'Save the excel file.
            workbook.Save(dataDir & "out_book1.xlsx")



        End Sub
    End Class
End Namespace