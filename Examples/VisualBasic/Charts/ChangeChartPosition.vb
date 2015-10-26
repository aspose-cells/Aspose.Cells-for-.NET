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
Imports Aspose.Cells.Charts

Namespace Aspose.Cells.Examples.Charts
    Public Class ChangeChartPosition
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            Dim workbook As New Workbook(dataDir & "chart.xls")

            Dim worksheet As Worksheet = workbook.Worksheets(1)

            'Load the chart from source worksheet
            Dim chart As Chart = worksheet.Charts(0)

            'Resize the chart
            chart.ChartObject.Width = 400
            chart.ChartObject.Height = 300

            'Reposition the chart
            chart.ChartObject.X = 250
            chart.ChartObject.Y = 150

            'Output the file
            workbook.Save(dataDir & "chart_out.xls")

        End Sub
    End Class
End Namespace