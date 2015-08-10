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
    Public Class SearchReplaceDataInRange
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim filePath As String = dataDir & "input.xlsx"

            Dim workbook As New Workbook(filePath)

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            'Specify the range where you want to search
            'Here the range is E3:H6
            Dim area As CellArea = CellArea.CreateCellArea("E9", "H15")

            'Specify Find options
            Dim opts As New FindOptions()
            opts.LookInType = LookInType.Values
            opts.LookAtType = LookAtType.EntireContent
            opts.SetRange(area)

            Dim cell As Cell = Nothing

            Do
                'Search the cell with value search within range
                cell = worksheet.Cells.Find("search", cell, opts)

                'If no such cell found, then break the loop
                If cell Is Nothing Then
                    Exit Do
                End If

                'Replace the cell with value replace
                cell.PutValue("replace")

            Loop While True

            'Save the workbook
            workbook.Save(dataDir & "output.xlsx")


        End Sub
    End Class
End Namespace