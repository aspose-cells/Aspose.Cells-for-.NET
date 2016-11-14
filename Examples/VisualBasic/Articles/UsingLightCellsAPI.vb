Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Imports System.Collections.Generic

Imports System.Text
Imports Aspose.Cells

Namespace Articles
    ' ExStart:WritingLargeExcelFile
    Public Class WriteUsingLightCellsAPI
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Specify your desired matrix
            Dim rowsCount As Integer = 10000
            Dim colsCount As Integer = 30

            Dim workbook = New Workbook()
            Dim ooxmlSaveOptions = New OoxmlSaveOptions()

            ooxmlSaveOptions.LightCellsDataProvider = New TestDataProvider(workbook, rowsCount, colsCount)

            workbook.Save(dataDir & "output.out.xlsx", ooxmlSaveOptions)
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
    ' ExEnd:WritingLargeExcelFile

    ' ExStart:ReadingLargeExcelFile
    Public Class ReadUsingLightCellsApi
        Public Shared Sub Run()
            ' ExStart:ExampleTitle
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim opts As New LoadOptions()
            Dim v As New LightCellsDataHandlerVisitCells()
            opts.LightCellsDataHandler = v
            Dim wb As New Workbook(dataDir & Convert.ToString("LargeBook1.xlsx"), opts)
            Dim sheetCount As Integer = wb.Worksheets.Count
            Console.WriteLine("Total sheets: " & sheetCount & ", cells: " & v.CellCount & ", strings: " & v.StringCount & ", formulas: " & v.FormulaCount)
        End Sub
    End Class

    Class LightCellsDataHandlerVisitCells
        Implements LightCellsDataHandler
        Private m_cellCount As Integer
        Private m_formulaCount As Integer
        Private m_stringCount As Integer

        Friend Sub New()
            m_cellCount = 0
            m_formulaCount = 0
            m_stringCount = 0
        End Sub

        Public ReadOnly Property CellCount() As Integer
            Get
                Return m_cellCount
            End Get
        End Property

        Public ReadOnly Property FormulaCount() As Integer
            Get
                Return m_formulaCount
            End Get
        End Property

        Public ReadOnly Property StringCount() As Integer
            Get
                Return m_stringCount
            End Get
        End Property

        Public Function StartSheet(sheet As Worksheet) As Boolean Implements LightCellsDataHandler.StartSheet
            Console.WriteLine("Processing sheet[" + sheet.Name + "]")
            Return True
        End Function

        Public Function StartRow(rowIndex As Integer) As Boolean Implements LightCellsDataHandler.StartRow
            Return True
        End Function

        Public Function ProcessRow(row As Row) As Boolean Implements LightCellsDataHandler.ProcessRow
            Return True
        End Function

        Public Function StartCell(column As Integer) As Boolean Implements LightCellsDataHandler.StartCell
            Return True
        End Function

        Public Function ProcessCell(cell As Cell) As Boolean Implements LightCellsDataHandler.ProcessCell
            m_cellCount += 1
            If cell.IsFormula Then
                m_formulaCount += 1
            ElseIf cell.Type = CellValueType.IsString Then
                m_stringCount += 1
            End If
            Return False
        End Function
    End Class
    ' ExEnd:ReadingLargeExcelFile
End Namespace



