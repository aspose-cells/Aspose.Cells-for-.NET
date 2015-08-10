'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells

Namespace Aspose.Cells.Examples.Files.Utility
    Public Class ConvertingToXPS
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Open an Excel file
            Dim workbook As New Global.Aspose.Cells.Workbook(dataDir & "Book1.xls")

            'Get the first worksheet
            Dim sheet As Global.Aspose.Cells.Worksheet = workbook.Worksheets(0)

            'Apply different Image and Print options
            Dim options As New Global.Aspose.Cells.Rendering.ImageOrPrintOptions()

            'Set the Format
            options.SaveFormat = SaveFormat.XPS

            'Render the sheet with respect to specified printing options
            Dim sr As New Global.Aspose.Cells.Rendering.SheetRender(sheet, options)

            ' Save
            sr.ToImage(0, dataDir & "out_printingxps.xps")

            'Export the whole workbook to XPS
            Dim wr As New Global.Aspose.Cells.Rendering.WorkbookRender(workbook, options)
            wr.ToImage(dataDir & "out_whole_printingxps.xps")
        End Sub
    End Class
End Namespace