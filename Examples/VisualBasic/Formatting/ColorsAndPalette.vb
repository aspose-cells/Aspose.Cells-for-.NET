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
Imports System.Drawing

Namespace Aspose.Cells.Examples.Formatting
    Public Class ColorsAndPalette
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            'Instantiating an Workbook object
            Dim workbook As New Workbook()

            'Adding Orchid color to the palette at 55th index
            workbook.ChangePalette(Color.Orchid, 55)

            'Adding a new worksheet to the Excel object
            Dim i As Integer = workbook.Worksheets.Add()

            'Obtaining the reference of the newly added worksheet by passing its sheet index
            Dim worksheet As Worksheet = workbook.Worksheets(i)

            'Accessing the "A1" cell from the worksheet
            Dim cell As Cell = worksheet.Cells("A1")

            'Adding some value to the "A1" cell
            cell.PutValue("Hello Aspose!")

            'Defining new Style object
            Dim styleObject As Style = workbook.Styles(workbook.Styles.Add())
            'Setting the Orchid (custom) color to the font
            styleObject.Font.Color = Color.Orchid

            'Applying the style to the cell
            cell.SetStyle(styleObject)

            'Saving the Excel file
            workbook.Save(dataDir & "book1.xls", SaveFormat.Auto)

        End Sub
    End Class
End Namespace