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

Namespace Aspose.Cells.Examples.Data.Data.Handling.AccessingCells
    Public Class RowAndColumnIndex
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiating a Workbook object
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Using the Sheet 1 in Workbook
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Accessing a cell using its name
            Dim cell As Cell = worksheet.Cells(0, 0)

            Dim value As String = cell.Value.ToString()

            Console.WriteLine(value)

        End Sub
    End Class
End Namespace