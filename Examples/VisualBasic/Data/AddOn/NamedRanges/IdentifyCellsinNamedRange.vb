'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Data.AddOn.NamedRanges
    Public Class IdentifyCellsinNamedRange
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Getting the specified named range
            Dim range As Range = workbook.Worksheets.GetRangeByName("TestRange")

            'Identify range cells.
            Console.WriteLine("First Row : " & range.FirstRow)
            Console.WriteLine("First Column : " & range.FirstColumn)
            Console.WriteLine("Row Count : " & range.RowCount)
            Console.WriteLine("Column Count : " & range.ColumnCount)

        End Sub
    End Class
End Namespace