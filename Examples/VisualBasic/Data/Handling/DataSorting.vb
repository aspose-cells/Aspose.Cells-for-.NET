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

Namespace Aspose.Cells.Examples.Data.Handling
    Public Class DataSorting
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook object.
            'Load a template file.
            Dim workbook As New Workbook(dataDir & "book1.xls")

            'Get the workbook datasorter object.
            Dim sorter As DataSorter = workbook.DataSorter

            'Set the first order for datasorter object.
            sorter.Order1 = Global.Aspose.Cells.SortOrder.Descending

            'Define the first key.
            sorter.Key1 = 0

            'Set the second order for datasorter object.
            sorter.Order2 = Global.Aspose.Cells.SortOrder.Ascending

            'Define the second key.
            sorter.Key2 = 1

            'Create a cells area (range).
            Dim ca As New CellArea()

            'Specify the start row index.
            ca.StartRow = 0

            'Specify the start column index.
            ca.StartColumn = 0

            'Specify the last row index.
            ca.EndRow = 13

            'Specify the last column index.
            ca.EndColumn = 1

            'Sort data in the specified data range (A1:B14)
            sorter.Sort(workbook.Worksheets(0).Cells, ca)

            'Save the excel file.
            workbook.Save(dataDir & "output.xls")


        End Sub
    End Class
End Namespace