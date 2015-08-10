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

Namespace Aspose.Cells.Examples.Files.Handling
    Public Class SavingFiles
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Creating a Workbook object
            Dim workbook As New Workbook()

            'Your Code goes here for any workbook related operations

            'Save in Excel 97 ? 2003 format
            workbook.Save(dataDir & "book1.xls")

            'OR
            workbook.Save(dataDir & "book1.xls", New XlsSaveOptions(SaveFormat.Excel97To2003))

            'Save in Excel2007 xlsx format
            workbook.Save(dataDir & "book1.xlsx", SaveFormat.Xlsx)

            'Save in Excel2007 xlsb format
            workbook.Save(dataDir & "book1.xlsb", SaveFormat.Xlsb)

            'Save in ODS format
            workbook.Save(dataDir & "book1.ods", SaveFormat.ODS)

            'Save in Pdf format
            workbook.Save(dataDir & "book1.pdf", SaveFormat.Pdf)

            'Save in Html format
            workbook.Save(dataDir & "book1.html", SaveFormat.Html)

            'Save in SpreadsheetML format
            workbook.Save(dataDir & "book1.xml", SaveFormat.SpreadsheetML)
        End Sub
    End Class
End Namespace