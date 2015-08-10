'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Rendering

Namespace Aspose.Cells.Examples.Files.Utility
    Public Class WorksheetToImage
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Create a new Workbook object and
            'open a template Excel file.
            Dim book As New Workbook(dataDir & "MyTestBook1.xls")
            'Get the first worksheet.
            Dim sheet As Worksheet = book.Worksheets(0)

            'Define ImageOrPrintOptions
            Dim imgOptions As New ImageOrPrintOptions()
            'Specify the image format
            imgOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            'Only one page for the whole sheet would be rendered
            imgOptions.OnePagePerSheet = True

            'Render the sheet with respect to specified image/print options
            Dim sr As New SheetRender(sheet, imgOptions)
            'Render the image for the sheet
            Dim bitmap As System.Drawing.Bitmap = sr.ToImage(0)

            'Save the image file specifying its image format.
            bitmap.Save(dataDir & "SheetImage.jpg")

            ' Display result, so that user knows the processing has finished.
            System.Console.WriteLine("Conversion to Image(s) completed.")
        End Sub
    End Class
End Namespace