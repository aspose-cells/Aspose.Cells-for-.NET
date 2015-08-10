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
    Public Class MoveRangeOfCells
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate the workbook object
            'Open the Excel file
            Dim workbook As New Workbook(dataDir & "book1.xls")

            Dim cells As Global.Aspose.Cells.Cells = workbook.Worksheets(0).Cells

            'Create Cell's area
            Dim ca As New CellArea()
            ca.StartColumn = 0
            ca.EndColumn = 1
            ca.StartRow = 0
            ca.EndRow = 4

            'Move Range
            cells.MoveRange(ca, 0, 2)

            'Save the resultant file
            workbook.Save(dataDir & "book2.xls")


        End Sub
    End Class
End Namespace