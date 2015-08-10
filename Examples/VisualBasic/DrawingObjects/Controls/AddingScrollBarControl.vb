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
Imports Aspose.Cells.Drawing
Imports System.Drawing

Namespace Aspose.Cells.Examples.DrawingObjects.Controls
    Public Class AddingScrollBarControl
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiate a new Workbook.
            Dim excelbook As New Workbook()

            'Get the first worksheet.
            Dim worksheet As Worksheet = excelbook.Worksheets(0)

            'Invisible the gridlines of the worksheet.
            worksheet.IsGridlinesVisible = False

            'Get the worksheet cells.
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells

            'Input a value into A1 cell.
            cells("A1").PutValue(1)

            'Set the font color of the cell.
            cells("A1").GetStyle().Font.Color = Color.Maroon

            'Set the font text bold.
            cells("A1").GetStyle().Font.IsBold = True

            'Set the number format.
            cells("A1").GetStyle().Number = 1

            'Add a scrollbar control.
            Dim scrollbar As Global.Aspose.Cells.Drawing.ScrollBar = worksheet.Shapes.AddScrollBar(0, 0, 1, 0, 125, 20)

            'Set the placement type of the scrollbar.
            scrollbar.Placement = PlacementType.FreeFloating

            'Set the linked cell for the control.
            scrollbar.LinkedCell = "A1"

            'Set the maximum value.
            scrollbar.Max = 20

            'Set the minimum value.
            scrollbar.Min = 1

            'Set the incr. change for the control.
            scrollbar.IncrementalChange = 1

            'Set the page change attribute.
            scrollbar.PageChange = 5

            'Set it 3-D shading.
            scrollbar.Shadow = True

            'Save the excel file.
            excelbook.Save(dataDir & "book1.xls")

        End Sub
    End Class
End Namespace