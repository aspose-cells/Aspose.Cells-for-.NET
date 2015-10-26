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

Namespace Aspose.Cells.Examples.Articles.DeleteBlankRowsColumns
    Public Class DeletingBlankRows
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new Workbook.
            'Open an existing excel file.
            Dim wb As New Workbook(dataDir & "SampleInput.xlsx")

            'Create a Worksheets object with reference to
            'the sheets of the Workbook.
            Dim sheets As WorksheetCollection = wb.Worksheets

            'Get first Worksheet from WorksheetCollection
            Dim sheet As Worksheet = sheets(0)

            'Delete the Blank Rows from the worksheet
            sheet.Cells.DeleteBlankRows()

            'Save the excel file.
            wb.Save(dataDir & "mybook.xlsx")


        End Sub
    End Class
End Namespace