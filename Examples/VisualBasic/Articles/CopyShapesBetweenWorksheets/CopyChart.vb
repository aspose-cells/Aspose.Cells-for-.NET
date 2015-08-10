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

Namespace Aspose.Cells.Examples.Articles.CopyShapesBetweenWorksheets
    Public Class CopyChart
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create a workbook object
            'Open the template file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            'Get the Chart from the "Chart" worksheet.
            Dim source As Global.Aspose.Cells.Charts.Chart = workbook.Worksheets("Sheet2").Charts(0)

            Dim cshape As Global.Aspose.Cells.Drawing.ChartShape = source.ChartObject

            'Copy the Chart to the Result Worksheet
            workbook.Worksheets("Sheet3").Shapes.AddCopy(cshape, 20, 0, 2, 0)

            'Save the Worksheet
            workbook.Save(dataDir & "Shapes.xlsx")

        End Sub
    End Class
End Namespace