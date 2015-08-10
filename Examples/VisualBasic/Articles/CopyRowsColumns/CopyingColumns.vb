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

Namespace Aspose.Cells.Examples.Articles.CopyRowsColumns
    Public Class CopyingColumns
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new Workbook
            'Open an existing excel file
            Dim workbook As New Workbook(dataDir & "aspose-sample.xlsx")

            'Get the first worksheet
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            'Get the Cells collection
            Dim cells As Global.Aspose.Cells.Cells = worksheet.Cells
            'Copy the first column to the third column
            cells.CopyColumn(cells, 0, 2)
            'Save the excel file
            workbook.Save(dataDir & "outaspose-sample.xlsx")


        End Sub
    End Class
End Namespace