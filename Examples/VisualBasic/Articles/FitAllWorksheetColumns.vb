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
    Public Class FitAllWorksheetColumns
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Create and initialize an instance of Workbook
            Dim book As New Workbook(dataDir & "TestBook.xlsx")
            'Create and initialize an instance of PdfSaveOptions
            Dim saveOptions As New PdfSaveOptions(SaveFormat.Pdf)
            'Set AllColumnsInOnePagePerSheet to true
            saveOptions.AllColumnsInOnePagePerSheet = True
            'Save Workbook to PDF fromart by passing the object of PdfSaveOptions
            book.Save(dataDir & "output.pdf", saveOptions)


        End Sub
    End Class
End Namespace