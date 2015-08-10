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
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging

Namespace Aspose.Cells.Examples.Articles
    Public Class CreateTransparentImage
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create workbook object from source file
            Dim wb As Workbook = New Workbook(dataDir & "aspose-sample.xlsx")

            'Apply different image or print options
            Dim imgOption As ImageOrPrintOptions = New ImageOrPrintOptions()
            imgOption.ImageFormat = ImageFormat.Png
            imgOption.HorizontalResolution = 200
            imgOption.VerticalResolution = 200
            imgOption.OnePagePerSheet = True

            'Apply transparency to the output image
            imgOption.Transparent = True

            'Create image after apply image or print options
            Dim sr As SheetRender = New SheetRender(wb.Worksheets(0), imgOption)
            sr.ToImage(0, dataDir & "output.png")

        End Sub
    End Class
End Namespace