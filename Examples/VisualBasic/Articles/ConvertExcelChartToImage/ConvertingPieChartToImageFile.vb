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

Namespace Aspose.Cells.Examples.Articles.ConvertExcelChartToImage
    Public Class ConvertingPieChartToImageFile
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new workbook.
            'Open the existing excel file which contains the pie chart.
            Dim workbook As New Workbook(dataDir & "PieChart.xls")

            'Get the designer chart (first chart) in the first worksheet.
            'of the workbook.
            Dim chart As Global.Aspose.Cells.Charts.Chart = workbook.Worksheets(0).Charts(0)

            'Convert the chart to an image file.
            chart.ToImage(dataDir & "PieChart.emf", System.Drawing.Imaging.ImageFormat.Emf)



        End Sub
    End Class
End Namespace