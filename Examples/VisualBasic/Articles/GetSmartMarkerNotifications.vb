Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System
Imports System.Collections

Namespace Articles
    Public Class GetSmartMarkerNotifications
        Public Shared Sub Run()
            ' ExStart:1
            Dim dataDir As String = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim outputPath As String = dataDir & Convert.ToString("Output.out.xlsx")

            ' Creating a DataTable that will serve as data source for designer spreadsheet
            Dim table As New DataTable("OppLineItems")
            table.Columns.Add("PRODUCT_FAMILY")
            table.Columns.Add("OPPORTUNITY_LINEITEM_PRODUCTNAME")
            table.Rows.Add(New Object() {"MMM", "P1"})
            table.Rows.Add(New Object() {"MMM", "P2"})
            table.Rows.Add(New Object() {"DDD", "P1"})
            table.Rows.Add(New Object() {"DDD", "P2"})
            table.Rows.Add(New Object() {"AAA", "P1"})

            ' Loading the designer spreadsheet in an instance of Workbook
            Dim workbook As New Workbook(dataDir & Convert.ToString("source.xlsx"))

            ' Loading the instance of Workbook in an instance of WorkbookDesigner
            Dim designer As New WorkbookDesigner(workbook)

            ' Set the WorkbookDesigner.CallBack property to an instance of newly created class
            designer.CallBack = New SmartMarkerCallBack(workbook)

            ' Set the data source 
            designer.SetDataSource(table)

            ' Process the Smart Markers in the designer spreadsheet
            designer.Process(False)

            ' Save the result
            workbook.Save(outputPath)
            ' ExEnd:1
        End Sub
    End Class

    ' ExStart:ISmartMarkerCallBack
    Class SmartMarkerCallBack
        Implements ISmartMarkerCallBack
        Private workbook As Workbook
        Friend Sub New(workbook As Workbook)
            Me.workbook = workbook
        End Sub
        Public Sub Process(sheetIndex As Integer, rowIndex As Integer, colIndex As Integer, tableName As String, columnName As String) Implements ISmartMarkerCallBack.Process
            Console.WriteLine("Processing Cell : " + workbook.Worksheets(sheetIndex).Name + "!" + CellsHelper.CellIndexToName(rowIndex, colIndex))
            Console.WriteLine(Convert.ToString((Convert.ToString("Processing Marker : ") & tableName) + ".") & columnName)
        End Sub
    End Class
    ' ExEnd:ISmartMarkerCallBack
End Namespace