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
    Public Class AddingLabelControl
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Create a new Workbook.
            Dim workbook As New Workbook()

            'Get the first worksheet in the workbook.
            Dim sheet As Worksheet = workbook.Worksheets(0)

            'Add a new label to the worksheet.
            Dim label As Global.Aspose.Cells.Drawing.Label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120)

            'Set the caption of the label.
            label.Text = "This is a Label"

            'Set the Placement Type, the way the
            'label is attached to the cells.
            label.Placement = PlacementType.FreeFloating

            'Set the fill color of the label.
            label.FillFormat.ForeColor = Color.Yellow

            'Saves the file.
            workbook.Save(dataDir & "book1.xls")

        End Sub
    End Class
End Namespace