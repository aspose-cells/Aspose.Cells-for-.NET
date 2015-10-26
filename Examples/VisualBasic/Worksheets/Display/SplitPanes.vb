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

Namespace Aspose.Cells.Examples.Worksheets.Display
    Public Class SplitPanes
        Public Shared Sub Main(ByVal args() As String)
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

            'Instantiate a new workbook and Open a template file
            Dim book As New Workbook(dataDir & "Book1.xls")

            'Set the active cell
            book.Worksheets(0).ActiveCell = "A20"

            'Split the worksheet window
            book.Worksheets(0).Split()

            'Save the excel file
            book.Save(dataDir & "Splitted_out1.xls")
        End Sub
    End Class
End Namespace