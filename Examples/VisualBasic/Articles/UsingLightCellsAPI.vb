'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Imports System.Collections.Generic

Imports System.Text
Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Articles
    Public Class UsingLightCellsAPI
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Specify your desired matrix
            Dim rowsCount As Integer = 10000
            Dim colsCount As Integer = 30

            Dim workbook = New Workbook()
            Dim ooxmlSaveOptions = New OoxmlSaveOptions()

            ooxmlSaveOptions.LightCellsDataProvider = New TestDataProvider(workbook, rowsCount, colsCount)

            workbook.Save(dataDir & "output.xlsx", ooxmlSaveOptions)
        End Sub
    End Class

    Friend Class TestDataProvider
        Implements LightCellsDataProvider
        Private _row As Integer = -1
        Private _column As Integer = -1

        Private maxRows As Integer
        Private maxColumns As Integer

        Private _workbook As Workbook
        Public Sub New(ByVal workbook As Workbook, ByVal maxRows As Integer, ByVal maxColumns As Integer)
            Me._workbook = workbook
            Me.maxRows = maxRows
            Me.maxColumns = maxColumns
        End Sub

#Region "LightCellsDataProvider Members"

        Public Function IsGatherString() As Boolean Implements LightCellsDataProvider.IsGatherString
            Return False
        End Function

        Public Function NextCell() As Integer Implements LightCellsDataProvider.NextCell
            _column += 1
            If _column < Me.maxColumns Then
                Return _column
            Else
                _column = -1
                Return -1
            End If
        End Function
        Public Function NextRow() As Integer Implements LightCellsDataProvider.NextRow
            _row += 1
            If _row < Me.maxRows Then
                _column = -1
                Return _row
            Else
                Return -1
            End If
        End Function

        Public Sub StartCell(ByVal cell As Cell) Implements LightCellsDataProvider.StartCell
            cell.PutValue(_row + _column)
            If _row = 1 Then
            Else
                cell.Formula = "=Rand() + A2"
            End If
        End Sub

        Public Sub StartRow(ByVal row As Row) Implements LightCellsDataProvider.StartRow
        End Sub

        Public Function StartSheet(ByVal sheetIndex As Integer) As Boolean Implements LightCellsDataProvider.StartSheet
            If sheetIndex = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace



