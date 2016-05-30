Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System

Namespace Data.Handling
    Public Class RetrievingDataFromCells
        Public Shared Sub Run()
            ' ExStart:1
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Opening an existing workbook
            Dim workbook As New Workbook(dataDir & "book1.xls")

            ' Accessing first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)

            For Each cell1 As Cell In worksheet.Cells
                ' Variables to store values of different data types
                Dim stringValue As String
                Dim doubleValue As Double
                Dim boolValue As Boolean
                Dim dateTimeValue As DateTime

                ' Passing the type of the data contained in the cell for evaluation
                Select Case cell1.Type
                    ' Evaluating the data type of the cell data for string value
                    Case CellValueType.IsString
                        stringValue = cell1.StringValue
                        Console.WriteLine("String Value: " & stringValue)

                        ' Evaluating the data type of the cell data for double value
                    Case CellValueType.IsNumeric
                        doubleValue = cell1.DoubleValue
                        Console.WriteLine("Double Value: " & doubleValue)

                        ' Evaluating the data type of the cell data for boolean value
                    Case CellValueType.IsBool
                        boolValue = cell1.BoolValue
                        Console.WriteLine("Bool Value: " & boolValue)

                        ' Evaluating the data type of the cell data for date/time value
                    Case CellValueType.IsDateTime
                        dateTimeValue = cell1.DateTimeValue
                        Console.WriteLine("DateTime Value: " & dateTimeValue)

                        ' Evaluating the unknown data type of the cell data
                    Case CellValueType.IsUnknown
                        stringValue = cell1.StringValue
                        Console.WriteLine("Unknown Value: " & stringValue)

                        ' Terminating the type checking of type of the cell data is null
                    Case CellValueType.IsNull
                End Select
            Next cell1
            ' ExEnd:1
        End Sub
    End Class
End Namespace