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

Namespace Aspose.Cells.Examples.Articles
    Public Class LimitNumberOfPagesGenerated
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Open an Excel file
            Dim wb As New Workbook(dataDir & "TestBook.xlsx")
            'Instantiate the PdfSaveOption
            Dim options As New PdfSaveOptions()

            'Print only Page 3 and Page 4 in the output PDF
            'Starting page index (0-based index)
            options.PageIndex = 3
            'Number of pages to be printed
            options.PageCount = 2

            'Save the PDF file
            wb.Save(dataDir & "outPDF1.pdf", options)


        End Sub
    End Class
End Namespace